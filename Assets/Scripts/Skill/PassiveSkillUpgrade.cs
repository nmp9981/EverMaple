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
}
