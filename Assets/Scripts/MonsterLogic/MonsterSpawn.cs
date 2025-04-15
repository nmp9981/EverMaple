using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField]
    List<Transform> spawnPositionList = new List<Transform>();

    MonsterFulling monsterFulling;

    //�ʿ� Ȱ��ȭ�� ����
    public static List<GameObject> activeMonster = new List<GameObject>();

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
    /// ���� ��ġ ����
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
    /// ���� ����
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

                //������ ũ��
                float monsterYSize = gm.GetComponent<Collider2D>().bounds.size.y * 0.5f;

                //���� ���� ��ġ(���� ũ�� ���)
                float randomXpos = Random.Range(-3, 3);
                gm.transform.position = spawnPos.position + Vector3.right*randomXpos+Vector3.up*monsterYSize;
                activeMonster.Add(gm);
            }
        }
        
    }
    /// <summary>
    /// ���� ����
    /// </summary>
    public void MonsterRespawn(Vector3 spawnPos)
    {
        int mobNum = Random.Range(0, 2);
        GameObject gm = monsterFulling.MakeObj(mobNum);

        //������ ũ��
        float monsterYSize = gm.GetComponent<Collider2D>().bounds.size.y * 0.5f;

        //���� ���� ��ġ(���� ũ�� ���)
        float randomXpos = Random.Range(-3, 3);
        gm.transform.position = spawnPos + Vector3.right * randomXpos + Vector3.up * monsterYSize;
        activeMonster.Add(gm);
    }
}
