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
    Image playerImage;
    [SerializeField]
    Image npcImage;
    [SerializeField]
    TextMeshProUGUI mesoText;

    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        StoreButtonBinding();
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
        foreach (Button btn in gameObject.GetComponentsInChildren<Button>())
        {
            string gmName = btn.name;
            switch (gmName)
            {
                case "StoreExit":
                    btn.onClick.AddListener(OutStore);
                    break;
                case "ItemBuy":
                    break;
                case "ItemSell":
                    break;
                default:
                    break;
            }
        }
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
}
