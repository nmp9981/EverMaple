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
            int hitDamage = CalDamage(throwAttack);
            //ũ��Ƽ�� ����
            bool isCri = PlayerAttackCommon.IsCritical();
            if (isCri)
            {
                hitDamage = (hitDamage *PlayerManager.PlayerInstance.CriticalDamagee)/100;//ũ��Ƽ�� ������ �ݿ�
            }

            targetMob.GetComponent<MonsterInfo>().DecreaseMonsterHP(hitDamage);

            //������ ����
            if (isCri)
            {
                PlayerAttackCommon.ShowCriticalDamageAsSkin(hitDamage, targetMob, hitNum);
            }
            else
            {
                PlayerAttackCommon.ShowDamageAsSkin(hitDamage, targetMob, hitNum);
            }

            gameObject.SetActive(false);
            return;
        }
    }
    /// <summary>
    /// ������ ���
    /// </summary>
    /// <returns></returns>
    int CalDamage(int throwAttack)
    {
        int maxDamage = throwAttack * skillCoefficient *(PlayerManager.PlayerInstance.PlayerLUK*5)/ 10000;
        int minDamage = maxDamage/2;
        int damage = Random.Range(minDamage, maxDamage);
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
