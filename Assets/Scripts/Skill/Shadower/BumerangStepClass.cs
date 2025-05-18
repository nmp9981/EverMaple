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

    //타격된 몬스터들
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
    /// 오브젝트 이동
    /// </summary>
    void MoveObject()
    {
        moveDir = lookDir * (hitNum==0?1:-1);//움직이는 방향 설정
        transform.position += moveDir * moveSpeed * Time.deltaTime;//이동
        moveDist += moveSpeed * Time.deltaTime;//총 이동거리

        //사거리 넘으면 비활성화
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
    /// 공격 명중
    /// </summary>
    /// <param name="collision"></param>
    private async void OnTriggerEnter2D(Collider2D collision)
    {
        //돌아올때는 아래 로직을 적용하지 않음
        if (hitNum != 0)
            return;

        if (collision.tag == monsterTag)
        {
            int hitDamage = CalDamage();
            //크리티컬 판정
            bool isCri = PlayerAttackCommon.IsCritical();
            if (isCri)
            {
                hitDamage = (hitDamage * PlayerManager.PlayerInstance.CriticalDamagee) / 100;//크리티컬 데미지 반영
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
            
            //최대 타깃 수만큼 공격
            if (restCount == 0)
            {
                //박스 콜라이더 비활성화
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }else
                hitMonters.Add(collision.gameObject);
        }
    }
    /// <summary>
    /// 부메랑 스텝 되돌아올때
    /// </summary>
    /// <returns></returns>
    async UniTask ReturnBumerang()
    {
        for(int i = hitMonters.Count - 1; i >= 0; i--)
        {
            int hitDamage = CalDamage();
            //크리티컬 판정
            bool isCri = PlayerAttackCommon.IsCritical();
            if (isCri)
            {
                hitDamage = (hitDamage * PlayerManager.PlayerInstance.CriticalDamagee) / 100;//크리티컬 데미지 반영
            }

            hitMonters[i].GetComponent<MonsterInfo>().DecreaseMonsterHP(hitDamage);

            //데미지 띄우기
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
    /// 데미지 계산
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
    /// 오브젝트 비활성화
    /// </summary>
    void DestroyObject()
    {
        gameObject.SetActive(false);
    }
}
