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
    /// ���� ��ų ���׷��̵�
    /// </summary>
    /// <param name="skillName"></param>
    /// <param name="skillLv"></param>
    public void BuffSkillLevelUP(string skillName, int skillLv)
    {
        switch (skillName)
        {
            case "���̽�Ʈ":
                hasteLv = skillLv;
                break;
            case "�ں��� �ν���":
                boosterLv = skillLv;
                break;
            case "��� �ν���":
                boosterLv = skillLv;
                break;
            case "��������Ʈ��":
                shadowPartnerLv = skillLv;
                break;
            case "�޼Ҿ�":
                mesoUpLv = skillLv;
                break;
            case "�޼Ұ���":
                mesoGuardLv = skillLv;
                break;
            case "������ ���":
                mapleWarriorLv = skillLv;
                break;
            default:
                break;
        }
    }
}
