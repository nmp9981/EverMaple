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

    public SkillToolTipText(Sprite skillSprite, string skillName, string skillExplain)
    {
        this.skillSprite = skillSprite;
        this.skillName = skillName;
        this.skillExplain = skillExplain;
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
            = new SkillToolTipText(skillIconList[0], "�Ժ�ٵ�", "���߷��� ȸ������ ���������ش�.");
        skillToolTipTextDic.Add("�Ժ�ٵ�", skillToolTip0);

        SkillToolTipText skillToolTip1
           = new SkillToolTipText(skillIconList[1], "Ų ������", "������, ǥâ �� ��ô ������ �����Ÿ��� ���������ش�");
        skillToolTipTextDic.Add("Ų ������", skillToolTip1);

        SkillToolTipText skillToolTip2
           = new SkillToolTipText(skillIconList[2], "��Ű����", "MP�� �Һ��Ͽ� 2���� ǥâ�� ���� LUK�� ���� ���� ������ ���Ѵ�. " +
           "�ں��� �����͸��� ���� ���� LUK ��ġ�� ���� �����Ѵ�.");
        skillToolTipTextDic.Add("��Ű����", skillToolTip2);

        SkillToolTipText skillToolTip3
           = new SkillToolTipText(skillIconList[3], "���� ����", "MP�� �Һ��Ͽ� �� �ð��� �ܰ����� �� ���� 2�� ���� ���.");
        skillToolTipTextDic.Add("���� ����", skillToolTip3);

        SkillToolTipText skillToolTip4
           = new SkillToolTipText(skillIconList[4], "�ں��� �����͸�", "ǥâ�� ���� �� �ٷ�� �ְԵȴ�.");
        skillToolTipTextDic.Add("�ں��� �����͸�", skillToolTip4);

        SkillToolTipText skillToolTip5
           = new SkillToolTipText(skillIconList[5], "�ں��� �ν���", "HP, MP�� �Һ��Ͽ� ���� �ð����� �ƴ��� ���ݼӵ��� �� �ܰ� ��½�Ų��." +
           " �ƴ븦 ����ϰ� ǥâ�� ���� ��쿡�� �ߵ��� �����ϴ�.");
        skillToolTipTextDic.Add("�ں��� �ν���", skillToolTip5);

        SkillToolTipText skillToolTip6
          = new SkillToolTipText(skillIconList[6], "ũ��Ƽ�� ���ο�", "���� Ȯ���� ǥâ�� ���� ũ��Ƽ�� ������ ����������.");
        skillToolTipTextDic.Add("ũ��Ƽ�� ���ο�", skillToolTip6);

        SkillToolTipText skillToolTip7
          = new SkillToolTipText(skillIconList[7], "���̽�Ʈ", "���� �ð����� �̵��ӵ��� �������� ���������ش�.");
        skillToolTipTextDic.Add("���̽�Ʈ", skillToolTip7);

        SkillToolTipText skillToolTip8
          = new SkillToolTipText(skillIconList[8], "��� �����͸�", "�ܰ� �迭 ������ ���õ��� ���߷��� ��½�Ų��.");
        skillToolTipTextDic.Add("��� �����͸�", skillToolTip8);

        SkillToolTipText skillToolTip9
          = new SkillToolTipText(skillIconList[9], "��� �ν���", "HP, MP�� �Һ��Ͽ� ���� �ð����� ����� ���ݼӵ��� �� �ܰ� ��½�Ų��. " +
          "�ܰ��� ��� ���� ��쿡�� �ߵ��� �����ϴ�.");
        skillToolTipTextDic.Add("��� �ν���", skillToolTip9);

        SkillToolTipText skillToolTip10
         = new SkillToolTipText(skillIconList[10], "��������ο�", "MP�� �Һ��Ͽ� �ܰ����� ������ �ְ� 6���� ������ ���Ѵ�.");
        skillToolTipTextDic.Add("��������ο�", skillToolTip10);

        SkillToolTipText skillToolTip11
         = new SkillToolTipText(skillIconList[11], "���ɹ̽�Ʈ", "���� �� ȸ�� �������� ȿ���� ����ϰų�" +
         "���º�ȭ �������� ����ð��� �þ��. ��, �������� ���� %�� ȸ������ �ִ� �����ۿ��� ������� �ʴ´�");
        skillToolTipTextDic.Add("���ɹ̽�Ʈ", skillToolTip11);

        SkillToolTipText skillToolTip12
         = new SkillToolTipText(skillIconList[12], "��������Ʈ��", "���� �ð����� �ڽŰ� �Ȱ��� �ൿ�� �ϴ� �׸��� ���Ḧ ��ȯ�س���. " +
         "������ ü���� ������ð��� ������ ������Եȴ�.");
        skillToolTipTextDic.Add("��������Ʈ��", skillToolTip12);

        SkillToolTipText skillToolTip13
         = new SkillToolTipText(skillIconList[13], "���", "MP�� �Ҹ��Ͽ� Ŀ�ٶ� ǥâ�� ����� ������." +
         " ������ ǥâ�� ���� ����ϸ� �� ���� ������ ������ �� �ִ�.");
        skillToolTipTextDic.Add("���", skillToolTip13);

        SkillToolTipText skillToolTip14
         = new SkillToolTipText(skillIconList[14], "�޼Ҿ�", "���� �ð����� �����κ��� ���� ���� �޼Ұ� ���������� �Ѵ�.");
        skillToolTipTextDic.Add("�޼Ҿ�", skillToolTip14);

        SkillToolTipText skillToolTip15
         = new SkillToolTipText(skillIconList[15], "�����", "�� �� ���� ���ϰ� ������ �����Ѵ�.");
        skillToolTipTextDic.Add("�����", skillToolTip15);

        SkillToolTipText skillToolTip16
         = new SkillToolTipText(skillIconList[16], "�ú���", "���Ḧ ��ȯ�Ͽ� �ֺ��� �� ���� ���� �����Ѵ�. �ִ� 5����� ������ �� �ִ�.");
        skillToolTipTextDic.Add("�ú���", skillToolTip16);

        SkillToolTipText skillToolTip17
         = new SkillToolTipText(skillIconList[17], "�޼Ұ���", "���� �ð����� �޼ҷ� �������� 50%�� �����Ѵ�. �������� ���� ������ ������ ���� �޼Ұ� �Һ�ȴ�.");
        skillToolTipTextDic.Add("�޼Ұ���", skillToolTip17);

        SkillToolTipText skillToolTip18
         = new SkillToolTipText(skillIconList[18], "������ ���", "���� �ð����� ��� ������ ���� �伾Ʈ �÷��ش�.");
        skillToolTipTextDic.Add("������ ���", skillToolTip18);

        SkillToolTipText skillToolTip19
         = new SkillToolTipText(skillIconList[19], "Ʈ���ý��ο�", "�� ���� ǥâ 3���� ���� ������ �Ѵ�.");
        skillToolTipTextDic.Add("Ʈ���ý��ο�", skillToolTip19);

        SkillToolTipText skillToolTip20
         = new SkillToolTipText(skillIconList[20], "�θ޶� ����", "���� �ӵ��� �ټ��� ���� �� �� ����.");
        skillToolTipTextDic.Add("�θ޶� ����", skillToolTip20);
    }
}
