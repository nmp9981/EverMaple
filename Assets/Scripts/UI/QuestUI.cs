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

    int curQuestNumber = 0;

    private void OnEnable()
    {
        QuestMain();
    }

    /// <summary>
    /// ����Ʈ NPC ���̱�
    /// </summary>
    /// <param name="spriteRen"></param>
    public void QuestMain()
    {
        npcImage.sprite = NPCCommon.npcSprite;
        curQuestNumber = NPCCommon.npcObj.GetComponent<QuestNPC>().curQuestNum;
       
        npcMainText.text = QuestDataBase.questDataList[curQuestNumber].finishScript;

        //�ʱ� ����
        InitQuestUI();

        //����Ʈ ���¿� ���� �ٸ� ��ũ��Ʈ ���
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
    /// ����Ʈ â �ݱ�
    /// </summary>
    public void QuestCloseButton()
    {
        InitQuestUI();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// ����Ʈ â �ʱ�ȭ
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

    #region ����Ʈ ��ư

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

        //���� �ޱ�
        int addExp = QuestDataBase.questDataList[curQuestNumber].rewardExp;
        int addMeso = QuestDataBase.questDataList[curQuestNumber].rewardMeso;
        string addItem = QuestDataBase.questDataList[curQuestNumber].rewardItem;

        completeButton.SetActive(true);
    }

    /// <summary>
    /// ����Ʈ ����
    /// </summary>
    public void AcceptQuest()
    {
        QuestDataBase.questDataList[curQuestNumber].questState = 2;
        QuestCloseButton();
    }

    /// <summary>
    /// ����Ʈ �Ϸ�
    /// </summary>
    public void CompleteQuest()
    {
        QuestDataBase.questDataList[curQuestNumber].questState = 4;

        //���� �ޱ�
        int addExp = QuestDataBase.questDataList[curQuestNumber].rewardExp;
        int addMeso = QuestDataBase.questDataList[curQuestNumber].rewardMeso;
        string addItem = QuestDataBase.questDataList[curQuestNumber].rewardItem;

        QuestCloseButton();
    }
    #endregion
}
