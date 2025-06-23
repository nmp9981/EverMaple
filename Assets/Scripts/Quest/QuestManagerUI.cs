using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManagerUI : MonoBehaviour
{
    [SerializeField]
    List<GameObject> questButtonList = new List<GameObject>();

    private void Awake()
    {
        BindingQuestButton();
    }
    private void OnEnable()
    {
        
    }

    /// <summary>
    /// 버튼 바인딩
    /// </summary>
    void BindingQuestButton()
    {
        foreach (Button btn in gameObject.GetComponentsInChildren<Button>(true))
        {
            string name = btn.gameObject.name;
            switch (name)
            {
                case "AbleStart":
                    btn.onClick.AddListener(ShowAbleQuwst);
                    break;
                case "QuestIng":
                    btn.onClick.AddListener(ShowQuesting);
                    break;
                case "Finished":
                    break;
                case "QuestNum0":
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
}
