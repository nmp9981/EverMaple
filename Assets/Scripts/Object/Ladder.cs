using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField]
    GameObject playerObject;

    //��ٸ� ����
    Bounds ladderBound = default;

    //Ÿ�� �ݶ��̴�
    [SerializeField]
    Collider2D tileCollider;
    //�÷��̾ ��ٸ��� Ÿ���ִ� ���ΰ�?
    public static bool isPlayerinLadder = false;
    //�÷��̾� �±�
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
    /// ��ٸ� ������ ���������ٸ� ���÷� ���ƿ�
    /// ��ٸ��� �÷��� �������µ� �������
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
    /// �÷��̾ ��ٸ��� �ӹ��� ���� ĳ���Ϳ� ������ ���� ���� ���ϰ� ���´�
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
