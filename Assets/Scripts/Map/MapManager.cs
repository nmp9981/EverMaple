using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    protected GameObject player;
    protected const string playerTag = "Player";

    protected int curMapNum;//���� �÷��̾ �ִ� ���� ��ȣ

    //�� ����Ű �����°�?
    public static bool isDownUpKey = false;

    protected virtual void Awake()
    {
        player = GameObject.Find("Player");
        curMapNum = 1;
    }

    /// <summary>
    /// ��Ż�� �̵�
    /// </summary>
    /// <param name="curNode"></param>
    /// <param name="nextNode"></param>
    public void MoveToPortal(int nextNode, int nextMapNum)
    {
        //��Ű ������ ǥ�� ����
        isDownUpKey = false;

        //ĳ���� ��� ��Ȱ��ȭ
        player.SetActive(false);

        //���������� �ٲ�
        PlayerManager.PlayerInstance.CurMapName = MapAndProtalList.mapList[nextMapNum].name;
        MapAndProtalList.mapList[nextMapNum].SetActive(true);
        MapAndProtalList.mapList[curMapNum].SetActive(false);
        curMapNum = nextMapNum;

        //ĳ���� Ȱ��ȭ
        player.SetActive(true);
        //ĳ���� ��ġ�� ��Ż ��ġ�� 
        float margin = 0.5f;
        player.transform.position = MapAndProtalList.portalList[nextNode].gameObject.transform.position
            +Vector3.up*margin;
    }
}
