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

    GameObject consumeUI;

    void OnMouseDown()
    {
        Debug.Log(gameObject.name + " 이(가) 클릭되었습니다!");

        switch (category)
        {
            case NPCCategory.Consume:

                break;
            case NPCCategory.Equipment:
                break;
            case NPCCategory.Taxi:
                break;
            case NPCCategory.Quest:
                break;
            default:
                break;
        }
    }
}
