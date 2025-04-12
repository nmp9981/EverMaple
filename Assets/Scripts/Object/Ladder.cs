using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField]
    GameObject playerObject;

    //사다리 영역
    Bounds ladderBound = default;

    //타일 콜라이더
    [SerializeField]
    Collider2D tileCollider;
    //플레이어가 사다리를 타고있는 중인가?
    public static bool isPlayerinLadder = false;
    //플레이어 태그
    const string playerTag = "Player";
    
    private void Awake()
    {
       ladderBound = this.gameObject.GetComponent<Collider2D>().bounds;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            isPlayerinLadder = true;
        }
    }
    /// <summary>
    /// 사다리 영역을 빠져나간다면 평상시로 돌아옴
    /// 사다리와 플랫폼 간섭상태도 원래대로
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            isPlayerinLadder = false;
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), tileCollider, false);
        }
    }

    /// <summary>
    /// 플레이어가 사다리에 머무는 동안 캐릭터와 지형이 서로 간섭 못하게 막는다
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            Debug.Log("2u49490");
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), tileCollider, true);
        }
    }
}
