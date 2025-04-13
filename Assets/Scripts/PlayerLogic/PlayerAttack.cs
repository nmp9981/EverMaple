using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //상수
    const float maxDist = 999f;

    //쿨타임
    float curAttackTime = 0;
    float coolAttackTime = 1f;

    //캐릭터 크기
    Bounds playerBound = default;
    //공격영역 바운드
    Bounds attackBound = default;

    private void Awake()
    {
        playerBound = GetComponent<BoxCollider2D>().bounds;
    }

    void Update()
    {
        TimeFlow();
    }
    /// <summary>
    /// 기본 공격 플로우
    /// </summary>
    public void BasicAttackFlow()
    {
        //아직 쿨타임이 안됨
        if(curAttackTime < coolAttackTime)
        {
            return;
        }
        //공격 영역 세팅
        attackBound = SettingAttackArea();

        //플레이어로부터 가장 가까이에 있는 몬스터 구하기
        GameObject nearMob = NearMonserFromPlayer(attackBound.center);

        //몬스터가 없으면 아래 로직은 실행하지않고 중단
        if (nearMob == null)
        {
            return;
        }

        //몬스터가 캐릭터의 공격 반경 내에 있는가?
        Bounds nearMobArea= nearMob.GetComponent<Collider2D>().bounds;
        if (IsMonsterInPlayerAttackArea(nearMobArea, attackBound))
        {
            //공격 모션과 데미지
            int attackPower = PlayerManager.PlayerInstance.PlayerAttack;
            int minAttackDamage = (attackPower * PlayerManager.PlayerInstance.Workmanship) / 100;
            int attackDamage = Random.Range(minAttackDamage, attackPower);
            //데미지 띄우기(기본 공격은 1회 타격)
            ShowDamageAsSkin(attackDamage, nearMob,1);
            //몬스터 HP감소
            DecreaseMonsterHP(nearMob,attackDamage);
        }
    }

    /// <summary>
    /// 공격영역 세팅 : 사각박스 사용
    /// </summary>
    Bounds SettingAttackArea()
    {
        Bounds bounds = new Bounds();
        bounds.center = playerBound.center + Vector3.left * 0.5f;
        bounds.size = playerBound.size;
        return bounds;
    }

    /// <summary>
    /// 플레이어로부터 가장 가까운 몬스터 반환
    /// </summary>
    GameObject NearMonserFromPlayer(Vector3 center)
    {
        GameObject nearMob = null;
        float dist = maxDist;
        foreach(var mob in MonsterSpawn.activeMonster)
        {
            float curDist = Mathf.Abs(mob.transform.position.x - gameObject.transform.position.x);
            //더 가까운 거리
            if (curDist < dist)
            {
                dist = curDist;
                nearMob = mob;
            }
        }
        return nearMob;
    }

    /// <summary>
    /// 몬스터가 캐릭터의 공격 반경 내에 있는가?
    /// AABB충돌 검출 방식 사용
    /// </summary>
    /// <returns></returns>
    bool IsMonsterInPlayerAttackArea(Bounds monsterArea, Bounds playerArea)
    {
        Vector3 maxMob = monsterArea.max;
        Vector3 minMob = monsterArea.min;
        Vector3 maxPlayer = playerArea.max;
        Vector3 minPlayer = playerArea.min;

        //2D이므로 x,y좌표만 비교
        bool isXCollide = false;
        bool isYCollide = false;
        
        //충돌 검사
        if (maxMob.x > minPlayer.x && minMob.x < maxPlayer.x)
        {
            isXCollide = true;
        }
        if (maxMob.y > minPlayer.y && minMob.y < maxPlayer.y)
        {
            isYCollide = true;
        }

        //충돌함
        if (isXCollide && isYCollide)
        {
            return true;
        }
        //충돌안함
        return false;
    }

    /// <summary>
    /// 몬스터 HP감소
    /// </summary>
    void DecreaseMonsterHP(GameObject targetMonster, int playerAttackDamage)
    {
        targetMonster.GetComponent<MonsterInfo>().monsterCurHP -=playerAttackDamage;
    }

    /// <summary>
    /// 피격 데미지 보이기
    /// </summary>
    /// <param name="Damage">데미지</param>
    /// <param name="playerPos">플레이어 위치</param>
    void ShowDamageAsSkin(int Damage, GameObject monsterPos, int hitNum)
    {
        string damageString = Damage.ToString();
        float damageLength = DamageObjectFulling.DamageSkinInstance.hitDamageImage[0].bounds.size.x * damageString.Length;
        Bounds bounds = monsterPos.GetComponent<BoxCollider2D>().bounds;
        Vector3 damageStartPos = bounds.center +hitNum* Vector3.up * (bounds.size.y * 0.5f + 0.5f) + damageLength * Vector3.left * 0.25f;

        for (int i = 0; i < damageString.Length; i++)
        {
            GameObject damImg = DamageObjectFulling.DamageSkinInstance.MakeObj((damageString[i] - '0'));
            damImg.transform.position = damageStartPos + Vector3.right * DamageObjectFulling.DamageSkinInstance.hitDamageImage[0].bounds.size.x * i * 1.5f;
        }
        InputKeyManager.orderSortNum += 1;
    }

    /// <summary>
    /// 시간 흐름
    /// </summary>
    void TimeFlow()
    {
        curAttackTime += Time.deltaTime;
    }
}
