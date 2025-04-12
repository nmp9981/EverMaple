using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField]
    PlayerInfoUI playerInfoUI;
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
            DecreasePlayerHP(finalMonsterPower);
            ShowDamageAsSkin(finalMonsterPower,this.gameObject);
            curHitTime = 0;
        }
    }

    /// <summary>
    /// ���ڵ�����
    /// </summary>
    void DecreasePlayerHP(int monsterPower)
    {
        PlayerManager.PlayerInstance.PlayerCurHP = Mathf.Max(0, PlayerManager.PlayerInstance.PlayerCurHP - monsterPower);
        playerInfoUI.ShowPlayerHPBar();
    }

    /// <summary>
    /// �ǰ� ������ ���̱�
    /// </summary>
    /// <param name="Damage">������</param>
    /// <param name="playerPos">�÷��̾� ��ġ</param>
    void ShowDamageAsSkin(long Damage, GameObject playerPos)
    {
        string damageString = Damage.ToString();
        float damageLength = DamageObjectFulling.DamageSkinInstance.hitDamageImage[0].bounds.size.x * damageString.Length;
        Bounds bounds = playerPos.GetComponent<BoxCollider2D>().bounds;
        Vector3 damageStartPos = bounds.center + Vector3.up * (bounds.size.y * 0.5f + 0.5f) + damageLength * Vector3.left * 0.25f;
       
        for (int i = 0; i < damageString.Length; i++)
        {
            GameObject damImg = DamageObjectFulling.DamageSkinInstance.MakeObj((damageString[i] - '0')+20);
            damImg.transform.position = damageStartPos + Vector3.right * DamageObjectFulling.DamageSkinInstance.hitDamageImage[0].bounds.size.x * i*1.5f;
        }
        InputKeyManager.orderSortNum += 1;
    }
    void TimeFlow()
    {
        curHitTime += Time.deltaTime;
    }
}
