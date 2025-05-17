using UnityEngine;

public class PassiveSkillUpgrade
{
    public void PassiveSkillLevelUP(string skillName, int skillLv)
    {
        switch (skillName)
        {
            case "�Ժ�ٵ�":
                NimbleBody(skillLv);
                break;
            case "Ų ������":
                KinEyes(skillLv);
                break;
            case "�ں��� �����͸�":
                Mastery(skillLv);
                break;
            case "��� �����͸�":
                Mastery(skillLv);
                break;
            case "���ɹ̽�Ʈ":
                Alkemist(skillLv);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// �Ժ�ٵ�
    /// </summary>
    /// <param name="skillLv"></param>
    public void NimbleBody(int skillLv)
    {
        PlayerManager.PlayerInstance.PlayerAddAccurary += 1;
        PlayerManager.PlayerInstance.PlayerAddAvoid += 1;
    }

    /// <summary>
    /// Ų������
    /// </summary>
    /// <param name="skillLv"></param>
    public void KinEyes(int skillLv)
    {
        PlayerManager.PlayerInstance.ThrowObjectMaxDist = 6 + skillLv * 0.75f;
    }

    /// <summary>
    /// �����͸�
    /// </summary>
    /// <param name="skillLv"></param>
    public void Mastery(int skillLv)
    {
        PlayerManager.PlayerInstance.Workmanship = 15+5*((skillLv-1)/2);
        PlayerManager.PlayerInstance.PlayerAddAccurary += 1;
    }

    /// <summary>
    /// ���ɹ̽�Ʈ
    /// </summary>
    /// <param name="skillLv"></param>
    public void Alkemist(int skillLv)
    {

    }
}
