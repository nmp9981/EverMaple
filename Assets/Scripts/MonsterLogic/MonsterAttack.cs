using UnityEngine;

public class MonsterInfo : MonoBehaviour
{
    public int monsterLv;
    public int monsterMaxHP;
    public int monsterExp;
    public int monsterMeso;
    public int monsterAttackPower;

    public int monsterCurHP;
    protected bool isAttack;

    //Ȱ��ȭ�� ����
    private void OnEnable()
    {
        monsterCurHP = monsterMaxHP;
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
