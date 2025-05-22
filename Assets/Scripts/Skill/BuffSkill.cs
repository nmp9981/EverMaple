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
    /// 메이플 용사 스킬
    /// </summary>
    /// <param name="isActive"></param>
    public void EffextMapleWarriorSkill(bool isActive)
    {
        //스킬레벨이 0이라 미발동
        if (mapleWarriorLv < 1)
            return;
        int addAmountPercent = (mapleWarriorLv+1) / 2;
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
