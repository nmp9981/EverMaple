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

    //�����ð�
    float coolHitTime = 1.0f;
    float curHitTime = 0;
    private void Update()
    {
        TimeFlow();
    }
    /// <summary>
    /// �ǰ�
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay2D(Collision2D collision)
    {
        //���ڵ�����
        if (collision.gameObject.tag.Contains(monsterTag))
        {
            //�����ð� ��������
            if(curHitTime < coolHitTime)
            {
                return;
            }

            //���� ���ݷ�
            MonsterInfo mobInfo = collision.gameObject.GetComponent<MonsterInfo>();
            int monsterAttackPower = mobInfo.monsterAttackPower;
            int finalMonsterPower = Random.Range(monsterAttackPower * 900, monsterAttackPower * 1100) / 1000;

            //�ǰݵ����� ����
            finalMonsterPower = Mathf.Max(1, finalMonsterPower - PlayerManager.PlayerInstance.PlayerPhysicsArmor - PlayerManager.PlayerInstance.PlayerStatPhysicsArmor);

            //�޼Ұ��� ����
            if (PlayerManager.PlayerInstance.IsActiveMesoGuard)
            {
                //�޼� �Һ�
                int spendMeso = (finalMonsterPower * PlayerManager.PlayerInstance.RateArmorMeso) / 100;
                if (PlayerManager.PlayerInstance.PlayerMeso >= spendMeso)
                {
                    PlayerManager.PlayerInstance.PlayerMeso -= spendMeso;
                    finalMonsterPower = finalMonsterPower / 2;
                    itmeUI.ShowPlayerMeso();
                }
            }

            //�̽� ����
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
    /// ���ڵ�����
    /// </summary>
    public void DecreasePlayerHP(int monsterPower)
    {
        PlayerManager.PlayerInstance.PlayerCurHP = Mathf.Max(0, PlayerManager.PlayerInstance.PlayerCurHP - monsterPower);
        playerInfoUI.ShowPlayerHPBar();

        //���
        if(PlayerManager.PlayerInstance.PlayerCurHP<=0)
            playerDie.gameObject.SetActive(true);
    }

    void TimeFlow()
    {
        curHitTime += Time.deltaTime;
    }
}
