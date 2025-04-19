using UnityEngine;
using UnityEngine.LowLevel;

public class PlayerAttack : MonoBehaviour
{
    //���
    const float maxDist = 999f;

    //���� ���� ũ��
    float attackBoundSize = 2f;

    //��Ÿ��
    float curAttackTime = 0;
    float coolAttackTime = 1f;

    //ĳ���� ũ��
    Bounds playerBound = default;
    //���ݿ��� �ٿ��
    Bounds attackBound = default;
    //��������Ʈ
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        playerBound = GetComponent<BoxCollider2D>().bounds;
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        //��Ÿ�� �ʱ�ȭ
        curAttackTime = 0;

        //���� ���
        PlayerAnimation.AttackAnim();

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

            //ũ��Ƽ�� ����
            int criValue = Random.Range(0, 100);

            if (criValue >= PlayerManager.PlayerInstance.CriticalProbably)
            {
                attackDamage *= 2;//ũ��Ƽ�� ������ �ݿ�
            }

            //���� HP����
            nearMob.GetComponent<MonsterInfo>().DecreaseMonsterHP(attackDamage);

            //������ ����(�⺻ ������ 1ȸ Ÿ��)
            if (criValue >= PlayerManager.PlayerInstance.CriticalProbably)
            {
                ShowCriticalDamageAsSkin(attackDamage, nearMob, 1);
            }
            else
            {
                ShowDamageAsSkin(attackDamage, nearMob, 1);
            }
        }
    }

    /// <summary>
    /// ���ݿ��� ���� : �簢�ڽ� ���
    /// </summary>
    Bounds SettingAttackArea()
    {
        Bounds bounds = new Bounds();
        //ĳ���Ͱ� �ٶ󺸴� ���⿡���� �ڽ� ��ġ�� �޶���
        Vector3 dir = spriteRenderer.flipX ? Vector3.right : Vector3.left;
        bounds.center = gameObject.transform.position + dir * 0.5f;
        bounds.size = playerBound.size* attackBoundSize;
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
            float curDist = Vector3.Distance(mob.transform.position ,gameObject.transform.position);
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
    /// ���� ������ ���̱�
    /// </summary>
    /// <param name="Damage">������</param>
    /// <param name="playerPos">�÷��̾� ��ġ</param>
    void ShowDamageAsSkin(int Damage, GameObject monsterPos, int hitNum)
    {
        string damageString = Damage.ToString();
        float damageLength = DamageObjectFulling.DamageSkinInstance.damageImage[0].bounds.size.x * damageString.Length;
        Bounds bounds = monsterPos.GetComponent<BoxCollider2D>().bounds;
        Vector3 damageStartPos = bounds.center +hitNum* Vector3.up * (bounds.size.y*0.5f+1f) + damageLength * Vector3.left * 0.2f;

        for (int i = 0; i < damageString.Length; i++)
        {
            GameObject damImg = DamageObjectFulling.DamageSkinInstance.MakeObj((damageString[i] - '0'));
            damImg.transform.position = damageStartPos + Vector3.right * DamageObjectFulling.DamageSkinInstance.damageImage[0].bounds.size.x * i*0.5f;
        }
        InputKeyManager.orderSortNum += 1;
    }

    /// <summary>
    /// ũ��Ƽ�� ���� ������ ���̱�
    /// </summary>
    /// <param name="Damage">������</param>
    /// <param name="playerPos">�÷��̾� ��ġ</param>
    void ShowCriticalDamageAsSkin(int Damage, GameObject monsterPos, int hitNum)
    {
        string damageString = Damage.ToString();
        float damageLength = DamageObjectFulling.DamageSkinInstance.criticalDamageImage[0].bounds.size.x * damageString.Length;
        Bounds bounds = monsterPos.GetComponent<BoxCollider2D>().bounds;
        Vector3 damageStartPos = bounds.center + hitNum * Vector3.up * (bounds.size.y * 0.5f + 1f) + damageLength * Vector3.left * 0.2f;

        for (int i = 0; i < damageString.Length; i++)
        {
            GameObject damImg = DamageObjectFulling.DamageSkinInstance.MakeObj((damageString[i] - '0')+10);
            damImg.transform.position = damageStartPos + Vector3.right * DamageObjectFulling.DamageSkinInstance.criticalDamageImage[0].bounds.size.x * i * 0.5f;
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
