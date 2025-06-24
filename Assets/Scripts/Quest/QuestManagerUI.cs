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

    //UI위치
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
    /// 버튼 바인딩
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
    /// 시작 가능 퀘스트 목록 보이기
    /// </summary>
    public void ShowAbleQuwst()
    {
        foreach(var quest in QuestDataBase.questDataList)
        {
            questButtonList[quest.questNum].SetActive(false);
            //레벨제한
            if (PlayerManager.PlayerInstance.PlayerLV < quest.reqLv)
                continue;

            //신규 퀘
            if (quest.questState != 1)
                continue;

            //퀘스트 활성화
            questButtonList[quest.questNum].SetActive(true);
        }
    }
    /// <summary>
    /// 진행중인 퀘스트 목록 보이기
    /// </summary>
    public void ShowQuesting()
    {
        foreach (var quest in QuestDataBase.questDataList)
        {
            questButtonList[quest.questNum].SetActive(false);
            
            //진행중인 퀘
            if (quest.questState != 2)
                continue;

            //퀘스트 활성화
            questButtonList[quest.questNum].SetActive(true);
        }
    }
    /// <summary>
    /// 완료한 퀘스트 목록 보이기
    /// </summary>
    public void ShowFinishQuest()
    {
        foreach (var quest in QuestDataBase.questDataList)
        {
            questButtonList[quest.questNum].SetActive(false);

            //진행중인 퀘
            if (quest.questState != 4)
                continue;

            //퀘스트 활성화
            questButtonList[quest.questNum].SetActive(true);
        }
    }

    /// <summary>
    /// 각 퀘스트 버튼
    /// </summary>
    /// <param name="questNumName"></param>
    public void QuestNumButton(string questNumName)
    {
        //퀘스트 번호
        int questIndex = int.Parse(questNumName.Substring(8));
        QuestData queData = QuestDataBase.questDataList[questIndex];

        //퀘스트 정보
        questTitleText.text = queData.questTitle;
        questLvText.text = $"Lv.{queData.reqLv} 이상";

        questInfoText.text = string.Empty;
        for(int idx=0;idx<queData.reqmonsterNum.Length; idx++)
        {
            string mobName = queData.reqMonsterName[idx];
            questInfoText.text += $"{mobName} ({queData.reqMonsterCount[idx]}/{queData.reqMonsterGoalCount[idx]})";
            questInfoText.text += "\n";
        }
    }
}
