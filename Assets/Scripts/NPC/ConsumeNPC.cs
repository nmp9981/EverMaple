using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConsumeNPC : NPCCommon
{
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
        //플레이어 이미지 표시
        playerImage.sprite = spriteRenderer.sprite;
        //NPC이미지 표시
        npcImage.sprite = NPCCommon.npcSprite;
        //메소 표시
        mesoText.text = PlayerManager.PlayerInstance.PlayerMeso.ToString();


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
}
