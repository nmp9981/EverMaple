using UnityEngine;
using UnityEngine.LowLevel;

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
    //스프라이트
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        playerBound = GetComponent<BoxCollider2D>().bounds;
        spriteRenderer = GetComponent<SpriteRenderer>();

        PlayerManager.PlayerInstance.PlayerStatAttack = 40;
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

        //공격 영역 크기
        float attackBoundSize = 3f;

        //플레이어가 바라보는 방향
        Vector3 lookDir = PlayerManager.PlayerInstance.PlayerLookDir;
        //공격 영역 세팅
        attackBound = SettingAttackArea(lookDir, attackBoundSize);

        //효과음
        SoundManager._sound.PlaySfx(0);

        //플레이어로부터 가장 가까이에 있는 몬스터 구하기
        GameObject nearMob = PlayerAttackCommon.NearMonserFromPlayer(lookDir ,gameObject.transform.position,attackBoundSize*2);
       
        //몬스터가 없으면 아래 로직은 실행하지않고 중단
        if (nearMob == null)
        {
            return;
        }
       
        //몬스터가 캐릭터의 공격 반경 내에 있는가?
        Bounds nearMobArea= nearMob.GetComponent<Collider2D>().bounds;
        if (PlayerAttackCommon.IsMonsterInPlayerAttackArea(nearMobArea, attackBound))
        {
            PlayerAttackCommon.PlayerAttackToOneMonster(nearMob,100,1);
            if(PlayerManager.PlayerInstance.IsShadowPartner)
                PlayerAttackCommon.PlayerAttackToOneMonster(nearMob, SkillDamageCalCulate.ShadowPartnerCoff, 2);
        }
    }

    /// <summary>
    ///  공격영역 세팅 : 사각박스 사용
    /// </summary>
    /// <param name="dir">캐릭터가 바라보는 방향</param>
    /// <returns></returns>
    public Bounds SettingAttackArea(Vector3 dir, float attackBoundSize)
    {
        Bounds bounds = new Bounds();
        //캐릭터가 바라보는 방향에따라 박스 위치가 달라짐
        bounds.center = gameObject.transform.position + dir * 0.5f;
        bounds.size = playerBound.size* attackBoundSize;
        return bounds;
    }

    /// <summary>
    /// 시간 흐름
    /// </summary>
    void TimeFlow()
    {
        curAttackTime += Time.deltaTime;
    }
}
