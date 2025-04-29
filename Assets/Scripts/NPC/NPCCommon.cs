using System;
using System.Collections.Generic;
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
    Count
};

public class NPCCommon : MonoBehaviour
{
    [SerializeField]
    NPCCategory category;

    GameObject consumeUI;

    void OnMouseDown()
    {
        Debug.Log(gameObject.name + " ��(��) Ŭ���Ǿ����ϴ�!");

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
