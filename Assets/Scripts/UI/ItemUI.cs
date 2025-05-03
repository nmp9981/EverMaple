using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Xml.Linq;

//������ �� �޴�
enum ItemTab
{
    Equipment,
    Consume,
    Count
}

public class ItemUI : MonoBehaviour, IDragHandler
{
    //UI��ġ
    private RectTransform rectTransform;

    //�޼� �ؽ�Ʈ
    TextMeshProUGUI mesoText;
    //���� ������ ��
    ItemTab itemTab;

    #region Unity �Լ�
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        itemTab = ItemTab.Equipment;

        BindingSkillText();
        ItemButtonBinding();
    }
    private void OnEnable()
    {
        ShowPlayerMeso();
        ShowItem();
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    #endregion

    /// <summary>
    /// �ؽ�Ʈ ���ε�
    /// </summary>
    void BindingSkillText()
    {
        foreach (TextMeshProUGUI txt in gameObject.GetComponentsInChildren<TextMeshProUGUI>(true))
        {
            string name = txt.gameObject.name;
            switch (name)
            {
                case "MesoText":
                    mesoText = txt;
                    break;
                default:
                    break;
            }
        }
    }
    /// <summary>
    /// ���� ��ư ���ε�
    /// </summary>
    void ItemButtonBinding()
    {
        foreach (Button btn in gameObject.GetComponentsInChildren<Button>(true))
        {
            string gmName = btn.name;

            switch (gmName)
            {
                case "EquipmentTab":
                    itemTab = ItemTab.Equipment;
                    btn.onClick.AddListener(ShowItem);
                    break;
                case "ConsumeTab":
                    itemTab = ItemTab.Consume;
                    btn.onClick.AddListener(ShowItem);
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// �⺻ ���� ���̱�
    /// </summary>
    void ShowPlayerMeso()
    {
        mesoText.text = PlayerManager.PlayerInstance.PlayerMeso.ToString();
    }
    /// <summary>
    /// ������ ���̱�
    /// </summary>
    void ShowItem()
    {
        switch (itemTab)
        {
            case ItemTab.Equipment:
                
                break;
            case ItemTab.Consume:
                
                break;
            default:
                break;
        }
    }
}
