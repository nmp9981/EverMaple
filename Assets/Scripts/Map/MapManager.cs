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
    KerningCuty,
    SleepyWood,
    Count
}
public class MapManager : MonoBehaviour
{
    //���� �÷��̾ �ִ� ����
    public static LocalMapName playerMapLocal = LocalMapName.Henesys;
    
    protected GameObject player;
    protected const string playerTag = "Player";

    //�� ����Ű �����°�?
    public static bool isDownUpKey = false;

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
    }
}
