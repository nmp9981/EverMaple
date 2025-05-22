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

    /// <summary>
    /// ������ ��� ��ų
    /// </summary>
    /// <param name="isActive"></param>
    public void EffextMapleWarriorSkill(bool isActive)
    {
        //��ų������ 0�̶� �̹ߵ�
        if (mapleWarriorLv < 1)
            return;
        int addAmountPercent = (mapleWarriorLv+1) / 2;
        int addSTR = (PlayerManager.PlayerInstance.PlayerSTR* addAmountPercent) / 100;
        int addDEX = (PlayerManager.PlayerInstance.PlayerDEX * addAmountPercent) / 100;
        int addINT = (PlayerManager.PlayerInstance.PlayerINT * addAmountPercent) / 100;
        int addLUK = (PlayerManager.PlayerInstance.PlayerLUK * addAmountPercent) / 100;

        //Ȱ��ȭ�� ���� ����
        if (isActive)
        {
            PlayerManager.PlayerInstance.PlayerSTR += addSTR;
            PlayerManager.PlayerInstance.PlayerDEX += addDEX;
            PlayerManager.PlayerInstance.PlayerINT += addINT;
            PlayerManager.PlayerInstance.PlayerLUK += addLUK;
        }
        else//��Ȱ��ȭ�� ���� �������
        {
            PlayerManager.PlayerInstance.PlayerSTR -= addSTR;
            PlayerManager.PlayerInstance.PlayerDEX -= addDEX;
            PlayerManager.PlayerInstance.PlayerINT -= addINT;
            PlayerManager.PlayerInstance.PlayerLUK -= addLUK;
        }
    }
}
