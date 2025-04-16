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

    public int spawnPosNumber;//스폰지점
    public string spawnMap;//스폰맵

    [SerializeField]
    protected GameObject HPBar;
    [SerializeField]
    protected Image HPBarValue;

    [SerializeField]
    PlayerInfo playerInfo;
    [SerializeField]
    MonsterSpawn monsterSpawn;

    //활성화시 로직
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
    /// 1) 경험치 획득
    /// 2) 확률로 메소 떨구기
    /// 3) 비활성화
    /// </summary>
    void DieMonster()
    {
        playerInfo.GetPlayerExp(monsterExp);

        MonsterSpawn.activeMonster.Remove(gameObject);
        Invoke("CallRespawn",5f);
        this.gameObject.SetActive(false);
    }
    /// <summary>
    /// 리스폰 함수 불러오기
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
