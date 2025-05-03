using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConsumeNPC : NPCCommon
{
    [SerializeField]
    GameObject consumeListObj;
    [SerializeField]
    GameObject equipmentListObj;

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
    private (int idx,int price) curBuyConsumeInfo = (-1,-1);

    private void Awake()
    {
        spriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        StoreButtonBinding();
        BindingInputfeild();
    }

    private void OnEnable()
    {
        ShowStoreUI();
    }

    /// <summary>
    /// 상점 버튼 바인딩
    /// </summary>
    void StoreButtonBinding()
    {
        foreach (Button btn in gameObject.GetComponentsInChildren<Button>(true))
        {
            string gmName = btn.name;

            //소비 아이템
            if (gmName.Contains("Goods"))
            {
                btn.onClick.AddListener(delegate { SettingCutSelectConsumeItem(btn.gameObject); });
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
        }
    }

    /// <summary>
    /// 상점 나가기
    /// </summary>
    public void OutStore()
    {
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
    }
    /// <summary>
    /// 아이템 구매 확정 여부
    /// </summary>
    /// <param name="btn"></param>
    public void QuestionItemBuy(GameObject btn)
    {
        //구매 창 열림
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
                CancelConsumeItemBuy();
            }
            else
            {

            }
        }
    }
    /// <summary>
    /// 장비아이템 구매 취소
    /// </summary>
    public void CancelEquipmentItemBuy()
    {
        buyEquipmentUI.SetActive(false);
    }
    /// <summary>
    /// 장비아이템 구매 확정
    /// </summary>
    public void SuccessEquipmentItemBuy()
    {

    }
}
