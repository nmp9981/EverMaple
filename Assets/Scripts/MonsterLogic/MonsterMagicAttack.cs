using UnityEngine;

public class MonsterMagicAttack : MonoBehaviour
{
    string playerTag = "Player";

    private Vector3 moveDir;
    private GameObject targetPlayer;
    private PlayerHit playerHit;

    float moveDist = 0;
    float destroyDist = 15;

    public float moveSpeed = 2f;
    public int MobAttack;
    public float marginYPos;
    public Vector3 startPos { get; set; }
   
    private void OnEnable()
    {
        targetPlayer = GameObject.Find("Player");
        playerHit = targetPlayer.GetComponent<PlayerHit>();
        moveDist = 0;

        //움직이는 방향 설정
        moveDir = targetPlayer.transform.position-startPos;
        moveDir.y = 0;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            //피격
            int hitDamage = CalDamage();
            playerHit.DecreasePlayerHP(hitDamage);

            //데미지 띄우기
            PlayerAttackCommon.ShowDamageAsSkin(hitDamage, targetPlayer);

            //투사체 파괴
            DestroyObject();
        }
    }

    /// <summary>
    /// 데미지 계산
    /// </summary>
    /// <returns></returns>
    int CalDamage()
    {
        int maxDamage = (MobAttack*110) / 100;
        int minDamage = (maxDamage * 90) / 100;
        int damage = Random.Range(minDamage, maxDamage);
        return damage;
    }
    /// <summary>
    /// 오브젝트 비활성화
    /// </summary>
    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
