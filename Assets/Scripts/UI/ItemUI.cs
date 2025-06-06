using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using static UnityEditor.Progress;

//������ �� �޴�
enum ItemTab
{
    Equipment,
    Consume,
    Count
}

public class ItemUI : MonoBehaviour, IDragHandler
{
    //������ ����Ʈ
    [SerializeField]
    GameObject ConsumeTab;
    [SerializeField]
    GameObject EquipmentTab;
    List<GameObject> itemInventoryList = new List<GameObject>();
    List<GameObject> equipmentItemInventoryList = new List<GameObject>();
    //�޼� �ؽ�Ʈ
    [SerializeField]
    TextMeshProUGUI mesoText;

    //UI��ġ
    private RectTransform rectTransform;

    //���� ������ ��
    ItemTab itemTab;

    //�� �κ��丮 ����
    const int totalInventoryCount = 24;

    #region Unity �Լ�
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
    /// ������ ������Ʈ ���
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
        //ó���� ��� �Ⱥ��̰�
        for (int idx = 0; idx < totalInventoryCount; idx++)
        {
            itemInventoryList[idx].SetActive(false);
            equipmentItemInventoryList[idx].SetActive(false);
        }
    }

    /// <summary>
    /// ���� ��ư ���ε�
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
    /// �⺻ ���� ���̱�
    /// </summary>
    public void ShowPlayerMeso()
    {
        mesoText.text = PlayerManager.PlayerInstance.PlayerMeso.ToString();
    }

    /// <summary>
    /// ������ �κ��丮 �ð�ȭ
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
            //�������� �ִ��� �˻�
            if (!ItemManager.itemInstance.consumeItems.ContainsKey(idx))
                continue;

            ConsumeItem item = ItemManager.itemInstance.consumeItems[idx];
            //�ش� �������� 0���϶��� ǥ�� ����
            if (item.count == 0)
                continue;
         
            itemInventoryList[ableIventoryCount].SetActive(true);
            itemInventoryList[ableIventoryCount].GetComponent<Image>().sprite = item.sprite;
            itemInventoryList[ableIventoryCount].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.count.ToString();

            ableIventoryCount++;
        }
        //�������� �Ⱥ��̰�
        for(int idx = ableIventoryCount; idx < totalInventoryCount; idx++)
        {
            itemInventoryList[idx].SetActive(false);
        }
    }

    /// <summary>
    /// ��� �κ��丮 �ð�ȭ
    /// </summary>
    public void ShowEquipmentInItemInventory()
    {
        itemTab = ItemTab.Equipment;

        ConsumeTab.SetActive(false);
        EquipmentTab.SetActive(true);

        int inventoryCount = ItemManager.itemInstance.consumeItems.Count;
       
        //ó���� �Ⱥ��̰�
        for (int idx = 0; idx < inventoryCount; idx++)
        {
            equipmentItemInventoryList[idx].gameObject.name = "Item";
            equipmentItemInventoryList[idx].SetActive(false);
        }

        //������ �ִ� ������ ��������
        for(int idx=0;idx<ItemManager.itemInstance.playerHaveEquipments.Count;idx++)
        {
            EquipmentItem item = ItemManager.itemInstance.playerHaveEquipments[idx];
            equipmentItemInventoryList[idx].SetActive(true);
            equipmentItemInventoryList[idx].GetComponent<Image>().sprite = item.sprite;
            equipmentItemInventoryList[idx].gameObject.name = item.name;
        }
    }
}
