using UnityEngine;

public class MonsterDropConsumeItem : MonoBehaviour
{
    string playerTag = "Player";

    public int itemIndex;
    public int itemCount;
    public SpriteRenderer itemImage;

    private void Awake()
    {
        itemImage = GetComponent<SpriteRenderer>();
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
            Destroy(gameObject);
        }
    }
}
