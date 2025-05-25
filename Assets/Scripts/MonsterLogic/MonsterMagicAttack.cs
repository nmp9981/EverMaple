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

        //�����̴� ���� ����
        moveDir = targetPlayer.transform.position-startPos;
        moveDir.y = 0;
    }

    void Update()
    {
        MoveObject();
    }

    /// <summary>
    /// ������Ʈ �̵�
    /// </summary>
    void MoveObject()
    {
        transform.position += moveDir * moveSpeed * Time.deltaTime;//�̵�
        moveDist += moveSpeed * Time.deltaTime;//�� �̵��Ÿ�

        //��Ÿ� ������ ��Ȱ��ȭ
        if (moveDist > destroyDist)
        {
            moveDist = 0;
            DestroyObject();
        }
    }

    /// <summary>
    /// ���� ����
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            //�ǰ�
            int hitDamage = CalDamage();
            playerHit.DecreasePlayerHP(hitDamage);

            //������ ����
            PlayerAttackCommon.ShowDamageAsSkin(hitDamage, targetPlayer);

            //����ü �ı�
            DestroyObject();
        }
    }

    /// <summary>
    /// ������ ���
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
    /// ������Ʈ ��Ȱ��ȭ
    /// </summary>
    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
