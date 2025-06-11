using System.Collections.Generic;
using UnityEngine;

public class DamageObjectFulling : MonoBehaviour
{
    public static DamageObjectFulling DamageSkinInstance = null;

    //������ �̹���
    public List<Sprite> damageImage = new List<Sprite>();
    public List<Sprite> criticalDamageImage = new List<Sprite>();
    public List<Sprite> hitDamageImage = new List<Sprite>();
    public List<Sprite> missDamageImage = new List<Sprite>();

    //������ �غ�
    const int blockMaxCount = 9;
    const int blockKinds = 32;
    public GameObject[] blockPrefabs;

    //������Ʈ �迭
    GameObject[][] blocks;
    GameObject[] targetPool;

    void Awake()
    {
        DamageSkinObjectLoad();

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
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount],
             new GameObject[blockMaxCount]
        };
        Generate();
    }

    /// <summary>
    /// �̱������� ����
    /// </summary>
    void DamageSkinObjectLoad()
    {
        if (DamageSkinInstance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            DamageSkinInstance = this; //���ڽ��� instance�� �־��ݴϴ�.
            DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
        }
        else
        {
            if (DamageSkinInstance != this) //instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ�
                Destroy(this.gameObject); //�� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ����
        }
    }
    void Generate()
    {
        //���
        for (int i = 0; i < blockKinds; i++)
        {
            for (int j = 0; j < blockMaxCount; j++)
            {
                blocks[i][j] = Instantiate(blockPrefabs[i]);
                blocks[i][j].SetActive(false);
                blocks[i][j].transform.parent = transform;//�ڽ� ������Ʈ�� ����
            }
        }
    }
    //������Ʈ ����
    public GameObject MakeObj(int num)
    {
        targetPool = blocks[num];

        for (int i = 0; i < targetPool.Length; i++)
        {
            if (!targetPool[i].activeSelf)
            {
                targetPool[i].SetActive(true);//Ȱ��ȭ �� �ѱ�
                return targetPool[i];
            }
        }
        return null;//������ �� ��ü
    }
    //������Ʈ ���翩�� Ȯ��
    public bool IsActiveObj(int num)
    {
        targetPool = blocks[num];

        for (int i = 0; i < targetPool.Length; i++)
        {
            if (targetPool[i].activeSelf) return true;//Ȱ��ȭ�Ȱ� ������
        }
        return false;//������ �� ��ü
    }
    //������Ʈ �����ϸ� ��������
    public GameObject GetObj(int num)
    {
        targetPool = blocks[num];

        for (int i = 0; i < targetPool.Length; i++)
        {
            if (targetPool[i].activeSelf) return targetPool[i];//Ȱ��ȭ�Ȱ� ������
        }
        return null;//������ �� ��ü
    }
    //������Ʈ �迭 ��������
    public GameObject[] GetPool(int num)//������ ������Ʈ Ǯ ��������
    {
        targetPool = blocks[num];
        return targetPool;
    }
    //������Ʈ�� ��Ȱ��ȭ
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
