using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Xml.Linq;

//아이템 탭 메뉴
enum ItemTab
{
    Equipment,
    Consume,
    Count
}

public class ItemUI : MonoBehaviour, IDragHandler
{
    //UI위치
    private RectTransform rectTransform;

    //메소 텍스트
    TextMeshProUGUI mesoText;
    //현재 아이템 탭
    ItemTab itemTab;

    #region Unity 함수
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
    /// 텍스트 바인딩
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
    /// 상점 버튼 바인딩
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
    /// 기본 스탯 보이기
    /// </summary>
    void ShowPlayerMeso()
    {
        mesoText.text = PlayerManager.PlayerInstance.PlayerMeso.ToString();
    }
    /// <summary>
    /// 아이템 보이기
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
