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

}
