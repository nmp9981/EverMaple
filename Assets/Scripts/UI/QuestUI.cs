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

    [SerializeField]
    GameObject acceptButton;
    [SerializeField]
    GameObject completeButton;
    [SerializeField]
    GameObject rewardObj;

    [SerializeField]
    PlayerInfoUI playerInfoUIObj;
    [SerializeField]
    PlayerInfo playerInfo;

    int curQuestNumber = 0;

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
        curQuestNumber = NPCCommon.npcObj.GetComponent<QuestNPC>().curQuestNum;
       
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
        acceptButton.SetActive(false);
        completeButton.SetActive(false);
        rewardObj.SetActive(false);
    }

    #region 퀘스트 버튼

    public void StartQuestButton()
    {
        InitQuestUI();
        npcMainText.text = QuestDataBase.questDataList[curQuestNumber].questSctipt[0];
        acceptButton.SetActive(true);
    }

    public void QuestINGButton()
    {
        InitQuestUI();
        npcMainText.text = QuestDataBase.questDataList[curQuestNumber].notFinishScript;
    }

    public void FinishQuestButton()
    {
        InitQuestUI();
        npcMainText.text = QuestDataBase.questDataList[curQuestNumber].finishScript;

        rewardObj.SetActive(true);

        //보상 받기
        int addExp = QuestDataBase.questDataList[curQuestNumber].rewardExp;
        int addMeso = QuestDataBase.questDataList[curQuestNumber].rewardMeso;
        string addItem = QuestDataBase.questDataList[curQuestNumber].rewardItem;

        //UI표시
        //경험치
        if(addExp!=0)
            rewardObj.transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"{addExp} exp";
        else {
            rewardObj.transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"{0} exp";
        }
        
        //메소
        if(addMeso!=0)
            rewardObj.transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"{addMeso} 메소";
        else
        {
            rewardObj.transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"{0} 메소";
        }

        //아이템
        if(addItem != string.Empty)
        {
            rewardObj.transform.GetChild(2).gameObject.SetActive(true);
        }
        else
            rewardObj.transform.GetChild(2).gameObject.SetActive(false);

        completeButton.SetActive(true);
    }

    /// <summary>
    /// 퀘스트 수락
    /// </summary>
    public void AcceptQuest()
    {
        QuestDataBase.questDataList[curQuestNumber].questState = 2;
        NPCCommon.npcObj.GetComponent<QuestNPC>().ShowQuestState();
        QuestCloseButton();
    }

    /// <summary>
    /// 퀘스트 완료
    /// </summary>
    public void CompleteQuest()
    {
        QuestDataBase.questDataList[curQuestNumber].questState = 4;

        //보상 목록
        int addExp = QuestDataBase.questDataList[curQuestNumber].rewardExp;
        int addMeso = QuestDataBase.questDataList[curQuestNumber].rewardMeso;
        string addItem = QuestDataBase.questDataList[curQuestNumber].rewardItem;

        //보상 받기
        playerInfo.GetPlayerExp(addExp);
        PlayerManager.PlayerInstance.PlayerMeso += addMeso;
        playerInfoUIObj.ShowGetMesoMessage(addMeso);

        //새로운 장비 아이템 정보 추가
        if (addItem != string.Empty)
        {
            EquipmentItem equipmentItem = new EquipmentItem();
            equipmentItem.sprite = ItemManager.itemInstance.equipmentItemDic[addItem].equipmentImage;
            equipmentItem.name = ItemManager.itemInstance.equipmentItemDic[addItem].name;

            ItemManager.itemInstance.playerHaveEquipments.Add(equipmentItem);
        }

        NPCCommon.npcObj.GetComponent<QuestNPC>().ShowQuestState();
        QuestCloseButton();
    }
    #endregion
}
