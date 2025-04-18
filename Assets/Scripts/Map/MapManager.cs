using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    protected GameObject player;
    protected const string playerTag = "Player";

    protected int curMapNum;//현재 플레이어가 있는 맵의 번호

    //위 방향키 눌렀는가?
    public static bool isDownUpKey = false;

    protected virtual void Awake()
    {
        player = GameObject.Find("Player");
        curMapNum = 1;
    }

    /// <summary>
    /// 포탈로 이동
    /// </summary>
    /// <param name="curNode"></param>
    /// <param name="nextNode"></param>
    public void MoveToPortal(int nextNode, int nextMapNum)
    {
        //위키 누르는 표시 종료
        isDownUpKey = false;

        //캐릭터 잠시 비활성화
        player.SetActive(false);

        //다음맵으로 바뀜
        PlayerManager.PlayerInstance.CurMapName = MapAndProtalList.mapList[nextMapNum].name;
        MapAndProtalList.mapList[nextMapNum].SetActive(true);
        MapAndProtalList.mapList[curMapNum].SetActive(false);
        curMapNum = nextMapNum;

        //캐릭터 활성화
        player.SetActive(true);
        //캐릭터 위치를 포탈 위치로 
        float margin = 0.5f;
        player.transform.position = MapAndProtalList.portalList[nextNode].gameObject.transform.position
            +Vector3.up*margin;
    }
}
