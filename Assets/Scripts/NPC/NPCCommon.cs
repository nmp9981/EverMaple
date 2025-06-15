using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//NPC종류 
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
    NPCCategory category;//NPC카테고리
    [SerializeField]
    int npcNum;//NPC번호 

    //UI 오브젝트
    protected GameObject canvasUI;
    protected GameObject consumeUI;
    protected GameObject taxiUI;
    protected GameObject questUI;
    protected GameObject upgradeJobUI;

    //NPC
    protected static (int,int) storeNPCIndex;//카테고리, NPC번호
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
                upgradeJobUI.SetActive(true);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// UI바인딩
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
}
