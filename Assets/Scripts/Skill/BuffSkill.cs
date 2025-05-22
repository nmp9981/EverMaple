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
}
