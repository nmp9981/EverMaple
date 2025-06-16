using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

//NPC���� 
public enum NPCCategory
{
    Consume,
    Equipment,
    Quest,
    Taxi,
    MoveWorld,
    UpgradeJob,
    Count
};

public class NPCCommon : MonoBehaviour
{
    [SerializeField]
    NPCCategory category;//NPCī�װ�
    [SerializeField]
    int npcNum;//NPC��ȣ 
    [SerializeField]
    int upgradeDim;//���׷���Ʈ ����

    //UI ������Ʈ
    protected GameObject canvasUI;
    protected GameObject consumeUI;
    protected GameObject taxiUI;
    protected GameObject questUI;
    protected GameObject upgradeJobUI;

    //NPC
    protected static (int,int) storeNPCIndex;//ī�װ�, NPC��ȣ
    protected static Sprite npcSprite;
    private SpriteRenderer npcRenderer;

    protected void Awake()
    {
        UIBinding();
        SettingNPCImage();
    }
   
    protected void SettingNPCImage()
    {
        npcSprite = npcRenderer.sprite;

        int categoryIdx = 0;
        switch (category)
        {
            case NPCCategory.Consume:
                categoryIdx = 0;
                break;
            case NPCCategory.Equipment:
                categoryIdx = 1;
                break;
            default:
                break;
        }
        storeNPCIndex = (categoryIdx, npcNum);
    }
   
    void OnMouseDown()
    {
        switch (category)
        {
            case NPCCategory.Consume:
            case NPCCategory.Equipment:
                SettingNPCImage();
                consumeUI.SetActive(true);
                break;
            case NPCCategory.Taxi:
                taxiUI.SetActive(true);
                break;
            case NPCCategory.Quest:
                questUI.SetActive(true);
                break;
            case NPCCategory.UpgradeJob:
                SetActiveUpgradeNPC();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// UI���ε�
    /// </summary>
    void UIBinding()
    {
        canvasUI = GameObject.Find("Canvas");
        npcRenderer = gameObject.GetComponent<SpriteRenderer>();

        switch (category)
        {
            case NPCCategory.Consume:
            case NPCCategory.Equipment:
                consumeUI = canvasUI.transform.GetChild(6).gameObject;
                npcRenderer = GetComponent<SpriteRenderer>();
                break;
            case NPCCategory.Taxi:
                taxiUI = canvasUI.transform.GetChild(7).gameObject;
                break;
            case NPCCategory.Quest:
                questUI = canvasUI.transform.GetChild(8).gameObject;
                break;
            case NPCCategory.UpgradeJob:
                upgradeJobUI = canvasUI.transform.GetChild(9).gameObject;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// ���� ���� NPC Ȱ��ȭ
    /// </summary>
    void SetActiveUpgradeNPC()
    {
        //���� ������ �ƴ�
        if (upgradeDim < 1)
            return;

        GameObject upgradeObj = upgradeJobUI.transform.GetChild(upgradeDim - 1).gameObject;
        upgradeObj.SetActive(true);

        if (upgradeDim == 3)
        {
            upgradeObj.transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =string.Empty;
            switch (PlayerManager.PlayerInstance.PlayerJOBEnum)
            {
                case PlayerJobClass.Assassin:
                    upgradeObj.transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "��� (Hermit)";
                    break;
                case PlayerJobClass.Hermit:
                    upgradeObj.transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "����Ʈ�ε� (NightLoad)";
                    break;
                case PlayerJobClass.Thief:
                    upgradeObj.transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "���������� (ThiefMaster)";
                    break;
                case PlayerJobClass.ThiefMaster:
                    upgradeObj.transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "������ (Shadower)";
                    break;
                default:
                    upgradeObj.transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "3�� ������ ���� 55�̻�!!";
                    break;
            }
        }

    }
}
