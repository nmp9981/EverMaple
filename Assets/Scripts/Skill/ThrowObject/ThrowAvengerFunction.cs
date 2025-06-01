using Unity.VisualScripting;
using UnityEngine;

public class ThrowAvengerFunction : MonoBehaviour
{
    int restCount;
    float moveSpeed = 10f;
    string monsterTag = "Monster";

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
        restCount = 6;
        destroyDist = PlayerManager.PlayerInstance.ThrowObjectMaxDist;
        lookDir = PlayerManager.PlayerInstance.PlayerLookDir;
        targetMob = PlayerAttackCommon.NearMonserFromPlayer(lookDir, startPos, destroyDist);
    }

    void Update()
    {
        MoveObject();
    }

    /// <summary>
    /// 오브젝트 이동
    /// </summary>
    void MoveObject()
    {
        moveDir = lookDir;//움직이는 방향 설정
        transform.position += moveDir * moveSpeed * Time.deltaTime;//이동
        moveDist += moveSpeed * Time.deltaTime;//총 이동거리

        //사거리 넘으면 비활성화
        if (moveDist > destroyDist)
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
        if(collision.tag == monsterTag)
        {
            int hitDamage = CalDamage();
            //크리티컬 판정
            bool isCri = PlayerAttackCommon.IsCritical();
            if (isCri)
            {
                hitDamage = (hitDamage*PlayerManager.PlayerInstance.CriticalDamagee)/100;//크리티컬 데미지 반영
            }

            collision.gameObject.GetComponent<MonsterInfo>().DecreaseMonsterHP(hitDamage);

            //데미지 띄우기
            if (isCri)
            {
                PlayerAttackCommon.ShowCriticalDamageAsSkin(hitDamage, collision.gameObject, hitNum);
            }
            else
            {
                PlayerAttackCommon.ShowDamageAsSkin(hitDamage, collision.gameObject, hitNum);
            }

            restCount -= 1;

            //최대 타깃수만큼 공격
            if (restCount == 0)
                DestroyObject();
        }
    }

    /// <summary>
    /// 데미지 계산
    /// </summary>
    /// <returns></returns>
    int CalDamage()
    {
        int maxDamage = (PlayerManager.PlayerInstance.PlayerStatAttack * skillCoefficient)/100;
        int minDamage = (maxDamage * PlayerManager.PlayerInstance.Workmanship)/100;
        int damage = Random.Range(minDamage, maxDamage);
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
