using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestManagerUI : MonoBehaviour
{
    [SerializeField]
    List<GameObject> questButtonList = new List<GameObject>();

    [SerializeField]
    TextMeshProUGUI questTitleText;
    [SerializeField]
    TextMeshProUGUI questLvText;
    [SerializeField]
    TextMeshProUGUI questInfoText;

    //UI��ġ
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        BindingQuestButton();
        foreach(GameObject questButton in questButtonList) { questButton.SetActive(false); }
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    /// <summary>
    /// ��ư ���ε�
    /// </summary>
    void BindingQuestButton()
    {
        foreach (Button btn in gameObject.GetComponentsInChildren<Button>(true))
        {
            string name = btn.gameObject.name.Substring(0,8);
            switch (name)
            {
                case "AbleStar":
                    btn.onClick.AddListener(ShowAbleQuwst);
                    break;
                case "QuestIng":
                    btn.onClick.AddListener(ShowQuesting);
                    break;
                case "Finished":
                    btn.onClick.AddListener(ShowFinishQuest);
                    break;
                case "QuestNum":
                    btn.onClick.AddListener(delegate { QuestNumButton(btn.gameObject.name); });
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// ���� ���� ����Ʈ ��� ���̱�
    /// </summary>
    public void ShowAbleQuwst()
    {
        foreach(var quest in QuestDataBase.questDataList)
        {
            questButtonList[quest.questNum].SetActive(false);
            //��������
            if (PlayerManager.PlayerInstance.PlayerLV < quest.reqLv)
                continue;

            //�ű� ��
            if (quest.questState != 1)
                continue;

            //����Ʈ Ȱ��ȭ
            questButtonList[quest.questNum].SetActive(true);
        }
    }
    /// <summary>
    /// �������� ����Ʈ ��� ���̱�
    /// </summary>
    public void ShowQuesting()
    {
        foreach (var quest in QuestDataBase.questDataList)
        {
            questButtonList[quest.questNum].SetActive(false);
            
            //�������� ��
            if (quest.questState != 2)
                continue;

            //����Ʈ Ȱ��ȭ
            questButtonList[quest.questNum].SetActive(true);
        }
    }
    /// <summary>
    /// �Ϸ��� ����Ʈ ��� ���̱�
    /// </summary>
    public void ShowFinishQuest()
    {
        foreach (var quest in QuestDataBase.questDataList)
        {
            questButtonList[quest.questNum].SetActive(false);

            //�������� ��
            if (quest.questState != 4)
                continue;

            //����Ʈ Ȱ��ȭ
            questButtonList[quest.questNum].SetActive(true);
        }
    }

    /// <summary>
    /// �� ����Ʈ ��ư
    /// </summary>
    /// <param name="questNumName"></param>
    public void QuestNumButton(string questNumName)
    {
        //����Ʈ ��ȣ
        int questIndex = int.Parse(questNumName.Substring(8));
        QuestData queData = QuestDataBase.questDataList[questIndex];

        //����Ʈ ����
        questTitleText.text = queData.questTitle;
        questLvText.text = $"Lv.{queData.reqLv} �̻�";

        questInfoText.text = string.Empty;
        for(int idx=0;idx<queData.reqmonsterNum.Length; idx++)
        {
            string mobName = queData.reqMonsterName[idx];
            questInfoText.text += $"{mobName} ({queData.reqMonsterCount[idx]}/{queData.reqMonsterGoalCount[idx]})";
            questInfoText.text += "\n";
        }
    }
}
