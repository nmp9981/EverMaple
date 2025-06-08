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

        #region 단검
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
            0, 0, 0, 0, 0, 1, 35, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("필드 대거", equiipmentOption3);

        EquiipmentOption equiipmentOption4
            = new EquiipmentOption(equipmentImageList[4], EquipmentType.Knife, 25, 0, 35, 0, 75, "",
            0, 0, 0, 0, 0, 1, 40, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("넙치검", equiipmentOption4);

        EquiipmentOption equiipmentOption5
            = new EquiipmentOption(equipmentImageList[5], EquipmentType.Knife, 30, 0, 40, 0, 90, "",
            0, 0, 0, 0, 0, 2, 45, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("쌍지단도", equiipmentOption5);

        EquiipmentOption equiipmentOption6
            = new EquiipmentOption(equipmentImageList[6], EquipmentType.Knife, 35, 0, 45, 0, 105, "",
            0, 0, 0, 0, 0, 2, 50, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("리프 크로", equiipmentOption6);

        EquiipmentOption equiipmentOption7
           = new EquiipmentOption(equipmentImageList[7], EquipmentType.Knife, 40, 0, 50, 0, 120, "",
           0, 0, 0, 0, 0, 3, 55, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("반월 자마다르", equiipmentOption7);

        EquiipmentOption equiipmentOption8
           = new EquiipmentOption(equipmentImageList[8], EquipmentType.Knife, 45, 0, 55, 0, 135, "",
           0, 0, 0, 0, 0, 3, 60, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("게파트", equiipmentOption8);

        EquiipmentOption equiipmentOption9
           = new EquiipmentOption(equipmentImageList[9], EquipmentType.Knife, 50, 0, 60, 0, 150, "",
           0, 0, 0, 0, 0, 4, 65, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("베즐러드", equiipmentOption9);

        EquiipmentOption equiipmentOption10
           = new EquiipmentOption(equipmentImageList[10], EquipmentType.Knife, 55, 0, 65, 0, 165, "",
           0, 0, 0, 0, 0, 4, 70, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("게타", equiipmentOption10);

        EquiipmentOption equiipmentOption11
           = new EquiipmentOption(equipmentImageList[11], EquipmentType.Knife, 60, 0, 70, 0, 180, "",
           0, 0, 0, 0, 0, 5, 75, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("칸디네", equiipmentOption11);

        EquiipmentOption equiipmentOption12
           = new EquiipmentOption(equipmentImageList[12], EquipmentType.Knife, 70, 0, 75, 0, 200, "",
           0, 0, 0, 0, 0, 5, 80, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("용천권", equiipmentOption12);

        EquiipmentOption equiipmentOption13
           = new EquiipmentOption(equipmentImageList[13], EquipmentType.Knife, 80, 0, 80, 0, 220, "",
           0, 0, 0, 0, 0, 6, 85, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("커세어", equiipmentOption13);

        EquiipmentOption equiipmentOption14
           = new EquiipmentOption(equipmentImageList[14], EquipmentType.Knife, 90, 0, 85, 0, 250, "",
           0, 0, 0, 0, 0, 6, 90, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("드래곤 칸자르", equiipmentOption14);
        #endregion

        #region 아대
        EquiipmentOption equiipmentOption15
           = new EquiipmentOption(equipmentImageList[15], EquipmentType.Claw, 8, 0, 0, 0, 0, "",
           0, 0, 0, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("가니어", equiipmentOption15);

        EquiipmentOption equiipmentOption16
            = new EquiipmentOption(equipmentImageList[16], EquipmentType.Claw, 14, 0, 25, 0, 45, "",
            0, 0, 0, 0, 0, 0, 14, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("티탄즈", equiipmentOption16);

        EquiipmentOption equiipmentOption17
            = new EquiipmentOption(equipmentImageList[17], EquipmentType.Claw, 20, 0, 30, 0, 60, "",
            0, 0, 0, 0, 0, 1, 16, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("이고르", equiipmentOption17);

        EquiipmentOption equiipmentOption18
            = new EquiipmentOption(equipmentImageList[18], EquipmentType.Claw, 25, 0, 35, 0, 75, "",
            0, 0, 0, 0, 0, 1, 18, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("메바", equiipmentOption18);

        EquiipmentOption equiipmentOption19
            = new EquiipmentOption(equipmentImageList[19], EquipmentType.Claw, 30, 0, 40, 0, 90, "",
            0, 0, 0, 0, 0, 2, 20, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("가즈", equiipmentOption19);

        EquiipmentOption equiipmentOption20
            = new EquiipmentOption(equipmentImageList[20], EquipmentType.Claw, 35, 0, 45, 0, 105, "",
            0, 0, 0, 0, 0, 2, 22, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("가디언", equiipmentOption20);

        EquiipmentOption equiipmentOption21
           = new EquiipmentOption(equipmentImageList[21], EquipmentType.Claw, 40, 0, 50, 0, 120, "",
           0, 0, 0, 0, 0, 3, 24, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("보닌", equiipmentOption21);

        EquiipmentOption equiipmentOption22
           = new EquiipmentOption(equipmentImageList[22], EquipmentType.Claw, 45, 0, 55, 0, 135, "",
           0, 0, 0, 0, 0, 3, 26, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("슬레인", equiipmentOption22);

        EquiipmentOption equiipmentOption23
           = new EquiipmentOption(equipmentImageList[23], EquipmentType.Claw, 50, 0, 60, 0, 150, "",
           0, 0, 0, 0, 0, 4, 28, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("기간틱", equiipmentOption23);

        EquiipmentOption equiipmentOption24
           = new EquiipmentOption(equipmentImageList[24], EquipmentType.Claw, 55, 0, 65, 0, 165, "",
           0, 0, 0, 0, 0, 4, 30, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("황갑충", equiipmentOption24);

        EquiipmentOption equiipmentOption25
           = new EquiipmentOption(equipmentImageList[25], EquipmentType.Claw, 60, 0, 70, 0, 180, "",
           0, 0, 0, 0, 0, 5, 32, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("코브라스티어", equiipmentOption25);

        EquiipmentOption equiipmentOption26
           = new EquiipmentOption(equipmentImageList[26], EquipmentType.Claw, 70, 0, 75, 0, 200, "",
           0, 0, 0, 0, 0, 5, 36, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("캐스터스", equiipmentOption26);

        EquiipmentOption equiipmentOption27
           = new EquiipmentOption(equipmentImageList[27], EquipmentType.Claw, 80, 0, 80, 0, 220, "",
           0, 0, 0, 0, 0, 6, 40, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("레드 크리븐", equiipmentOption27);

        EquiipmentOption equiipmentOption28
           = new EquiipmentOption(equipmentImageList[28], EquipmentType.Claw, 90, 0, 85, 0, 250, "",
           0, 0, 0, 0, 0, 6, 44, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("드래곤 퍼플 슬레브", equiipmentOption28);
        #endregion
    }
    #endregion
}
