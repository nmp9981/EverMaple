using UnityEngine;

public class BuffSkill
{
    public int hasteLv = 20;
    public int boosterLv = 20;
    public int shadowPartnerLv = 30;
    public int mesoUpLv = 20;
    public int mesoGuardLv = 20;
    public int mapleWarriorLv = 20;

    /// <summary>
    /// 버프 스킬 업그레이드
    /// </summary>
    /// <param name="skillName"></param>
    /// <param name="skillLv"></param>
    public void BuffSkillLevelUP(string skillName, int skillLv)
    {
        switch (skillName)
        {
            case "헤이스트":
                hasteLv = skillLv;
                break;
            case "자벨린 부스터":
                boosterLv = skillLv;
                break;
            case "대거 부스터":
                boosterLv = skillLv;
                break;
            case "쉐도우파트너":
                shadowPartnerLv = skillLv;
                break;
            case "메소업":
                mesoUpLv = skillLv;
                break;
            case "메소가드":
                mesoGuardLv = skillLv;
                break;
            case "메이플 용사":
                mapleWarriorLv = skillLv;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 쉐도우 파트너 스킬
    /// </summary>
    /// <param name="isActive">활성화 여부</param>
    /// <param name="skillLv">스킬 레벨</param>
    public void EffectShadowPartnerSkill(bool isActive, int skillLv)
    {
        //스킬레벨이 0이라 미발동
        if (skillLv < 1)
            return;

        //쉐도우 파트너 활성화
        PlayerManager.PlayerInstance.IsShadowPartner = isActive;
        //쉐도우 파트너 데미지
        if(skillLv<8)
            SkillDamageCalCulate.ShadowPartnerCoff = 21;
        else if(skillLv>=8 && skillLv<=24)
            SkillDamageCalCulate.ShadowPartnerCoff = 14+skillLv;
        else
            SkillDamageCalCulate.ShadowPartnerCoff = 2*skillLv-10;
    }

    /// <summary>
    /// 메소 가드 스킬
    /// </summary>
    /// <param name="isActive"></param>
    public void EffectMasoGuardSkill(bool isActive, int skillLv)
    {
        //스킬레벨이 0이라 미발동
        if (skillLv < 1)
            return;

        //반값 피격 데미지
        PlayerManager.PlayerInstance.IsActiveMesoGuard = isActive;
        //피격시 메소 소비율
        PlayerManager.PlayerInstance.RateArmorMeso = (skillLv<17)?90 - skillLv/2:98-skillLv;
    }


    /// <summary>
    /// 메이플 용사 스킬
    /// </summary>
    /// <param name="isActive"></param>
    public void EffextMapleWarriorSkill(bool isActive, int skillLv)
    {
        //스킬레벨이 0이라 미발동
        if (skillLv < 1)
            return;

        //스탯 증가량
        int addAmountPercent = (skillLv + 1) / 2;
        int addSTR = (PlayerManager.PlayerInstance.PlayerSTR* addAmountPercent) / 100;
        int addDEX = (PlayerManager.PlayerInstance.PlayerDEX * addAmountPercent) / 100;
        int addINT = (PlayerManager.PlayerInstance.PlayerINT * addAmountPercent) / 100;
        int addLUK = (PlayerManager.PlayerInstance.PlayerLUK * addAmountPercent) / 100;

        //활성화시 스탯 증가
        if (isActive)
        {
            PlayerManager.PlayerInstance.PlayerSTR += addSTR;
            PlayerManager.PlayerInstance.PlayerDEX += addDEX;
            PlayerManager.PlayerInstance.PlayerINT += addINT;
            PlayerManager.PlayerInstance.PlayerLUK += addLUK;
        }
        else//비활성화시 스탯 원래대로
        {
            PlayerManager.PlayerInstance.PlayerSTR -= addSTR;
            PlayerManager.PlayerInstance.PlayerDEX -= addDEX;
            PlayerManager.PlayerInstance.PlayerINT -= addINT;
            PlayerManager.PlayerInstance.PlayerLUK -= addLUK;
        }
    }
}
