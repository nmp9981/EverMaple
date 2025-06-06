using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using static UnityEditor.Progress;

//아이템 탭 메뉴
enum ItemTab
{
    Equipment,
    Consume,
    Count
}

public class ItemUI : MonoBehaviour, IDragHandler
{
    //아이템 리스트
    [SerializeField]
    GameObject ConsumeTab;
    [SerializeField]
    GameObject EquipmentTab;
    List<GameObject> itemInventoryList = new List<GameObject>();
    List<GameObject> equipmentItemInventoryList = new List<GameObject>();
    //메소 텍스트
    [SerializeField]
    TextMeshProUGUI mesoText;

    //UI위치
    private RectTransform rectTransform;

    //현재 아이템 탭
    ItemTab itemTab;

    //총 인벤토리 개수
    const int totalInventoryCount = 24;

    #region Unity 함수
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        itemTab = ItemTab.Equipment;

        EnrollItemObjectList();
        ItemButtonBinding();
    }
    private void OnEnable()
    {
        ShowPlayerMeso();
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    #endregion

    /// <summary>
    /// 아이템 오브젝트 등록
    /// </summary>
    void EnrollItemObjectList()
    {
        foreach(var item in ConsumeTab.GetComponentsInChildren<TextMeshProUGUI>(true))
        {
            itemInventoryList.Add(item.transform.parent.gameObject);
        }
        foreach (var item in EquipmentTab.GetComponentsInChildren<TextMeshProUGUI>(true))
        {
            equipmentItemInventoryList.Add(item.transform.parent.gameObject);
        }
        //처음엔 모두 안보이게
        for (int idx = 0; idx < totalInventoryCount; idx++)
        {
            itemInventoryList[idx].SetActive(false);
            equipmentItemInventoryList[idx].SetActive(false);
        }
    }

    /// <summary>
    /// 상점 버튼 바인딩
    /// </summary>
    void ItemButtonBinding()
    {
        foreach (Button btn in gameObject.GetComponentsInChildren<Button>(true))
        {
            string gmName = btn.name;

            switch (gmName)
            {
                case "EquipmentTab":
                    btn.onClick.AddListener(ShowEquipmentInItemInventory);
                    break;
                case "ConsumeTab":
                    btn.onClick.AddListener(ShowConsumeInItemInventory);
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// 기본 스탯 보이기
    /// </summary>
    public void ShowPlayerMeso()
    {
        mesoText.text = PlayerManager.PlayerInstance.PlayerMeso.ToString();
    }

    /// <summary>
    /// 아이템 인벤토리 시각화
    /// </summary>
    public void ShowConsumeInItemInventory()
    {
        itemTab = ItemTab.Consume;

        EquipmentTab.SetActive(false);
        ConsumeTab.SetActive(true);
        int inventoryCount = ItemManager.itemInstance.consumeItems.Count;
        int ableIventoryCount = 0;

        foreach(int idx in ItemManager.itemInstance.consumeItems.Keys)
        {
            //아이템이 있는지 검사
            if (!ItemManager.itemInstance.consumeItems.ContainsKey(idx))
                continue;

            ConsumeItem item = ItemManager.itemInstance.consumeItems[idx];
            //해당 아이템이 0개일때는 표시 안함
            if (item.count == 0)
                continue;
         
            itemInventoryList[ableIventoryCount].SetActive(true);
            itemInventoryList[ableIventoryCount].GetComponent<Image>().sprite = item.sprite;
            itemInventoryList[ableIventoryCount].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.count.ToString();

            ableIventoryCount++;
        }
        //나머지는 안보이게
        for(int idx = ableIventoryCount; idx < totalInventoryCount; idx++)
        {
            itemInventoryList[idx].SetActive(false);
        }
    }

    /// <summary>
    /// 장비 인벤토리 시각화
    /// </summary>
    public void ShowEquipmentInItemInventory()
    {
        itemTab = ItemTab.Equipment;

        ConsumeTab.SetActive(false);
        EquipmentTab.SetActive(true);

        int inventoryCount = ItemManager.itemInstance.consumeItems.Count;
       
        //처음엔 안보이게
        for (int idx = 0; idx < inventoryCount; idx++)
        {
            equipmentItemInventoryList[idx].gameObject.name = "Item";
            equipmentItemInventoryList[idx].SetActive(false);
        }

        //가지고 있는 장비들이 보여야함
        for(int idx=0;idx<ItemManager.itemInstance.playerHaveEquipments.Count;idx++)
        {
            EquipmentItem item = ItemManager.itemInstance.playerHaveEquipments[idx];
            equipmentItemInventoryList[idx].SetActive(true);
            equipmentItemInventoryList[idx].GetComponent<Image>().sprite = item.sprite;
            equipmentItemInventoryList[idx].gameObject.name = item.name;
        }
    }
}
