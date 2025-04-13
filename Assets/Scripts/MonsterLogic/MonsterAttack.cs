using UnityEngine;

public class MonsterInfo : MonoBehaviour
{
    public int monsterLv;
    public float monsterMaxHP;
    public int monsterExp;
    public int monsterMeso;
    public int monsterAttackPower;

    public int monsterCurHP;
    protected bool isAttack;
}


public class MonsterAttack : MonsterInfo
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //몬스터가 피격

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
