using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using NUnit.Framework.Constraints;

public class SkillUI : MonoBehaviour, IDragHandler
{
    //�нú� ��ų Ŭ����
    PassiveSkillUpgrade passiveSkillUpgrade = new PassiveSkillUpgrade();
    //���� ��ų Ŭ����
    BuffSkill buffSkill = new BuffSkill();

    //UI��ġ
    private RectTransform rectTransform;
    //�нú� ��ų �˻�
    private string passiveSkillText = "PassiveSkill";
    //��Ƽ�� ��ų �˻�
    private string activeSkillText = "ActiveSkill";

    //��ų ����Ʈ
    TextMeshProUGUI sppointText;
    //0~4����ų â
    [SerializeField]
    List<GameObject> skillDimentionUI;
    //����
    [SerializeField]
    StatUI statUI;

    #region Unity �Լ�
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
    /// ��ư ���ε�
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
    /// ��ų����Ʈ ���̱�
    /// </summary>
    void ShowCharacterSkillUI()
    {
        sppointText.text = PlayerManager.PlayerInstance.PlayerSkillPoint.ToString();
    }
    /// <summary>
    /// ������ �°� ��ųâ ����
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
    /// ��ų ������
    /// </summary>
    /// <param name="skillObj">�������� ��ų</param>
    void SkillLevelUP(GameObject skillObj)
    {
        //��ų ����Ʈ�� ����
        if (PlayerManager.PlayerInstance.PlayerSkillPoint < 1)
            return;

        string skillNameText = skillObj.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text;
        TextMeshProUGUI curSkillLvText = skillObj.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        int curSkillLv = int.Parse(curSkillLvText.text);

        //����
        if (IsMaxSkillLv(skillNameText, curSkillLv))
            return;

        //��ų ����Ʈ �Ҹ�
        PlayerManager.PlayerInstance.PlayerSkillPoint -= 1;
        ShowCharacterSkillUI();

        //��ų ������
        curSkillLvText.text = (curSkillLv + 1).ToString();

        //�нú� ��ų
        if(skillObj.tag == passiveSkillText)
        {
            passiveSkillUpgrade.PassiveSkillLevelUP(skillNameText, int.Parse(curSkillLvText.text));
            statUI.ShowCharacterDetailStat();
        }
        //��Ƽ�� ���� ��ų
        if(skillObj.tag == activeSkillText)
        {
            buffSkill.BuffSkillLevelUP(skillNameText, int.Parse(curSkillLvText.text));
        }
    }

    /// <summary>
    /// ��ų ���� ���� �˻�
    /// </summary>
    /// <param name="skillNameText">��ų ��</param>
    /// <param name="curSkillLv">��ų ���� ����</param>
    /// <returns></returns>
    bool IsMaxSkillLv(string skillNameText, int curSkillLv)
    {
        bool flag = false;
        switch (skillNameText)
        {
            case "Ų ������":
                flag = (curSkillLv >= 8) ? true : false;
                break;
            case "��������ο�":
            case "ũ��Ƽ�� ���ο�":
            case "��������Ʈ��":
            case "���":
            case "�����":
            case "�ú���":
            case "Ʈ���ý��ο�":
            case "�θ޶� ����":
                flag = (curSkillLv >= 30) ? true : false;
                break;
            default:
                flag = (curSkillLv >= 20) ? true : false;
                break;
        }
        return flag;
    }
}
