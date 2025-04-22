using UnityEngine;
using UnityEngine.LowLevel;

public class PlayerAttack : MonoBehaviour
{
    //상수
    const float maxDist = 999f;

    //공격 영역 크기
    float attackBoundSize = 3f;

    //쿨타임
    float curAttackTime = 0;
    float coolAttackTime = 1f;

    //캐릭터 크기
    Bounds playerBound = default;
    //공격영역 바운드
    Bounds attackBound = default;
    //스프라이트
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        playerBound = GetComponent<BoxCollider2D>().bounds;
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        //쿨타임 초기화
        curAttackTime = 0;

        //공격 모션
        PlayerAnimation.AttackAnim();

        //플레이어가 바라보는 방향
        Vector3 lookDir = PlayerManager.PlayerInstance.PlayerLookDir;
        //공격 영역 세팅
        attackBound = SettingAttackArea(lookDir);

        //플레이어로부터 가장 가까이에 있는 몬스터 구하기
        GameObject nearMob = PlayerAttackCommon.NearMonserFromPlayer(lookDir ,gameObject.transform.position,attackBoundSize*2);
       
        //몬스터가 없으면 아래 로직은 실행하지않고 중단
        if (nearMob == null)
        {
            return;
        }
       
        //몬스터가 캐릭터의 공격 반경 내에 있는가?
        Bounds nearMobArea= nearMob.GetComponent<Collider2D>().bounds;
        if (IsMonsterInPlayerAttackArea(nearMobArea, attackBound))
        {
            PlayerAttackToMonster(nearMob);
        }
    }

    /// <summary>
    ///  공격영역 세팅 : 사각박스 사용
    /// </summary>
    /// <param name="dir">캐릭터가 바라보는 방향</param>
    /// <returns></returns>
    Bounds SettingAttackArea(Vector3 dir)
    {
        Bounds bounds = new Bounds();
        //캐릭터가 바라보는 방향에따라 박스 위치가 달라짐
        bounds.center = gameObject.transform.position + dir * 0.5f;
        bounds.size = playerBound.size* attackBoundSize;
        return bounds;
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
    /// 실제 공격
    /// </summary>
    void PlayerAttackToMonster(GameObject nearMob)
    {
        //공격 모션과 데미지
        int attackPower = PlayerManager.PlayerInstance.PlayerAttack;
        int minAttackDamage = (attackPower * PlayerManager.PlayerInstance.Workmanship) / 100;
        int attackDamage = Random.Range(minAttackDamage, attackPower);

        //크리티컬 판정
        bool isCri = PlayerAttackCommon.IsCritical();
        if (isCri)
        {
            attackDamage *= 2;//크리티컬 데미지 반영
        }
       
        //몬스터 HP감소
        nearMob.GetComponent<MonsterInfo>().DecreaseMonsterHP(attackDamage);

        //데미지 띄우기(기본 공격은 1회 타격)
        if (isCri)
        {
            PlayerAttackCommon.ShowCriticalDamageAsSkin(attackDamage, nearMob, 1);
        }
        else
        {
            PlayerAttackCommon.ShowDamageAsSkin(attackDamage, nearMob, 1);
        }
    }

    /// <summary>
    /// 시간 흐름
    /// </summary>
    void TimeFlow()
    {
        curAttackTime += Time.deltaTime;
    }
}
