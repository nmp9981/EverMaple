using System.Collections.Generic;
using UnityEngine;

public static class PlayerAttackCommon
{
    const float PIDiv03 = Mathf.PI * 0.3f;

    /// <summary>
    /// �÷��̾�κ��� ���� ����� ���� ��ȯ 
    /// �̶� �÷��̾ �ٶ󺸴� ���� ���
    /// </summary>
    public static GameObject NearMonserFromPlayer(Vector3 lookDir, Vector3 playerPos, float limitDist, float limitAngle = PIDiv03)
    {
        GameObject nearMob = null;
        float dist = float.MaxValue;
        foreach (var mob in MonsterSpawn.activeMonster)
        {
            //������ ������ �˻�
            Vector3 diff = mob.transform.position - playerPos;
            //diff�� ����� ���Ͱ� ������, ������ ���Ͱ� ���ʿ� �ִ�.
            //�Ʒ� ����� ������ ĳ���Ͱ� �ٶ󺸴� ���⿡�� �ش� ���Ͱ� ����.
            float dotValue = diff.x * lookDir.x;//���� ��
            if (dotValue < 0)
                continue;

            //�Ÿ� �˻�
            float curDist = diff.magnitude;
            //��Ÿ� ��
            if (curDist > limitDist)
                continue;

            //���հ��� �ʹ� ������ ��ó ���ͷ� ���� �ʴ´�.
            float cos = dotValue / curDist;
            float theta = Mathf.Abs(Mathf.Acos(cos));
            if (theta > limitAngle)
                continue;

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
    /// �÷��̾�κ��� �������� �ִ� ���͵� ��ȯ
    /// �̶� �÷��̾ �ٶ󺸴� ���� ���
    /// </summary>
    public static List<GameObject> TargetMonstersFromPlayer(Vector3 lookDir, Vector3 playerPos, float limitXDist, float limitYDist, float countslimit,float limitAngle = PIDiv03)
    {
        List<GameObject> mobInArea = new List<GameObject>();
        float dist = float.MaxValue;
        foreach (var mob in MonsterSpawn.activeMonster)
        {
            //������ ������ �˻�
            Vector3 diff = mob.transform.position - playerPos;
            //diff�� ����� ���Ͱ� ������, ������ ���Ͱ� ���ʿ� �ִ�.
            //�Ʒ� ����� ������ ĳ���Ͱ� �ٶ󺸴� ���⿡�� �ش� ���Ͱ� ����.
            float dotValue = diff.x * lookDir.x;//���� ��
            if (dotValue < 0)
                continue;

            //�Ÿ� �˻�
            float curDist = diff.magnitude;
            //X�� ���� ����
            if (curDist > limitXDist)
                continue;

            //y�� ���� ����
            if (Mathf.Abs(mob.transform.position.y - playerPos.y) > limitYDist)
                continue;

            //���հ��� �ʹ� ������ ��ó ���ͷ� ���� �ʴ´�.
            float cos = dotValue / curDist;
            float theta = Mathf.Abs(Mathf.Acos(cos));
            if (theta > limitAngle)
                continue;

            //�������� ���Ͱ� �����Ƿ� ���� ������� ����
            mobInArea.Add(mob);

            //�ִ� Ÿ����� �����ϸ� �ݺ����� ���������ʰ� ����������.
            if (mobInArea.Count >= countslimit)
                break;
        }
        return mobInArea;
    }
    /// <summary>
    /// ũ��Ƽ�� ����
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
    /// ���� ������ ���̱�
    /// </summary>
    /// <param name="Damage">������</param>
    /// <param name="playerPos">�÷��̾� ��ġ</param>
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
    /// ũ��Ƽ�� ���� ������ ���̱�
    /// </summary>
    /// <param name="Damage">������</param>
    /// <param name="playerPos">�÷��̾� ��ġ</param>
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
    /// �ǰ� ������ ���̱�
    /// </summary>
    /// <param name="Damage">������</param>
    /// <param name="playerPos">�÷��̾� ��ġ</param>
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
    /// ���Ͱ� ĳ������ ���� �ݰ� ���� �ִ°�?
    /// AABB�浹 ���� ��� ���
    /// </summary>
    /// <returns></returns>
    public static bool IsMonsterInPlayerAttackArea(Bounds monsterArea, Bounds playerArea)
    {
        Vector3 maxMob = monsterArea.max;
        Vector3 minMob = monsterArea.min;
        Vector3 maxPlayer = playerArea.max;
        Vector3 minPlayer = playerArea.min;

        //2D�̹Ƿ� x,y��ǥ�� ��
        bool isXCollide = false;
        bool isYCollide = false;

        //�浹 �˻�
        if (maxMob.x > minPlayer.x && minMob.x < maxPlayer.x)
        {
            isXCollide = true;
        }
        if (maxMob.y > minPlayer.y && minMob.y < maxPlayer.y)
        {
            isYCollide = true;
        }

        //�浹��
        if (isXCollide && isYCollide)
        {
            return true;
        }
        //�浹����
        return false;
    }

    /// <summary>
    /// ���� ���� ���� ����
    /// </summary>
    /// <param name="nearMob">��� ����</param>
    /// <param name="skillCoefficient">���� ���</param>
    public static void PlayerAttackToOneMonster(GameObject nearMob, int skillCoefficient, int hitNum)
    {
        //���� ��ǰ� ������
        int maxAttackDamage = (PlayerManager.PlayerInstance.PlayerAttack * skillCoefficient) / 100;
        int minAttackDamage = (maxAttackDamage * PlayerManager.PlayerInstance.Workmanship) / 100;
        int attackDamage = Random.Range(minAttackDamage, maxAttackDamage);

        //ũ��Ƽ�� ����
        bool isCri = IsCritical();
        if (isCri)
        {
            attackDamage = (attackDamage * PlayerManager.PlayerInstance.CriticalDamagee)/100;//ũ��Ƽ�� ������ �ݿ�
        }

        //���� HP����
        nearMob.GetComponent<MonsterInfo>().DecreaseMonsterHP(attackDamage);

        //������ ����(�⺻ ������ 1ȸ Ÿ��)
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
