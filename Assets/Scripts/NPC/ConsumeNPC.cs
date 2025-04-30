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
        ShowStoreUI();

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
    }

    /// <summary>
    /// ���� ������
    /// </summary>
    public void OutStore()
    {
        gameObject.SetActive(false);
    }
}
