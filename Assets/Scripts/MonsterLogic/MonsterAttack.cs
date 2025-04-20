using UnityEngine;
using UnityEngine.UI;

public class MonsterInfo : MonoBehaviour
{
    //몬스터 정보
    public int monsterLv;
    public int monsterMaxHP;
    public int monsterExp;
    public int monsterMeso;
    public int monsterAttackPower;

    public int monsterCurHP;
    protected bool isAttack;

    public int spawnPosNumber;//스폰지점
    public string spawnMap;//스폰맵

    //몬스터 이동
    private float monsterMoveSpeed = 3f;
    private float monsterMoveTime = 0;
    private float monsterMoveCoolTime = 0.1f;
    private string wallTag = "Wall";

    //몬스터 HP바
    [SerializeField]
    protected GameObject HPBar;
    [SerializeField]
    protected Image HPBarValue;

    //애니메이션
    Animator anim;

    //기타
    [SerializeField]
    PlayerInfo playerInfo;
    MonsterSpawn monsterSpawn;
    SpriteRenderer spriteRenderer;

    //활성화시 로직
    private void OnEnable()
    {
        monsterCurHP = monsterMaxHP;
        HPBarValue.fillAmount = 1;
        playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
        monsterSpawn = GameObject.Find(PlayerManager.PlayerInstance.CurMapName).GetComponent<MonsterSpawn>();
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

    private void LateUpdate()
    {
        MoveHPBar();
    }
    /// <summary>
    /// 몬스터 위치 따라서 HP바 이동
    /// </summary>
    void MoveHPBar()
    {
        HPBar.transform.position = Camera.main.WorldToScreenPoint(this.gameObject.transform.position + new Vector3(0, 1f, 0));
    }
    /// <summary>
    /// 몬스터 HP감소
    /// </summary>
    /// <param name="attackDamage"></param>
    public void DecreaseMonsterHP(int attackDamage)
    {

        monsterCurHP = Mathf.Max(monsterCurHP - attackDamage,0);
        HPBarValue.fillAmount = (float)monsterCurHP / monsterMaxHP;

        //몬스터 사망
        if(monsterCurHP <= 0)
        {
            anim.SetBool("IsDie", true);
            Invoke("DieMonster", 0.5f);
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
    /// 3) 경험치 획득
    /// 4) 확률로 메소 떨구기
    /// 5) 비활성화
    /// </summary>
    void DieMonster()
    {
        monsterMoveSpeed = 0;
        playerInfo.GetPlayerExp(monsterExp);

        MonsterSpawn.activeMonster.Remove(gameObject);
        monsterSpawn.CallRespawn();
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// 몬스터 이동 AI
    /// </summary>
    void MonsterMoveAI()
    {
        //행동 결정
        if (monsterMoveTime >= monsterMoveCoolTime)
        {
            //이동할지 서있을지
            int ranNum = Random.Range(0, 4) % 2;
            //서있기
            if (ranNum == 0)
            {
                StandState();
            }
            else//방향 바꾸면서 이동
            {
                ChangeMoveDirection();
                MoveState();
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
    void ChangeMoveDirection()
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
    }
    /// <summary>
    /// 움직이는 상테
    /// </summary>
    void MoveState()
    {
        monsterMoveSpeed = spriteRenderer.flipX?3:-3;
        anim.SetBool("IsMove", true);
        anim.SetBool("IsStand", false);
        anim.SetBool("IsHit", false);
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
