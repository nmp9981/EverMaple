using UnityEngine;
using UnityEngine.UI;

public class MonsterDropItem : MonoBehaviour
{
    string playerTag = "Player";

    public string itemName;
    public SpriteRenderer itemImage;

    private void Awake()
    {
        itemImage = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        itemImage.sprite = ItemManager.itemInstance.equipmentItemDic[itemName].equipmentImage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            //���ο� ��� ������ ���� �߰�
            EquipmentItem equipmentItem = new EquipmentItem();
            equipmentItem.sprite = itemImage.sprite;
            equipmentItem.name = itemName;

            ItemManager.itemInstance.playerHaveEquipments.Add(equipmentItem);
            Destroy(gameObject);
        }
    }
}
