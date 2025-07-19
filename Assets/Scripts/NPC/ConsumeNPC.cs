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
    GameObject equipmentTotalListObj;//실제 장비

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

    //선택한 구매 소비 아이템
    private (int idx,int price) curBuyConsumeInfo = (-1,-1);
    private List<GameObject> equipmentListInStore = new List<GameObject>();
    //선택한 구매 장비 아이템
    private (int idx, int price, string name, Sprite sprite) curBuyEquipmentInfo = (-1, -1, string.Empty, null);
    //선택한 판매 소비 아이템
    private (int idx, int price, int maxCount) curSellConsumeInfo = (-1, -1,-1);
    //선택한 판매 장비 아이템
    private (int price, string name, Sprite sprite) curSellEquipmentInfo = (-1, string.Empty, null);

    //UI위치
    private RectTransform rectTransform;

    //판매 장비, 소비 오브젝트 리스트
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
    /// 상점 버튼 바인딩
    /// </summary>
    void StoreButtonBinding()
    {
        foreach (Button btn in gameObject.GetComponentsInChildren<Button>(true))
        {
            string gmName = btn.name;

            //아이템 판매
            if (btn.gameObject.tag.Contains("SellItem"))
            {
                //소비 아이템
                if (gmName.Contains("Goods") && !gmName.Contains("Equipment"))
                {
                    btn.onClick.AddListener(delegate { SettingSellSelectConsumeItem(btn.gameObject); });
                    continue;
                }
                //장비 아이템
                if (gmName.Contains("EquipmentGoods"))
                {
                    btn.onClick.AddListener(delegate { SettingSellSelectEquipmentItem(btn.gameObject); });
                    continue;
                }
            }
            else//아이템 구매
            {
                //소비 아이템
                if (gmName.Contains("Goods") && !gmName.Contains("Equipment"))
                {
                    btn.onClick.AddListener(delegate { SettingCutSelectConsumeItem(btn.gameObject); });
                    continue;
                }
                //장비 아이템
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
    /// 상점 UI 내용 표시
    /// </summary>
    void ShowStoreUI()
    {
        //플레이어 이미지 표시
        playerImage.sprite = spriteRenderer.sprite;
        //NPC이미지 표시
        npcImage.sprite = NPCCommon.npcSprite;
        //메소 표시
        mesoText.text = PlayerManager.PlayerInstance.PlayerMeso.ToString();
        //물품 리스트 보이기
        ShowGoodsList();
    }

    /// <summary>
    /// 물품 리스트 보이기
    /// </summary>
    void ShowGoodsList()
    {
        //소비 리스트
        if (storeNPCIndex.Item1 == 0)
        {
            equipmentListObj.gameObject.SetActive(false);
            consumeListObj.gameObject.SetActive(true);
        }
        else//장비 리스트
        {
            consumeListObj.gameObject.SetActive(false);
            equipmentListObj.gameObject.SetActive(true);

            //판매할 장비를 정합니다.
            DecideSellEquipment();
        }
    }

    /// <summary>
    /// 상점 나가기
    /// </summary>
    public void OutStore()
    {
        consumeToolTipObj.SetActive(false);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 현재 구매할 아이템 설정
    /// </summary>
    public void SettingCutSelectConsumeItem(GameObject btn)
    {
        curBuyConsumeInfo.idx = int.Parse(btn.gameObject.name.Substring(5));
        string priceText = btn.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        curBuyConsumeInfo.price = int.Parse(priceText.Substring(0, priceText.Length - 3));

        //툴팁 보이게
        if(consumeToolTipObj.activeSelf)
            consumeToolTipObj.SetActive(false);
        else
        {
            //내용 설정
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
    /// 아이템 구매 확정 여부
    /// </summary>
    /// <param name="btn"></param>
    public void QuestionItemBuy(GameObject btn)
    {
        //구매 창 열림
        consumeToolTipObj.SetActive(false);
        if (storeNPCIndex.Item1 == 0)
        {
            buyConsumeUI.SetActive(true);
        }
        else if(storeNPCIndex.Item1 == 1)
            buyEquipmentUI.SetActive(true);
    }

    /// <summary>
    /// 소비아이템 구매 취소
    /// </summary>
    public void CancelConsumeItemBuy()
    {
        curBuyConsumeInfo.idx = -1;
        curBuyConsumeInfo.price = -1;

        buyConsumeUI.SetActive(false);
        consumeToolTipObj.SetActive(false);
    }
    /// <summary>
    /// 소비아이템 구매 확정
    /// </summary>
    public void SuccessConsumeItemBuy()
    {
        //선택한 아이템이 없음
        if (curBuyConsumeInfo.idx == -1)
        {
            return;
        }

        //구매 개수 조건
        if(itemCount > 0)
        {
            int totalPrice = itemCount * curBuyConsumeInfo.price;

            //구매가능
            if(totalPrice <= PlayerManager.PlayerInstance.PlayerMeso)
            {
                PlayerManager.PlayerInstance.PlayerMeso -= totalPrice;
                mesoText.text = PlayerManager.PlayerInstance.PlayerMeso.ToString();

                //새로운 아이템
                if (!ItemManager.itemInstance.consumeItems.ContainsKey(curBuyConsumeInfo.idx))
                {
                    //새로운 아이템 정보 추가
                    ConsumeItem consumeItem = new ConsumeItem();
                    consumeItem.sprite = ItemManager.itemInstance.consumeItemImage[curBuyConsumeInfo.idx];
                    consumeItem.name = consumeItem.sprite.name;
                    consumeItem.count = itemCount;
                    ItemManager.itemInstance.consumeItems.Add(curBuyConsumeInfo.idx,consumeItem);
                }
                else//기존 아이템에서 추가
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
    /// 현재 구매할 장비 아이템 설정
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
    /// 장비아이템 구매 취소
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
    /// 장비아이템 구매 확정
    /// </summary>
    public void SuccessEquipmentItemBuy()
    {
        //선택한 장비가 없음
        if (curBuyEquipmentInfo.idx == -1)
        {
            return;
        }

        //구매가능
        if (curBuyEquipmentInfo.price <= PlayerManager.PlayerInstance.PlayerMeso)
        {
            PlayerManager.PlayerInstance.PlayerMeso -= curBuyEquipmentInfo.price;
            mesoText.text = PlayerManager.PlayerInstance.PlayerMeso.ToString();

            //새로운 장비 아이템 정보 추가
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
    /// 상점에 있는 장비 등록
    /// </summary>
    void EnrollEquipmentAndConsumeInstore()
    {
        //구매 장비
        foreach (Transform equip in equipmentTotalListObj.GetComponentInChildren<Transform>())
        {
            equipmentListInStore.Add(equip.gameObject);
        }
        //판매 장비
        foreach(Button equip in sellEquipUI.GetComponentsInChildren<Button>(true))
        {
            sellEquipmentSpaceList.Add(equip.gameObject);
        }
        //판매 소비템
        foreach (Button cons in sellConsumeUI.GetComponentsInChildren<Button>(true))
        {
           sellConsumeSpaceList.Add(cons.gameObject);
        }
    }

    /// <summary>
    /// 판매할 장비
    /// </summary>
    void DecideSellEquipment()
    {
        //물품 모두 끔
        foreach(GameObject equip in equipmentListInStore)
        {
            equip.SetActive(false);
        }

        //캐릭터가 있는 마을에 따라 결정
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

        //해당 물품만 켠다
        foreach(int equipNum in setEquipmentNums)
        {
            if (equipNum == -1)
                continue;
            equipmentListInStore[equipNum].SetActive(true);
        }
    }
    #region 아이템 판매
    /// <summary>
    /// 아이템 판매 확정 여부
    /// </summary>
    /// <param name="btn"></param>
    public void QuestionItemSell(GameObject btn)
    {
        sellConsumeUICheck.SetActive(false);
        sellEquipmentUICheck.SetActive(false);
        //판매 창 열림
        if (sellConsumeUI.activeSelf)
        {
            sellConsumeUICheck.SetActive(true);
        }else if(sellEquipUI.activeSelf)
            sellEquipmentUICheck.SetActive(true);
    }

    /// <summary>
    /// 장비 판매 목록 켜기
    /// </summary>
    public void OnEquipmentSellTab()
    {
        sellConsumeUI.SetActive(false);
        sellEquipUI.SetActive(true);

        ShowEquipmentSellUI();
    }
    /// <summary>
    /// 장비아이템 판매 목록 보이기
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
               $"{CalSellEquipmentMeso(ItemManager.itemInstance.playerHaveEquipments[i].name)} 메소";
            sellEquipmentSpaceList[i].transform.GetChild(2).GetComponent<Image>().sprite =
               ItemManager.itemInstance.playerHaveEquipments[i].sprite;
        }
    }
    /// <summary>
    /// 장비 판매 메소
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    int CalSellEquipmentMeso(string name)
    {
        return ItemManager.itemInstance.equipmentItemDic[name].sellPrice;
    }
    /// <summary>
    /// 소비 판매 목록 켜기
    /// </summary>
    public void OnConsumeSellUI()
    {
        sellEquipUI.SetActive(false);
        sellConsumeUI.SetActive(true);

        ShowConsumeSellUI();
    }
    /// <summary>
    /// 소비아이템 판매 목록 보이기
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
    /// 현재 판매할 소비 아이템 설정
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
    /// 현재 판매할 장비 아이템 설정
    /// </summary>
    public void SettingSellSelectEquipmentItem(GameObject btn)
    {
        string priceText = btn.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        curSellEquipmentInfo.price = int.Parse(priceText.Substring(0, priceText.Length - 3));
        curSellEquipmentInfo.name = btn.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        curSellEquipmentInfo.sprite = btn.gameObject.transform.GetChild(2).GetComponent<Image>().sprite;
    }

    /// <summary>
    /// 소비아이템 구매 취소
    /// </summary>
    public void CancelConsumeItemSell()
    {
        curSellConsumeInfo.idx = -1;
        curSellConsumeInfo.price = -1;
        curSellConsumeInfo.maxCount = -1;

        sellConsumeUICheck.SetActive(false);
    }
    /// <summary>
    /// 소비아이템 구매 확정
    /// </summary>
    public void SuccessConsumeItemSell()
    {
        //선택한 아이템이 없음
        if (curSellConsumeInfo.idx == -1)
        {
            return;
        }

        //판매 개수 조건
        if (itemCount > 0)
        {
            //현재 아이템
            ConsumeItem curConsumeItem = ItemManager.itemInstance.consumeItems[curSellConsumeInfo.idx];

            //현재 가지고 있는 개수보다 많으면 안됨
            if(itemCount <= curConsumeItem.count)
            {
                int totalPrice = itemCount * curSellConsumeInfo.price;

                //메소 획득
                PlayerManager.PlayerInstance.PlayerMeso += totalPrice;
                mesoText.text = PlayerManager.PlayerInstance.PlayerMeso.ToString();

                //아이템 개수 수정
                curConsumeItem.count -= itemCount;
                ItemManager.itemInstance.consumeItems[curSellConsumeInfo.idx] = curConsumeItem;

                ShowConsumeSellUI();
            }
        }
        CancelConsumeItemSell();
    }

    /// <summary>
    /// 장비아이템 구매 취소
    /// </summary>
    public void CancelEquipmentItemSell()
    {
        curSellEquipmentInfo.price = -1;
        curSellEquipmentInfo.name = string.Empty;
        curSellEquipmentInfo.sprite = null;

        sellEquipmentUICheck.SetActive(false);
    }
    /// <summary>
    /// 장비아이템 판매 확정
    /// </summary>
    public void SuccessEquipmentItemSell()
    {
        //선택한 장비가 없음
        if (curSellEquipmentInfo.price == -1)
        {
            return;
        }

        //판매하기
        PlayerManager.PlayerInstance.PlayerMeso += curSellEquipmentInfo.price;
        mesoText.text = PlayerManager.PlayerInstance.PlayerMeso.ToString();

        //새로운 장비 아이템 정보 추가
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
