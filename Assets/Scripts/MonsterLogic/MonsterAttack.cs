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

    //활성화시 로직
    private void OnEnable()
    {
        monsterCurHP = monsterMaxHP;
    }

    private void Update()
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
            DieMonster();
        }
    }

    /// <summary>
    /// 몬스터 사망
    /// </summary>
    void DieMonster()
    {

    }
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
