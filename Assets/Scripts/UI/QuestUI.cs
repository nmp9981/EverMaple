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
    /// ����Ʈ NPC ���̱�
    /// </summary>
    /// <param name="spriteRen"></param>
    public void QuestMain()
    {
        npcImage.sprite = NPCCommon.npcSprite;
        int curQuestNumber = NPCCommon.npcObj.GetComponent<QuestNPC>().curQuestNum;
       
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
    }
}
