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
        ItemManager.itemInstance.consumeItemToolTipDic.Add(0, consumToolTip0);

        ConsumeToolTipText consumToolTip1 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[1], "��Ȳ ����", "HP�� 150 ȸ����Ų��.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add(1, consumToolTip1);

        ConsumeToolTipText consumToolTip2 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[2], "�Ͼ� ����", "HP�� 300 ȸ����Ų��.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add(2, consumToolTip2);

        ConsumeToolTipText consumToolTip3 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[3], "�Ķ� ����", "MP�� 100 ȸ����Ų��.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add(3, consumToolTip3);

        ConsumeToolTipText consumToolTip4 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[4], "���� ������", "MP�� 300 ȸ����Ų��.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add(4, consumToolTip4);
    }
    
}
