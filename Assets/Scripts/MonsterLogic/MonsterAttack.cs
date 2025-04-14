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

    [SerializeField]
    protected GameObject HPBar;
    [SerializeField]
    protected Image HPBarValue;

    [SerializeField]
    PlayerInfo playerInfo;

    //Ȱ��ȭ�� ����
    private void OnEnable()
    {
        monsterCurHP = monsterMaxHP;
        playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
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
        this.gameObject.SetActive(false);
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
