using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : MonoBehaviour
{
    public int questNum;//퀘스트 번호
    public int reqLv;//요구 레벨
    public int questState = 0;//퀘 상태, 1:시작, 2:진행중, 3:완료, 4:클리어

    public List<Sprite> stateSpriteList = new List<Sprite>();

    /// <summary>
    /// 퀘스트 상태 보이기
    /// </summary>
    public void ShowQuestState()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stateSpriteList[questState];
    }

}
