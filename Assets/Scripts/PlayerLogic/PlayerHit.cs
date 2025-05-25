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
            int monsterAttackPower = collision.gameObject.GetComponent<MonsterInfo>().monsterAttackPower;
            int finalMonsterPower = Random.Range(monsterAttackPower * 400, monsterAttackPower * 600) / 500;

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

            DecreasePlayerHP(finalMonsterPower);
            PlayerAttackCommon.ShowDamageAsSkin(finalMonsterPower,this.gameObject);
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
