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
        GameObject spawnPosObject = this.gameObject.transform.GetChild(2).gameObject;
        foreach(Transform t in spawnPosObject.GetComponentInChildren<Transform>())
        {
            spawnPositionList.Add(t);
        }
    }
    void Start()
    {
        MonsterSpawnMapEnter();
    }

    void MonsterSpawnMapEnter()
    {
        foreach (var spawnPos in spawnPositionList)
        {
            int genCount = 2;

            for (int i = 0; i < genCount; i++)
            {
                int mobNum = Random.Range(0, 2);
                GameObject gm = monsterFulling.MakeObj(mobNum);
                gm.transform.position = spawnPos.position+new Vector3(Random.Range(-3, 3), 0, 0);
                
            }
        }
        
    }
}
