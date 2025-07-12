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
    [SerializeField]
    GameObject notWearUI;
    [SerializeField]
    GameObject equipmentInfoUI;

    //선택한 소비 아이템
    public GameObject clickedConsumeObject = null;
    RectTransform enrollKwyRectTrans;
    RectTransform enrollKeyEquipmentRectTrans;

    #region 장비 정보 기록
    [SerializeField]
    Image equipImage;
    TextMeshProUGUI equipmentName;

    TextMeshProUGUI reqLvText;
    TextMeshProUGUI reqSTRText;
    TextMeshProUGUI reqDEXText;
    TextMeshProUGUI reqINTText;
    TextMeshProUGUI reqLUKText;

    TextMeshProUGUI classText;
    TextMeshProUGUI strText;
    TextMeshProUGUI dexText;
    TextMeshProUGUI intText;
    TextMeshProUGUI lukText;
    TextMeshProUGUI attackText;
    TextMeshProUGUI pdText;
    TextMeshProUGUI mbText;
    TextMeshProUGUI avoidText;
    #endregion



    void Awake()
    {
        enrollKwyRectTrans = enrollKwySlotObject.GetComponent<RectTransform>();
        enrollKeyEquipmentRectTrans = enrollKeySlotEquipmentObject.GetComponent<RectTransform>();
        SlotButtonBinding();
        BindingEquipmentInfoUI();
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
        }else if(clickedObject.tag == "EquipmentUI")//장비 장착 취소
        {
            equipmentUI.CancelEquipmentInstallaion(clickedObject.gameObject.name);
        }
        else
        {
            clickedConsumeObject = null;
            enrollKwySlotObject.SetActive(false);
        }

        equipmentInfoUI.gameObject.SetActive(false);
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
   /// 장비 정보 텍스트 바인딩
   /// </summary>
    void BindingEquipmentInfoUI()
    {
        foreach (TextMeshProUGUI txt in equipmentInfoUI.GetComponentsInChildren<TextMeshProUGUI>(true))
        {
            string btnName = txt.gameObject.name;

            switch (btnName)
            {
                case "EquipmentName":
                    equipmentName = txt;
                    break;
                case "reqLv":
                    reqLvText = txt;
                    break;
                case "ReqSTR":
                    reqSTRText = txt;
                    break;
                case "ReqDEX":
                    reqDEXText = txt;
                    break;
                case "ReqINT":
                    reqINTText = txt;
                    break;
                case "ReqLUK":
                    reqLUKText = txt;
                    break;
                case "Class":
                    classText = txt;
                    break;
                case "Str":
                    strText = txt;
                    break;
                case "Dex":
                    dexText = txt;
                    break;
                case "Int":
                    intText = txt;
                    break;
                case "Luk":
                    lukText = txt;
                    break;
                case "Attack":
                    attackText = txt;
                    break;
                case "PD":
                    pdText = txt;
                    break;
                case "MD":
                    mbText = txt;
                    break;
                case "Avoid":
                    avoidText = txt;
                    break;
                default:
                    break;
            }
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
        //장비 정보 UI 끄기
        equipmentInfoUI.SetActive(false);

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
        else
        {
            notWearUI.SetActive(true);
        }

        enrollKeySlotEquipmentObject.SetActive(false);
    }

    /// <summary>
    /// 장비 정보 보기
    /// </summary>
    public void ShowEquipemntInfo()
    {
        //선택한 오브젝트가 없음
        if (clickedConsumeObject == null)
        {
            equipmentInfoUI.SetActive(false);
            return;
        }

        //장비의 정보를 받아야함
        EquiipmentOption equipmentOption = ItemManager.itemInstance.equipmentItemDic[clickedConsumeObject.gameObject.name];
        
        //장비 정보 기록
        RecordEquipmentInfo(equipmentOption);

        equipmentInfoUI.SetActive(true);
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
        equipmentInfoUI.SetActive(false);
        enrollKeySlotEquipmentObject.SetActive(false);
    }

    /// <summary>
    /// 장착 불가 UI제거
    /// </summary>
    public void CheckNotWearUI()
    {
        notWearUI.SetActive(false);
    }

    /// <summary>
    /// 장비 정보 기록
    /// </summary>
    /// <param name="equip"></param>
    void RecordEquipmentInfo(EquiipmentOption equip)
    {
        //이름
        equipmentName.text = equip.name;

        //이미지
        equipImage.sprite = equip.equipmentImage;

        //제한
        reqLvText.text = $"Req Lv : {equip.reqLv}";
        if (PlayerManager.PlayerInstance.PlayerLV >= equip.reqLv)
            reqLvText.color = Color.white;
        else reqLvText.color = Color.red;

        reqSTRText.text = $"Req STR : {equip.reqSTR}";
        if (PlayerManager.PlayerInstance.PlayerSTR + PlayerManager.PlayerInstance.PlayerAddSTR >= equip.reqSTR)
            reqSTRText.color = Color.white;
        else reqSTRText.color = Color.red;

        reqDEXText.text = $"Req DEX : {equip.reqDEX}";
        if (PlayerManager.PlayerInstance.PlayerDEX + PlayerManager.PlayerInstance.PlayerAddDEX >= equip.reqDEX)
            reqDEXText.color = Color.white;
        else reqDEXText.color = Color.red;

        reqINTText.text = $"Req INT : {equip.reqINT}";
        if (PlayerManager.PlayerInstance.PlayerINT + PlayerManager.PlayerInstance.PlayerAddINT >= equip.reqINT)
            reqINTText.color = Color.white;
        else reqINTText.color = Color.red;

        reqLUKText.text = $"Req LUK : {equip.reqLUK}";
        if (PlayerManager.PlayerInstance.PlayerLUK + PlayerManager.PlayerInstance.PlayerAddLUK >= equip.reqLUK)
            reqLUKText.color = Color.white;
        else reqLUKText.color = Color.red;

        //옵션
        switch (equip.equipmentType)
        {
            case EquipmentType.Claw:
                classText.text = "장비 분류 : 아대";
                break;
            case EquipmentType.Knife:
                classText.text = "장비 분류 : 단검";
                break;
            case EquipmentType.Hat:
                classText.text = "장비 분류 : 모자";
                break;
            case EquipmentType.Up:
                classText.text = "장비 분류 : 상의";
                break;
            case EquipmentType.Down:
                classText.text = "장비 분류 : 하의";
                break;
            case EquipmentType.Shoes:
                classText.text = "장비 분류 : 신발";
                break;
            case EquipmentType.Cape:
                classText.text = "장비 분류 : 망토";
                break;
            case EquipmentType.Earing:
                classText.text = "장비 분류 : 이어링";
                break;
            case EquipmentType.Glove:
                classText.text = "장비 분류 : 장갑";
                break;
            default:
                break;
        }

        if (equip.addAttack != 0)
        {
            attackText.text = $"공격력 : +{equip.addAttack}";
            attackText.gameObject.SetActive(true);
        }
        else attackText.gameObject.SetActive(false);

        if (equip.addSTR != 0)
        {
            strText.text = $"STR : +{equip.addSTR}";
            strText.gameObject.SetActive(true);
        }
        else strText.gameObject.SetActive(false);

        if (equip.addDEX != 0)
        {
            dexText.text = $"DEX : +{equip.addDEX}";
            dexText.gameObject.SetActive(true);
        }
        else dexText.gameObject.SetActive(false);

        if (equip.addINT != 0)
        {
            intText.text = $"INT : +{equip.addINT}";
            intText.gameObject.SetActive(true);
        }
        else intText.gameObject.SetActive(false);

        if (equip.addLUK != 0)
        {
            lukText.text = $"LUK : +{equip.addLUK}";
            lukText.gameObject.SetActive(true);
        }
        else lukText.gameObject.SetActive(false);

        if (equip.addPhysicsArmor != 0)
        {
            pdText.text = $"물리방어력 : +{equip.addPhysicsArmor}";
            pdText.gameObject.SetActive(true);
        }
        else pdText.gameObject.SetActive(false);

        if (equip.addMagicArmor != 0)
        {
            mbText.text = $"마법방어력 : +{equip.addMagicArmor}";
            mbText.gameObject.SetActive(true);
        }
        else mbText.gameObject.SetActive(false);

        if (equip.addAvoid != 0)
        {
            avoidText.text = $"회피율 : +{equip.addAvoid}";
            avoidText.gameObject.SetActive(true);
        }
        else avoidText.gameObject.SetActive(false);
    }
}