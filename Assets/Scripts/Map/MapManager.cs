using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

/// <summary>
/// ���� ��
/// </summary>
public enum LocalMapName
{
    LithHarbor,
    Henesys,
    Ellinia,
    Perion,
    KerningCity,
    SleepyWood,
    Count
}
public class MapManager : MonoBehaviour
{
    //���� �÷��̾ �ִ� ����
    public static LocalMapName playerMapLocal = LocalMapName.LithHarbor;
    
    protected GameObject player;
    protected const string playerTag = "Player";

    //�� ����Ű �����°�?
    public static bool isDownUpKey = false;

    //���� ����Ʈ
    public int[] villageList = {0,2,6,12,17,22};

    protected virtual void Awake()
    {
        player = GameObject.Find("Player");
    }

    /// <summary>
    /// ��Ż�� �̵�
    /// </summary>
    /// <param name="curNode"></param>
    /// <param name="nextNode"></param>
    public async UniTask MoveToPortal(int nextNode, int nextMapNum)
    {
        //��Ű ������ ǥ�� ����
        isDownUpKey = false;

        //���������� �ٲ�
        PlayerManager.PlayerInstance.CurMapName = MapAndProtalList.mapList[nextMapNum].name;

        await UniTask.Delay(100);
        MapAndProtalList.mapList[MapAndProtalList.curMapNum].SetActive(false);
        MapAndProtalList.mapList[nextMapNum].SetActive(true);
        MapAndProtalList.curMapNum = nextMapNum;

        //ĳ���� ��ġ�� ��Ż ��ġ�� 
        float margin = 0.5f;
        player.transform.position = MapAndProtalList.portalList[nextNode].gameObject.transform.position
            +Vector3.up*margin;

        //���� ��ġ �˻�
        LocalCheck(MapAndProtalList.curMapNum);
    }

    /// <summary>
    /// ���� ��ġ �˻�
    /// </summary>
    public void LocalCheck(int mapNumber)
    {
        if (mapNumber <= 1)
        {
            playerMapLocal = LocalMapName.LithHarbor;
        }
        else if (mapNumber >= 2 && mapNumber <= 4)
            playerMapLocal = LocalMapName.Henesys;
        else if (mapNumber >= 5 && mapNumber <= 9)
            playerMapLocal = LocalMapName.Ellinia;
        else if (mapNumber >= 10 && mapNumber <= 15)
            playerMapLocal = LocalMapName.Perion;
        else if (mapNumber >= 16 && mapNumber <= 20)
            playerMapLocal = LocalMapName.KerningCity;
        else
            playerMapLocal = LocalMapName.SleepyWood;
    }
}
