using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using TMPro;

/// <summary>
/// ���� ��
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
    //�� ����Ű �����°�?
    public static bool isDownUpKey = false;
    //���� �÷��̾ �ִ� ����
    public static LocalMapName playerMapLocal = LocalMapName.LithHarbor;

    protected TextMeshProUGUI mapRealNameText;    
    protected GameObject player;
    protected const string playerTag = "Player";

    //���� ����Ʈ
    public int[] villageList = {0,2,6,12,17,22};

    protected virtual void Awake()
    {
        player = GameObject.Find("Player");
        mapRealNameText = GameObject.Find("MapNameText").GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// ��Ż�� �̵�
    /// </summary>
    /// <param name="curNode"></param>
    /// <param name="nextNode"></param>
    public async UniTask MoveToPortal(int nextNode, int nextMapNum)
    {
        //��Ű ������ ǥ�� ����
        isDownUpKey = false;

        //���������� �ٲ�
        PlayerManager.PlayerInstance.CurMapName = MapAndProtalList.mapList[nextMapNum].name;

        //�� UI����
        mapRealNameText.text = $"{realMapName[nextMapNum]}";

        await UniTask.Delay(100);
        MapAndProtalList.mapList[MapAndProtalList.curMapNum].SetActive(false);
        MapAndProtalList.mapList[nextMapNum].SetActive(true);
        MapAndProtalList.curMapNum = nextMapNum;

        //ĳ���� ��ġ�� ��Ż ��ġ�� 
        float margin = 0.5f;
        player.transform.position = MapAndProtalList.portalList[nextNode].gameObject.transform.position
            +Vector3.up*margin;

        //���� ��ġ �˻�
        LocalCheck(MapAndProtalList.curMapNum);
    }

    /// <summary>
    /// ���� ��ġ �˻�
    /// </summary>
    public void LocalCheck(int mapNumber)
    {
        if (mapNumber <= 1)
        {
            playerMapLocal = LocalMapName.LithHarbor;
        }
        else if (mapNumber >= 2 && mapNumber <= 4)
            playerMapLocal = LocalMapName.Henesys;
        else if (mapNumber >= 5 && mapNumber <= 9)
            playerMapLocal = LocalMapName.Ellinia;
        else if (mapNumber >= 10 && mapNumber <= 15)
            playerMapLocal = LocalMapName.Perion;
        else if (mapNumber >= 16 && mapNumber <= 20)
            playerMapLocal = LocalMapName.KerningCity;
        else
            playerMapLocal = LocalMapName.SleepyWood;
    }

    #region �� ���� �̸�
    protected string[] realMapName = new string[]{
        "�����ױ�",
        "�����ױ� : �����ױ� ���ֱ�",
        "��׽ý�",
        "��׽ý� : ��׽ý� �����",
        "��׽ý� : ��׽ý� ��",
        "�����Ͼ� : �����ʵ�",
        "�����Ͼ�",
        "�����Ͼ� : �ھƿ�������",
        "�����Ͼ� : �����ʵ�",
        "�����Ͼ� : �������� ���� ��",
        "�丮�� : �丮�� ���ʷ�",
        "�丮�� : ������",
        "�丮��",
        "�丮�� : ������",
        "�丮�� : �丮�� ���ʷ�",
        "�丮�� : �丮�� ��Ÿ������",
        "Ŀ�׽�Ƽ : Ŀ�׽�Ƽ ������",
        "Ŀ�׽�Ƽ",
        "Ŀ�׽�Ƽ : Ŀ�׽�Ƽ ������",
        "Ŀ�׽�Ƽ : ��Ȳ�� ��",
        "Ŀ�׽�Ƽ : ������ ũ����",
        "�����ǿ�� : ������",
        "�����ǿ��",
        "�����ǿ�� : ���̱� I",
        "�����ǿ�� : ���̱� II",
        "�����ǿ�� : ���� ���� ����",
        "�����ǿ�� : ������ �Ա�",
        "�����ǿ�� : ���ֹ�������"
    };
    #endregion
}
