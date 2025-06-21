using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    [SerializeField]
    Image npcImage;
    [SerializeField]
    TextMeshProUGUI npcMainText;

    [SerializeField]
    GameObject QuestStart;
    [SerializeField]
    GameObject QuestIng;
    [SerializeField]
    GameObject QuestFinishIng;

    private void OnEnable()
    {
        QuestMain();
    }

    /// <summary>
    /// 퀘스트 NPC 보이기
    /// </summary>
    /// <param name="spriteRen"></param>
    public void QuestMain()
    {
        npcImage.sprite = NPCCommon.npcSprite;
        int curQuestNumber = NPCCommon.npcObj.GetComponent<QuestNPC>().curQuestNum;
       
        npcMainText.text = QuestDataBase.questDataList[curQuestNumber].finishScript;

        //초기 설정
        InitQuestUI();

        //퀘스트 상태에 따라 다른 스크립트 출력
        switch (QuestDataBase.questDataList[curQuestNumber].questState)
        {
            case 0:
                break;
            case 1:
                QuestStart.SetActive(true);
                QuestStart.transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    QuestDataBase.questDataList[curQuestNumber].questTitle;
                break;
            case 2:
                QuestIng.SetActive(true);
                QuestIng.transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                   QuestDataBase.questDataList[curQuestNumber].questTitle;
                break;
            case 3:
                QuestFinishIng.SetActive(true);
                QuestFinishIng.transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                   QuestDataBase.questDataList[curQuestNumber].questTitle;
                break;
            case 4:
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 퀘스트 창 닫기
    /// </summary>
    public void QuestCloseButton()
    {
        InitQuestUI();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 퀘스트 창 초기화
    /// </summary>
    public void InitQuestUI()
    {
        QuestStart.SetActive(false);
        QuestIng.SetActive(false);
        QuestFinishIng.SetActive(false);
    }
}
