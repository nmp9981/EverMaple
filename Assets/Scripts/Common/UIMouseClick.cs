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

    //������ �Һ� ������
    public GameObject clickedConsumeObject = null;
    RectTransform enrollKwyRectTrans;
    RectTransform enrollKeyEquipmentRectTrans;

    #region ��� ���� ���
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
        }else if(clickedObject.tag == "EquipmentUI")//��� ���� ���
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
   /// ��� ���� �ؽ�Ʈ ���ε�
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
        //��� ���� UI ����
        equipmentInfoUI.SetActive(false);

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
        else
        {
            notWearUI.SetActive(true);
        }

        enrollKeySlotEquipmentObject.SetActive(false);
    }

    /// <summary>
    /// ��� ���� ����
    /// </summary>
    public void ShowEquipemntInfo()
    {
        //������ ������Ʈ�� ����
        if (clickedConsumeObject == null)
        {
            equipmentInfoUI.SetActive(false);
            return;
        }

        //����� ������ �޾ƾ���
        EquiipmentOption equipmentOption = ItemManager.itemInstance.equipmentItemDic[clickedConsumeObject.gameObject.name];
        
        //��� ���� ���
        RecordEquipmentInfo(equipmentOption);

        equipmentInfoUI.SetActive(true);
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
        equipmentInfoUI.SetActive(false);
        enrollKeySlotEquipmentObject.SetActive(false);
    }

    /// <summary>
    /// ���� �Ұ� UI����
    /// </summary>
    public void CheckNotWearUI()
    {
        notWearUI.SetActive(false);
    }

    /// <summary>
    /// ��� ���� ���
    /// </summary>
    /// <param name="equip"></param>
    void RecordEquipmentInfo(EquiipmentOption equip)
    {
        //�̸�
        equipmentName.text = equip.name;

        //�̹���
        equipImage.sprite = equip.equipmentImage;

        //����
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

        //�ɼ�
        switch (equip.equipmentType)
        {
            case EquipmentType.Claw:
                classText.text = "��� �з� : �ƴ�";
                break;
            case EquipmentType.Knife:
                classText.text = "��� �з� : �ܰ�";
                break;
            case EquipmentType.Hat:
                classText.text = "��� �з� : ����";
                break;
            case EquipmentType.Up:
                classText.text = "��� �з� : ����";
                break;
            case EquipmentType.Down:
                classText.text = "��� �з� : ����";
                break;
            case EquipmentType.Shoes:
                classText.text = "��� �з� : �Ź�";
                break;
            case EquipmentType.Cape:
                classText.text = "��� �з� : ����";
                break;
            case EquipmentType.Earing:
                classText.text = "��� �з� : �̾";
                break;
            case EquipmentType.Glove:
                classText.text = "��� �з� : �尩";
                break;
            default:
                break;
        }

        if (equip.addAttack != 0)
        {
            attackText.text = $"���ݷ� : +{equip.addAttack}";
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
            pdText.text = $"�������� : +{equip.addPhysicsArmor}";
            pdText.gameObject.SetActive(true);
        }
        else pdText.gameObject.SetActive(false);

        if (equip.addMagicArmor != 0)
        {
            mbText.text = $"�������� : +{equip.addMagicArmor}";
            mbText.gameObject.SetActive(true);
        }
        else mbText.gameObject.SetActive(false);

        if (equip.addAvoid != 0)
        {
            avoidText.text = $"ȸ���� : +{equip.addAvoid}";
            avoidText.gameObject.SetActive(true);
        }
        else avoidText.gameObject.SetActive(false);
    }
}