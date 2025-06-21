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

}
