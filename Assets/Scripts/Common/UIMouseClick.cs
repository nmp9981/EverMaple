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

    //선택한 소비 아이템
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
    /// 슬롯 버튼 바인딩
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
    /// 키 등록 오브젝트 열기
    /// </summary>
    public void OpenSettingItemKeyWindow()
    {
        selectKeyObject.SetActive(true);
    }
   
    /// <summary>
    /// 키 등록
    /// </summary>
    public void SettingItemKey(string inputKey)
    {
        //HP관련은 A, MP관련은 D로 고정, 엘릭서는 F로 고정
        //이미지 이름으로 구분
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
    /// 키 등록 취소
    /// </summary>
    public void CancelEnrollKey()
    {
        enrollKwySlotObject.SetActive(false);
    }

    /// <summary>
    /// 장비 장착
    /// </summary>
    public void EquipmentInstallation()
    {
        //선택한 오브젝트가 없음
        if (clickedConsumeObject == null)
        {
            enrollKeySlotEquipmentObject.SetActive(false);
            return;
        }

        //장비의 정보를 받아야함
        EquiipmentOption equipmentOption = ItemManager.itemInstance.equipmentItemDic[clickedConsumeObject.gameObject.name];

        //장비 장착이 가능한지 검사
        if (equipmentUI.CheckAbleUseEquipment(equipmentOption))
        {
            //해당 장비의 능력치 적용
            equipmentUI.AddEquipmentOption(equipmentOption);
        }

        enrollKeySlotEquipmentObject.SetActive(false);
    }
    /// <summary>
    /// 장비 삭제
    /// </summary>
    public void DeleteEquipmentInItemUI()
    {
        //선택한 오브젝트가 없음
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
    /// 장비 UI 취소
    /// </summary>
    public void CancelEquipmentInItemUI()
    {
        enrollKeySlotEquipmentObject.SetActive(false);
    }
    /// <summary>
    /// 장착한 장비 착용 취소
    /// </summary>
    public void CancelEquipmentInstallation()
    {
        //해당 장비 옵션 만큼 능력치를 빼야함
        EquiipmentOption equipmentOption = ItemManager.itemInstance.equipmentItemDic[clickedConsumeObject.gameObject.name];
        equipmentUI.MinusEquipmentOption(equipmentOption);
    }
}