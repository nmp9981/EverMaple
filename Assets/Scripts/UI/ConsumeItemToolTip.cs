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
        ItemManager.itemInstance.consumeItemToolTipDic.Add("빨간 포션", consumToolTip0);

        ConsumeToolTipText consumToolTip1 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[1], "주황 포션", "HP를 150 회복시킨다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("주황 포션", consumToolTip1);

        ConsumeToolTipText consumToolTip2 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[2], "하얀 포션", "HP를 300 회복시킨다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("하얀 포션", consumToolTip2);

        ConsumeToolTipText consumToolTip3 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[3], "파란 포션", "MP를 100 회복시킨다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("파란 포션", consumToolTip3);

        ConsumeToolTipText consumToolTip4 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[4], "마나 엘릭서", "MP를 300 회복시킨다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("마나 엘릭서", consumToolTip4);

        ConsumeToolTipText consumToolTip5 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[5], "장어구이", "HP를 1000 회복시킨다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("장어구이", consumToolTip5);

        ConsumeToolTipText consumToolTip6 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[6], "맑은 물", "MP를 800 회복시킨다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("맑은 물", consumToolTip6);

        ConsumeToolTipText consumToolTip7 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[7], "쭈쭈바", "HP를 2000 회복시킨다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("쭈쭈바", consumToolTip7);

        ConsumeToolTipText consumToolTip8 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[8], "팥빙수", "MP를 2000 회복시킨다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("팥빙수", consumToolTip8);

        ConsumeToolTipText consumToolTip9 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[9], "전사의 물약", "5분동안 물리 공격력이 5증가한다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("전사의 물약", consumToolTip9);

        ConsumeToolTipText consumToolTip10 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[10], "마법사의 물약", "5분동안 마력이 5증가한다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("마법사의 물약", consumToolTip10);

        ConsumeToolTipText consumToolTip11 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[11], "명사수의 물약", "5분동안 명중률이 10증가한다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("명사수의 물약", consumToolTip11);

        ConsumeToolTipText consumToolTip12 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[12], "민첩함의 물약", "5분동안 회피율이 10증가한다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("민첩함의 물약", consumToolTip12);

        ConsumeToolTipText consumToolTip13 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[13], "속도 향상의 물약", "5분동안 이동 속도가 10증가한다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("속도 향상의 물약", consumToolTip13);

        ConsumeToolTipText consumToolTip14 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[14], "마을 귀환 주문서", "가까운 마을로 귀환한다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("마을 귀환 주문서", consumToolTip14);

        ConsumeToolTipText consumToolTip15 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[15], "현자의 물약", "5분동안 마력이 10증가한다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("현자의 물약", consumToolTip15);

        ConsumeToolTipText consumToolTip16 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[16], "고목나무의 수액", "5분동안 마법 방어력이 10증가한다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("고목나무의 수액", consumToolTip16);

        ConsumeToolTipText consumToolTip17 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[17], "드레이크의 피", "5분동안 물리 공격력이 8증가한다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("드레이크의 피", consumToolTip17);

        ConsumeToolTipText consumToolTip18 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[18], "드레이크의 고기", "5분동안 물리 방어력이 10증가한다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("드레이크의 고기", consumToolTip18);

        ConsumeToolTipText consumToolTip19 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[19], "엘릭서", "HP, MP를 50%를 회복시킨다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("엘릭서", consumToolTip19);

        ConsumeToolTipText consumToolTip20 = new ConsumeToolTipText(ItemManager.itemInstance.consumeItemImage[20], "파워 엘릭서", "HP, MP를 100%를 회복시킨다.");
        ItemManager.itemInstance.consumeItemToolTipDic.Add("파워 엘릭서", consumToolTip20);
    }
}
