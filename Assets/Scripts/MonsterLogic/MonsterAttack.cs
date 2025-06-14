using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterInfo : MonoBehaviour
{
    //몬스터 정보
    public int monsterID;
    public int monsterLv;
    public int monsterMaxHP;
    public int monsterExp;
    public int monsterMeso;
    public int monsterAttackPower;

    public int monsterArmor;//방어력
    public int monsterAvoid;//회피율

    public int monsterCurHP;

    [SerializeField]
    protected bool isBoss;//보스 여부
    [SerializeField]
    protected bool isAttack;//마공 여부
    [SerializeField]
    protected GameObject throwBall;//투사체

    public int spawnPosNumber;//스폰지점
    public string spawnMap;//스폰맵

    //몬스터 이동
    public float monsterMoveSpeed = 3f;
    private float monsterMoveTime = 0;
    private float monsterMoveCoolTime = 0.1f;
    private string wallTag = "Wall";

    //몬스터 HP바
    [SerializeField]
    protected GameObject HPBar;
    [SerializeField]
    protected Transform HPBarValue;
    const float HPBarMaxScale = 2;

    //몬스터 HP바
    [SerializeField]
    private Image bossHPBar;

    //애니메이션
    Animator anim;

    //메소
    [SerializeField]
    GameObject mesoObj;

    //기타
    [SerializeField]
    PlayerInfo playerInfo;
    MonsterSpawn monsterSpawn;
    SpriteRenderer spriteRenderer;

    //드랍 장비 아이템
    [SerializeField]
    GameObject dropEquipmentItemPrefab;
    [SerializeField]
    List<string> dropItemNames = new List<string>();

    //드랍 소비 아이템
    [SerializeField]
    GameObject dropConsumeItemPrefab;
    [SerializeField]
    List<int> dropConsumeItemIndexList = new List<int>();

    //사망 판정용
    private int dieCount;

    //활성화시 로직
    private void OnEnable()
    {
        dieCount = 0;
        monsterCurHP = monsterMaxHP;

        //일반 몹
        if(HPBarValue!=null)
            HPBarValue.localScale = new Vector3(HPBarMaxScale, HPBarValue.localScale.y, 1);

        //보스 몹
        if (bossHPBar != null)
        {
            bossHPBar.fillAmount = 1;
        }

        playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
        
        anim = GetComponent<Animator>();

        //스프라이트 관련
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;
    }

    private void Update()
    {
        MonsterMoveAI();
        Timeflow();
    }
   
    /// <summary>
    /// 몬스터 HP감소
    /// </summary>
    /// <param name="attackDamage"></param>
    public void DecreaseMonsterHP(int attackDamage)
    {
        monsterCurHP = Mathf.Max(monsterCurHP - attackDamage,0);
        float restHPRate = (float)monsterCurHP*HPBarMaxScale / monsterMaxHP;

        //일반 몹
        if (HPBarValue != null)
            HPBarValue.localScale = new Vector3(restHPRate, HPBarValue.localScale.y, 1);

        //보스 몹
        if (bossHPBar != null)
            bossHPBar.fillAmount = (float)monsterCurHP / (float)monsterMaxHP;

        //몬스터 사망
        if (monsterCurHP <= 0)
        {
            dieCount += 1;
            if (dieCount == 1)
            {
                anim.SetBool("IsDie", true);
                Invoke("DieMonster", 0.5f);
            }
        }
        else//피격 상태
        {
            HitState();
        }
    }

    /// <summary>
    /// 몬스터 사망
    /// 1) 몬스터 이동속도 0
    /// 2) 사망 애니메이션 실행
    /// 3) 아이템 드랍, 경험치 획득
    /// 4) 확률로 메소 떨구기
    /// 5) 비활성화
    /// </summary>
    void DieMonster()
    {
        monsterMoveSpeed = 0;
        playerInfo.GetPlayerExp(monsterExp);

        MesoDrop();
        ItemDrop();

        MonsterSpawn.activeMonster.Remove(gameObject);
        monsterSpawn = GameObject.Find(PlayerManager.PlayerInstance.CurMapName).GetComponent<MonsterSpawn>();
        monsterSpawn.CallRespawn(isBoss);
        this.gameObject.SetActive(false);
    }
    /// <summary>
    /// 메소 드랍
    /// </summary>
    void MesoDrop()
    {
        int mesoValue = Random.Range(0, 100);

        //메소 드랍 X
        if (mesoValue < 33)
            return;
       
        GameObject dropMeso = Instantiate(mesoObj);
        dropMeso.transform.position = this.gameObject.transform.position;
        dropMeso.gameObject.name = $"Meso_{monsterLv}";
        ItemManager.itemInstance.fieldDropItems.Add(dropMeso);
    }

    /// <summary>
    /// 아이템 드랍
    /// </summary>
    void ItemDrop()
    {
        //정비 드랍률은 1%
        for(int i = 0; i < dropItemNames.Count; i++)
        {
            int dropRan = Random.Range(0, 10000);
            if(dropRan <= 100)
            {
                GameObject dropEquipment = Instantiate(dropEquipmentItemPrefab);
                dropEquipment.transform.position = this.gameObject.transform.position+Vector3.right*i;
                dropEquipment.GetComponent<MonsterDropItem>().itemName = dropItemNames[i];
            }
        }
        //소비 아이템 드랍
        for (int i = 0; i < dropConsumeItemIndexList.Count; i++)
        {
            int dropRan = Random.Range(0, 10000);
            if (dropRan <= 9000)
            {
                GameObject dropEquipment = Instantiate(dropConsumeItemPrefab);
                dropEquipment.transform.position = this.gameObject.transform.position + Vector3.left * i;
                dropEquipment.GetComponent<MonsterDropConsumeItem>().itemIndex = dropConsumeItemIndexList[i];
            }
        }
    }

    /// <summary>
    /// 몬스터 이동 AI
    /// </summary>
    void MonsterMoveAI()
    {
        //행동 결정 (보스가 아니거나 머쉬맘일때만 적용)
        if (monsterMoveTime >= monsterMoveCoolTime && (monsterID==25 || !isBoss))
        {
            //서있을지 또는 (이동 or 공격)할지
            int ranDivNum = (isAttack &&  monsterCurHP < monsterMaxHP) ? 3 : 2;
            int ranNum = Random.Range(0, 6) % ranDivNum;
            //서있기
            if (ranNum == 0)
            {
                StandState();
            }
            else if(ranNum==1)//방향 바꾸면서 이동
            {
                ChangeMoveDirection();
                MoveState();
            }
            else//공격하기 (현재 HP < Max HP 일때만 발동)
            {
                AttackState();
                MonsterToPlayerAttack();
            }
            monsterMoveTime = 0;
        }

        //이동
        transform.position += Vector3.right*monsterMoveSpeed* Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //벽과 닿으면 방향 전환
        if (collision.gameObject.tag == wallTag)
        {
            ChangeMoveDirection();
        }
    }

    /// <summary>
    /// 이동 방향 전환
    /// </summary>
    public void ChangeMoveDirection()
    {
        monsterMoveSpeed *= (-1f);
        spriteRenderer.flipX = !spriteRenderer.flipX;

        monsterMoveCoolTime = Random.Range(100, 350) * 0.01f;
    }

    /// <summary>
    /// 시간 흐름
    /// </summary>
    void Timeflow()
    {
        monsterMoveTime += Time.deltaTime;
    }

    /// <summary>
    /// 서있는 상태
    /// </summary>
    void StandState()
    {
        monsterMoveSpeed = 0;
        anim.SetBool("IsStand", true);
        anim.SetBool("IsMove", false);
        anim.SetBool("IsHit", false);

        if(isAttack)
            anim.SetBool("IsAttack", false);
    }
    /// <summary>
    /// 움직이는 상테
    /// </summary>
    public void MoveState()
    {
        monsterMoveSpeed = spriteRenderer.flipX?3:-3;
        anim.SetBool("IsMove", true);
        anim.SetBool("IsStand", false);
        anim.SetBool("IsHit", false);

        if (isAttack)
            anim.SetBool("IsAttack", false);
    }
    /// <summary>
    /// 피격 상태
    /// </summary>
    void HitState()
    {
        anim.SetBool("IsHit",true);
        monsterMoveSpeed = 0;
        Invoke("StandState", 0.4f);
    }
    void AttackState()
    {
        anim.SetBool("IsAttack", true);
        monsterMoveSpeed = 0;
        Invoke("StandState", 0.4f);
    }

     //몬스터가 공격
    void MonsterToPlayerAttack()
    {
        //마공을 안함
        if (!isAttack)
        {
            return;
        }

        //몬스터가 이미 죽음
        if (!gameObject.activeSelf)
            return;

        //투사체 오브젝트 생성
        MonsterMagicAttack throwObj = Instantiate(throwBall).GetComponent<MonsterMagicAttack>();
        
        throwObj.transform.position = gameObject.transform.position + throwObj.marginYPos * Vector3.down;
        throwObj.startPos = throwObj.transform.position;
        throwObj.sideValue = 1;

        //양방향
        if (throwObj.isSide)
        {
            MonsterMagicAttack throwObj2 = Instantiate(throwBall).GetComponent<MonsterMagicAttack>();
            throwObj2.transform.position = gameObject.transform.position + throwObj.marginYPos * Vector3.down;
            throwObj2.startPos = throwObj.transform.position;
            throwObj2.sideValue = -1;
        }
    }
}


public class MonsterAttack : MonsterInfo
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //몬스터가 피격

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //몬스터 피격


    }
    //몬스터가 공격
    void MonsterToPlayerAttack()
    {
        //마공을 안함
        if (!isAttack)
        {
            return;
        }


    }

}
