using System.Collections.Generic;
using UnityEngine;

public class MapAndProtalList : MonoBehaviour
{
    //포탈 리스트
    public static List<Portal> portalList = new List<Portal>();

    //맵리스트
    public static List<GameObject> mapList = new List<GameObject>();

    //현재 플레이어가 있는 맵의 번호
    public static int curMapNum = 0;

    void Awake()
    { 
        EnrollPortalList();
        EnrollMapList();
    }

    /// <summary>
    /// 포탈 리스트 등록
    /// </summary>
    void EnrollPortalList()
    {
        foreach (Portal pot in this.gameObject.GetComponentsInChildren<Portal>(true))
        {
            portalList.Add(pot);
        }
    }
    /// <summary>
    /// 맵리스트 등록
    /// </summary>
    void EnrollMapList()
    {
        foreach (Transform tr in gameObject.GetComponentInChildren<Transform>(true))
        {
            mapList.Add(tr.gameObject);
        }
    }
}
