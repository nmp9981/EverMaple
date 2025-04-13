using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //���
    const float maxDist = 999f;

    //��Ÿ��
    float curAttackTime = 0;
    float coolAttackTime = 1f;

    //ĳ���� ũ��
    Bounds playerBound = default;
    //���ݿ��� �ٿ��
    Bounds attackBound = default;

    private void Awake()
    {
        playerBound = GetComponent<BoxCollider2D>().bounds;
    }

    void Update()
    {
        TimeFlow();
    }
    /// <summary>
    /// �⺻ ���� �÷ο�
    /// </summary>
    public void BasicAttackFlow()
    {
        //���� ��Ÿ���� �ȵ�
        if(curAttackTime < coolAttackTime)
        {
            return;
        }
        //���� ���� ����
        attackBound = SettingAttackArea();

        //�÷��̾�κ��� ���� �����̿� �ִ� ���� ���ϱ�
        GameObject nearMob = NearMonserFromPlayer(attackBound.center);

        //���Ͱ� ������ �Ʒ� ������ ���������ʰ� �ߴ�
        if (nearMob == null)
        {
            return;
        }

        //���Ͱ� ĳ������ ���� �ݰ� ���� �ִ°�?
        Bounds nearMobArea= nearMob.GetComponent<Collider2D>().bounds;
        if (IsMonsterInPlayerAttackArea(nearMobArea, attackBound))
        {
            //���� ��ǰ� ������
            int attackPower = PlayerManager.PlayerInstance.PlayerAttack;
            int minAttackDamage = (attackPower * PlayerManager.PlayerInstance.Workmanship) / 100;
            int attackDamage = Random.Range(minAttackDamage, attackPower);
            //������ ����(�⺻ ������ 1ȸ Ÿ��)
            ShowDamageAsSkin(attackDamage, nearMob,1);
            //���� HP����
            DecreaseMonsterHP(nearMob,attackDamage);
        }
    }

    /// <summary>
    /// ���ݿ��� ���� : �簢�ڽ� ���
    /// </summary>
    Bounds SettingAttackArea()
    {
        Bounds bounds = new Bounds();
        bounds.center = playerBound.center + Vector3.left * 0.5f;
        bounds.size = playerBound.size;
        return bounds;
    }

    /// <summary>
    /// �÷��̾�κ��� ���� ����� ���� ��ȯ
    /// </summary>
    GameObject NearMonserFromPlayer(Vector3 center)
    {
        GameObject nearMob = null;
        float dist = maxDist;
        foreach(var mob in MonsterSpawn.activeMonster)
        {
            float curDist = Mathf.Abs(mob.transform.position.x - gameObject.transform.position.x);
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
    /// ���Ͱ� ĳ������ ���� �ݰ� ���� �ִ°�?
    /// AABB�浹 ���� ��� ���
    /// </summary>
    /// <returns></returns>
    bool IsMonsterInPlayerAttackArea(Bounds monsterArea, Bounds playerArea)
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
    /// ���� HP����
    /// </summary>
    void DecreaseMonsterHP(GameObject targetMonster, int playerAttackDamage)
    {
        targetMonster.GetComponent<MonsterInfo>().monsterCurHP -=playerAttackDamage;
    }

    /// <summary>
    /// �ǰ� ������ ���̱�
    /// </summary>
    /// <param name="Damage">������</param>
    /// <param name="playerPos">�÷��̾� ��ġ</param>
    void ShowDamageAsSkin(int Damage, GameObject monsterPos, int hitNum)
    {
        string damageString = Damage.ToString();
        float damageLength = DamageObjectFulling.DamageSkinInstance.hitDamageImage[0].bounds.size.x * damageString.Length;
        Bounds bounds = monsterPos.GetComponent<BoxCollider2D>().bounds;
        Vector3 damageStartPos = bounds.center +hitNum* Vector3.up * (bounds.size.y * 0.5f + 0.5f) + damageLength * Vector3.left * 0.25f;

        for (int i = 0; i < damageString.Length; i++)
        {
            GameObject damImg = DamageObjectFulling.DamageSkinInstance.MakeObj((damageString[i] - '0'));
            damImg.transform.position = damageStartPos + Vector3.right * DamageObjectFulling.DamageSkinInstance.hitDamageImage[0].bounds.size.x * i * 1.5f;
        }
        InputKeyManager.orderSortNum += 1;
    }

    /// <summary>
    /// �ð� �帧
    /// </summary>
    void TimeFlow()
    {
        curAttackTime += Time.deltaTime;
    }
}
