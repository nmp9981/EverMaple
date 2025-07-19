using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// �Һ������ ���� Ŭ����
/// </summary>
public class ConsumeToolTipText
{
    public Sprite itemSprite;
    public string name;
    public string itemExplain;

    public ConsumeToolTipText(Sprite itemSprite, string name, string itemExplain)
    {
        this.itemSprite = itemSprite;
        this.name = name;   
        this.itemExplain = itemExplain;
    }
}

public class ConsumeItemToolTip : MonoBehaviour
{
    private void Start()
    {
        EnrollItemText();
    }
    /// <summary>
    /// ������ ���� ���
    /// </summary>
    void EnrollItemText()
    {
        ConsumeToolTipText consumToolTip0 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[0], "���� ����", "HP�� 50 ȸ����Ų��.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("���� ����", consumToolTip0);

        ConsumeToolTipText consumToolTip1 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[1], "��Ȳ ����", "HP�� 150 ȸ����Ų��.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("��Ȳ ����", consumToolTip1);

        ConsumeToolTipText consumToolTip2 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[2], "�Ͼ� ����", "HP�� 300 ȸ����Ų��.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("�Ͼ� ����", consumToolTip2);

        ConsumeToolTipText consumToolTip3 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[3], "�Ķ� ����", "MP�� 100 ȸ����Ų��.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("�Ķ� ����", consumToolTip3);

        ConsumeToolTipText consumToolTip4 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[4], "���� ������", "MP�� 300 ȸ����Ų��.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("���� ������", consumToolTip4);

        ConsumeToolTipText consumToolTip5 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[5], "����", "HP�� 1000 ȸ����Ų��.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("����", consumToolTip5);

        ConsumeToolTipText consumToolTip6 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[6], "���� ��", "MP�� 800 ȸ����Ų��.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("���� ��", consumToolTip6);

        ConsumeToolTipText consumToolTip7 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[7], "���޹�", "HP�� 2000 ȸ����Ų��.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("���޹�", consumToolTip7);

        ConsumeToolTipText consumToolTip8 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[8], "�Ϻ���", "MP�� 2000 ȸ����Ų��.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("�Ϻ���", consumToolTip8);

        ConsumeToolTipText consumToolTip9 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[9], "������ ����", "5�е��� ���� ���ݷ��� 5�����Ѵ�.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("������ ����", consumToolTip9);

        ConsumeToolTipText consumToolTip10 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[10], "�������� ����", "5�е��� ������ 5�����Ѵ�.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("�������� ����", consumToolTip10);

        ConsumeToolTipText consumToolTip11 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[11], "������ ����", "5�е��� ���߷��� 10�����Ѵ�.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("������ ����", consumToolTip11);

        ConsumeToolTipText consumToolTip12 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[12], "��ø���� ����", "5�е��� ȸ������ 10�����Ѵ�.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("��ø���� ����", consumToolTip12);

        ConsumeToolTipText consumToolTip13 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[13], "�ӵ� ����� ����", "5�е��� �̵� �ӵ��� 10�����Ѵ�.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("�ӵ� ����� ����", consumToolTip13);

        ConsumeToolTipText consumToolTip14 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[14], "���� ��ȯ �ֹ���", "����� ������ ��ȯ�Ѵ�.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("���� ��ȯ �ֹ���", consumToolTip14);

        ConsumeToolTipText consumToolTip15 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[15], "������ ����", "5�е��� ������ 10�����Ѵ�.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("������ ����", consumToolTip15);

        ConsumeToolTipText consumToolTip16 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[16], "��񳪹��� ����", "5�е��� ���� ������ 10�����Ѵ�.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("��񳪹��� ����", consumToolTip16);

        ConsumeToolTipText consumToolTip17 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[17], "�巹��ũ�� ��", "5�е��� ���� ���ݷ��� 8�����Ѵ�.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("�巹��ũ�� ��", consumToolTip17);

        ConsumeToolTipText consumToolTip18 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[18], "�巹��ũ�� ���", "5�е��� ���� ������ 10�����Ѵ�.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("�巹��ũ�� ���", consumToolTip18);

        ConsumeToolTipText consumToolTip19 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[19], "������", "HP, MP�� 50%�� ȸ����Ų��.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("������", consumToolTip19);

        ConsumeToolTipText consumToolTip20 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[20], "�Ŀ� ������", "HP, MP�� 100%�� ȸ����Ų��.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("�Ŀ� ������", consumToolTip20);
    }
}
