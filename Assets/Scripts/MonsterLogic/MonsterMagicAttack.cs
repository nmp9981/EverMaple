using UnityEngine;

public class MonsterMagicAttack : MonoBehaviour
{
    string playerTag = "Player";

    private Vector3 moveDir;
    private GameObject targetPlayer;
    private PlayerHit playerHit;

    float moveDist = 0;
    float destroyDist = 15;

    //양방향 공격 여부
    public bool isSide;
    public int sideValue = 1;

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
        transform.position += moveDir * moveSpeed * Time.deltaTime*sideValue;//이동
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
            //미스 판정
            if (PlayerAttackCommon.IsHitMiss(80))
                PlayerAttackCommon.ShowMissHitDamageAsSkin(targetPlayer);
            else
            {
                //피격
                int hitDamage = CalDamage();
                playerHit.DecreasePlayerHP(hitDamage);

                //데미지 띄우기
                PlayerAttackCommon.ShowDamageAsSkin(hitDamage, targetPlayer);
            }

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
        int maxDamage = (MobAttack*105) / 100;
        int minDamage = (maxDamage * 95) / 100;
        int damage = Random.Range(minDamage, maxDamage);

        damage = Mathf.Max(1, damage - PlayerManager.PlayerInstance.PlayerMagicArmor - PlayerManager.PlayerInstance.PlayerStatMagicArmor);

        //피격데미지 감소 - 메소가드
        if (PlayerManager.PlayerInstance.IsActiveMesoGuard)
        {
            //메소 소비량
            int spendMeso = (damage * PlayerManager.PlayerInstance.RateArmorMeso) / 100;
            if (PlayerManager.PlayerInstance.PlayerMeso >= spendMeso)
            {
                PlayerManager.PlayerInstance.PlayerMeso -= spendMeso;
                damage = Mathf.Max(1,damage / 2);
            }
        }
        
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
