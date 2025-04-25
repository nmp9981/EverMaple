using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillUI : MonoBehaviour, IDragHandler
{
    //UI위치
    private RectTransform rectTransform;

    TextMeshProUGUI sppointText;

    #region Unity 함수
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        BindingSkillText();
    }
    private void OnEnable()
    {
        ShowCharacterSkillUI();
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
                case "SPPoint":
                    sppointText = txt;
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// 기본 스탯 보이기
    /// </summary>
    void ShowCharacterSkillUI()
    {
        sppointText.text = PlayerManager.PlayerInstance.PlayerSkillPoint.ToString();
    }
}
