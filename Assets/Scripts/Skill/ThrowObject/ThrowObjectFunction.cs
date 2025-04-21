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

    float moveDist = 0;
    float destroyDist = 8;

    public int hitNum { get; set; }
    
    private void OnEnable()
    {
        GameObject player = GameObject.Find("Player");
        lookDir = PlayerManager.PlayerInstance.PlayerLookDir;
        targetMob = PlayerAttackCommon.NearMonserFromPlayer(lookDir,player.transform.position);
        moveDir = (targetMob.transform.position - player.transform.position).normalized;
    }

    void Update()
    {
        MoveObject();
        CollideToMonster();
    }

    /// <summary>
    /// 오브젝트 이동
    /// </summary>
    void MoveObject()
    {
        transform.position += moveDir * moveSpeed * Time.deltaTime;
        moveDist += moveSpeed * Time.deltaTime;

        //사거리 넘으면 비활성화
        if(moveDist > destroyDist)
        {
            moveDist = 0;
            DestroyObject();
        }
    }
    /// <summary>
    /// 공격 명중
    /// </summary>
    void CollideToMonster()
    {
        //타겟몹이 있을때만 적용
        if (targetMob == null)
            return;

        float dist = Vector3.Distance(targetMob.transform.position, gameObject.transform.position);
        //공격 명중
        if (dist < judgeCollideDist)
        {
            int hitDamage = CalDamage(throwAttack);
            targetMob.GetComponent<MonsterInfo>().DecreaseMonsterHP(hitDamage);
            PlayerAttackCommon.ShowDamageAsSkin(hitDamage,targetMob,hitNum);

            gameObject.SetActive(false);
            return;
        }
    }
    /// <summary>
    /// 데미지 계산
    /// </summary>
    /// <returns></returns>
    int CalDamage(int throwAttack)
    {
        return throwAttack;
    }
    /// <summary>
    /// 오브젝트 비활성화
    /// </summary>
    void DestroyObject()
    {
        gameObject.SetActive(false);
    }
}
