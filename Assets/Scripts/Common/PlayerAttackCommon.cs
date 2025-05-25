using System.Collections.Generic;
using UnityEngine;

public static class PlayerAttackCommon
{
    const float PIDiv03 = Mathf.PI * 0.3f;

    /// <summary>
    /// 플레이어로부터 가장 가까운 몬스터 반환 
    /// 이때 플레이어가 바라보는 방향 고려
    /// </summary>
    public static GameObject NearMonserFromPlayer(Vector3 lookDir, Vector3 playerPos, float limitDist, float limitAngle = PIDiv03)
    {
        GameObject nearMob = null;
        float dist = float.MaxValue;
        foreach (var mob in MonsterSpawn.activeMonster)
        {
            //방향이 같은지 검사
            Vector3 diff = mob.transform.position - playerPos;
            //diff가 양수면 몬스터가 오른쪽, 음수면 몬스터가 왼쪽에 있다.
            //아래 결과가 음수면 캐릭터가 바라보는 방향에는 해당 몬스터가 없다.
            float dotValue = diff.x * lookDir.x;//내적 값
            if (dotValue < 0)
                continue;

            //거리 검사
            float curDist = diff.magnitude;
            //사거리 밖
            if (curDist > limitDist)
                continue;

            //사잇각이 너무 높으면 근처 몬스터로 보지 않는다.
            float cos = dotValue / curDist;
            float theta = Mathf.Abs(Mathf.Acos(cos));
            if (theta > limitAngle)
                continue;

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
    /// 플레이어로부터 범위내에 있는 몬스터들 반환
    /// 이때 플레이어가 바라보는 방향 고려
    /// </summary>
    public static List<GameObject> TargetMonstersFromPlayer(Vector3 lookDir, Vector3 playerPos, float limitXDist, float limitYDist, float countslimit,float limitAngle = PIDiv03)
    {
        List<GameObject> mobInArea = new List<GameObject>();
        float dist = float.MaxValue;
        foreach (var mob in MonsterSpawn.activeMonster)
        {
            //방향이 같은지 검사
            Vector3 diff = mob.transform.position - playerPos;
            //diff가 양수면 몬스터가 오른쪽, 음수면 몬스터가 왼쪽에 있다.
            //아래 결과가 음수면 캐릭터가 바라보는 방향에는 해당 몬스터가 없다.
            float dotValue = diff.x * lookDir.x;//내적 값
            if (dotValue < 0)
                continue;

            //거리 검사
            float curDist = diff.magnitude;
            //X축 범위 제한
            if (curDist > limitXDist)
                continue;

            //y축 범위 제한
            if (Mathf.Abs(mob.transform.position.y - playerPos.y) > limitYDist)
                continue;

            //사잇각이 너무 높으면 근처 몬스터로 보지 않는다.
            float cos = dotValue / curDist;
            float theta = Mathf.Abs(Mathf.Acos(cos));
            if (theta > limitAngle)
                continue;

            //범위내에 몬스터가 있으므로 공격 대상으로 설정
            mobInArea.Add(mob);

            //최대 타깃수에 도달하면 반복문을 실행하지않고 빠져나간다.
            if (mobInArea.Count >= countslimit)
                break;
        }
        return mobInArea;
    }
    /// <summary>
    /// 크리티컬 판정
    /// </summary>
    /// <returns></returns>
    public static bool IsCritical()
    {
        int criValue = Random.Range(1, 101);

        if (criValue <= PlayerManager.PlayerInstance.CriticalProbably)
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
        Vector3 damageStartPos = bounds.center + Vector3.up * (hitNum * DamageObjectFulling.DamageSkinInstance.damageImage[0].bounds.size.y * 0.5f+0.5f) + damageLength * Vector3.left * 0.2f;

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
        Vector3 damageStartPos = bounds.center +Vector3.up * (hitNum * DamageObjectFulling.DamageSkinInstance.criticalDamageImage[0].bounds.size.y * 0.5f + 0.5f) + damageLength * Vector3.left * 0.2f;

        for (int i = 0; i < damageString.Length; i++)
        {
            GameObject damImg = DamageObjectFulling.DamageSkinInstance.MakeObj((damageString[i] - '0') + 10);
            damImg.transform.position = damageStartPos + Vector3.right * DamageObjectFulling.DamageSkinInstance.criticalDamageImage[0].bounds.size.x * i * 0.5f;
        }
        InputKeyManager.orderSortNum += 1;
    }
    /// <summary>
    /// 피격 데미지 보이기
    /// </summary>
    /// <param name="Damage">데미지</param>
    /// <param name="playerPos">플레이어 위치</param>
    public static void ShowDamageAsSkin(long Damage, GameObject playerPos)
    {
        string damageString = Damage.ToString();
        float damageLength = DamageObjectFulling.DamageSkinInstance.hitDamageImage[0].bounds.size.x * damageString.Length;
        Bounds bounds = playerPos.GetComponent<BoxCollider2D>().bounds;
        Vector3 damageStartPos = bounds.center + Vector3.up * (bounds.size.y * 0.5f + 0.5f) + damageLength * Vector3.left * 0.25f;

        for (int i = 0; i < damageString.Length; i++)
        {
            GameObject damImg = DamageObjectFulling.DamageSkinInstance.MakeObj((damageString[i] - '0') + 20);
            damImg.transform.position = damageStartPos + Vector3.right * DamageObjectFulling.DamageSkinInstance.hitDamageImage[0].bounds.size.x * i * 1.5f;
        }
        InputKeyManager.orderSortNum += 1;
    }

    /// <summary>
    /// 몬스터가 캐릭터의 공격 반경 내에 있는가?
    /// AABB충돌 검출 방식 사용
    /// </summary>
    /// <returns></returns>
    public static bool IsMonsterInPlayerAttackArea(Bounds monsterArea, Bounds playerArea)
    {
        Vector3 maxMob = monsterArea.max;
        Vector3 minMob = monsterArea.min;
        Vector3 maxPlayer = playerArea.max;
        Vector3 minPlayer = playerArea.min;

        //2D이므로 x,y좌표만 비교
        bool isXCollide = false;
        bool isYCollide = false;

        //충돌 검사
        if (maxMob.x > minPlayer.x && minMob.x < maxPlayer.x)
        {
            isXCollide = true;
        }
        if (maxMob.y > minPlayer.y && minMob.y < maxPlayer.y)
        {
            isYCollide = true;
        }

        //충돌함
        if (isXCollide && isYCollide)
        {
            return true;
        }
        //충돌안함
        return false;
    }

    /// <summary>
    /// 단일 몬스터 실제 공격
    /// </summary>
    /// <param name="nearMob">대상 몬스터</param>
    /// <param name="skillCoefficient">공격 계수</param>
    public static void PlayerAttackToOneMonster(GameObject nearMob, int skillCoefficient, int hitNum)
    {
        //공격 모션과 데미지
        int maxAttackDamage = (PlayerManager.PlayerInstance.PlayerAttack * skillCoefficient) / 100;
        int minAttackDamage = (maxAttackDamage * PlayerManager.PlayerInstance.Workmanship) / 100;
        int attackDamage = Random.Range(minAttackDamage, maxAttackDamage);

        //크리티컬 판정
        bool isCri = IsCritical();
        if (isCri)
        {
            attackDamage = (attackDamage * PlayerManager.PlayerInstance.CriticalDamagee)/100;//크리티컬 데미지 반영
        }

        //몬스터 HP감소
        nearMob.GetComponent<MonsterInfo>().DecreaseMonsterHP(attackDamage);

        //데미지 띄우기(기본 공격은 1회 타격)
        if (isCri)
        {
            ShowCriticalDamageAsSkin(attackDamage, nearMob, hitNum);
        }
        else
        {
            ShowDamageAsSkin(attackDamage, nearMob, hitNum);
        }
    }
}
