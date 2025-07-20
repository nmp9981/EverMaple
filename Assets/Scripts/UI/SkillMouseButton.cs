using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillMouseButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject skillInfoUI;

    [Header("스킬 툴팁")]
    [SerializeField]
    SkillToolTipClass skillToolTipClass;
    [SerializeField]
    TextMeshProUGUI skillNameToolTip;
    [SerializeField]
    Image skillImageToolTip;
    [SerializeField]
    TextMeshProUGUI skillExplainToolTip;
    [SerializeField]
    TextMeshProUGUI skillFunctionToolTip;

    string skillTag = "Skill";

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
        if (clickedObject.tag.Contains(skillTag))
        {
            skillInfoUI.SetActive(true);
            string skillName = gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text;
            int skillLv = int.Parse(gameObject.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text);
            ShowSkillInfo(skillName, skillLv);
        }
        else
        {
            skillInfoUI.SetActive(false);
        }
    }

    /// <summary>
    /// 스킬 정보 보이기
    /// </summary>
    /// <param name="skillName"></param>
    /// <param name="skillLv"></param>
    void ShowSkillInfo(string skillName, int skillLv)
    {
        skillNameToolTip.text = skillName;
        skillImageToolTip.sprite = skillToolTipClass.skillToolTipTextDic[skillName].skillSprite;
        skillExplainToolTip.text = skillToolTipClass.skillToolTipTextDic[skillName].skillExplain;
        skillFunctionToolTip.text = $"[레벨 {skillLv} -> {skillLv+1}]";
    }
}
