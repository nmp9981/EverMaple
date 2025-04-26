using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField]
    List<Transform> spawnPositionList = new List<Transform>();
    [SerializeField]
    List<int> appearMonsterNum = new List<int>();

    MonsterFulling monsterFulling;

    float resenTime = 5f;
    

    //�ʿ� Ȱ��ȭ�� ����
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
        ItemManager.itemInstance.ClearItemInFeild();
    }

    /// <summary>
    /// ���� ��ġ ����
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
    /// ���� ����
    /// </summary>
    void MonsterSpawnMapEnter()
    {
        for(int idx = 0;idx < spawnPositionList.Count;idx++)
        {
            int genCount = 2;

            for (int i = 0; i < genCount; i++)
            {
                int mobIndex = Random.Range(0, appearMonsterNum.Count);
                int mobNum = appearMonsterNum[mobIndex];
                GameObject gm = monsterFulling.MakeObj(mobNum);
                
                //���� ���� ��ġ ���
                MonsterInfo monsterInfo = gm.GetComponent<MonsterInfo>();
                monsterInfo.spawnPosNumber = idx;
                monsterInfo.spawnMap = PlayerManager.PlayerInstance.CurMapName;

                //������ ũ��
                float monsterYSize = gm.GetComponent<Collider2D>().bounds.size.y * 0.5f;

                //���� ���� ��ġ(���� ũ�� ���)
                float randomXpos = Random.Range(-30, 30)*0.1f;
                gm.transform.position = spawnPositionList[idx].position + Vector3.right*randomXpos+Vector3.up*monsterYSize;
                activeMonster.Add(gm);
            }
        }
        
    }
    /// <summary>
    /// ������ �Լ� �ҷ�����
    /// </summary>
    public void CallRespawn()
    {
        Invoke("MonsterRespawn", 5f);
    }
    /// <summary>
    /// ���� ����
    /// </summary>
    public void MonsterRespawn()
    {
        //���� ��ġ�� ������
        if (spawnPositionList.Count == 0)
        {
            SetSpawnPosition();
        }

        int spawnNum = Random.Range(0, this.spawnPositionList.Count);

        int mobIndex = Random.Range(0, appearMonsterNum.Count);
        int mobNum = appearMonsterNum[mobIndex];
        GameObject gm = monsterFulling.MakeObj(mobNum);

        //������ ũ��
        float monsterYSize = gm.GetComponent<Collider2D>().bounds.size.y * 0.5f;

        //���� ���� ��ġ
        MonsterInfo mobInfo = gm.GetComponent<MonsterInfo>();
        mobInfo.spawnPosNumber = spawnNum;
        mobInfo.spawnMap = PlayerManager.PlayerInstance.CurMapName;

        //���� ���� ��ġ(���� ũ�� ���)
        float randomXpos = Random.Range(-30, 30)*0.1f;
        gm.transform.position = spawnPositionList[spawnNum].position + Vector3.right * randomXpos + Vector3.up * monsterYSize;
        activeMonster.Add(gm);
    }
    /// <summary>
    /// �ʿ� �ִ� ���� �����
    /// </summary>
    void MonsterListDestroy()
    {
        //Ȱ��ȭ ���Ͱ� �����Ҷ� ����
        if (activeMonster != null)
        {
            foreach (GameObject mob in activeMonster)
            {
                if (mob == null)
                    continue;
                mob.gameObject.SetActive(false);
            }
            activeMonster.Clear();
        }
        //������ġ �ʱ�ȭ
        spawnPositionList.Clear();
    }
}
