using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentDataBase : MonoBehaviour
{
    //장비 이미지 리스트
    [SerializeField]
    List<Sprite> equipmentImageList = new List<Sprite>();
    
    private void Start()
    {
        EnrollEquipment();
    }

    #region 장비 등록
    /// <summary>
    /// 장비 등록
    /// </summary>
    void EnrollEquipment()
    {
        ItemManager.itemInstance.equipmentItemDic = new Dictionary<string, EquiipmentOption>();

        EquiipmentOption equiipmentOption0 
            = new EquiipmentOption(equipmentImageList[0],EquipmentType.Knife, 0,0,0,0,0,"",
            0,0,0,0,0,0,17,0,0,0,0,0,0,0);
        ItemManager.itemInstance.equipmentItemDic.Add("도루코 대거", equiipmentOption0);

        EquiipmentOption equiipmentOption1
            = new EquiipmentOption(equipmentImageList[1], EquipmentType.Knife, 8, 0, 0, 0, 0, "",
            0, 0, 0, 0, 0, 0, 24, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("후르츠 대거", equiipmentOption1);

        EquiipmentOption equiipmentOption2
            = new EquiipmentOption(equipmentImageList[2], EquipmentType.Knife, 14, 0, 25, 0, 45, "",
            0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("삼각 자마다르", equiipmentOption2);

        EquiipmentOption equiipmentOption3
            = new EquiipmentOption(equipmentImageList[3], EquipmentType.Knife, 20, 0, 30, 0, 60, "",
            0, 0, 0, 0, 0, 0, 35, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("필드 대거", equiipmentOption3);

        EquiipmentOption equiipmentOption4
            = new EquiipmentOption(equipmentImageList[4], EquipmentType.Knife, 25, 0, 35, 0, 75, "",
            0, 0, 0, 0, 0, 0, 40, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("넙치검", equiipmentOption4);

        EquiipmentOption equiipmentOption5
            = new EquiipmentOption(equipmentImageList[5], EquipmentType.Knife, 30, 0, 40, 0, 90, "",
            0, 0, 0, 0, 0, 0, 45, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("쌍지단도", equiipmentOption5);
    }
    #endregion
}
