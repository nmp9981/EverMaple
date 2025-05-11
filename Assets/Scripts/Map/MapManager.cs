using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

/// <summary>
/// 지역 명
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
    //현재 플레이어가 있는 지역
    public static LocalMapName playerMapLocal = LocalMapName.Henesys;
    
    protected GameObject player;
    protected const string playerTag = "Player";

    //위 방향키 눌렀는가?
    public static bool isDownUpKey = false;

    protected virtual void Awake()
    {
        player = GameObject.Find("Player");
    }

    /// <summary>
    /// 포탈로 이동
    /// </summary>
    /// <param name="curNode"></param>
    /// <param name="nextNode"></param>
    public async UniTask MoveToPortal(int nextNode, int nextMapNum)
    {
        //위키 누르는 표시 종료
        isDownUpKey = false;

        //다음맵으로 바뀜
        PlayerManager.PlayerInstance.CurMapName = MapAndProtalList.mapList[nextMapNum].name;

        await UniTask.Delay(100);
        MapAndProtalList.mapList[MapAndProtalList.curMapNum].SetActive(false);
        MapAndProtalList.mapList[nextMapNum].SetActive(true);
        MapAndProtalList.curMapNum = nextMapNum;

        //캐릭터 위치를 포탈 위치로 
        float margin = 0.5f;
        player.transform.position = MapAndProtalList.portalList[nextNode].gameObject.transform.position
            +Vector3.up*margin;
    }
}
