using System.Collections.Generic;
using UnityEngine;

public class MonsterFulling : MonoBehaviour
{
    //프리팹 준비
    const int blockMaxCount = 30;
    const int blockKinds = 27;
    public GameObject[] monsterPrefabs;
    public List<GameObject> bossPrefabObjList = new List<GameObject>();

    //오브젝트 배열
    GameObject[][] blocks;
    GameObject[] targetPool;

    void Awake()
    {
        blocks = new GameObject[blockKinds][]
        {
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount]
        };
        Generate();
    }
    void Generate()
    {
        //블록
        for (int i = 0; i < blockKinds; i++)
        {
            int mobCount = (i >= 25) ? 1 : blockMaxCount;
            for (int j = 0; j < mobCount; j++)
            {
                blocks[i][j] = Instantiate(monsterPrefabs[i]);
                blocks[i][j].transform.parent = this.transform;
                blocks[i][j].SetActive(false);

                //보스 등록
                if (i >= 25)
                {
                    bossPrefabObjList.Add(blocks[i][j]);
                }
            }
        }
    }
    //오브젝트 생성
    public GameObject MakeObj(int num)
    {
        targetPool = blocks[num];

        for (int i = 0; i < targetPool.Length; i++)
        {
            if (!targetPool[i].activeSelf)
            {
                targetPool[i].SetActive(true);//활성화 후 넘김
                return targetPool[i];
            }
        }
        return null;//없으면 빈 객체
    }
    //오브젝트 존재여부 확인
    public bool IsActiveObj(int num)
    {
        targetPool = blocks[num];

        for (int i = 0; i < targetPool.Length; i++)
        {
            if (targetPool[i].activeSelf) return true;//활성화된게 있으면
        }
        return false;//없으면 빈 객체
    }
    //오브젝트 존재하면 가져오기
    public GameObject GetObj(int num)
    {
        targetPool = blocks[num];

        for (int i = 0; i < targetPool.Length; i++)
        {
            if (targetPool[i].activeSelf) return targetPool[i];//활성화된게 있으면
        }
        return null;//없으면 빈 객체
    }
    //오브젝트 배열 가져오기
    public GameObject[] GetPool(int num)//지정한 오브젝트 풀 가져오기
    {
        targetPool = blocks[num];
        return targetPool;
    }
    //오브젝트들 비활성화
    public void OffObj()
    {
        for (int i = 0; i < blockKinds; i++)
        {
            for (int j = 0; j < blockMaxCount; j++)
            {
                if (blocks[i][j].activeSelf) blocks[i][j].SetActive(false);
            }
        }
    }
}
