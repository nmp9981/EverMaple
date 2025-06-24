using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;

public class ThrowObjectFunction : MonoBehaviour
{
    [SerializeField]
    private int throwAttack;
   
    float moveSpeed = 10f;
    const float judgeCollideDist = 0.5f;

    private Vector3 moveDir;
    private Vector3 lookDir;
    private GameObject targetMob;

    float moveDist = 0;
    float destroyDist;

    public int skillCoefficient { get; set; }
    public Vector3 startPos { get; set; }
    public int hitNum { get; set; }
    
    private void OnEnable()
    {
        moveDist = 0;
        destroyDist = PlayerManager.PlayerInstance.ThrowObjectMaxDist;
        lookDir = PlayerManager.PlayerInstance.PlayerLookDir;
        targetMob = PlayerAttackCommon.NearMonserFromPlayer(lookDir, startPos, destroyDist);

        SetMoveDir();
    }

    void Update()
    {
        MoveObject();
        CollideToMonster();
    }

    /// <summary>
    /// �����̴� ���� ����
    /// </summary>
    void SetMoveDir()
    {
        if (targetMob != null)
            moveDir = (targetMob.transform.position - startPos).normalized;
        else moveDir = lookDir;
    }

    /// <summary>
    /// ������Ʈ �̵�
    /// </summary>
    void MoveObject()
    {
        transform.position += moveDir * moveSpeed * Time.deltaTime;
        moveDist += moveSpeed * Time.deltaTime;

        //��Ÿ� ������ ��Ȱ��ȭ
        if(moveDist > destroyDist)
        {
            moveDist = 0;
            DestroyObject();
        }
    }
    /// <summary>
    /// ���� ����
    /// </summary>
    void CollideToMonster()
    {
        //Ÿ�ٸ��� �������� ����
        if (targetMob == null)
            return;

        float dist = Vector3.Distance(targetMob.transform.position, gameObject.transform.position);
        //���� ����
        if (dist < judgeCollideDist)
        {
            MonsterInfo mobInfo = targetMob.GetComponent<MonsterInfo>();

            //�̽� ����
            if (PlayerAttackCommon.IsAttackMiss(mobInfo.monsterLv, mobInfo.monsterAvoid))
            {
                PlayerAttackCommon.ShowMissAttackDamageAsSkin(mobInfo.gameObject, hitNum);
                return;
            }

            int hitDamage = CalDamage(mobInfo,throwAttack);
            //ũ��Ƽ�� ����
            bool isCri = PlayerAttackCommon.IsCritical();
            if (isCri)
            {
                hitDamage = (hitDamage *PlayerManager.PlayerInstance.CriticalDamagee)/100;//ũ��Ƽ�� ������ �ݿ�
            }

            mobInfo.DecreaseMonsterHP(hitDamage);

            //������ ����
            if (isCri)
            {
                PlayerAttackCommon.ShowCriticalDamageAsSkin(hitDamage, targetMob, hitNum);
            }
            else
            {
                PlayerAttackCommon.ShowDamageAsSkin(hitDamage, targetMob, hitNum);
            }

            //����
            SoundManager._sound.PlaySfx(16);

            gameObject.SetActive(false);
            return;
        }
    }
    /// <summary>
    /// ������ ���
    /// </summary>
    /// <returns></returns>
    int CalDamage(MonsterInfo mobInfo,int throwAttack)
    {
        //�� ��, �� ���ݷ�
        int totalLUK = PlayerManager.PlayerInstance.PlayerLUK + PlayerManager.PlayerInstance.PlayerAddLUK;
        int totalAttackValue = throwAttack + PlayerManager.PlayerInstance.PlayerAttack;

        //������
        int maxDamage = totalAttackValue * skillCoefficient *(totalLUK*5)/ 10000;
        int minDamage = maxDamage/2;
        int damage = Random.Range(minDamage, maxDamage);

        //������ ����
        int diffLV = Mathf.Max(0, mobInfo.monsterLv - PlayerManager.PlayerInstance.PlayerLV);
        int decreaseDamage = (diffLV * damage)/100;
        damage = Mathf.Max(1, damage - decreaseDamage - mobInfo.monsterArmor);
        return damage;
    }
    /// <summary>
    /// ������Ʈ ��Ȱ��ȭ
    /// </summary>
    void DestroyObject()
    {
        gameObject.SetActive(false);
    }
}
