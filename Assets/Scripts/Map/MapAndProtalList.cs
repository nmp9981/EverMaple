using System.Collections.Generic;
using UnityEngine;

public class MapAndProtalList : MonoBehaviour
{
    //��Ż ����Ʈ
    public static List<Portal> portalList = new List<Portal>();

    //�ʸ���Ʈ
    public static List<GameObject> mapList = new List<GameObject>();

    //���� �÷��̾ �ִ� ���� ��ȣ
    public static int curMapNum = 0;

    void Awake()
    { 
        EnrollPortalList();
        EnrollMapList();
    }

    /// <summary>
    /// ��Ż ����Ʈ ���
    /// </summary>
    void EnrollPortalList()
    {
        foreach (Portal pot in this.gameObject.GetComponentsInChildren<Portal>(true))
        {
            portalList.Add(pot);
        }
    }
    /// <summary>
    /// �ʸ���Ʈ ���
    /// </summary>
    void EnrollMapList()
    {
        foreach (Transform tr in gameObject.GetComponentInChildren<Transform>(true))
        {
            mapList.Add(tr.gameObject);
        }
    }
}
