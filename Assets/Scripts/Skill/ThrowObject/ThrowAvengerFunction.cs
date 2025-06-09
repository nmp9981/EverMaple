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
    /// ������Ʈ �̵�
    /// </summary>
    void MoveObject()
    {
        moveDir = lookDir;//�����̴� ���� ����
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == monsterTag)
        {
            MonsterInfo mobInfo = collision.gameObject.GetComponent<MonsterInfo>();
            int hitDamage = CalDamage(mobInfo);
            //ũ��Ƽ�� ����
            bool isCri = PlayerAttackCommon.IsCritical();
            if (isCri)
            {
                hitDamage = (hitDamage*PlayerManager.PlayerInstance.CriticalDamagee)/100;//ũ��Ƽ�� ������ �ݿ�
            }

            mobInfo.DecreaseMonsterHP(hitDamage);

            //������ ����
            if (isCri)
            {
                PlayerAttackCommon.ShowCriticalDamageAsSkin(hitDamage, collision.gameObject, hitNum);
            }
            else
            {
                PlayerAttackCommon.ShowDamageAsSkin(hitDamage, collision.gameObject, hitNum);
            }

            restCount -= 1;

            //�ִ� Ÿ�����ŭ ����
            if (restCount == 0)
                DestroyObject();
        }
    }

    /// <summary>
    /// ������ ���
    /// </summary>
    /// <returns></returns>
    int CalDamage(MonsterInfo mobInfo)
    {
        int maxDamage = (PlayerManager.PlayerInstance.PlayerStatAttack * skillCoefficient)/100;
        int minDamage = (maxDamage * PlayerManager.PlayerInstance.Workmanship)/100;
        int damage = Random.Range(minDamage, maxDamage);

        //������ ����
        int diffLV = Mathf.Max(0, mobInfo.monsterLv - PlayerManager.PlayerInstance.PlayerLV);
        int decreaseDamage = (diffLV * damage) / 100;
        damage = damage - decreaseDamage;
        return damage;
    }
    /// <summary>
    /// ������Ʈ ��Ȱ��ȭ
    /// </summary>
    void DestroyObject()
    {
        gameObject.SetActive(false);
    }
}
