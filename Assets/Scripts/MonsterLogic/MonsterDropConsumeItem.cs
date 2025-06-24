using UnityEngine;

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
            //���ο� ������
            if (!ItemManager.itemInstance.consumeItems.ContainsKey(itemIndex))
            {
                //���ο� ������ ���� �߰�
                ConsumeItem consumeItem = new ConsumeItem();
                consumeItem.sprite = ItemManager.itemInstance.consumeItemImage[itemIndex];
                consumeItem.name = consumeItem.sprite.name;
                consumeItem.count = itemCount;
                ItemManager.itemInstance.consumeItems.Add(itemIndex, consumeItem);
            }
            else//���� �����ۿ��� �߰�
            {
                ConsumeItem curConsumeItem = ItemManager.itemInstance.consumeItems[itemIndex];
                curConsumeItem.count += itemCount;
                ItemManager.itemInstance.consumeItems[itemIndex] = curConsumeItem;
            }

            SoundManager._sound.PlaySfx(24);
            playerInfoUI.ShowGetItemMessage(ItemManager.itemInstance.consumeItems[itemIndex].name);
            Destroy(gameObject);
        }
    }
}
