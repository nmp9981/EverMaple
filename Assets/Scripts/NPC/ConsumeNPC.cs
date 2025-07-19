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
    GameObject sellConsumeUICheck;
    [SerializeField]
    GameObject sellEquipmentUICheck;

    [SerializeField]
    GameObject sellEquipUI;
    [SerializeField]
    GameObject sellConsumeUI;

    [SerializeField]
    Image playerImage;
    [SerializeField]
    Image npcImage;
    [SerializeField]
    TextMeshProUGUI mesoText;

    [SerializeField]
    GameObject consumeToolTipObj;

    private int itemCount = 0;
    private int maxEquipmentCount = 24;
    private int maxConsumeNumber = 21;
    private SpriteRenderer spriteRenderer;

    //������ ���� �Һ� ������
    private (int idx,int price) curBuyConsumeInfo = (-1,-1);
    private List<GameObject> equipmentListInStore = new List<GameObject>();
    //������ ���� ��� ������
    private (int idx, int price, string name, Sprite sprite) curBuyEquipmentInfo = (-1, -1, string.Empty, null);
    //������ �Ǹ� �Һ� ������
    private (int idx, int price, int maxCount) curSellConsumeInfo = (-1, -1,-1);
    //������ �Ǹ� ��� ������
    private (int price, string name, Sprite sprite) curSellEquipmentInfo = (-1, string.Empty, null);

    //UI��ġ
    private RectTransform rectTransform;

    //�Ǹ� ���, �Һ� ������Ʈ ����Ʈ
    private List<GameObject> sellEquipmentSpaceList = new List<GameObject>();
    private List<GameObject> sellConsumeSpaceList = new List<GameObject>();

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        spriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        StoreButtonBinding();
        BindingInputfeild();
        EnrollEquipmentAndConsumeInstore();
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

            //������ �Ǹ�
            if (btn.gameObject.tag.Contains("SellItem"))
            {
                //�Һ� ������
                if (gmName.Contains("Goods") && !gmName.Contains("Equipment"))
                {
                    btn.onClick.AddListener(delegate { SettingSellSelectConsumeItem(btn.gameObject); });
                    continue;
                }
                //��� ������
                if (gmName.Contains("EquipmentGoods"))
                {
                    btn.onClick.AddListener(delegate { SettingSellSelectEquipmentItem(btn.gameObject); });
                    continue;
                }
            }
            else//������ ����
            {
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
                    btn.onClick.AddListener(delegate { QuestionItemSell(btn.gameObject); });
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
                case "ConsumeSellSucccess":
                    btn.onClick.AddListener(SuccessConsumeItemSell);
                    break;
                case "ConsumeSellCancel":
                    btn.onClick.AddListener(CancelConsumeItemSell);
                    break;
                case "EquipmentSellSucccess":
                    btn.onClick.AddListener(SuccessEquipmentItemSell);
                    break;
                case "EquipmentSellCancel":
                    btn.onClick.AddListener(CancelEquipmentItemSell);
                    break;
                case "EquipmentSellTab":
                    btn.onClick.AddListener(OnEquipmentSellTab);
                    break;
                case "ComsumeSellTab":
                    btn.onClick.AddListener(OnConsumeSellUI);
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
                case "SellCountText":
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
        consumeToolTipObj.SetActive(false);
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

        //���� ���̰�
        if(consumeToolTipObj.activeSelf)
            consumeToolTipObj.SetActive(false);
        else
        {
            //���� ����
            string nameText = btn.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
            consumeToolTipObj.SetActive(true);
            consumeToolTipObj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = nameText;
            consumeToolTipObj.transform.GetChild(2).GetComponent<Image>().sprite 
                = ItemManager.itemInstance.consumeItemToolTipDic[nameText].itemSprite;
            consumeToolTipObj.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text 
                = ItemManager.itemInstance.consumeItemToolTipDic[nameText].itemExplain;
        }
    }
    /// <summary>
    /// ������ ���� Ȯ�� ����
    /// </summary>
    /// <param name="btn"></param>
    public void QuestionItemBuy(GameObject btn)
    {
        //���� â ����
        consumeToolTipObj.SetActive(false);
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
        consumeToolTipObj.SetActive(false);
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
    void EnrollEquipmentAndConsumeInstore()
    {
        //���� ���
        foreach (Transform equip in equipmentTotalListObj.GetComponentInChildren<Transform>())
        {
            equipmentListInStore.Add(equip.gameObject);
        }
        //�Ǹ� ���
        foreach(Button equip in sellEquipUI.GetComponentsInChildren<Button>(true))
        {
            sellEquipmentSpaceList.Add(equip.gameObject);
        }
        //�Ǹ� �Һ���
        foreach (Button cons in sellConsumeUI.GetComponentsInChildren<Button>(true))
        {
           sellConsumeSpaceList.Add(cons.gameObject);
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
    #region ������ �Ǹ�
    /// <summary>
    /// ������ �Ǹ� Ȯ�� ����
    /// </summary>
    /// <param name="btn"></param>
    public void QuestionItemSell(GameObject btn)
    {
        sellConsumeUICheck.SetActive(false);
        sellEquipmentUICheck.SetActive(false);
        //�Ǹ� â ����
        if (sellConsumeUI.activeSelf)
        {
            sellConsumeUICheck.SetActive(true);
        }else if(sellEquipUI.activeSelf)
            sellEquipmentUICheck.SetActive(true);
    }

    /// <summary>
    /// ��� �Ǹ� ��� �ѱ�
    /// </summary>
    public void OnEquipmentSellTab()
    {
        sellConsumeUI.SetActive(false);
        sellEquipUI.SetActive(true);

        ShowEquipmentSellUI();
    }
    /// <summary>
    /// �������� �Ǹ� ��� ���̱�
    /// </summary>
    void ShowEquipmentSellUI()
    {
        for (int i = 0; i < maxEquipmentCount; i++)
        {
            sellEquipmentSpaceList[i].SetActive(false);
        }

        for (int i = 0; i < ItemManager.itemInstance.playerHaveEquipments.Count; i++)
        {
            sellEquipmentSpaceList[i].SetActive(true);

            sellEquipmentSpaceList[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                ItemManager.itemInstance.playerHaveEquipments[i].name;
            sellEquipmentSpaceList[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text =
               $"{CalSellEquipmentMeso(ItemManager.itemInstance.playerHaveEquipments[i].name)} �޼�";
            sellEquipmentSpaceList[i].transform.GetChild(2).GetComponent<Image>().sprite =
               ItemManager.itemInstance.playerHaveEquipments[i].sprite;
        }
    }
    /// <summary>
    /// ��� �Ǹ� �޼�
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    int CalSellEquipmentMeso(string name)
    {
        return ItemManager.itemInstance.equipmentItemDic[name].sellPrice;
    }
    /// <summary>
    /// �Һ� �Ǹ� ��� �ѱ�
    /// </summary>
    public void OnConsumeSellUI()
    {
        sellEquipUI.SetActive(false);
        sellConsumeUI.SetActive(true);

        ShowConsumeSellUI();
    }
    /// <summary>
    /// �Һ������ �Ǹ� ��� ���̱�
    /// </summary>
    void ShowConsumeSellUI()
    {
        for (int idx = 0; idx < maxConsumeNumber; idx++)
        {
            sellConsumeSpaceList[idx].SetActive(false);
            if (ItemManager.itemInstance.consumeItems.ContainsKey(idx))
            {
                ConsumeItem consumeItem = ItemManager.itemInstance.consumeItems[idx];
                if (consumeItem.count != 0)
                {
                    sellConsumeSpaceList[idx].SetActive(true);
                    sellConsumeSpaceList[idx].gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text
                        = consumeItem.count.ToString();
                }
            }
        }
    }

    /// <summary>
    /// ���� �Ǹ��� �Һ� ������ ����
    /// </summary>
    public void SettingSellSelectConsumeItem(GameObject btn)
    {
        curSellConsumeInfo.idx = int.Parse(btn.gameObject.name.Substring(5));
        string priceText = btn.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        curSellConsumeInfo.price = int.Parse(priceText.Substring(0, priceText.Length - 3));
        string maxSellCountText = btn.gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text;
        curSellConsumeInfo.maxCount = int.Parse(maxSellCountText);
    }
    /// <summary>
    /// ���� �Ǹ��� ��� ������ ����
    /// </summary>
    public void SettingSellSelectEquipmentItem(GameObject btn)
    {
        string priceText = btn.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        curSellEquipmentInfo.price = int.Parse(priceText.Substring(0, priceText.Length - 3));
        curSellEquipmentInfo.name = btn.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        curSellEquipmentInfo.sprite = btn.gameObject.transform.GetChild(2).GetComponent<Image>().sprite;
    }

    /// <summary>
    /// �Һ������ ���� ���
    /// </summary>
    public void CancelConsumeItemSell()
    {
        curSellConsumeInfo.idx = -1;
        curSellConsumeInfo.price = -1;
        curSellConsumeInfo.maxCount = -1;

        sellConsumeUICheck.SetActive(false);
    }
    /// <summary>
    /// �Һ������ ���� Ȯ��
    /// </summary>
    public void SuccessConsumeItemSell()
    {
        //������ �������� ����
        if (curSellConsumeInfo.idx == -1)
        {
            return;
        }

        //�Ǹ� ���� ����
        if (itemCount > 0)
        {
            //���� ������
            ConsumeItem curConsumeItem = ItemManager.itemInstance.consumeItems[curSellConsumeInfo.idx];

            //���� ������ �ִ� �������� ������ �ȵ�
            if(itemCount <= curConsumeItem.count)
            {
                int totalPrice = itemCount * curSellConsumeInfo.price;

                //�޼� ȹ��
                PlayerManager.PlayerInstance.PlayerMeso += totalPrice;
                mesoText.text = PlayerManager.PlayerInstance.PlayerMeso.ToString();

                //������ ���� ����
                curConsumeItem.count -= itemCount;
                ItemManager.itemInstance.consumeItems[curSellConsumeInfo.idx] = curConsumeItem;

                ShowConsumeSellUI();
            }
        }
        CancelConsumeItemSell();
    }

    /// <summary>
    /// �������� ���� ���
    /// </summary>
    public void CancelEquipmentItemSell()
    {
        curSellEquipmentInfo.price = -1;
        curSellEquipmentInfo.name = string.Empty;
        curSellEquipmentInfo.sprite = null;

        sellEquipmentUICheck.SetActive(false);
    }
    /// <summary>
    /// �������� �Ǹ� Ȯ��
    /// </summary>
    public void SuccessEquipmentItemSell()
    {
        //������ ��� ����
        if (curSellEquipmentInfo.price == -1)
        {
            return;
        }

        //�Ǹ��ϱ�
        PlayerManager.PlayerInstance.PlayerMeso += curSellEquipmentInfo.price;
        mesoText.text = PlayerManager.PlayerInstance.PlayerMeso.ToString();

        //���ο� ��� ������ ���� �߰�
        EquipmentItem equipmentItem = new EquipmentItem();
        equipmentItem.sprite = curSellEquipmentInfo.sprite;
        equipmentItem.name = curSellEquipmentInfo.name;

        ItemManager.itemInstance.playerHaveEquipments.Remove(equipmentItem);
        ShowEquipmentSellUI();
        CancelEquipmentItemBuy();

        sellEquipmentUICheck.SetActive(false);
    }
    #endregion
}
