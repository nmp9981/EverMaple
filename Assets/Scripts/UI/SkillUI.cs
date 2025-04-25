using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillUI : MonoBehaviour, IDragHandler
{
    //UI��ġ
    private RectTransform rectTransform;

    TextMeshProUGUI sppointText;

    #region Unity �Լ�
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
    /// �ؽ�Ʈ ���ε�
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
    /// �⺻ ���� ���̱�
    /// </summary>
    void ShowCharacterSkillUI()
    {
        sppointText.text = PlayerManager.PlayerInstance.PlayerSkillPoint.ToString();
    }
}
