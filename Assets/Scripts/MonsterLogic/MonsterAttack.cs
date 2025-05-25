using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class MonsterInfo : MonoBehaviour
{
    //���� ����
    public int monsterID;
    public int monsterLv;
    public int monsterMaxHP;
    public int monsterExp;
    public int monsterMeso;
    public int monsterAttackPower;

    public int monsterCurHP;

    [SerializeField]
    protected bool isAttack;//���� ����
    [SerializeField]
    protected GameObject throwBall;//����ü

    public int spawnPosNumber;//��������
    public string spawnMap;//������

    //���� �̵�
    private float monsterMoveSpeed = 3f;
    private float monsterMoveTime = 0;
    private float monsterMoveCoolTime = 0.1f;
    private string wallTag = "Wall";

    //���� HP��
    [SerializeField]
    protected GameObject HPBar;
    [SerializeField]
    protected Transform HPBarValue;
    const float HPBarMaxScale = 2;

    //�ִϸ��̼�
    Animator anim;

    //�޼�
    [SerializeField]
    GameObject mesoObj;

    //��Ÿ
    [SerializeField]
    PlayerInfo playerInfo;
    MonsterSpawn monsterSpawn;
    SpriteRenderer spriteRenderer;

    //��� ������
    private int dieCount;

    //Ȱ��ȭ�� ����
    private void OnEnable()
    {
        dieCount = 0;
        monsterCurHP = monsterMaxHP;
        HPBarValue.localScale = new Vector3(HPBarMaxScale, HPBarValue.localScale.y, 1);
        playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
        monsterSpawn = GameObject.Find(PlayerManager.PlayerInstance.CurMapName).GetComponent<MonsterSpawn>();
        anim = GetComponent<Animator>();

        //��������Ʈ ����
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;
    }

    private void Update()
    {
        MonsterMoveAI();
        Timeflow();
    }
   
    /// <summary>
    /// ���� HP����
    /// </summary>
    /// <param name="attackDamage"></param>
    public void DecreaseMonsterHP(int attackDamage)
    {

        monsterCurHP = Mathf.Max(monsterCurHP - attackDamage,0);
        float restHPRate = (float)monsterCurHP*HPBarMaxScale / monsterMaxHP;
        HPBarValue.localScale = new Vector3(restHPRate, HPBarValue.localScale.y, 1);

        //���� ���
        if (monsterCurHP <= 0)
        {
            dieCount += 1;
            if (dieCount == 1)
            {
                anim.SetBool("IsDie", true);
                Invoke("DieMonster", 0.5f);
            }
        }
        else//�ǰ� ����
        {
            HitState();
        }
    }

    /// <summary>
    /// ���� ���
    /// 1) ���� �̵��ӵ� 0
    /// 2) ��� �ִϸ��̼� ����
    /// 3) ������ ���, ����ġ ȹ��
    /// 4) Ȯ���� �޼� ������
    /// 5) ��Ȱ��ȭ
    /// </summary>
    void DieMonster()
    {
        monsterMoveSpeed = 0;
        playerInfo.GetPlayerExp(monsterExp);

        MesoDrop();
        ItemDrop();

        MonsterSpawn.activeMonster.Remove(gameObject);
        monsterSpawn.CallRespawn();
        this.gameObject.SetActive(false);
    }
    /// <summary>
    /// �޼� ���
    /// </summary>
    void MesoDrop()
    {
        int mesoValue = Random.Range(0, 100);

        //�޼� ��� X
        if (mesoValue < 33)
            return;
       
        GameObject dropMeso = Instantiate(mesoObj);
        dropMeso.transform.position = this.gameObject.transform.position;
        dropMeso.gameObject.name = $"Meso_{monsterLv}";
        ItemManager.itemInstance.fieldDropItems.Add(dropMeso);
    }

    /// <summary>
    /// ������ ���
    /// </summary>
    void ItemDrop()
    {

    }

    /// <summary>
    /// ���� �̵� AI
    /// </summary>
    void MonsterMoveAI()
    {
        //�ൿ ����
        if (monsterMoveTime >= monsterMoveCoolTime)
        {
            //�������� �Ǵ� (�̵� or ����)����
            int ranDivNum = (isAttack &&  monsterCurHP < monsterMaxHP) ? 3 : 2;
            int ranNum = Random.Range(0, 6) % ranDivNum;
            //���ֱ�
            if (ranNum == 0)
            {
                StandState();
            }
            else if(ranNum==1)//���� �ٲٸ鼭 �̵�
            {
                ChangeMoveDirection();
                MoveState();
            }
            else//�����ϱ� (���� HP < Max HP �϶��� �ߵ�)
            {
                AttackState();
                MonsterToPlayerAttack();
            }
            monsterMoveTime = 0;
        }

        //�̵�
        transform.position += Vector3.right*monsterMoveSpeed* Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //���� ������ ���� ��ȯ
        if (collision.gameObject.tag == wallTag)
        {
            ChangeMoveDirection();
        }
    }

    /// <summary>
    /// �̵� ���� ��ȯ
    /// </summary>
    void ChangeMoveDirection()
    {
        monsterMoveSpeed *= (-1f);
        spriteRenderer.flipX = !spriteRenderer.flipX;

        monsterMoveCoolTime = Random.Range(100, 350) * 0.01f;
    }

    /// <summary>
    /// �ð� �帧
    /// </summary>
    void Timeflow()
    {
        monsterMoveTime += Time.deltaTime;
    }

    /// <summary>
    /// ���ִ� ����
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
    /// �����̴� ����
    /// </summary>
    void MoveState()
    {
        monsterMoveSpeed = spriteRenderer.flipX?3:-3;
        anim.SetBool("IsMove", true);
        anim.SetBool("IsStand", false);
        anim.SetBool("IsHit", false);

        if (isAttack)
            anim.SetBool("IsAttack", false);
    }
    /// <summary>
    /// �ǰ� ����
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

     //���Ͱ� ����
    void MonsterToPlayerAttack()
    {
        //������ ����
        if (!isAttack)
        {
            return;
        }

        //���Ͱ� �̹� ����
        if (!gameObject.activeSelf)
            return;

        //����ü ������Ʈ ����
        MonsterMagicAttack throwObj = Instantiate(throwBall).GetComponent<MonsterMagicAttack>();
        
        throwObj.transform.position = gameObject.transform.position + throwObj.marginYPos * Vector3.down;
        throwObj.startPos = throwObj.transform.position;
        throwObj.sideValue = 1;

        //�����
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
        //���Ͱ� �ǰ�

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //���� �ǰ�


    }
    //���Ͱ� ����
    void MonsterToPlayerAttack()
    {
        //������ ����
        if (!isAttack)
        {
            return;
        }


    }

}
