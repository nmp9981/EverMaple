using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemUI : MonoBehaviour, IDragHandler
{
    //UI��ġ
    private RectTransform rectTransform;

    TextMeshProUGUI mesoText;

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
                case "MesoText":
                    mesoText = txt;
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
        mesoText.text = PlayerManager.PlayerInstance.PlayerSkillPoint.ToString();
    }
}
