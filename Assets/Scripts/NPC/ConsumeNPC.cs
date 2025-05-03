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
    /// ���� ��ư ���ε�
    /// </summary>
    void StoreButtonBinding()
    {
        foreach (Button btn in gameObject.GetComponentsInChildren<Button>(true))
        {
            string gmName = btn.name;

            //�Һ� ������
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
                CancelConsumeItemBuy();
            }
            else
            {

            }
        }
    }
    /// <summary>
    /// �������� ���� ���
    /// </summary>
    public void CancelEquipmentItemBuy()
    {
        buyEquipmentUI.SetActive(false);
    }
    /// <summary>
    /// �������� ���� Ȯ��
    /// </summary>
    public void SuccessEquipmentItemBuy()
    {

    }
}
