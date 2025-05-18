using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class BumerangStepClass : MonoBehaviour
{
    int restCount;
    float moveSpeed = 30f;
    int hitNum = 0;
    string monsterTag = "Monster";

    private Vector3 moveDir;
    private Vector3 lookDir;
   
    float moveDist = 0;
    float destroyDist = 10;

    //Ÿ�ݵ� ���͵�
    private List<GameObject> hitMonters = new List<GameObject>();

    public int skillCoefficient { get; set; }
    public Vector3 startPos { get; set; }

    private void OnEnable()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        moveDist = 0;
        hitNum = 0;
        restCount = 4;
        lookDir = PlayerManager.PlayerInstance.PlayerLookDir;
        hitMonters.Clear();
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
        moveDir = lookDir * (hitNum==0?1:-1);//�����̴� ���� ����
        transform.position += moveDir * moveSpeed * Time.deltaTime;//�̵�
        moveDist += moveSpeed * Time.deltaTime;//�� �̵��Ÿ�

        //��Ÿ� ������ ��Ȱ��ȭ
        if (moveDist > destroyDist)
        {
            moveDist = 0;
            if (hitNum == 0)
            {
                hitNum = 1;
                ReturnBumerang();
            }
            else
                DestroyObject();
        }
    }

    /// <summary>
    /// ���� ����
    /// </summary>
    /// <param name="collision"></param>
    private async void OnTriggerEnter2D(Collider2D collision)
    {
        //���ƿö��� �Ʒ� ������ �������� ����
        if (hitNum != 0)
            return;

        if (collision.tag == monsterTag)
        {
            int hitDamage = CalDamage();
            //ũ��Ƽ�� ����
            bool isCri = PlayerAttackCommon.IsCritical();
            if (isCri)
            {
                hitDamage = (hitDamage * PlayerManager.PlayerInstance.CriticalDamagee) / 100;//ũ��Ƽ�� ������ �ݿ�
            }

            collision.gameObject.GetComponent<MonsterInfo>().DecreaseMonsterHP(hitDamage);

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
            
            //�ִ� Ÿ�� ����ŭ ����
            if (restCount == 0)
            {
                //�ڽ� �ݶ��̴� ��Ȱ��ȭ
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }else
                hitMonters.Add(collision.gameObject);
        }
    }
    /// <summary>
    /// �θ޶� ���� �ǵ��ƿö�
    /// </summary>
    /// <returns></returns>
    async UniTask ReturnBumerang()
    {
        for(int i = hitMonters.Count - 1; i >= 0; i--)
        {
            int hitDamage = CalDamage();
            //ũ��Ƽ�� ����
            bool isCri = PlayerAttackCommon.IsCritical();
            if (isCri)
            {
                hitDamage = (hitDamage * PlayerManager.PlayerInstance.CriticalDamagee) / 100;//ũ��Ƽ�� ������ �ݿ�
            }

            hitMonters[i].GetComponent<MonsterInfo>().DecreaseMonsterHP(hitDamage);

            //������ ����
            if (isCri)
            {
                PlayerAttackCommon.ShowCriticalDamageAsSkin(hitDamage, hitMonters[i], hitNum);
            }
            else
            {
                PlayerAttackCommon.ShowDamageAsSkin(hitDamage, hitMonters[i], hitNum);
            }
        }
    }

    /// <summary>
    /// ������ ���
    /// </summary>
    /// <returns></returns>
    int CalDamage()
    {
        int maxDamage = (PlayerManager.PlayerInstance.PlayerAttack * skillCoefficient) / 100;
        int minDamage = (maxDamage * PlayerManager.PlayerInstance.Workmanship) / 100;
        int damage = Random.Range(minDamage, maxDamage);
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
