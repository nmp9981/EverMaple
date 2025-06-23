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
    /// ��ư ���ε�
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
    /// ���� ���� ����Ʈ ��� ���̱�
    /// </summary>
    public void ShowAbleQuwst()
    {
        foreach(var quest in QuestDataBase.questDataList)
        {
            questButtonList[quest.questNum].SetActive(false);
            //��������
            if (PlayerManager.PlayerInstance.PlayerLV < quest.reqLv)
                continue;

            //�ű� ��
            if (quest.questState != 1)
                continue;

            //����Ʈ Ȱ��ȭ
            questButtonList[quest.questNum].SetActive(true);
        }
    }
    /// <summary>
    /// �������� ����Ʈ ��� ���̱�
    /// </summary>
    public void ShowQuesting()
    {
        foreach (var quest in QuestDataBase.questDataList)
        {
            questButtonList[quest.questNum].SetActive(false);
            
            //�������� ��
            if (quest.questState != 2)
                continue;

            //����Ʈ Ȱ��ȭ
            questButtonList[quest.questNum].SetActive(true);
        }
    }
}
