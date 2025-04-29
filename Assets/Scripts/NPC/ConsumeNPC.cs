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
        //�÷��̾� �̹��� ǥ��
        playerImage.sprite = spriteRenderer.sprite;
        //NPC�̹��� ǥ��
        npcImage.sprite = NPCCommon.npcSprite;
        //�޼� ǥ��
        mesoText.text = PlayerManager.PlayerInstance.PlayerMeso.ToString();


    }

    /// <summary>
    /// ���� ��ư ���ε�
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
