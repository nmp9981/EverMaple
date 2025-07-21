using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ų ���� Ŭ����
/// </summary>
public class SkillToolTipText
{
    public Sprite skillSprite;//��ų �̹���
    public string skillName;//��ų��
    public string skillExplain;//��ų ����
    public int masterLv;//������ ����

    public SkillToolTipText(Sprite skillSprite, string skillName, string skillExplain,int masterLv)
    {
        this.skillSprite = skillSprite;
        this.skillName = skillName;
        this.skillExplain = skillExplain;
        this.masterLv = masterLv;
    }
}

public class SkillToolTipClass : MonoBehaviour
{
    public Dictionary<string, SkillToolTipText> skillToolTipTextDic = new Dictionary<string, SkillToolTipText>(); 
    public List<Sprite> skillIconList = new List<Sprite>();

    private void Start()
    {
        EnrollSkillText();
    }
    void EnrollSkillText()
    {
        SkillToolTipText skillToolTip0 
            = new SkillToolTipText(skillIconList[0], "�Ժ�ٵ�", "���߷��� ȸ������ ���������ش�.",20);
        skillToolTipTextDic.Add("�Ժ�ٵ�", skillToolTip0);

        SkillToolTipText skillToolTip1
           = new SkillToolTipText(skillIconList[1], "Ų ������", "������, ǥâ �� ��ô ������ �����Ÿ��� ���������ش�",8);
        skillToolTipTextDic.Add("Ų ������", skillToolTip1);

        SkillToolTipText skillToolTip2
           = new SkillToolTipText(skillIconList[2], "��Ű����", "MP�� �Һ��Ͽ� 2���� ǥâ�� ���� LUK�� ���� ���� ������ ���Ѵ�. " +
           "�ں��� �����͸��� ���� ���� LUK ��ġ�� ���� �����Ѵ�.",20);
        skillToolTipTextDic.Add("��Ű����", skillToolTip2);

        SkillToolTipText skillToolTip3
           = new SkillToolTipText(skillIconList[3], "���� ����", "MP�� �Һ��Ͽ� �� �ð��� �ܰ����� �� ���� 2�� ���� ���.",20);
        skillToolTipTextDic.Add("���� ����", skillToolTip3);

        SkillToolTipText skillToolTip4
           = new SkillToolTipText(skillIconList[4], "�ں��� �����͸�", "ǥâ�� ���� �� �ٷ�� �ְԵȴ�.",20);
        skillToolTipTextDic.Add("�ں��� �����͸�", skillToolTip4);

        SkillToolTipText skillToolTip5
           = new SkillToolTipText(skillIconList[5], "�ں��� �ν���", "HP, MP�� �Һ��Ͽ� ���� �ð����� �ƴ��� ���ݼӵ��� �� �ܰ� ��½�Ų��." +
           " �ƴ븦 ����ϰ� ǥâ�� ���� ��쿡�� �ߵ��� �����ϴ�.",20);
        skillToolTipTextDic.Add("�ں��� �ν���", skillToolTip5);

        SkillToolTipText skillToolTip6
          = new SkillToolTipText(skillIconList[6], "ũ��Ƽ�� ���ο�", "���� Ȯ���� ǥâ�� ���� ũ��Ƽ�� ������ ����������.",30);
        skillToolTipTextDic.Add("ũ��Ƽ�� ���ο�", skillToolTip6);

        SkillToolTipText skillToolTip7
          = new SkillToolTipText(skillIconList[7], "���̽�Ʈ", "���� �ð����� �̵��ӵ��� �������� ���������ش�.",20);
        skillToolTipTextDic.Add("���̽�Ʈ", skillToolTip7);

        SkillToolTipText skillToolTip8
          = new SkillToolTipText(skillIconList[8], "��� �����͸�", "�ܰ� �迭 ������ ���õ��� ���߷��� ��½�Ų��.",20);
        skillToolTipTextDic.Add("��� �����͸�", skillToolTip8);

        SkillToolTipText skillToolTip9
          = new SkillToolTipText(skillIconList[9], "��� �ν���", "HP, MP�� �Һ��Ͽ� ���� �ð����� ����� ���ݼӵ��� �� �ܰ� ��½�Ų��. " +
          "�ܰ��� ��� ���� ��쿡�� �ߵ��� �����ϴ�.",20);
        skillToolTipTextDic.Add("��� �ν���", skillToolTip9);

        SkillToolTipText skillToolTip10
         = new SkillToolTipText(skillIconList[10], "��������ο�", "MP�� �Һ��Ͽ� �ܰ����� ������ �ְ� 6���� ������ ���Ѵ�.",30);
        skillToolTipTextDic.Add("��������ο�", skillToolTip10);

        SkillToolTipText skillToolTip11
         = new SkillToolTipText(skillIconList[11], "���ɹ̽�Ʈ", "���� �� ȸ�� �������� ȿ���� ����ϰų�" +
         "���º�ȭ �������� ����ð��� �þ��. ��, �������� ���� %�� ȸ������ �ִ� �����ۿ��� ������� �ʴ´�",20);
        skillToolTipTextDic.Add("���ɹ̽�Ʈ", skillToolTip11);

        SkillToolTipText skillToolTip12
         = new SkillToolTipText(skillIconList[12], "��������Ʈ��", "���� �ð����� �ڽŰ� �Ȱ��� �ൿ�� �ϴ� �׸��� ���Ḧ ��ȯ�س���. " +
         "������ ü���� ������ð��� ������ ������Եȴ�.",30);
        skillToolTipTextDic.Add("��������Ʈ��", skillToolTip12);

        SkillToolTipText skillToolTip13
         = new SkillToolTipText(skillIconList[13], "���", "MP�� �Ҹ��Ͽ� Ŀ�ٶ� ǥâ�� ����� ������." +
         " ������ ǥâ�� ���� ����ϸ� �� ���� ������ ������ �� �ִ�.",30);
        skillToolTipTextDic.Add("���", skillToolTip13);

        SkillToolTipText skillToolTip14
         = new SkillToolTipText(skillIconList[14], "�޼Ҿ�", "���� �ð����� �����κ��� ���� ���� �޼Ұ� ���������� �Ѵ�.",20);
        skillToolTipTextDic.Add("�޼Ҿ�", skillToolTip14);

        SkillToolTipText skillToolTip15
         = new SkillToolTipText(skillIconList[15], "�����", "�� �� ���� ���ϰ� ������ �����Ѵ�.",30);
        skillToolTipTextDic.Add("�����", skillToolTip15);

        SkillToolTipText skillToolTip16
         = new SkillToolTipText(skillIconList[16], "�ú���", "���Ḧ ��ȯ�Ͽ� �ֺ��� �� ���� ���� �����Ѵ�. �ִ� 5����� ������ �� �ִ�.",30);
        skillToolTipTextDic.Add("�ú���", skillToolTip16);

        SkillToolTipText skillToolTip17
         = new SkillToolTipText(skillIconList[17], "�޼Ұ���", "���� �ð����� �޼ҷ� �������� 50%�� �����Ѵ�. �������� ���� ������ ������ ���� �޼Ұ� �Һ�ȴ�.",20);
        skillToolTipTextDic.Add("�޼Ұ���", skillToolTip17);

        SkillToolTipText skillToolTip18
         = new SkillToolTipText(skillIconList[18], "������ ���", "���� �ð����� ��� ������ ���� �伾Ʈ �÷��ش�.",20);
        skillToolTipTextDic.Add("������ ���", skillToolTip18);

        SkillToolTipText skillToolTip19
         = new SkillToolTipText(skillIconList[19], "Ʈ���ý��ο�", "�� ���� ǥâ 3���� ���� ������ �Ѵ�.",30);
        skillToolTipTextDic.Add("Ʈ���ý��ο�", skillToolTip19);

        SkillToolTipText skillToolTip20
         = new SkillToolTipText(skillIconList[20], "�θ޶� ����", "���� �ӵ��� �ټ��� ���� �� �� ����.",30);
        skillToolTipTextDic.Add("�θ޶� ����", skillToolTip20);
    }

    /// <summary>
    /// �� ��ų ��ɵ� �� ����
    /// </summary>
    /// <returns></returns>
    public string SKillFunctionExplainDetail(string skillName, int skillLv)
    {
        string detailText = string.Empty;
        int spendMP = 0;
        int nextSpendMP = 0;
        int coff = 0;
        int nextCoff = 0;

        switch (skillName)
        {
            case "�Ժ�ٵ�":
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                    detailText = $"���߷� +{skillLv}, ȸ���� +{skillLv}\n���߷� +{skillLv+1}, ȸ���� +{skillLv+1}";
                else
                    detailText = $"���߷� +{skillLv}, ȸ���� +{skillLv}";
                break;
            case "Ų ������":
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                    detailText = $"��ô ������ �����Ÿ� ����: +{skillLv*0.75}\n��ô ������ �����Ÿ� ����: +{(skillLv+1) * 0.75}";
                else
                    detailText = $"��ô ������ �����Ÿ� ����: +{skillLv * 0.75}";
                break;
            case "��Ű����":
                spendMP = 6 + skillLv / 2;
                nextSpendMP = 6 + (skillLv+1) / 2;
                coff = (skillLv==0)?0: 50 + skillLv * 5;
                nextCoff = 50 + (skillLv + 1) * 5;
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, ������ {coff}% x 2\nMP -{nextSpendMP}, ������ {nextCoff}% x 2";
                }
                else
                    detailText = $"MP -{spendMP}, ������ {coff}% x 2";
                break;
            case "���� ����":
                spendMP = 7 + (skillLv + 1) / 3;
                nextSpendMP = 7 + (skillLv + 2) / 3;
                coff = (skillLv == 0) ? 0 : 70 + (skillLv * 7) / 2;
                nextCoff = 70 + (skillLv * 7) / 2;
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, ������ {coff}% x 2\nMP -{nextSpendMP}, ������ {nextCoff}% x 2";
                }
                else
                    detailText = $"MP -{spendMP}, ������ {coff}% x 2";
                break;
            default:
                break;
        }
        return detailText;
    }
}
