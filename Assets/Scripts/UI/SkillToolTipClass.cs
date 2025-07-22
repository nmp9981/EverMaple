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
                nextCoff = 70 + ((skillLv+1) * 7) / 2;
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, ������ {coff}% x 2\nMP -{nextSpendMP}, ������ {nextCoff}% x 2";
                }
                else
                    detailText = $"MP -{spendMP}, ������ {coff}% x 2";
                break;
            case "�ں��� �����͸�":
                coff = (skillLv == 0) ? 0 : 15 + 5 * ((skillLv - 1) / 2);
                nextCoff = 15 + 5 * (skillLv / 2); ;
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"�ƴ� �迭�� ���� ���õ� {coff}%, ���߷� +{skillLv}\n�ƴ� �迭�� ���� ���õ� {nextCoff}%, ���߷� +{skillLv+1}";
                }
                else
                    detailText = $"�ƴ� �迭�� ���� ���õ� {coff}%, ���߷� +{skillLv}";
                break;
            case "�ں��� �ν���":
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"HP -{30 - skillLv}, MP -{30 - skillLv}�Һ��Ͽ� �ƴ��� ���� �ӵ� ��� {skillLv * 10} �� ����\n" +
                        $"HP -{29 - skillLv}, MP -{29 - skillLv}�Һ��Ͽ� �ƴ��� ���� �ӵ� ��� {skillLv * 10+10} �� ����";
                }
                else
                    detailText = $"HP -{30-skillLv}, MP -{30-skillLv}�Һ��Ͽ� �ƴ��� ���� �ӵ� ��� {skillLv*10} �� ����";
                break;
            case "ũ��Ƽ�� ���ο�":
                int coffProb = skillLv<21? 2 * skillLv: 20 + skillLv;
                int nextCoffProb = (skillLv+1) < 21 ? 2 * skillLv+2 : 21 + skillLv;
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"{coffProb}%�� Ȯ��, ũ��Ƽ�� ������ {110 + 3 * skillLv}%\n" +
                        $"{nextCoffProb}%�� Ȯ��, ũ��Ƽ�� ������ {113 + 3 * skillLv}%";
                }
                else
                    detailText = $"{coffProb}%�� Ȯ��, ũ��Ƽ�� ������ {110 + 3 * skillLv}%";
                break;
            case "���̽�Ʈ":
                spendMP = skillLv<=10?15:30;
                nextSpendMP = (skillLv+1 <= 10) ? 15 : 30;
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, �̵��ӵ� +{skillLv * 2}. ������ +{skillLv}, {skillLv * 10}�� ����\n" +
                        $"MP -{nextSpendMP}, �̵��ӵ� +{skillLv * 2+2}. ������ +{skillLv+1}, {skillLv * 10+10}�� ����";
                }
                else
                    detailText = $"MP -{spendMP}, �̵��ӵ� +{skillLv*2}. ������ +{skillLv}, {skillLv*10}�� ����";
                break;
            case "��� �����͸�":
                coff = (skillLv == 0) ? 0 : 15 + 5 * ((skillLv - 1) / 2);
                nextCoff = 15 + 5 * (skillLv / 2); ;
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"�ܰ� �迭�� ���� ���õ� {coff}%, ���߷� +{skillLv}\n�ܰ� �迭�� ���� ���õ� {nextCoff}%, ���߷� +{skillLv + 1}";
                }
                else
                    detailText = $"�ܰ� �迭�� ���� ���õ� {coff}%, ���߷� +{skillLv}";
                break;
            case "��� �ν���":
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"HP -{30 - skillLv}, MP -{30 - skillLv}�Һ��Ͽ� �ܰ��� ���� �ӵ� ��� {skillLv * 10} �� ����\n" +
                        $"HP -{29 - skillLv}, MP -{29 - skillLv}�Һ��Ͽ� �ܰ��� ���� �ӵ� ��� {skillLv * 10 + 10} �� ����";
                }
                else
                    detailText = $"HP -{30 - skillLv}, MP -{30 - skillLv}�Һ��Ͽ� �ܰ��� ���� �ӵ� ��� {skillLv * 10} �� ����";
                break;
            case "��������ο�":
                spendMP = 9 * ((skillLv + 9) / 10);
                nextSpendMP = 9 * ((skillLv + 10) / 10);
                coff = 50 + skillLv;
                nextCoff = 51 + skillLv;
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, {2 * ((skillLv + 9) / 10)}�� ���� ����, ������ {coff}%\n" +
                        $"MP -{nextSpendMP}, {2 * ((skillLv + 10) / 10)}�� ���� ����, ������ {nextCoff}%";
                }
                else
                    detailText = $"MP -{spendMP}, {2 * ((skillLv + 9) / 10)}�� ���� ����, ������ {coff}%";
                break;
            case "���ɹ̽�Ʈ":
                coff = (skillLv<11)? 100+3 * skillLv: 130 + 2 * skillLv;
                nextCoff = (skillLv +1< 11) ?103+ 3 * skillLv : 132 + 2 * skillLv;
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"ȸ���� {coff}%, ���� �ð� {coff}%\n" +
                        $"ȸ���� {nextCoff}%, ���� �ð� {nextCoff}%";
                }
                else
                    detailText = $"ȸ���� {coff}%, ���� �ð� {coff}%";
                break;
            case "��������Ʈ��":
               //���� ���� ���
                if (skillLv < 8)
                    coff = 21;
                else if (skillLv >= 8 && skillLv <= 24)
                    coff = 14 + skillLv;
                else
                    coff = 2 * skillLv - 10;

                //���� ���� ���
                if (skillLv < 7)
                    nextCoff = 21;
                else if (skillLv >= 7 && skillLv <= 23)
                    nextCoff = 14 + skillLv;
                else
                    nextCoff = 2 * skillLv - 10;

                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{205 - skillLv * 5}, ������ {coff}%, {((skillLv + 9) / 10) * 60}�� ����\n" +
                        $"MP -{200 - skillLv * 5}, ������ {nextCoff}%, {((skillLv + 10) / 10) * 60}�� ����";
                }
                else
                    detailText = $"MP -{205 - skillLv * 5}, ������ {coff}%, {((skillLv + 9) / 10) * 60}�� ����";
                break;
            case "���":
                spendMP = 9 + 7 * ((skillLv + 9) / 10);
                nextSpendMP = 9 + 7 * ((skillLv + 10) / 10);

                //���� ���� ���
                if (skillLv <= 10)
                    coff = 60 + 5 * skillLv;
                else if (skillLv > 20)
                    coff = 90 + 3 * skillLv;
                else
                    coff = 70 + 4 * skillLv;

                //���� ���� ���
                if (skillLv <= 9)
                    nextCoff = 60 + 5 * skillLv;
                else if (skillLv > 19)
                    nextCoff = 90 + 3 * skillLv;
                else
                    nextCoff = 70 + 4 * skillLv;

                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, ������ {coff}%, ǥâ 3�� �Һ��Ͽ� �ִ� {3 + (skillLv + 9) / 10}�� ����\n" +
                        $"MP -{nextSpendMP}, ������ {nextCoff}%, ǥâ 3�� �Һ��Ͽ� �ִ� {3 + (skillLv + 10) / 10}�� ����";
                }
                else
                    detailText = $"MP -{spendMP}, ������ {coff}%, ǥâ 3�� �Һ��Ͽ� �ִ� {3 + (skillLv + 9) / 10}�� ����";
                break;
            case "�޼Ҿ�":
                coff = (skillLv <= 10) ? 3 * skillLv : 30 + 2 * skillLv;
                nextCoff = (skillLv+1 <= 10) ? 3 * skillLv+3 : 32 + 2 * skillLv;

                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -60, �޼� ��Ӿ� +{coff}%, {20 + 5 * skillLv}�� ����\n" +
                        $"MP -60, �޼� ��Ӿ� +{nextCoff}%, {25 + 5 * skillLv}�� ����";
                }
                else
                    detailText = $"MP -60, �޼� ��Ӿ� +{coff}%, {20 + 5 * skillLv}�� ����";
                break;
            case "�����":
                spendMP = 5 + 7 * ((skillLv + 9) / 10);
                nextSpendMP = 5 + 7 * ((skillLv + 10) / 10);
                coff = (skillLv < 21) ? 200 + skillLv * 10 : 300 + 5 * skillLv;
                nextCoff = (skillLv < 20) ? 210 + skillLv * 10 : 305 + 5 * skillLv;

                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, ������ {coff}%\n" +
                        $"MP -{nextSpendMP}, ������ {nextCoff}%";
                }
                else
                    detailText = $"MP -{spendMP}, ������ {coff}%";
                break;
            case "�ú���":
                spendMP = 10 * ((skillLv + 9) / 10);
                nextSpendMP = 10 * ((skillLv + 10) / 10);
                int targetNum = 2 + ((skillLv + 9) / 10);
                int nextTargetNum = 2 + ((skillLv + 10) / 10);
                coff = 160 + skillLv * 5 - targetNum*20;
                nextCoff = 165 + skillLv * 5 - nextTargetNum * 20;

                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, ������ {coff}%, {targetNum}���� �н��� ���� ����\n" +
                        $"MP -{nextSpendMP}, ������ {nextCoff}%, {nextTargetNum}���� �н��� ���� ����";
                }
                else
                    detailText = $"MP -{spendMP}, ������ {coff}%, {targetNum}���� �н��� ���� ����";
                break;
            case "�޼Ұ���":
                coff = (skillLv < 17) ? 90 - skillLv / 2 : 98 - skillLv;
                nextCoff = (skillLv < 16) ? 90 - (skillLv + 1) / 2 : 97 - skillLv;

                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -35, ������ �������� {coff}%�� �޼ҷ� ���, {120 + skillLv * 3}�� ����\n" +
                        $"MP -35, ������ �������� {nextCoff}%�� �޼ҷ� ���, {123 + skillLv * 3}�� ����";
                }
                else
                    detailText = $"MP -35, ������ �������� {coff}%�� �޼ҷ� ���, {120 + skillLv * 3}�� ����";
                break;
            case "������ ���":
                spendMP = 10 * skillLv / 5 + 10;
                nextSpendMP = 10 * (skillLv+1) / 5 + 10;
                coff = (skillLv + 1) / 2;
                nextCoff = (skillLv + 2) / 2;

                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, ��� ���� +{coff}%, ���ӽð� {30 * skillLv}��\n" +
                        $"MP -{nextSpendMP}, ��� ���� +{nextCoff}%, ���ӽð� {30 * skillLv+30}��";
                }
                else
                    detailText = $"MP -{spendMP}, ��� ���� +{coff}%, ���ӽð� {30 * skillLv}��";
                break;
            case "Ʈ���ý��ο�":
                spendMP = 10 + (skillLv + 2) / 3;
                nextSpendMP = 10 + (skillLv + 3) / 3;
                coff = (skillLv > 20) ? 120 + skillLv : 100 + 2 * skillLv;
                nextCoff = (skillLv > 20) ? 121 + skillLv : 102 + 2 * skillLv;

                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, ������ {coff}%\n" +
                        $"MP -{nextSpendMP}, ������ {nextCoff}%";
                }
                else
                    detailText = $"MP -{spendMP}, ������ {coff}%";
                break;
            case "�θ޶� ����":
                spendMP = 13 + 3 * ((skillLv + 5) / 6);
                nextSpendMP = 13 + 3 * ((skillLv + 6) / 6);
                coff = (skillLv > 20) ? 350 + 5 * skillLv : 250 + 10 * skillLv;
                nextCoff = (skillLv > 19) ? 355 + 5 * skillLv : 260 + 10 * skillLv;

                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, {1 + (skillLv + 9) / 10}���� ������ ������ {coff}%\n" +
                        $"MP -{nextSpendMP}, {1 + (skillLv + 10) / 10}���� ������ ������ {nextCoff}%";
                }
                else
                    detailText = $"MP -{spendMP}, {1 + (skillLv + 9) / 10}���� ������ ������ {coff}%";
                break;
            default:
                break;
        }
        return detailText;
    }
}
