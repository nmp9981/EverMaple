using UnityEngine;

public class MoveVillage
{
    MapManager mapManager = new MapManager();

    /// <summary>
    /// ������ �̵�
    /// </summary>
    public void MoveToNearVillage()
    {
        //���� ��ġ
        int villageMapIndex = SearchNearVillageIndex();

        switch (MapManager.playerMapLocal)
        {
            case LocalMapName.LithHarbor:
                mapManager.MoveToPortal(0,villageMapIndex);
                break;
            case LocalMapName.Henesys:
                mapManager.MoveToPortal(3, villageMapIndex);
                break;
            case LocalMapName.Ellinia:
                mapManager.MoveToPortal(17, villageMapIndex);
                break;
            case LocalMapName.Perion:
                mapManager.MoveToPortal(30, villageMapIndex);
                break;
            case LocalMapName.KerningCity:
                mapManager.MoveToPortal(41, villageMapIndex);
                break;
            case LocalMapName.SleepyWood:
                mapManager.MoveToPortal(57, villageMapIndex);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// ���� ����� ������ �ε���
    /// </summary>
    /// <returns></returns>
    int SearchNearVillageIndex()
    {
        return mapManager.villageList[(int)MapManager.playerMapLocal];
    }
}
