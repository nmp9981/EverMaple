using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIMouseClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject enrollKwySlotObject;
    [SerializeField]
    GameObject enrollKeySlotEquipmentObject;
    [SerializeField]
    GameObject selectKeyObject;
    [SerializeField]
    ItemUI itemUI;
    [SerializeField]
    EquiipmentUI equipmentUI;

    //������ �Һ� ������
    public GameObject clickedConsumeObject = null;
    RectTransform enrollKwyRectTrans;
    RectTransform enrollKeyEquipmentRectTrans;

    void Awake()
    {
        enrollKwyRectTrans = enrollKwySlotObject.GetComponent<RectTransform>();
        enrollKeyEquipmentRectTrans = enrollKeySlotEquipmentObject.GetComponent<RectTransform>();
        SlotButtonBinding();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
        if(clickedObject.tag == ItemManager.consumeTag)
        {
            clickedConsumeObject = clickedObject;
            enrollKwySlotObject.SetActive(true);
            enrollKwyRectTrans.position = Input.mousePosition + new Vector3(30,-30,0);
        }else if(clickedObject.tag == ItemManager.equipmentTag)
        {
            clickedConsumeObject = clickedObject;
            enrollKeySlotEquipmentObject.SetActive(true);
            enrollKeyEquipmentRectTrans.position = Input.mousePosition + new Vector3(30, -30, 0);
        }
        else
        {
            clickedConsumeObject = null;
            enrollKwySlotObject.SetActive(false);
        }
    }

    /// <summary>
    /// ���� ��ư ���ε�
    /// </summary>
    void SlotButtonBinding()
    {
        foreach (Button btn in selectKeyObject.GetComponentsInChildren<Button>(true))
        {
            string btnName = btn.gameObject.name;
            if (!btn.name.Contains("Key"))
                continue;

            btn.onClick.AddListener(delegate { SettingItemKey(btnName.Substring(3)); });
        }
    }

    /// <summary>
    /// Ű ��� ������Ʈ ����
    /// </summary>
    public void OpenSettingItemKeyWindow()
    {
        selectKeyObject.SetActive(true);
    }
   
    /// <summary>
    /// Ű ���
    /// </summary>
    public void SettingItemKey(string inputKey)
    {
        //HP������ A, MP������ D�� ����, �������� F�� ����
        //�̹��� �̸����� ����
        string itemName = clickedConsumeObject.GetComponent<Image>().sprite.name;
        switch (inputKey)
        {
            case "A":
                ItemManager.itemInstance.EnrollHPPosion(itemName);
                break;
            case "D":
                ItemManager.itemInstance.EnrollMPPosion(itemName);
                break;
            case "F":
                ItemManager.itemInstance.EnrollElixerPosion(itemName);
                break;
            default:
                ItemManager.itemInstance.EnrollBuffPosion(itemName,inputKey);
                break;
        }
    }

    /// <summary>
    /// Ű ��� ���
    /// </summary>
    public void CancelEnrollKey()
    {
        enrollKwySlotObject.SetActive(false);
    }

    /// <summary>
    /// ��� ����
    /// </summary>
    public void EquipmentInstallation()
    {
        //������ ������Ʈ�� ����
        if (clickedConsumeObject == null)
        {
            enrollKeySlotEquipmentObject.SetActive(false);
            return;
        }

        //����� ������ �޾ƾ���
        EquiipmentOption equipmentOption = ItemManager.itemInstance.equipmentItemDic[clickedConsumeObject.gameObject.name];

        //��� ������ �������� �˻�
        if (equipmentUI.CheckAbleUseEquipment(equipmentOption))
        {
            //�ش� ����� �ɷ�ġ ����
            equipmentUI.AddEquipmentOption(equipmentOption);
        }

        enrollKeySlotEquipmentObject.SetActive(false);
    }
    /// <summary>
    /// ��� ����
    /// </summary>
    public void DeleteEquipmentInItemUI()
    {
        //������ ������Ʈ�� ����
        if (clickedConsumeObject == null)
        {
            enrollKeySlotEquipmentObject.SetActive(false);
            return;
        }

        int index = int.Parse(clickedConsumeObject.GetComponentInChildren<TextMeshProUGUI>().text);
        itemUI.EraseEquipmentInItemInventory(index, clickedConsumeObject.gameObject.name);
        clickedConsumeObject.gameObject.name = "NULL";

        enrollKeySlotEquipmentObject.SetActive(false);
    }

    /// <summary>
    /// ��� UI ���
    /// </summary>
    public void CancelEquipmentInItemUI()
    {
        enrollKeySlotEquipmentObject.SetActive(false);
    }
    /// <summary>
    /// ������ ��� ���� ���
    /// </summary>
    public void CancelEquipmentInstallation()
    {
        //�ش� ��� �ɼ� ��ŭ �ɷ�ġ�� ������
        EquiipmentOption equipmentOption = ItemManager.itemInstance.equipmentItemDic[clickedConsumeObject.gameObject.name];
        equipmentUI.MinusEquipmentOption(equipmentOption);
    }
}