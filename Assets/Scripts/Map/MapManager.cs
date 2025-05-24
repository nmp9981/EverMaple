using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using TMPro;

/// <summary>
/// 지역 명
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
    //위 방향키 눌렀는가?
    public static bool isDownUpKey = false;
    //현재 플레이어가 있는 지역
    public static LocalMapName playerMapLocal = LocalMapName.LithHarbor;

    protected TextMeshProUGUI mapRealNameText;    
    protected GameObject player;
    protected const string playerTag = "Player";

    //마을 리스트
    public int[] villageList = {0,2,8,14,19,25};

    protected virtual void Awake()
    {
        player = GameObject.Find("Player");
        mapRealNameText = GameObject.Find("MapNameText").GetComponent<TextMeshProUGUI>();
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

        //맵 UI적용
        if(mapRealNameText==null)
            mapRealNameText = GameObject.Find("MapNameText").GetComponent<TextMeshProUGUI>();
        mapRealNameText.text = $"{realMapName[nextMapNum]}";

        await UniTask.Delay(100);
        MapAndProtalList.mapList[MapAndProtalList.curMapNum].SetActive(false);
        MapAndProtalList.mapList[nextMapNum].SetActive(true);
        MapAndProtalList.curMapNum = nextMapNum;

        //캐릭터 위치를 포탈 위치로 
        float margin = 0.5f;
        if (player == null)
            player = GameObject.Find("Player");
        player.transform.position = MapAndProtalList.portalList[nextNode].gameObject.transform.position
            +Vector3.up*margin;

        //지역 위치 검사
        LocalCheck(MapAndProtalList.curMapNum);
    }

    /// <summary>
    /// 지역 위치 검사
    /// </summary>
    public void LocalCheck(int mapNumber)
    {
        if (mapNumber <= 1)
        {
            playerMapLocal = LocalMapName.LithHarbor;
        }
        else if (mapNumber >= 2 && mapNumber <= 6)
            playerMapLocal = LocalMapName.Henesys;
        else if (mapNumber >= 7 && mapNumber <= 11)
            playerMapLocal = LocalMapName.Ellinia;
        else if (mapNumber >= 12 && mapNumber <= 17)
            playerMapLocal = LocalMapName.Perion;
        else if (mapNumber >= 18 && mapNumber <= 23)
            playerMapLocal = LocalMapName.KerningCity;
        else
            playerMapLocal = LocalMapName.SleepyWood;
    }

    #region 맵 실제 이름
    protected string[] realMapName = new string[]{
        "리스항구",
        "리스항구 : 리스항구 오솔길",
        "헤네시스",
        "헤네시스 : 헤네시스 사냥터",
        "헤네시스 : 헤네시스 숲",
        "헤네시스 : 골렘의 사원",
        "헤네시스 : 남의 집",
        "엘리니아 : 남쪽필드",
        "엘리니아",
        "엘리니아 : 솟아오른나무",
        "엘리니아 : 북쪽필드",
        "엘리니아 : 던전으로 가는 길",
        "페리온 : 페리온 동쪽령",
        "페리온 : 바위길",
        "페리온",
        "페리온 : 바위산",
        "페리온 : 페리온 서쪽령",
        "페리온 : 페리온 불타버린땅",
        "커닝시티 : 커닝시티 공사장",
        "커닝시티",
        "커닝시티 : 커닝시티 해질녘",
        "커닝시티 : 니은숲",
        "커닝시티 : 방황의 늪",
        "커닝시티 : 위험한 크로코",
        "슬리피우드 : 깊은숲",
        "슬리피우드",
        "슬리피우드 : 슬리피 던전",
        "슬리피우드 : 개미굴 I",
        "슬리피우드 : 개미굴 II",
        "슬리피우드 : 빛을 잃은 동굴",
        "슬리피우드 : 와일드카고의 영역",
        "슬리피우드 : 신전의 입구",
        "슬리피우드 : 저주받은신전",
    };
    #endregion
}
