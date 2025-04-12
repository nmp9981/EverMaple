using UnityEngine;

public class Ladder : MonoBehaviour
{
    //Ÿ�� �ݶ��̴�
    [SerializeField]
    Collider2D tileCollider;
    //�÷��̾ ��ٸ��� Ÿ���ִ� ���ΰ�?
    public static bool isPlayerinLadder = false;
    //�÷��̾� �±�
    const string playerTag = "Player";

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
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), tileCollider, true);
        }
    }
}
