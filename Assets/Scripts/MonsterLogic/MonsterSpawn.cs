using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField]
    List<Transform> spawnPositionList = new List<Transform>();

    MonsterFulling monsterFulling;

    float resenTime = 5f;

    //맵에 활성화된 몬스터
    public static List<GameObject> activeMonster = new List<GameObject>();

    private void Awake()
    {
        monsterFulling = GameObject.Find("MonsterSpawn").GetComponent<MonsterFulling>();
    }
    private void OnEnable()
    {
        SetSpawnPosition();
        MonsterSpawnMapEnter();
    }

    private void OnDisable()
    {
        MonsterListDestroy();
    }

    /// <summary>
    /// 스폰 위치 설정
    /// </summary>
    void SetSpawnPosition()
    {
        GameObject spawnPosObject = this.gameObject.transform.GetChild(2).gameObject;
        foreach (Transform t in spawnPosObject.GetComponentInChildren<Transform>(true))
        {
            spawnPositionList.Add(t);
        }
    }

    /// <summary>
    /// 몬스터 스폰
    /// </summary>
    void MonsterSpawnMapEnter()
    {
        for(int idx = 0;idx < spawnPositionList.Count;idx++)
        {
            int genCount = 2;

            for (int i = 0; i < genCount; i++)
            {
                int mobNum = Random.Range(0, 2);
                GameObject gm = monsterFulling.MakeObj(mobNum);
                
                //몬스터 리젠 위치 등록
                MonsterInfo monsterInfo = gm.GetComponent<MonsterInfo>();
                monsterInfo.spawnPosNumber = idx;
                monsterInfo.spawnMap = PlayerManager.PlayerInstance.CurMapName;

                //몬스터의 크기
                float monsterYSize = gm.GetComponent<Collider2D>().bounds.size.y * 0.5f;

                //최종 생성 위치(몬스터 크기 고려)
                float randomXpos = Random.Range(-30, 30)*0.1f;
                gm.transform.position = spawnPositionList[idx].position + Vector3.right*randomXpos+Vector3.up*monsterYSize;
                activeMonster.Add(gm);
            }
        }
        
    }
    /// <summary>
    /// 리스폰 함수 불러오기
    /// </summary>
    public void CallRespawn()
    {
        Invoke("MonsterRespawn", 5f);
    }
    /// <summary>
    /// 몬스터 리젠
    /// </summary>
    public void MonsterRespawn()
    {
        //스폰 위치가 없을때
        if (spawnPositionList.Count == 0)
        {
            SetSpawnPosition();
        }

        int spawnNum = Random.Range(0, this.spawnPositionList.Count);
       
        int mobNum = Random.Range(0, 3);
        GameObject gm = monsterFulling.MakeObj(mobNum);

        //몬스터의 크기
        float monsterYSize = gm.GetComponent<Collider2D>().bounds.size.y * 0.5f;

        //몬스터 스폰 위치
        MonsterInfo mobInfo = gm.GetComponent<MonsterInfo>();
        mobInfo.spawnPosNumber = spawnNum;
        mobInfo.spawnMap = PlayerManager.PlayerInstance.CurMapName;

        //최종 생성 위치(몬스터 크기 고려)
        float randomXpos = Random.Range(-30, 30)*0.1f;
        gm.transform.position = spawnPositionList[spawnNum].position + Vector3.right * randomXpos + Vector3.up * monsterYSize;
        activeMonster.Add(gm);
    }
    /// <summary>
    /// 맵에 있는 몬스터 지우기
    /// </summary>
    void MonsterListDestroy()
    {
        //활성화 몬스터가 존재할때 적용
        if (activeMonster != null)
        {
            foreach (GameObject mob in activeMonster)
            {
                mob.gameObject.SetActive(false);
            }
            activeMonster.Clear();
        }
        //스폰위치 초기화
        spawnPositionList.Clear();
    }
}
