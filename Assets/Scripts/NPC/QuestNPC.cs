using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : MonoBehaviour
{
    public int questNPCNum;//NPC번호
    public int curQuestNum;//현재 퀘스트 번호

    public List<Sprite> stateSpriteList = new List<Sprite>();

    /// <summary>
    /// 퀘스트 상태 보이기
    /// </summary>
    public void ShowQuestState()
    {
        int curQuestState = QuestDataBase.questDataList[curQuestNum].questState;
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stateSpriteList[curQuestState];
    }

    /// <summary>
    /// 다음 퀘스트 상태 결정
    /// </summary>
    /// <param name="state"></param>
    public void ShowNextQuestState(int state)
    {
        //렙제와 선행퀘 검사
        int curQuestState = QuestDataBase.questDataList[state].questState;
        if (QuestDataBase.questDataList[state].reqLv <= PlayerManager.PlayerInstance.PlayerLV)
        {
            if (CheckBeforeQuest())
                curQuestState = 1;
        }
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stateSpriteList[curQuestState];
    }

    /// <summary>
    /// 선행 퀘스트 체크
    /// </summary>
    /// <returns></returns>
    bool CheckBeforeQuest()
    {
        if(curQuestNum==1 ||  curQuestNum==2 || curQuestNum==4 || curQuestNum==6 || curQuestNum == 10)
        {
            //이전 퀘 완료가 안됨
            if (QuestDataBase.questDataList[curQuestNum - 1].questState != 4)
                return false;
        } 
        return true;
    }
}
