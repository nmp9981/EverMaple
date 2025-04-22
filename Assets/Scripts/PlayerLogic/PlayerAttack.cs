using UnityEngine;
using UnityEngine.LowLevel;

public class PlayerAttack : MonoBehaviour
{
    //���
    const float maxDist = 999f;

    //���� ���� ũ��
    float attackBoundSize = 3f;

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

        //�÷��̾ �ٶ󺸴� ����
        Vector3 lookDir = PlayerManager.PlayerInstance.PlayerLookDir;
        //���� ���� ����
        attackBound = SettingAttackArea(lookDir);

        //�÷��̾�κ��� ���� �����̿� �ִ� ���� ���ϱ�
        GameObject nearMob = PlayerAttackCommon.NearMonserFromPlayer(lookDir ,gameObject.transform.position,attackBoundSize*2);
       
        //���Ͱ� ������ �Ʒ� ������ ���������ʰ� �ߴ�
        if (nearMob == null)
        {
            return;
        }
       
        //���Ͱ� ĳ������ ���� �ݰ� ���� �ִ°�?
        Bounds nearMobArea= nearMob.GetComponent<Collider2D>().bounds;
        if (IsMonsterInPlayerAttackArea(nearMobArea, attackBound))
        {
            PlayerAttackToMonster(nearMob);
        }
    }

    /// <summary>
    ///  ���ݿ��� ���� : �簢�ڽ� ���
    /// </summary>
    /// <param name="dir">ĳ���Ͱ� �ٶ󺸴� ����</param>
    /// <returns></returns>
    Bounds SettingAttackArea(Vector3 dir)
    {
        Bounds bounds = new Bounds();
        //ĳ���Ͱ� �ٶ󺸴� ���⿡���� �ڽ� ��ġ�� �޶���
        bounds.center = gameObject.transform.position + dir * 0.5f;
        bounds.size = playerBound.size* attackBoundSize;
        return bounds;
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
    /// ���� ����
    /// </summary>
    void PlayerAttackToMonster(GameObject nearMob)
    {
        //���� ��ǰ� ������
        int attackPower = PlayerManager.PlayerInstance.PlayerAttack;
        int minAttackDamage = (attackPower * PlayerManager.PlayerInstance.Workmanship) / 100;
        int attackDamage = Random.Range(minAttackDamage, attackPower);

        //ũ��Ƽ�� ����
        bool isCri = PlayerAttackCommon.IsCritical();
        if (isCri)
        {
            attackDamage *= 2;//ũ��Ƽ�� ������ �ݿ�
        }
       
        //���� HP����
        nearMob.GetComponent<MonsterInfo>().DecreaseMonsterHP(attackDamage);

        //������ ����(�⺻ ������ 1ȸ Ÿ��)
        if (isCri)
        {
            PlayerAttackCommon.ShowCriticalDamageAsSkin(attackDamage, nearMob, 1);
        }
        else
        {
            PlayerAttackCommon.ShowDamageAsSkin(attackDamage, nearMob, 1);
        }
    }

    /// <summary>
    /// �ð� �帧
    /// </summary>
    void TimeFlow()
    {
        curAttackTime += Time.deltaTime;
    }
}
