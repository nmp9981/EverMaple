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

    //���� HP��
    [SerializeField]
    protected GameObject HPBar;
    [SerializeField]
    protected Image HPBarValue;

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
            DieMonster();
        }
    }

    /// <summary>
    /// ���� ���
    /// 1) ����ġ ȹ��
    /// 2) Ȯ���� �޼� ������
    /// 3) ��Ȱ��ȭ
    /// </summary>
    void DieMonster()
    {
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
        //���� ��ȯ
        if (monsterMoveTime >= monsterMoveCoolTime)
        {
            monsterMoveSpeed *= (-1f);
            spriteRenderer.flipX = !spriteRenderer.flipX;

            monsterMoveCoolTime = Random.Range(150, 400)*0.01f;
            monsterMoveTime = 0;
        }
        //�̵�
        transform.position += Vector3.right*monsterMoveSpeed* Time.deltaTime;
    }
    /// <summary>
    /// �ð� �帧
    /// </summary>
    void Timeflow()
    {
        monsterMoveTime += Time.deltaTime;
    }
}


public class MonsterAttack : MonsterInfo
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //���Ͱ� �ǰ�

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
