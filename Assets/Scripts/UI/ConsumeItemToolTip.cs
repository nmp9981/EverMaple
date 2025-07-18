using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 소비아이템 툴팁 클래스
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
    /// 아이템 툴팁 등록
    /// </summary>
    void EnrollItemText()
    {
        ConsumeToolTipText consumToolTip0 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[0], "빨간 포션", "HP를 50 회복시킨다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add(0, consumToolTip0);

        ConsumeToolTipText consumToolTip1 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[1], "주황 포션", "HP를 150 회복시킨다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add(1, consumToolTip1);

        ConsumeToolTipText consumToolTip2 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[2], "하얀 포션", "HP를 300 회복시킨다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add(2, consumToolTip2);

        ConsumeToolTipText consumToolTip3 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[3], "파란 포션", "MP를 100 회복시킨다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add(3, consumToolTip3);

        ConsumeToolTipText consumToolTip4 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[4], "마나 엘릭서", "MP를 300 회복시킨다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add(4, consumToolTip4);
    }
    
}
