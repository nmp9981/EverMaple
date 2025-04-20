using UnityEngine;
using UnityEngine.UI;

public class MonsterInfo : MonoBehaviour
{
    //���� ����
    public int monsterLv;
    public int monsterMaxHP;
    public int monsterExp;
    public int monsterMeso;
    public int monsterAttackPower;

    public int monsterCurHP;
    protected bool isAttack;

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
    protected Image HPBarValue;

    //�ִϸ��̼�
    Animator anim;

    //��Ÿ
    [SerializeField]
    PlayerInfo playerInfo;
    MonsterSpawn monsterSpawn;
    SpriteRenderer spriteRenderer;

    //Ȱ��ȭ�� ����
    private void OnEnable()
    {
        monsterCurHP = monsterMaxHP;
        HPBarValue.fillAmount = 1;
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

    private void LateUpdate()
    {
        MoveHPBar();
    }
    /// <summary>
    /// ���� ��ġ ���� HP�� �̵�
    /// </summary>
    void MoveHPBar()
    {
        HPBar.transform.position = Camera.main.WorldToScreenPoint(this.gameObject.transform.position + new Vector3(0, 1f, 0));
    }
    /// <summary>
    /// ���� HP����
    /// </summary>
    /// <param name="attackDamage"></param>
    public void DecreaseMonsterHP(int attackDamage)
    {

        monsterCurHP = Mathf.Max(monsterCurHP - attackDamage,0);
        HPBarValue.fillAmount = (float)monsterCurHP / monsterMaxHP;

        //���� ���
        if(monsterCurHP <= 0)
        {
            anim.SetBool("IsDie", true);
            Invoke("DieMonster", 0.5f);
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
    /// 3) ����ġ ȹ��
    /// 4) Ȯ���� �޼� ������
    /// 5) ��Ȱ��ȭ
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
    /// ���� �̵� AI
    /// </summary>
    void MonsterMoveAI()
    {
        //�ൿ ����
        if (monsterMoveTime >= monsterMoveCoolTime)
        {
            //�̵����� ��������
            int ranNum = Random.Range(0, 4) % 2;
            //���ֱ�
            if (ranNum == 0)
            {
                StandState();
            }
            else//���� �ٲٸ鼭 �̵�
            {
                ChangeMoveDirection();
                MoveState();
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
