using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : MonoBehaviour
{
    public int questNPCNum;//NPC��ȣ
    public int curQuestNum;//���� ����Ʈ ��ȣ

    public List<Sprite> stateSpriteList = new List<Sprite>();

    /// <summary>
    /// ����Ʈ ���� ���̱�
    /// </summary>
    public void ShowQuestState()
    {
        int curQuestState = QuestDataBase.questDataList[curQuestNum].questState;
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stateSpriteList[curQuestState];
    }

    /// <summary>
    /// ���� ����Ʈ ���� ����
    /// </summary>
    /// <param name="state"></param>
    public void ShowNextQuestState(int state)
    {
        //������ ������ �˻�
        int curQuestState = QuestDataBase.questDataList[state].questState;
        if (QuestDataBase.questDataList[state].reqLv <= PlayerManager.PlayerInstance.PlayerLV)
        {
            if (CheckBeforeQuest())
                curQuestState = 1;
        }
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stateSpriteList[curQuestState];
    }

    /// <summary>
    /// ���� ����Ʈ üũ
    /// </summary>
    /// <returns></returns>
    bool CheckBeforeQuest()
    {
        if(curQuestNum==1 ||  curQuestNum==2 || curQuestNum==4 || curQuestNum==6 || curQuestNum == 10)
        {
            //���� �� �Ϸᰡ �ȵ�
            if (QuestDataBase.questDataList[curQuestNum - 1].questState != 4)
                return false;
        } 
        return true;
    }
}
