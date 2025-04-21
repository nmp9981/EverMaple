using UnityEngine;

public static class PlayerAttackCommon
{
    /// <summary>
    /// 플레이어로부터 가장 가까운 몬스터 반환 
    /// 이때 플레이어가 바라보는 방향 고려
    /// </summary>
    public static GameObject NearMonserFromPlayer(Vector3 lookDir, Vector3 playerPos)
    {
        GameObject nearMob = null;
        float dist = float.MaxValue;
        foreach (var mob in MonsterSpawn.activeMonster)
        {
            //방향이 같은지 검사
            Vector3 diff = mob.transform.position - playerPos;
            //diff가 양수면 몬스터가 오른쪽, 음수면 몬스터가 왼쪽에 있다.
            //아래 결과가 음수면 캐릭터가 바라보는 방향에는 해당 몬스터가 없다.
            if (diff.x * lookDir.x < 0)
                continue;

            //거리 검사
            float curDist = diff.magnitude;
            //더 가까운 거리
            if (curDist < dist)
            {
                dist = curDist;
                nearMob = mob;
            }
        }
        return nearMob;
    }
    /// <summary>
    /// 크리티컬 판정
    /// </summary>
    /// <returns></returns>
    public static bool IsCritical()
    {
        int criValue = Random.Range(0, 100);

        if (criValue >= PlayerManager.PlayerInstance.CriticalProbably)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 공격 데미지 보이기
    /// </summary>
    /// <param name="Damage">데미지</param>
    /// <param name="playerPos">플레이어 위치</param>
    public static void ShowDamageAsSkin(int Damage, GameObject monsterPos, int hitNum)
    {
        string damageString = Damage.ToString();
        float damageLength = DamageObjectFulling.DamageSkinInstance.damageImage[0].bounds.size.x * damageString.Length;
        Bounds bounds = monsterPos.GetComponent<BoxCollider2D>().bounds;
        Vector3 damageStartPos = bounds.center + hitNum * Vector3.up * (bounds.size.y * 0.5f + 1f) + damageLength * Vector3.left * 0.2f;

        for (int i = 0; i < damageString.Length; i++)
        {
            GameObject damImg = DamageObjectFulling.DamageSkinInstance.MakeObj((damageString[i] - '0'));
            damImg.transform.position = damageStartPos + Vector3.right * DamageObjectFulling.DamageSkinInstance.damageImage[0].bounds.size.x * i * 0.5f;
        }
        InputKeyManager.orderSortNum += 1;
    }

    /// <summary>
    /// 크리티컬 공격 데미지 보이기
    /// </summary>
    /// <param name="Damage">데미지</param>
    /// <param name="playerPos">플레이어 위치</param>
    public static void ShowCriticalDamageAsSkin(int Damage, GameObject monsterPos, int hitNum)
    {
        string damageString = Damage.ToString();
        float damageLength = DamageObjectFulling.DamageSkinInstance.criticalDamageImage[0].bounds.size.x * damageString.Length;
        Bounds bounds = monsterPos.GetComponent<BoxCollider2D>().bounds;
        Vector3 damageStartPos = bounds.center + hitNum * Vector3.up * (bounds.size.y * 0.5f + 1f) + damageLength * Vector3.left * 0.2f;

        for (int i = 0; i < damageString.Length; i++)
        {
            GameObject damImg = DamageObjectFulling.DamageSkinInstance.MakeObj((damageString[i] - '0') + 10);
            damImg.transform.position = damageStartPos + Vector3.right * DamageObjectFulling.DamageSkinInstance.criticalDamageImage[0].bounds.size.x * i * 0.5f;
        }
        InputKeyManager.orderSortNum += 1;
    }
}
