using UnityEngine;
using UnityEngine.UI;

public class MonsterInfo : MonoBehaviour
{
    public int monsterLv;
    public int monsterMaxHP;
    public int monsterExp;
    public int monsterMeso;
    public int monsterAttackPower;

    public int monsterCurHP;
    protected bool isAttack;

    public int spawnPosNumber;//��������
    public string spawnMap;//������

    [SerializeField]
    protected GameObject HPBar;
    [SerializeField]
    protected Image HPBarValue;

    [SerializeField]
    PlayerInfo playerInfo;
    [SerializeField]
    MonsterSpawn monsterSpawn;

    //Ȱ��ȭ�� ����
    private void OnEnable()
    {
        monsterCurHP = monsterMaxHP;
        HPBarValue.fillAmount = 1;
        playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
        monsterSpawn = GameObject.Find("Map").GetComponent<MonsterSpawn>();
    }

    private void Update()
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
        Invoke("CallRespawn",5f);
        this.gameObject.SetActive(false);
    }
    /// <summary>
    /// ������ �Լ� �ҷ�����
    /// </summary>
    void CallRespawn()
    {
        monsterSpawn.MonsterRespawn();
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
