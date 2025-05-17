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
            case "ũ��Ƽ�� ���ο�":
                CriticalThrow(skillLv);
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
    /// ũ��Ƽ�� ���ο�
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
