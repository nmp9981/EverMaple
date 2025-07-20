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
    }
}
