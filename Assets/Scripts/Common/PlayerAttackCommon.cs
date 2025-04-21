using UnityEngine;

public static class PlayerAttackCommon
{
    /// <summary>
    /// �÷��̾�κ��� ���� ����� ���� ��ȯ 
    /// �̶� �÷��̾ �ٶ󺸴� ���� ���
    /// </summary>
    public static GameObject NearMonserFromPlayer(Vector3 lookDir, Vector3 playerPos)
    {
        GameObject nearMob = null;
        float dist = float.MaxValue;
        foreach (var mob in MonsterSpawn.activeMonster)
        {
            //������ ������ �˻�
            Vector3 diff = mob.transform.position - playerPos;
            //diff�� ����� ���Ͱ� ������, ������ ���Ͱ� ���ʿ� �ִ�.
            //�Ʒ� ����� ������ ĳ���Ͱ� �ٶ󺸴� ���⿡�� �ش� ���Ͱ� ����.
            if (diff.x * lookDir.x < 0)
                continue;

            //�Ÿ� �˻�
            float curDist = diff.magnitude;
            //�� ����� �Ÿ�
            if (curDist < dist)
            {
                dist = curDist;
                nearMob = mob;
            }
        }
        return nearMob;
    }
    /// <summary>
    /// ũ��Ƽ�� ����
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
    /// ���� ������ ���̱�
    /// </summary>
    /// <param name="Damage">������</param>
    /// <param name="playerPos">�÷��̾� ��ġ</param>
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
    /// ũ��Ƽ�� ���� ������ ���̱�
    /// </summary>
    /// <param name="Damage">������</param>
    /// <param name="playerPos">�÷��̾� ��ġ</param>
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
