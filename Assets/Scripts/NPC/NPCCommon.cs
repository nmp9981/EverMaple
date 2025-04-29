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
    Count
};

public class NPCCommon : MonoBehaviour
{
    [SerializeField]
    NPCCategory category;

    //UI 오브젝트
    protected GameObject canvasUI;
    protected GameObject consumeUI;
    protected GameObject taxiUI;
    protected GameObject questUI;

    protected Sprite npcSprite;
    private SpriteRenderer npcRenderer;

    protected void Awake()
    {
        UIBinding();
        SettingNPCImage();
    }

    protected virtual void SettingNPCImage()
    {
        npcRenderer = gameObject.GetComponent<SpriteRenderer>();
        npcSprite = npcRenderer.sprite;
    }
  
    void OnMouseDown()
    {
        switch (category)
        {
            case NPCCategory.Consume:
            case NPCCategory.Equipment:
                consumeUI.SetActive(true);
                break;
            case NPCCategory.Taxi:
                taxiUI.SetActive(true);
                break;
            case NPCCategory.Quest:
                questUI.SetActive(true);
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

        switch (category)
        {
            case NPCCategory.Consume:
            case NPCCategory.Equipment:
                consumeUI = canvasUI.transform.GetChild(5).gameObject;
                npcRenderer = GetComponent<SpriteRenderer>();
                break;
            case NPCCategory.Taxi:
                taxiUI = canvasUI.transform.GetChild(6).gameObject;
                break;
            case NPCCategory.Quest:
                questUI = canvasUI.transform.GetChild(7).gameObject;
                break;
            default:
                break;
        }
    }
}
