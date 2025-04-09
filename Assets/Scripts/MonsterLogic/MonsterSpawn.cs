using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    MonsterFulling monsterFulling;
    private void Awake()
    {
        monsterFulling = GetComponent<MonsterFulling>();
    }
    
    void Start()
    {
        MonsterSpawnMapEnter();
    }

    void MonsterSpawnMapEnter()
    {
        int genCount = 5;

        for (int i = 0; i < genCount; i++)
        {
            int mobNum = Random.Range(0, 2);
            GameObject gm = monsterFulling.MakeObj(mobNum);
            gm.transform.position = new Vector3(Random.Range(-3,3),0,0);
        }
    }
}
