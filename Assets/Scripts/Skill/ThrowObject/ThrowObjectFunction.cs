using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;

public class ThrowObjectFunction : MonoBehaviour
{
    [SerializeField]
    int throwAttack;
    float moveSpeed = 5f;
    const float judgeCollideDist = 0.1f;

    private Vector3 moveDir;
    private Vector3 lookDir;
    private GameObject targetMob;

    public int hitNum { get; set; }
    
    private void OnEnable()
    {
        lookDir = PlayerManager.PlayerInstance.PlayerLookDir;
        targetMob = PlayerAttackCommon.NearMonserFromPlayer(lookDir,this.transform.position);
        moveDir = (targetMob.transform.position - transform.position).normalized;
    }

    void Update()
    {
        MoveObject();
        CollideToMonster();
    }

    /// <summary>
    /// ������Ʈ �̵�
    /// </summary>
    void MoveObject()
    {
        transform.position = moveDir * moveSpeed * Time.deltaTime;
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
            PlayerAttackCommon.ShowDamageAsSkin(hitDamage,targetMob,hitNum);

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
        return throwAttack;
    }
}
