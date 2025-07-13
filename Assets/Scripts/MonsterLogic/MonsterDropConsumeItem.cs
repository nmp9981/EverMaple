using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MonsterDropConsumeItem : MonoBehaviour
{
    string playerTag = "Player";

    PlayerInfoUI playerInfoUI;

    public int itemIndex;
    public int itemCount;
    public SpriteRenderer itemImage;

    private void Awake()
    {
        itemImage = GetComponent<SpriteRenderer>();
        playerInfoUI = GameObject.Find("UserInfo").GetComponent<PlayerInfoUI>();
    }
    private void Start()
    {
        itemImage.sprite = ItemManager.itemInstance.consumeItemImage[itemIndex];
        itemCount = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            //새로운 아이템
            if (!ItemManager.itemInstance.consumeItems.ContainsKey(itemIndex))
            {
                //새로운 아이템 정보 추가
                ConsumeItem consumeItem = new ConsumeItem();
                consumeItem.sprite = ItemManager.itemInstance.consumeItemImage[itemIndex];
                consumeItem.name = consumeItem.sprite.name;
                consumeItem.count = itemCount;
                ItemManager.itemInstance.consumeItems.Add(itemIndex, consumeItem);
            }
            else//기존 아이템에서 추가
            {
                ConsumeItem curConsumeItem = ItemManager.itemInstance.consumeItems[itemIndex];
                curConsumeItem.count += itemCount;
                ItemManager.itemInstance.consumeItems[itemIndex] = curConsumeItem;

                AddConsumeItemInKeySlot(curConsumeItem);
            }

            SoundManager._sound.PlaySfx(24);
            playerInfoUI.ShowGetItemMessage(ItemManager.itemInstance.consumeItems[itemIndex].name);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 키슬롯에 소비아이템 추가
    /// </summary>
    void AddConsumeItemInKeySlot(ConsumeItem curConsumeItem)
    {
        //itemIndex는 실제 아이템 인덱스
        if (itemIndex == ItemManager.itemInstance.UseHPPosionIndex)
            ItemManager.itemInstance.keySlotImage[0].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = curConsumeItem.count.ToString();
        else if (itemIndex == ItemManager.itemInstance.UseMPPosionIndex)
            ItemManager.itemInstance.keySlotImage[1].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = curConsumeItem.count.ToString();
        else if (itemIndex == ItemManager.itemInstance.UseElixerPosionIndex)
            ItemManager.itemInstance.keySlotImage[2].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = curConsumeItem.count.ToString();
        else//버프 물약
        {
            int inputKey = -1;
            foreach (var key in ItemManager.itemInstance.keySlotBuffItems)
            {
                if (key.Value == itemIndex)
                    inputKey = key.Key;
            }
            if (inputKey != -1)
                ItemManager.itemInstance.keySlotImage[inputKey].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = curConsumeItem.count.ToString();
        }
    }
}
