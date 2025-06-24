using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ConsumeNPC : NPCCommon
{
    [SerializeField]
    GameObject consumeListObj;
    [SerializeField]
    GameObject equipmentListObj;
    [SerializeField]
    GameObject equipmentTotalListObj;//���� ���

    [SerializeField]
    GameObject buyConsumeUI;
    [SerializeField]
    GameObject buyEquipmentUI;

    [SerializeField]
    Image playerImage;
    [SerializeField]
    Image npcImage;
    [SerializeField]
    TextMeshProUGUI mesoText;

    private int itemCount = 0;
    private SpriteRenderer spriteRenderer;

    //������ �Һ� ������
    private (int idx,int price) curBuyConsumeInfo = (-1,-1);
    private List<GameObject> equipmentListInStore = new List<GameObject>();
    //������ ��� ������
    private (int idx, int price, string name, Sprite sprite) curBuyEquipmentInfo = (-1, -1, string.Empty, null);

    //UI��ġ
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        spriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        StoreButtonBinding();
        BindingInputfeild();
        EnrollEquipmentInstore();
    }

    private void OnEnable()
    {
        ShowStoreUI();
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }
    /// <summary>
    /// ���� ��ư ���ε�
    /// </summary>
    void StoreButtonBinding()
    {
        foreach (Button btn in gameObject.GetComponentsInChildren<Button>(true))
        {
            string gmName = btn.name;

            //�Һ� ������
            if (gmName.Contains("Goods") && !gmName.Contains("Equipment"))
            {
                btn.onClick.AddListener(delegate { SettingCutSelectConsumeItem(btn.gameObject); });
                continue;
            }
            //��� ������
            if (gmName.Contains("EquipmentGoods"))
            {
                btn.onClick.AddListener(delegate { SettingCutSelectEqiupmentItem(btn.gameObject); });
                continue;
            }

            switch (gmName)
            {
                case "StoreExit":
                    btn.onClick.AddListener(OutStore);
                    break;
                case "ItemBuy":
                    btn.onClick.AddListener(delegate { QuestionItemBuy(btn.gameObject); });
                    break;
                case "ItemSell":
                    break;
                case "ConsumeBuySucccess":
                    btn.onClick.AddListener(SuccessConsumeItemBuy);
                    break;
                case "ConsumeBuyCancel":
                    btn.onClick.AddListener(CancelConsumeItemBuy);
                    break;
                case "EquipmentBuySucccess":
                    btn.onClick.AddListener(SuccessEquipmentItemBuy);
                    break;
                case "EquipmentBuyCancel":
                    btn.onClick.AddListener(CancelEquipmentItemBuy);
                    break;
                default:
                    break;
            }
        }
    }

    void BindingInputfeild()
    {
        foreach (TMP_InputField inp in gameObject.GetComponentsInChildren<TMP_InputField>(true))
        {
            string gmName = inp.gameObject.name;
            switch (gmName)
            {
                case "BuyCountText":
                    inp.onEndEdit.AddListener(delegate { SettingCountItem(inp); });
                    break;
                default:
                    break;
            }
        }
    }
    public void SettingCountItem(TMP_InputField inp)
    {
        itemCount = int.Parse(inp.text);
    }

    /// <summary>
    /// ���� UI ���� ǥ��
    /// </summary>
    void ShowStoreUI()
    {
        //�÷��̾� �̹��� ǥ��
        playerImage.sprite = spriteRenderer.sprite;
        //NPC�̹��� ǥ��
        npcImage.sprite = NPCCommon.npcSprite;
        //�޼� ǥ��
        mesoText.text = PlayerManager.PlayerInstance.PlayerMeso.ToString();
        //��ǰ ����Ʈ ���̱�
        ShowGoodsList();
    }

    /// <summary>
    /// ��ǰ ����Ʈ ���̱�
    /// </summary>
    void ShowGoodsList()
    {
        //�Һ� ����Ʈ
        if (storeNPCIndex.Item1 == 0)
        {
            equipmentListObj.gameObject.SetActive(false);
            consumeListObj.gameObject.SetActive(true);
        }
        else//��� ����Ʈ
        {
            consumeListObj.gameObject.SetActive(false);
            equipmentListObj.gameObject.SetActive(true);

            //�Ǹ��� ��� ���մϴ�.
            DecideSellEquipment();
        }
    }

    /// <summary>
    /// ���� ������
    /// </summary>
    public void OutStore()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// ���� ������ ������ ����
    /// </summary>
    public void SettingCutSelectConsumeItem(GameObject btn)
    {
        curBuyConsumeInfo.idx = int.Parse(btn.gameObject.name.Substring(5));
        string priceText = btn.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        curBuyConsumeInfo.price = int.Parse(priceText.Substring(0, priceText.Length - 3));
    }
    /// <summary>
    /// ������ ���� Ȯ�� ����
    /// </summary>
    /// <param name="btn"></param>
    public void QuestionItemBuy(GameObject btn)
    {
        //���� â ����
        if (storeNPCIndex.Item1 == 0)
        {
            buyConsumeUI.SetActive(true);
        }
        else if(storeNPCIndex.Item1 == 1)
            buyEquipmentUI.SetActive(true);
    }

    /// <summary>
    /// �Һ������ ���� ���
    /// </summary>
    public void CancelConsumeItemBuy()
    {
        curBuyConsumeInfo.idx = -1;
        curBuyConsumeInfo.price = -1;

        buyConsumeUI.SetActive(false);
    }
    /// <summary>
    /// �Һ������ ���� Ȯ��
    /// </summary>
    public void SuccessConsumeItemBuy()
    {
        //������ �������� ����
        if (curBuyConsumeInfo.idx == -1)
        {
            return;
        }

        //���� ���� ����
        if(itemCount > 0)
        {
            int totalPrice = itemCount * curBuyConsumeInfo.price;

            //���Ű���
            if(totalPrice <= PlayerManager.PlayerInstance.PlayerMeso)
            {
                PlayerManager.PlayerInstance.PlayerMeso -= totalPrice;
                mesoText.text = PlayerManager.PlayerInstance.PlayerMeso.ToString();

                //���ο� ������
                if (!ItemManager.itemInstance.consumeItems.ContainsKey(curBuyConsumeInfo.idx))
                {
                    //���ο� ������ ���� �߰�
                    ConsumeItem consumeItem = new ConsumeItem();
                    consumeItem.sprite = ItemManager.itemInstance.consumeItemImage[curBuyConsumeInfo.idx];
                    consumeItem.name = consumeItem.sprite.name;
                    consumeItem.count = itemCount;
                    ItemManager.itemInstance.consumeItems.Add(curBuyConsumeInfo.idx,consumeItem);
                }
                else//���� �����ۿ��� �߰�
                {
                    ConsumeItem curConsumeItem = ItemManager.itemInstance.consumeItems[curBuyConsumeInfo.idx];
                    curConsumeItem.count += itemCount;
                    ItemManager.itemInstance.consumeItems[curBuyConsumeInfo.idx] = curConsumeItem;
                }
                
                CancelConsumeItemBuy();
            }
            else
            {

            }
        }
    }

    /// <summary>
    /// ���� ������ ��� ������ ����
    /// </summary>
    public void SettingCutSelectEqiupmentItem(GameObject btn)
    {
        curBuyEquipmentInfo.idx = int.Parse(btn.gameObject.name.Substring(17,2));
        string priceText = btn.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        curBuyEquipmentInfo.price = int.Parse(priceText.Substring(0, priceText.Length - 3));
        curBuyEquipmentInfo.name = btn.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        curBuyEquipmentInfo.sprite = btn.gameObject.transform.GetChild(2).GetComponent<Image>().sprite;
    }

    /// <summary>
    /// �������� ���� ���
    /// </summary>
    public void CancelEquipmentItemBuy()
    {
        curBuyEquipmentInfo.idx = -1;
        curBuyEquipmentInfo.price = -1;
        curBuyEquipmentInfo.name = string.Empty;
        curBuyEquipmentInfo.sprite = null;

        buyEquipmentUI.SetActive(false);
    }
    /// <summary>
    /// �������� ���� Ȯ��
    /// </summary>
    public void SuccessEquipmentItemBuy()
    {
        //������ ��� ����
        if (curBuyEquipmentInfo.idx == -1)
        {
            return;
        }

        //���Ű���
        if (curBuyEquipmentInfo.price <= PlayerManager.PlayerInstance.PlayerMeso)
        {
            PlayerManager.PlayerInstance.PlayerMeso -= curBuyEquipmentInfo.price;
            mesoText.text = PlayerManager.PlayerInstance.PlayerMeso.ToString();

            //���ο� ��� ������ ���� �߰�
            EquipmentItem equipmentItem = new EquipmentItem();
            equipmentItem.sprite = curBuyEquipmentInfo.sprite;
            equipmentItem.name = curBuyEquipmentInfo.name;

            ItemManager.itemInstance.playerHaveEquipments.Add(equipmentItem);
            CancelEquipmentItemBuy();
        }
        else
        {

        }

        buyEquipmentUI.SetActive(false);
    }

    /// <summary>
    /// ������ �ִ� ��� ���
    /// </summary>
    void EnrollEquipmentInstore()
    {
        foreach (Transform equip in equipmentTotalListObj.GetComponentInChildren<Transform>())
        {
            equipmentListInStore.Add(equip.gameObject);
        }
    }

    /// <summary>
    /// �Ǹ��� ���
    /// </summary>
    void DecideSellEquipment()
    {
        //��ǰ ��� ��
        foreach(GameObject equip in equipmentListInStore)
        {
            equip.SetActive(false);
        }

        //ĳ���Ͱ� �ִ� ������ ���� ����
        int[] setEquipmentNums = new int[12];
        switch (MapManager.playerMapLocal)
        {
            case LocalMapName.Henesys:
                setEquipmentNums = new int[]{0,1,9,17,22,23,28,29,34,35,40,43};
                break;
            case LocalMapName.Ellinia:
                setEquipmentNums = new int[] { 2,3,10,11,18,24,30,36,-1,-1,-1,-1 };
                break;
            case LocalMapName.Perion:
                setEquipmentNums = new int[] {3,4,11,12,19,25,31,37,41,44,-1,-1};
                break;
            case LocalMapName.KerningCity:
                setEquipmentNums = new int[] { 5,6,13,14,20,26,32,38, -1, -1, -1, -1 };
                break;
            case LocalMapName.SleepyWood:
                setEquipmentNums = new int[] { 7,8,15,16,21,27,33,39,42,45, -1, -1 };
                break;
            default:
                break;
        }

        //�ش� ��ǰ�� �Ҵ�
        foreach(int equipNum in setEquipmentNums)
        {
            if (equipNum == -1)
                continue;
            equipmentListInStore[equipNum].SetActive(true);
        }
    }
}
