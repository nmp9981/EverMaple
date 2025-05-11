using UnityEngine;

public class MoveVillage
{
    MapManager mapManager = new MapManager();

    /// <summary>
    /// 마을로 이동
    /// </summary>
    public void MoveToNearVillage()
    {
        //마을 위치
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
                mapManager.MoveToPortal(12, villageMapIndex);
                break;
            case LocalMapName.Perion:
                mapManager.MoveToPortal(25, villageMapIndex);
                break;
            case LocalMapName.KerningCity:
                mapManager.MoveToPortal(36, villageMapIndex);
                break;
            case LocalMapName.SleepyWood:
                mapManager.MoveToPortal(49, villageMapIndex);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 가장 가까운 마을의 인덱스
    /// </summary>
    /// <returns></returns>
    int SearchNearVillageIndex()
    {
        return mapManager.villageList[(int)MapManager.playerMapLocal];
    }
}
