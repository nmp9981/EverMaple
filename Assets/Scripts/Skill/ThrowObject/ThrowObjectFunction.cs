using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;

public class ThrowObjectFunction : MonoBehaviour
{
    [SerializeField]
    private int throwAttack;
   
    float moveSpeed = 10f;
    string monsterTag = "Monster";
    const float judgeCollideDist = 0.5f;

    private Vector3 moveDir;
    private Vector3 lookDir;
    private GameObject targetMob;
    private SpriteRenderer dragSprite;

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
        dragSprite = GetComponent<SpriteRenderer>();

        SetMoveDir();
    }

    void Update()
    {
        MoveObject();
    }

    /// <summary>
    /// 움직이는 방향 설정
    /// </summary>
    void SetMoveDir()
    {
        if (targetMob != null)
            moveDir = (targetMob.transform.position - startPos).normalized;
        else moveDir = lookDir;

        if (moveDir == Vector3.right) dragSprite.flipX = true;
        else dragSprite.flipX = false;
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
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == monsterTag)
        {
            MonsterInfo mobInfo = collision.gameObject.GetComponent<MonsterInfo>();

            //미스 판정
            if (PlayerAttackCommon.IsAttackMiss(mobInfo.monsterLv, mobInfo.monsterAvoid))
            {
                PlayerAttackCommon.ShowMissAttackDamageAsSkin(mobInfo.gameObject, hitNum);
                return;
            }

            int hitDamage = CalDamage(mobInfo, throwAttack);
            //크리티컬 판정
            bool isCri = PlayerAttackCommon.IsCritical();
            if (isCri)
            {
                hitDamage = (hitDamage * PlayerManager.PlayerInstance.CriticalDamagee) / 100;//크리티컬 데미지 반영
            }

            mobInfo.DecreaseMonsterHP(hitDamage);

            //데미지 띄우기
            if (isCri)
            {
                PlayerAttackCommon.ShowCriticalDamageAsSkin(hitDamage, collision.gameObject, hitNum);
            }
            else
            {
                PlayerAttackCommon.ShowDamageAsSkin(hitDamage, collision.gameObject, hitNum);
            }

            //사운드
            SoundManager._sound.PlaySfx(16);

            //표창 오브젝트 비활성화
            gameObject.SetActive(false);
        }
    }
   
    /// <summary>
    /// 데미지 계산
    /// </summary>
    /// <returns></returns>
    int CalDamage(MonsterInfo mobInfo,int throwAttack)
    {
        //총 럭, 총 공격력
        int totalLUK = PlayerManager.PlayerInstance.PlayerLUK + PlayerManager.PlayerInstance.PlayerAddLUK;
        int totalAttackValue = throwAttack + PlayerManager.PlayerInstance.PlayerAttack;

        //데미지
        int maxDamage = totalAttackValue * skillCoefficient *(totalLUK*5)/ 10000;
        int minDamage = maxDamage/2;
        int damage = Random.Range(minDamage, maxDamage);

        //데미지 감소
        int diffLV = Mathf.Max(0, mobInfo.monsterLv - PlayerManager.PlayerInstance.PlayerLV);
        int decreaseDamage = (diffLV * damage)/100;
        damage = Mathf.Max(1, damage - decreaseDamage - mobInfo.monsterArmor);
        return damage;
    }
    /// <summary>
    /// 오브젝트 비활성화
    /// </summary>
    void DestroyObject()
    {
        gameObject.SetActive(false);
    }
}
