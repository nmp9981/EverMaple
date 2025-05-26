using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

//공격 범위
public enum AttackRange
{
    Near,
    Far,
    Count
}
public class SkillManager : MonoBehaviour
{
    GameObject player;
    PlayerInfoUI playerInfoUI;
    PlayerAttack playerAttack;
    ThrowObjectFulling throwObjectFulling;
    SkillEffectManager skillEffectManager;

    //캐릭터 크기
    Bounds playerBound = default;

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerBound = player.GetComponent<BoxCollider2D>().bounds;
        playerInfoUI = GameObject.Find("UserInfo").GetComponent<PlayerInfoUI>();
        playerAttack = player.GetComponent<PlayerAttack>();
        throwObjectFulling = GetComponent<ThrowObjectFulling>();
        skillEffectManager = GetComponent<SkillEffectManager>();
    }

    /// <summary>
    /// MP 소모
    /// </summary>
    public void DecreasePlayerMP(int spendMP)
    {
        PlayerManager.PlayerInstance.PlayerCurMP = Mathf.Max(0, PlayerManager.PlayerInstance.PlayerCurMP - spendMP);
        playerInfoUI.ShowPlayerMPBar();
    }
    /// <summary>
    /// HP 소모
    /// </summary>
    public void DecreasePlayerHP(int spendHP)
    {
        PlayerManager.PlayerInstance.PlayerCurHP = Mathf.Max(0, PlayerManager.PlayerInstance.PlayerCurHP - spendHP);
        playerInfoUI.ShowPlayerHPBar();
    }

    #region 공격 스킬
    //럭키 세븐
    public async UniTask LuckySeven(int hitNum)
    {
        //MP검사
        if (PlayerManager.PlayerInstance.PlayerCurMP < 16)
            return;

        //MP 소모
        DecreasePlayerMP(16);

        //공격 모션
        PlayerAnimation.AttackAnim();

        //쉐도우 파트너 적용
        if (PlayerManager.PlayerInstance.IsShadowPartner)
            hitNum *= 2;

        //이펙트
        skillEffectManager.PlaySkillAnimation("LuckySeven", 0.5f, 0);

        for (int i = 0; i < hitNum; i++)
        {
            ThrowObjectFunction throwObj = throwObjectFulling.MakeObj(0).GetComponent<ThrowObjectFunction>();
            throwObj.transform.position = player.transform.position + 0.5f * PlayerManager.PlayerInstance.PlayerLookDir;
            throwObj.startPos = throwObj.transform.position;
            throwObj.hitNum = i;

            if(i>=hitNum/2)
                throwObj.skillCoefficient = (SkillDamageCalCulate.LuckySevenCoff*SkillDamageCalCulate.ShadowPartnerCoff)/100;
            else
                throwObj.skillCoefficient = SkillDamageCalCulate.LuckySevenCoff;

            await UniTask.Delay(PlayerManager.PlayerInstance.PlayerAttackSpeed/4);
        }
    }
    //트리플 스로우
    public async UniTask TripleThrow(int hitNum)
    {
        //MP검사
        if (PlayerManager.PlayerInstance.PlayerCurMP < 20)
            return;

        //MP 소모
        DecreasePlayerMP(20);

        //공격 모션
        PlayerAnimation.AttackAnim();

        //쉐도우 파트너 적용
        if (PlayerManager.PlayerInstance.IsShadowPartner)
            hitNum *= 2;

        //이펙트
        skillEffectManager.PlaySkillAnimation("TripleThrow", 0.5f, 0);

        for (int i = 0; i < hitNum; i++)
        {
            ThrowObjectFunction throwObj = throwObjectFulling.MakeObj(0).GetComponent<ThrowObjectFunction>();
            throwObj.transform.position = player.transform.position + 0.5f * PlayerManager.PlayerInstance.PlayerLookDir;
            throwObj.startPos = throwObj.transform.position;
            throwObj.hitNum = i;

            if (i >= hitNum / 2)
                throwObj.skillCoefficient = (SkillDamageCalCulate.TripleThrowCoff * SkillDamageCalCulate.ShadowPartnerCoff) / 100;
            else
                throwObj.skillCoefficient = SkillDamageCalCulate.TripleThrowCoff;

            await UniTask.Delay(PlayerManager.PlayerInstance.PlayerAttackSpeed / 6);
        }
    }

    //더블 스텝
    public async UniTask DoubleStep(int hitNum)
    {
        //MP검사
        if (PlayerManager.PlayerInstance.PlayerCurMP < 14)
            return;

        //MP 소모
        DecreasePlayerMP(14);

        //공격 모션
        PlayerAnimation.AttackAnim();

        //공격 영역 크기
        float attackBoundSize = 3f;

        //플레이어가 바라보는 방향
        Vector3 lookDir = PlayerManager.PlayerInstance.PlayerLookDir;
        //공격 영역 세팅
        Bounds attackBound = playerAttack.SettingAttackArea(lookDir, attackBoundSize);

        //이펙트
        skillEffectManager.PlaySkillAnimation("DoubleStep", 0.5f, 0);

        //플레이어로부터 가장 가까이에 있는 몬스터 구하기
        GameObject nearMob = PlayerAttackCommon.NearMonserFromPlayer(lookDir, player.transform.position, attackBoundSize * 2);

        //몬스터가 없으면 아래 로직은 실행하지않고 중단
        if (nearMob == null)
        {
            return;
        }
       
        //몬스터가 캐릭터의 공격 반경 내에 있는가?
        Bounds nearMobArea = nearMob.GetComponent<Collider2D>().bounds;
        if (PlayerAttackCommon.IsMonsterInPlayerAttackArea(nearMobArea, attackBound))
        {
            for (int i = 1; i <= hitNum; i++)
            {
                PlayerAttackCommon.PlayerAttackToOneMonster(nearMob, SkillDamageCalCulate.DoubleStepCoff, i);
                await UniTask.Delay(PlayerManager.PlayerInstance.PlayerAttackSpeed / 5);
            }               
        }
    }
    //새비지 블로우
    public async UniTask Savageblow(int hitNum)
    {
        //MP검사
        if (PlayerManager.PlayerInstance.PlayerCurMP < 27)
            return;

        //MP 소모
        DecreasePlayerMP(27);

        //공격 모션
        PlayerAnimation.AttackAnim();

        //공격 영역 크기
        float attackBoundSize = 3f;

        //플레이어가 바라보는 방향
        Vector3 lookDir = PlayerManager.PlayerInstance.PlayerLookDir;
        //공격 영역 세팅
        Bounds attackBound = playerAttack.SettingAttackArea(lookDir, attackBoundSize);

        //이펙트
        skillEffectManager.PlaySkillAnimation("SavageBlow", 0.5f,0);

        //플레이어로부터 가장 가까이에 있는 몬스터 구하기
        GameObject nearMob = PlayerAttackCommon.NearMonserFromPlayer(lookDir, player.transform.position, attackBoundSize * 2);

        //몬스터가 없으면 아래 로직은 실행하지않고 중단
        if (nearMob == null)
        {
            return;
        }

        //몬스터가 캐릭터의 공격 반경 내에 있는가?
        Bounds nearMobArea = nearMob.GetComponent<Collider2D>().bounds;
        if (PlayerAttackCommon.IsMonsterInPlayerAttackArea(nearMobArea, attackBound))
        {
            for (int i = 1; i <= hitNum; i++)
            {
                PlayerAttackCommon.PlayerAttackToOneMonster(nearMob, SkillDamageCalCulate.SavageblowCoff, i);
                await UniTask.Delay(PlayerManager.PlayerInstance.PlayerAttackSpeed / 8);
            }
        }
    }
    //어벤져
    public async UniTask Avenger(int hitNum)
    {
        //MP검사
        if (PlayerManager.PlayerInstance.PlayerCurMP < 30)
            return;

        //MP 소모
        DecreasePlayerMP(30);

        //공격 모션
        PlayerAnimation.AttackAnim();

        //쉐도우 파트너 적용
        if (PlayerManager.PlayerInstance.IsShadowPartner)
            hitNum *= 2;

        //이펙트
        skillEffectManager.PlaySkillAnimation("Avenger", -0.5f, 0);

        for (int i = 0; i < hitNum; i++)
        {
            ThrowAvengerFunction throwObj = throwObjectFulling.MakeObj(10).GetComponent<ThrowAvengerFunction>();
            throwObj.transform.position = player.transform.position + 0.5f * PlayerManager.PlayerInstance.PlayerLookDir;
            throwObj.startPos = throwObj.transform.position;
            throwObj.hitNum = i;
            throwObj.skillCoefficient = SkillDamageCalCulate.AvengerCoff;

            if(i==0)
                throwObj.skillCoefficient = SkillDamageCalCulate.AvengerCoff;
            else
                throwObj.skillCoefficient = (SkillDamageCalCulate.AvengerCoff*SkillDamageCalCulate.ShadowPartnerCoff)/100;

            await UniTask.Delay(PlayerManager.PlayerInstance.PlayerAttackSpeed / 4);
        }
    }

    //부메랑 스텝
    public async UniTask BumerangStep(int hitNum)
    {
        //MP검사
        if (PlayerManager.PlayerInstance.PlayerCurMP < 26)
            return;

        //MP 소모
        DecreasePlayerMP(26);

        //공격 모션
        PlayerAnimation.AttackAnim();

        //이펙트
        skillEffectManager.PlaySkillAnimation("BumerangStep", 2f, 0);

        BumerangStepClass throwObj = throwObjectFulling.MakeObj(11).GetComponent<BumerangStepClass>();
        throwObj.transform.position = player.transform.position + 0.5f * PlayerManager.PlayerInstance.PlayerLookDir;
        throwObj.startPos = throwObj.transform.position;
        throwObj.skillCoefficient = SkillDamageCalCulate.BumerangStepCoff;
    }
    //시브즈
    public async UniTask Thieves()
    {
        //MP검사
        if (PlayerManager.PlayerInstance.PlayerCurMP < 25)
            return;

        //MP 소모
        DecreasePlayerMP(25);

        //공격 모션
        PlayerAnimation.AttackAnim();

        //공격 영역 크기
        float attackXSize = 16f;
        float attackYSize = 3f;

        //플레이어가 바라보는 방향
        Vector3 lookDir = PlayerManager.PlayerInstance.PlayerLookDir;

        //스킬 시작점
        Vector3 skillStartPos = player.transform.position - attackXSize * 0.5f * lookDir;

        //이펙트
        skillEffectManager.PlaySkillAnimation("Thivse", 0.01f, 0);

        //플레이어로부터 가장 가까이에 있는 몬스터들 구하기
        List<GameObject> nearMobList = PlayerAttackCommon.TargetMonstersFromPlayer(lookDir, skillStartPos, attackXSize, attackYSize, 5);

        //몬스터가 없으면 아래 로직은 실행하지않고 중단
        if (nearMobList == null)
        {
            return;
        }

        //몬스터들 공격
        foreach(var nearMob in nearMobList)
        {
            PlayerAttackCommon.PlayerAttackToOneMonster(nearMob, SkillDamageCalCulate.ThievesCoff, 0);
        }
    }
    //어썰터
    public async UniTask Assertor()
    {
        //MP검사
        if (PlayerManager.PlayerInstance.PlayerCurMP < 25)
            return;

        //MP 소모
        DecreasePlayerMP(25);

        //공격 모션
        PlayerAnimation.AttackAnim();

        //공격 영역 크기
        float attackBoundSize = 6f;

        //플레이어가 바라보는 방향
        Vector3 lookDir = PlayerManager.PlayerInstance.PlayerLookDir;
        //공격 영역 세팅
        Bounds attackBound = playerAttack.SettingAttackArea(lookDir, attackBoundSize);

        //이펙트
        skillEffectManager.PlaySkillAnimation("Assertor", 0.5f, 0);

        //플레이어로부터 가장 가까이에 있는 몬스터 구하기
        GameObject nearMob = PlayerAttackCommon.NearMonserFromPlayer(lookDir, player.transform.position, attackBoundSize * 2);

        //몬스터가 없으면 아래 로직은 실행하지않고 중단
        if (nearMob == null)
        {
            return;
        }

        //벽을 넘으면 안됨
        RaycastHit2D hit = Physics2D.Raycast(
            new Vector2(player.transform.position.x, player.transform.position.y), 
            new Vector2(lookDir.x, lookDir.y), attackBoundSize*1.5f,1<<12);
        if (hit.collider)
        {
            return;
        }

        //몬스터가 캐릭터의 공격 반경 내에 있는가?
        Bounds nearMobArea = nearMob.GetComponent<Collider2D>().bounds;
        if (PlayerAttackCommon.IsMonsterInPlayerAttackArea(nearMobArea, attackBound))
        {
            player.transform.position = new Vector3(player.transform.position.x + attackBoundSize * lookDir.x, nearMobArea.center.y+0.1f, 0);
            PlayerAttackCommon.PlayerAttackToOneMonster(nearMob, SkillDamageCalCulate.AssertorCoff, 0);
        }
    }
    #endregion

    #region 버프 스킬
    public void UseHasteSkill()
    {
        //MP검사
        if (PlayerManager.PlayerInstance.PlayerCurMP < 30)
            return;

        //MP 소모
        DecreasePlayerMP(30);

        //버프 시전
        if (ItemManager.itemInstance.buffItemList[10].activeSelf)
            ItemManager.itemInstance.buffItemList[10].SetActive(false);
        ItemManager.itemInstance.buffItemList[10].SetActive(true);
    }

    public void UseJavelinBoosterSkill()
    {
        //HP, MP검사
        if (PlayerManager.PlayerInstance.PlayerCurMP < 10 || PlayerManager.PlayerInstance.PlayerCurHP <= 10)
            return;

        //HP, MP 소모
        DecreasePlayerHP(10);
        DecreasePlayerMP(10);

        //버프 시전
        if (ItemManager.itemInstance.buffItemList[11].activeSelf)
            ItemManager.itemInstance.buffItemList[11].SetActive(false);
        ItemManager.itemInstance.buffItemList[11].SetActive(true);
    }
    public void UseDagerBoosterSkill()
    {
        //HP, MP검사
        if (PlayerManager.PlayerInstance.PlayerCurMP < 10 || PlayerManager.PlayerInstance.PlayerCurHP <= 10)
            return;

        //HP, MP 소모
        DecreasePlayerHP(10);
        DecreasePlayerMP(10);

        //버프 시전
        if (ItemManager.itemInstance.buffItemList[12].activeSelf)
            ItemManager.itemInstance.buffItemList[12].SetActive(false);
        ItemManager.itemInstance.buffItemList[12].SetActive(true);
    }
    public void UseShadowPartnerSkill()
    {
        //MP검사
        if (PlayerManager.PlayerInstance.PlayerCurMP < 55)
            return;

        //MP 소모
        DecreasePlayerMP(55);

        //버프 시전
        if (ItemManager.itemInstance.buffItemList[13].activeSelf)
            ItemManager.itemInstance.buffItemList[13].SetActive(false);
        ItemManager.itemInstance.buffItemList[13].SetActive(true);
    }
    public void UseMesoUPSkill()
    {
        //MP검사
        if (PlayerManager.PlayerInstance.PlayerCurMP < 60)
            return;

        //MP 소모
        DecreasePlayerMP(60);

        //버프 시전
        if (ItemManager.itemInstance.buffItemList[14].activeSelf)
            ItemManager.itemInstance.buffItemList[14].SetActive(false);
        ItemManager.itemInstance.buffItemList[14].SetActive(true);
    }
    public void UseMesoGuardSkill()
    {
        //MP검사
        if (PlayerManager.PlayerInstance.PlayerCurMP < 35)
            return;

        //MP 소모
        DecreasePlayerMP(35);

        //버프 시전
        if (ItemManager.itemInstance.buffItemList[15].activeSelf)
            ItemManager.itemInstance.buffItemList[15].SetActive(false);
        ItemManager.itemInstance.buffItemList[15].SetActive(true);
    }
    public void UseMapleWarriorSkill()
    {
        //MP검사
        if (PlayerManager.PlayerInstance.PlayerCurMP < 50)
            return;

        //MP 소모
        DecreasePlayerMP(50);

        //버프 시전
        if (ItemManager.itemInstance.buffItemList[16].activeSelf)
            ItemManager.itemInstance.buffItemList[16].SetActive(false);
        ItemManager.itemInstance.buffItemList[16].SetActive(true);
    }
    #endregion
}
