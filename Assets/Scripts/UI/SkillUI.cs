using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using NUnit.Framework.Constraints;

public class SkillUI : MonoBehaviour, IDragHandler
{
    //패시브 스킬 클래스
    PassiveSkillUpgrade passiveSkillUpgrade = new PassiveSkillUpgrade();
    //버프 스킬 클래스
    BuffSkill buffSkill = new BuffSkill();

    //UI위치
    private RectTransform rectTransform;
    //패시브 스킬 검사
    private string passiveSkillText = "PassiveSkill";
    //액티브 스킬 검사
    private string activeSkillText = "ActiveSkill";

    //스킬 포인트
    TextMeshProUGUI sppointText;
    //0~4차스킬 창
    [SerializeField]
    List<GameObject> skillDimentionUI;
    //스탯
    [SerializeField]
    StatUI statUI;

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

        string skillNameText = skillObj.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text;
        TextMeshProUGUI curSkillLvText = skillObj.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        int curSkillLv = int.Parse(curSkillLvText.text);

        //만랩
        if (IsMaxSkillLv(skillNameText, curSkillLv))
            return;

        //스킬 포인트 소모
        PlayerManager.PlayerInstance.PlayerSkillPoint -= 1;
        ShowCharacterSkillUI();

        //스킬 레벨업
        curSkillLvText.text = (curSkillLv + 1).ToString();

        //패시브 스킬
        if(skillObj.tag == passiveSkillText)
        {
            passiveSkillUpgrade.PassiveSkillLevelUP(skillNameText, int.Parse(curSkillLvText.text));
            statUI.ShowCharacterDetailStat();
        }
        //액티브 버프 스킬
        if(skillObj.tag == activeSkillText)
        {
            buffSkill.BuffSkillLevelUP(skillNameText, int.Parse(curSkillLvText.text));
        }
    }

    /// <summary>
    /// 스킬 만렙 여부 검사
    /// </summary>
    /// <param name="skillNameText">스킬 명</param>
    /// <param name="curSkillLv">스킬 현재 레벨</param>
    /// <returns></returns>
    bool IsMaxSkillLv(string skillNameText, int curSkillLv)
    {
        bool flag = false;
        switch (skillNameText)
        {
            case "킨 아이즈":
                flag = (curSkillLv >= 8) ? true : false;
                break;
            case "새비지블로우":
            case "크리티컬 스로우":
            case "쉐도우파트너":
            case "어벤져":
            case "어썰터":
            case "시브즈":
            case "트리플스로우":
            case "부메랑 스텝":
                flag = (curSkillLv >= 30) ? true : false;
                break;
            default:
                flag = (curSkillLv >= 20) ? true : false;
                break;
        }
        return flag;
    }
}
