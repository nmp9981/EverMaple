using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class SkillUI : MonoBehaviour, IDragHandler
{
    //UI위치
    private RectTransform rectTransform;

    //스킬 포인트
    TextMeshProUGUI sppointText;
    //0~4차스킬 창
    [SerializeField]
    List<GameObject> skillDimentionUI;

    #region Unity 함수
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        BindingSkillText();
        BindingSkillButton();
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
    /// 버튼 바인딩
    /// </summary>
    void BindingSkillButton()
    {
        foreach (Button btn in gameObject.GetComponentsInChildren<Button>(true))
        {
            string name = btn.gameObject.name;
            switch (name)
            {
                case "SkillDim1":
                    btn.onClick.AddListener(delegate { OpenSkillWindow(1); });
                    break;
                case "SkillDim2":
                    btn.onClick.AddListener(delegate { OpenSkillWindow(2); });
                    break;
                case "SkillDim3":
                    btn.onClick.AddListener(delegate { OpenSkillWindow(3); });
                    break;
                case "SkillDim4":
                    btn.onClick.AddListener(delegate { OpenSkillWindow(4); });
                    break;
                case "SkillUP":
                    btn.onClick.AddListener(delegate { SkillLevelUP(btn.transform.parent.gameObject); });
                    break;
                default:
                    break;
            }
        }
    }

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
    /// 스킬포인트 보이기
    /// </summary>
    void ShowCharacterSkillUI()
    {
        sppointText.text = PlayerManager.PlayerInstance.PlayerSkillPoint.ToString();
    }
    /// <summary>
    /// 차수에 맞게 스킬창 열기
    /// </summary>
    void OpenSkillWindow(int dim)
    {
        foreach(GameObject gm in skillDimentionUI)
        {
            gm.SetActive(false);
        }
        skillDimentionUI[dim].gameObject.SetActive(true);
    }

    /// <summary>
    /// 스킬 레벨업
    /// </summary>
    /// <param name="skillObj">레벨업할 스킬</param>
    void SkillLevelUP(GameObject skillObj)
    {
        //스킬 포인트가 없음
        if (PlayerManager.PlayerInstance.PlayerSkillPoint < 1)
            return;

        //스킬 포인트 소모
        PlayerManager.PlayerInstance.PlayerSkillPoint -= 1;
        ShowCharacterSkillUI();

        //스킬 레벨업
        TextMeshProUGUI curSkillLvText = skillObj.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        curSkillLvText.text = (int.Parse(curSkillLvText.text) + 1).ToString();
    }
}
