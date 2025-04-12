using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField]
    PlayerInfoUI playerInfoUI;
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
            int monsterAttackPower = collision.gameObject.GetComponent<MonsterInfo>().monsterAttackPower;
            int finalMonsterPower = Random.Range(monsterAttackPower * 400, monsterAttackPower * 600) / 500;
            DecreasePlayerHP(finalMonsterPower);
            ShowDamageAsSkin(finalMonsterPower,this.gameObject);
            curHitTime = 0;
        }
    }

    /// <summary>
    /// 몸박데미지
    /// </summary>
    void DecreasePlayerHP(int monsterPower)
    {
        PlayerManager.PlayerInstance.PlayerCurHP = Mathf.Max(0, PlayerManager.PlayerInstance.PlayerCurHP - monsterPower);
        playerInfoUI.ShowPlayerHPBar();
    }

    /// <summary>
    /// 피격 데미지 보이기
    /// </summary>
    /// <param name="Damage">데미지</param>
    /// <param name="playerPos">플레이어 위치</param>
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
