using UnityEngine;

public class PassiveSkillUpgrade
{
    public void PassiveSkillLevelUP(string skillName, int skillLv)
    {
        switch (skillName)
        {
            case "님블바디":
                NimbleBody(skillLv);
                break;
            case "킨 아이즈":
                KinEyes(skillLv);
                break;
            case "자벨린 마스터리":
                Mastery(skillLv);
                break;
            case "대거 마스터리":
                Mastery(skillLv);
                break;
            case "알케미스트":
                Alkemist(skillLv);
                break;
            case "크리티컬 스로우":
                CriticalThrow(skillLv);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 님블바디
    /// </summary>
    /// <param name="skillLv"></param>
    public void NimbleBody(int skillLv)
    {
        PlayerManager.PlayerInstance.PlayerAddAccurary += 1;
        PlayerManager.PlayerInstance.PlayerAddAvoid += 1;
    }

    /// <summary>
    /// 킨아이즈
    /// </summary>
    /// <param name="skillLv"></param>
    public void KinEyes(int skillLv)
    {
        PlayerManager.PlayerInstance.ThrowObjectMaxDist = 6 + skillLv * 0.75f;
    }

    /// <summary>
    /// 마스터리
    /// </summary>
    /// <param name="skillLv"></param>
    public void Mastery(int skillLv)
    {
        PlayerManager.PlayerInstance.Workmanship = 15+5*((skillLv-1)/2);
        PlayerManager.PlayerInstance.PlayerAddAccurary += 1;
    }

    /// <summary>
    /// 알케미스트
    /// </summary>
    /// <param name="skillLv"></param>
    public void Alkemist(int skillLv)
    {
        int addAmountBuff = 0;
        int addAmountHeal = 0;
        if (skillLv < 11)
        {
            addAmountBuff = 3 * skillLv;
            addAmountHeal = 3 * skillLv;
        }
        else
        {
            addAmountBuff = 30+ 2* skillLv;
            addAmountHeal = 30+ 2* skillLv;
        }
    }

    /// <summary>
    /// 크리티컬 스로우
    /// </summary>
    /// <param name="skillLv"></param>
    public void CriticalThrow(int skillLv)
    {
        if (skillLv < 21)
        {
            PlayerManager.PlayerInstance.CriticalProbably = 2 * skillLv;
        }
        else
        {
            PlayerManager.PlayerInstance.CriticalProbably = 40 + skillLv;
        }
        PlayerManager.PlayerInstance.CriticalDamagee = 110 + 3 * skillLv;
    }
}
