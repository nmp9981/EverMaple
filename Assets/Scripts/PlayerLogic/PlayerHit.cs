using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField]
    PlayerInfoUI playerInfoUI;
    [SerializeField]
    ItemUI itmeUI;
    [SerializeField]
    PlayerDie playerDie;
    
    const string monsterTag ="Monster";

    //무적시간
    float coolHitTime = 1.0f;
    float curHitTime = 0;
    private void Update()
    {
        TimeFlow();
    }
    /// <summary>
    /// 피격
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay2D(Collision2D collision)
    {
        //몸박데미지
        if (collision.gameObject.tag.Contains(monsterTag))
        {
            //무적시간 안지났음
            if(curHitTime < coolHitTime)
            {
                return;
            }

            //몬스터 공격력
            MonsterInfo mobInfo = collision.gameObject.GetComponent<MonsterInfo>();
            int monsterAttackPower = mobInfo.monsterAttackPower;
            int finalMonsterPower = Random.Range(monsterAttackPower * 900, monsterAttackPower * 1100) / 1000;

            //피격데미지 감소
            finalMonsterPower = Mathf.Max(1, finalMonsterPower - PlayerManager.PlayerInstance.PlayerPhysicsArmor - PlayerManager.PlayerInstance.PlayerStatPhysicsArmor);

            //메소가드 여부
            if (PlayerManager.PlayerInstance.IsActiveMesoGuard)
            {
                //메소 소비량
                int spendMeso = (finalMonsterPower * PlayerManager.PlayerInstance.RateArmorMeso) / 100;
                if (PlayerManager.PlayerInstance.PlayerMeso >= spendMeso)
                {
                    PlayerManager.PlayerInstance.PlayerMeso -= spendMeso;
                    finalMonsterPower = finalMonsterPower / 2;
                    itmeUI.ShowPlayerMeso();
                }
            }

            //미스 판정
            if (PlayerAttackCommon.IsHitMiss(mobInfo.monsterLv))
                PlayerAttackCommon.ShowMissHitDamageAsSkin(this.gameObject);
            else
            {
                DecreasePlayerHP(finalMonsterPower);
                PlayerAttackCommon.ShowDamageAsSkin(finalMonsterPower, this.gameObject);
            }
            curHitTime = 0;
        }
    }

    /// <summary>
    /// 몸박데미지
    /// </summary>
    public void DecreasePlayerHP(int monsterPower)
    {
        PlayerManager.PlayerInstance.PlayerCurHP = Mathf.Max(0, PlayerManager.PlayerInstance.PlayerCurHP - monsterPower);
        playerInfoUI.ShowPlayerHPBar();

        //사망
        if(PlayerManager.PlayerInstance.PlayerCurHP<=0)
            playerDie.gameObject.SetActive(true);
    }

    void TimeFlow()
    {
        curHitTime += Time.deltaTime;
    }
}
