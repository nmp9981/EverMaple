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
    /// ������ ��Ʈ�� ��ų
    /// </summary>
    /// <param name="isActive">Ȱ��ȭ ����</param>
    /// <param name="skillLv">��ų ����</param>
    public void EffectShadowPartnerSkill(bool isActive, int skillLv)
    {
        //��ų������ 0�̶� �̹ߵ�
        if (skillLv < 1)
            return;

        //������ ��Ʈ�� Ȱ��ȭ
        PlayerManager.PlayerInstance.IsShadowPartner = isActive;
        //������ ��Ʈ�� ������
        if(skillLv<8)
            SkillDamageCalCulate.ShadowPartnerCoff = 21;
        else if(skillLv>=8 && skillLv<=24)
            SkillDamageCalCulate.ShadowPartnerCoff = 14+skillLv;
        else
            SkillDamageCalCulate.ShadowPartnerCoff = 2*skillLv-10;
    }

    /// <summary>
    /// �޼� ���� ��ų
    /// </summary>
    /// <param name="isActive"></param>
    public void EffectMasoGuardSkill(bool isActive, int skillLv)
    {
        //��ų������ 0�̶� �̹ߵ�
        if (skillLv < 1)
            return;

        //�ݰ� �ǰ� ������
        PlayerManager.PlayerInstance.IsActiveMesoGuard = isActive;
        //�ǰݽ� �޼� �Һ���
        PlayerManager.PlayerInstance.RateArmorMeso = (skillLv<17)?90 - skillLv/2:98-skillLv;
    }


    /// <summary>
    /// ������ ��� ��ų
    /// </summary>
    /// <param name="isActive"></param>
    public void EffextMapleWarriorSkill(bool isActive, int skillLv)
    {
        //��ų������ 0�̶� �̹ߵ�
        if (skillLv < 1)
            return;

        //���� ������
        int addAmountPercent = (skillLv + 1) / 2;
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
