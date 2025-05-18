using Cysharp.Threading.Tasks;
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

    //캐릭터 크기
    Bounds playerBound = default;

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerBound = player.GetComponent<BoxCollider2D>().bounds;
        playerInfoUI = GameObject.Find("UserInfo").GetComponent<PlayerInfoUI>();
        playerAttack = player.GetComponent<PlayerAttack>();
        throwObjectFulling = GetComponent<ThrowObjectFulling>();
    }

    /// <summary>
    /// MP 소모
    /// </summary>
    private void DecreasePlayerMP(int spendMP)
    {
        PlayerManager.PlayerInstance.PlayerCurMP = Mathf.Max(0, PlayerManager.PlayerInstance.PlayerCurMP - spendMP);
        playerInfoUI.ShowPlayerMPBar();
    }
   
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

        for (int i = 0; i < hitNum; i++)
        {
            ThrowObjectFunction throwObj = throwObjectFulling.MakeObj(0).GetComponent<ThrowObjectFunction>();
            throwObj.transform.position = player.transform.position + 0.5f * PlayerManager.PlayerInstance.PlayerLookDir;
            throwObj.startPos = throwObj.transform.position;
            throwObj.hitNum = i;
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

        for (int i = 0; i < hitNum; i++)
        {
            ThrowObjectFunction throwObj = throwObjectFulling.MakeObj(0).GetComponent<ThrowObjectFunction>();
            throwObj.transform.position = player.transform.position + 0.5f * PlayerManager.PlayerInstance.PlayerLookDir;
            throwObj.startPos = throwObj.transform.position;
            throwObj.hitNum = i;
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
    public async UniTask Avenger()
    {
        //MP검사
        if (PlayerManager.PlayerInstance.PlayerCurMP < 30)
            return;

        //MP 소모
        DecreasePlayerMP(30);

        //공격 모션
        PlayerAnimation.AttackAnim();

        ThrowAvengerFunction throwObj = throwObjectFulling.MakeObj(10).GetComponent<ThrowAvengerFunction>();
        throwObj.transform.position = player.transform.position + 0.5f * PlayerManager.PlayerInstance.PlayerLookDir;
        throwObj.startPos = throwObj.transform.position;
        throwObj.hitNum = 0;
        throwObj.skillCoefficient = SkillDamageCalCulate.AvengerCoff;
    }

    public async UniTask BumerangStep(int hitNum)
    {
        //MP검사
        if (PlayerManager.PlayerInstance.PlayerCurMP < 26)
            return;

        //MP 소모
        DecreasePlayerMP(26);

        //공격 모션
        PlayerAnimation.AttackAnim();

        for (int i = 0; i < hitNum; i++)
        {
            ThrowObjectFunction throwObj = throwObjectFulling.MakeObj(0).GetComponent<ThrowObjectFunction>();
            throwObj.transform.position = player.transform.position + 0.5f * PlayerManager.PlayerInstance.PlayerLookDir;
            throwObj.startPos = throwObj.transform.position;
            throwObj.hitNum = i;
            throwObj.skillCoefficient = SkillDamageCalCulate.TripleThrowCoff;

            await UniTask.Delay(PlayerManager.PlayerInstance.PlayerAttackSpeed / 6);
        }
    }
}
