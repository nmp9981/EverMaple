using UnityEngine;

public class MonsterDropItem : MonoBehaviour
{
    string playerTag = "Player";

    PlayerInfoUI playerInfoUI;

    public string itemName;
    public SpriteRenderer itemImage;

    float curTime = 0;
    private void Awake()
    {
        itemImage = GetComponent<SpriteRenderer>();
        playerInfoUI = GameObject.Find("UserInfo").GetComponent<PlayerInfoUI>();
    }
    private void Start()
    {
        itemImage.sprite = ItemManager.itemInstance.equipmentItemDic[itemName].equipmentImage;
    }


    private void OnEnable()
    {
        curTime = 0;
    }

    private void Update()
    {
        TimeOut();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            //새로운 장비 아이템 정보 추가
            EquipmentItem equipmentItem = new EquipmentItem();
            equipmentItem.sprite = itemImage.sprite;
            equipmentItem.name = itemName;

            if (ItemManager.itemInstance.playerHaveEquipments.Count < 24)
            {
                ItemManager.itemInstance.playerHaveEquipments.Add(equipmentItem);
                playerInfoUI.ShowGetItemMessage(itemName);
                SoundManager._sound.PlaySfx(24);
                Destroy(gameObject);
            }
            else
            {
                playerInfoUI.ShowNotGetItemMessage();
            }
            
        }
    }

    /// <summary>
    /// 시간 초과
    /// </summary>
    void TimeOut()
    {
        curTime += Time.deltaTime;
        if(curTime>100)
            Destroy(gameObject);
    }
}
