using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField]
    List<Transform> spawnPositionList = new List<Transform>();

    MonsterFulling monsterFulling;

    private void Awake()
    {
        monsterFulling = GameObject.Find("MonsterSpawn").GetComponent<MonsterFulling>();
        SetSpawnPosition();
    }
    void Start()
    {
        MonsterSpawnMapEnter();
    }

    /// <summary>
    /// 스폰 위치 설정
    /// </summary>
    void SetSpawnPosition()
    {
        GameObject spawnPosObject = this.gameObject.transform.GetChild(2).gameObject;
        foreach (Transform t in spawnPosObject.GetComponentInChildren<Transform>())
        {
            spawnPositionList.Add(t);
        }
    }

    /// <summary>
    /// 몬스터 스폰
    /// </summary>
    void MonsterSpawnMapEnter()
    {
        foreach (var spawnPos in spawnPositionList)
        {
            int genCount = 2;

            for (int i = 0; i < genCount; i++)
            {
                int mobNum = Random.Range(0, 2);
                GameObject gm = monsterFulling.MakeObj(mobNum);

                //몬스터의 크기
                float monsterYSize = gm.GetComponent<Collider2D>().bounds.size.y * 0.5f;

                //최종 생성 위치(몬스터 크기 고려)
                float randomXpos = Random.Range(-3, 3);
                gm.transform.position = spawnPos.position + Vector3.right*randomXpos+Vector3.up*monsterYSize;
            }
        }
        
    }
}
