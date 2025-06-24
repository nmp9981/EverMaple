using UnityEngine;
using UnityEngine.LowLevel;

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
    //��������Ʈ
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        playerBound = GetComponent<BoxCollider2D>().bounds;
        spriteRenderer = GetComponent<SpriteRenderer>();

        PlayerManager.PlayerInstance.PlayerStatAttack = 40;
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

        //���� ���� ũ��
        float attackBoundSize = 3f;

        //�÷��̾ �ٶ󺸴� ����
        Vector3 lookDir = PlayerManager.PlayerInstance.PlayerLookDir;
        //���� ���� ����
        attackBound = SettingAttackArea(lookDir, attackBoundSize);

        //ȿ����
        SoundManager._sound.PlaySfx(0);

        //�÷��̾�κ��� ���� �����̿� �ִ� ���� ���ϱ�
        GameObject nearMob = PlayerAttackCommon.NearMonserFromPlayer(lookDir ,gameObject.transform.position,attackBoundSize*2);
       
        //���Ͱ� ������ �Ʒ� ������ ���������ʰ� �ߴ�
        if (nearMob == null)
        {
            return;
        }
       
        //���Ͱ� ĳ������ ���� �ݰ� ���� �ִ°�?
        Bounds nearMobArea= nearMob.GetComponent<Collider2D>().bounds;
        if (PlayerAttackCommon.IsMonsterInPlayerAttackArea(nearMobArea, attackBound))
        {
            PlayerAttackCommon.PlayerAttackToOneMonster(nearMob,100,1);
            if(PlayerManager.PlayerInstance.IsShadowPartner)
                PlayerAttackCommon.PlayerAttackToOneMonster(nearMob, SkillDamageCalCulate.ShadowPartnerCoff, 2);
        }
    }

    /// <summary>
    ///  ���ݿ��� ���� : �簢�ڽ� ���
    /// </summary>
    /// <param name="dir">ĳ���Ͱ� �ٶ󺸴� ����</param>
    /// <returns></returns>
    public Bounds SettingAttackArea(Vector3 dir, float attackBoundSize)
    {
        Bounds bounds = new Bounds();
        //ĳ���Ͱ� �ٶ󺸴� ���⿡���� �ڽ� ��ġ�� �޶���
        bounds.center = gameObject.transform.position + dir * 0.5f;
        bounds.size = playerBound.size* attackBoundSize;
        return bounds;
    }

    /// <summary>
    /// �ð� �帧
    /// </summary>
    void TimeFlow()
    {
        curAttackTime += Time.deltaTime;
    }
}
