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
           = new EquiipmentOption(equipmentImageList[12], EquipmentType.Knife, 70, 0, 75, 0, 210, "",
           0, 0, 0, 0, 0, 5, 80, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("용천권", equiipmentOption12);

        EquiipmentOption equiipmentOption13
           = new EquiipmentOption(equipmentImageList[13], EquipmentType.Knife, 80, 0, 80, 0, 240, "",
           0, 0, 0, 0, 0, 6, 85, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("커세어", equiipmentOption13);

        EquiipmentOption equiipmentOption14
           = new EquiipmentOption(equipmentImageList[14], EquipmentType.Knife, 90, 0, 85, 0, 280, "",
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
           = new EquiipmentOption(equipmentImageList[26], EquipmentType.Claw, 70, 0, 75, 0, 210, "",
           0, 0, 0, 0, 0, 5, 36, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("캐스터스", equiipmentOption26);

        EquiipmentOption equiipmentOption27
           = new EquiipmentOption(equipmentImageList[27], EquipmentType.Claw, 80, 0, 80, 0, 240, "",
           0, 0, 0, 0, 0, 6, 40, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("레드 크리븐", equiipmentOption27);

        EquiipmentOption equiipmentOption28
           = new EquiipmentOption(equipmentImageList[28], EquipmentType.Claw, 90, 0, 85, 0, 280, "",
           0, 0, 0, 0, 0, 6, 44, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("드래곤 퍼플 슬레브", equiipmentOption28);
        #endregion

        #region 모자
        EquiipmentOption equiipmentOption29
           = new EquiipmentOption(equipmentImageList[29], EquipmentType.Hat, 8, 0, 0, 0, 0, "",
           0, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("빨간 머리띠", equiipmentOption29);

        EquiipmentOption equiipmentOption30
          = new EquiipmentOption(equipmentImageList[30], EquipmentType.Hat, 14, 0, 20, 0, 35, "",
          0, 0, 0, 0, 0, 0, 0, 0, 12, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("시프 후드", equiipmentOption30);

        EquiipmentOption equiipmentOption31
         = new EquiipmentOption(equipmentImageList[31], EquipmentType.Hat, 20, 0, 25, 0, 50, "",
         0, 0, 0, 0, 0, 1, 0, 0, 15, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("루즈캡", equiipmentOption31);

        EquiipmentOption equiipmentOption32
         = new EquiipmentOption(equipmentImageList[32], EquipmentType.Hat, 30, 0, 30, 0, 80, "",
         0, 0, 0, 0, 0, 2, 0, 0, 20, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("갈색 삿갓", equiipmentOption32);

        EquiipmentOption equiipmentOption33
        = new EquiipmentOption(equipmentImageList[33], EquipmentType.Hat, 40, 0, 40, 0, 110, "",
        0, 0, 0, 0, 0, 3, 0, 0, 25, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("가이즈", equiipmentOption33);

        EquiipmentOption equiipmentOption34
        = new EquiipmentOption(equipmentImageList[34], EquipmentType.Hat, 50, 0, 50, 0, 140, "",
        0, 0, 0, 0, 0, 4, 0, 0, 30, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("필퍼", equiipmentOption34);

        EquiipmentOption equiipmentOption35
        = new EquiipmentOption(equipmentImageList[35], EquipmentType.Hat, 60, 0, 60, 0, 170, "",
        0, 0, 0, 0, 0, 5, 0, 0, 35, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("하이드후드", equiipmentOption35);

        EquiipmentOption equiipmentOption36
        = new EquiipmentOption(equipmentImageList[36], EquipmentType.Hat, 80, 0, 75, 0, 220, "",
        0, 0, 0, 0, 0, 7, 0, 0, 45, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("피레타햇", equiipmentOption36);
        #endregion

        #region 상의
        EquiipmentOption equiipmentOption37
        = new EquiipmentOption(equipmentImageList[37], EquipmentType.Up, 0, 0, 0, 0, 0, "",
        0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("하얀 반팔티", equiipmentOption37);

        EquiipmentOption equiipmentOption38
        = new EquiipmentOption(equipmentImageList[38], EquipmentType.Up, 8, 0, 0, 0, 0, "",
        0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("흑몽", equiipmentOption38);

        EquiipmentOption equiipmentOption39
        = new EquiipmentOption(equipmentImageList[39], EquipmentType.Up, 14, 0, 20, 0, 35, "",
        0, 0, 0, 0, 0, 1, 0, 0, 14, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("흑야", equiipmentOption39);

        EquiipmentOption equiipmentOption40
         = new EquiipmentOption(equipmentImageList[40], EquipmentType.Up, 20, 0, 25, 0, 50, "",
         0, 0, 0, 1, 0, 1, 0, 0, 18, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("파오", equiipmentOption40);

        EquiipmentOption equiipmentOption41
         = new EquiipmentOption(equipmentImageList[41], EquipmentType.Up, 30, 0, 30, 0, 80, "",
         0, 0, 0, 1, 0, 2, 0, 0, 27, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("스니크", equiipmentOption41);

        EquiipmentOption equiipmentOption42
         = new EquiipmentOption(equipmentImageList[42], EquipmentType.Up, 40, 0, 40, 0, 110, "",
         0, 0, 0, 2, 0, 2, 0, 0, 36, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("스틸러", equiipmentOption42);

        EquiipmentOption equiipmentOption43
         = new EquiipmentOption(equipmentImageList[43], EquipmentType.Up, 50, 0, 50, 0, 140, "",
         0, 0, 0, 3, 0, 3, 0, 0, 45, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("너클베스트", equiipmentOption43);

        EquiipmentOption equiipmentOption44
         = new EquiipmentOption(equipmentImageList[44], EquipmentType.Up, 60, 0, 60, 0, 170, "",
         0, 0, 0, 3, 0, 4, 0, 0, 54, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("쉐도우", equiipmentOption44);

        EquiipmentOption equiipmentOption45
         = new EquiipmentOption(equipmentImageList[45], EquipmentType.Up, 70, 0, 70, 0, 200, "",
         0, 0, 0, 4, 0, 4, 0, 0, 63, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("스콜피오", equiipmentOption45);

        EquiipmentOption equiipmentOption46
         = new EquiipmentOption(equipmentImageList[46], EquipmentType.Up, 80, 0, 75, 0, 220, "",
         0, 0, 0, 4, 0, 5, 0, 0, 72, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("피라테", equiipmentOption46);
        #endregion

        #region 하의
        EquiipmentOption equiipmentOption47
        = new EquiipmentOption(equipmentImageList[47], EquipmentType.Down, 0, 0, 0, 0, 0, "",
        0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("청 반바지", equiipmentOption47);

        EquiipmentOption equiipmentOption48
        = new EquiipmentOption(equipmentImageList[48], EquipmentType.Down, 8, 0, 0, 0, 0, "",
        0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("흑몽 바지", equiipmentOption48);

        EquiipmentOption equiipmentOption49
        = new EquiipmentOption(equipmentImageList[49], EquipmentType.Down, 14, 0, 20, 0, 35, "",
        0, 0, 0, 0, 0, 0, 0, 0, 11, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("흑야 바지", equiipmentOption49);

        EquiipmentOption equiipmentOption50
         = new EquiipmentOption(equipmentImageList[50], EquipmentType.Down, 20, 0, 25, 0, 50, "",
         0, 0, 0, 0, 0, 1, 0, 0, 15, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("파오 바지", equiipmentOption50);

        EquiipmentOption equiipmentOption51
         = new EquiipmentOption(equipmentImageList[51], EquipmentType.Down, 30, 0, 30, 0, 80, "",
         0, 0, 0, 0, 0, 2, 0, 0, 22, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("스니크 바지", equiipmentOption51);

        EquiipmentOption equiipmentOption52
         = new EquiipmentOption(equipmentImageList[52], EquipmentType.Down, 40, 0, 40, 0, 110, "",
         0, 0, 0, 1, 0, 2, 0, 0, 29, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("스틸러 바지", equiipmentOption52);

        EquiipmentOption equiipmentOption53
         = new EquiipmentOption(equipmentImageList[53], EquipmentType.Down, 50, 0, 50, 0, 140, "",
         0, 0, 0, 1, 0, 3, 0, 0, 36, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("너클베스트 바지", equiipmentOption53);

        EquiipmentOption equiipmentOption54
         = new EquiipmentOption(equipmentImageList[54], EquipmentType.Down, 60, 0, 60, 0, 170, "",
         0, 0, 0, 2, 0, 3, 0, 0, 43, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("쉐도우 바지", equiipmentOption54);

        EquiipmentOption equiipmentOption55
         = new EquiipmentOption(equipmentImageList[55], EquipmentType.Down, 70, 0, 70, 0, 200, "",
         0, 0, 0, 2, 0, 4, 0, 0, 50, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("스콜피오 바지", equiipmentOption55);

        EquiipmentOption equiipmentOption56
         = new EquiipmentOption(equipmentImageList[56], EquipmentType.Down, 80, 0, 75, 0, 220, "",
         0, 0, 0, 3, 0, 5, 0, 0, 57, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("피라테 바지", equiipmentOption56);
        #endregion

        #region 신발
        EquiipmentOption equiipmentOption57
        = new EquiipmentOption(equipmentImageList[57], EquipmentType.Shoes, 0, 0, 0, 0, 0, "",
        0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("가죽 신발", equiipmentOption57);

        EquiipmentOption equiipmentOption58
        = new EquiipmentOption(equipmentImageList[58], EquipmentType.Shoes, 8, 0, 0, 0, 0, "",
        0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("닌자 샌들", equiipmentOption58);

        EquiipmentOption equiipmentOption59
        = new EquiipmentOption(equipmentImageList[59], EquipmentType.Shoes, 14, 0, 20, 0, 35, "",
        0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("에나멜 부츠", equiipmentOption59);

        EquiipmentOption equiipmentOption60
         = new EquiipmentOption(equipmentImageList[60], EquipmentType.Shoes, 20, 0, 25, 0, 50, "",
         0, 0, 0, 0, 0, 1, 0, 0, 10, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("래피 부츠", equiipmentOption60);

        EquiipmentOption equiipmentOption61
         = new EquiipmentOption(equipmentImageList[61], EquipmentType.Shoes, 30, 0, 30, 0, 80, "",
         0, 0, 0, 0, 0, 1, 0, 0, 15, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("아이젠", equiipmentOption61);

        EquiipmentOption equiipmentOption62
         = new EquiipmentOption(equipmentImageList[62], EquipmentType.Shoes, 40, 0, 40, 0, 110, "",
         0, 0, 0, 0, 0, 2, 0, 0, 20, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("하프슈즈", equiipmentOption62);

        EquiipmentOption equiipmentOption63
         = new EquiipmentOption(equipmentImageList[63], EquipmentType.Shoes, 50, 0, 50, 0, 140, "",
         0, 0, 0, 0, 0, 2, 0, 0, 25, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("고니슈즈", equiipmentOption63);

        EquiipmentOption equiipmentOption64
         = new EquiipmentOption(equipmentImageList[64], EquipmentType.Shoes, 60, 0, 60, 0, 170, "",
         0, 0, 0, 1, 0, 3, 0, 0, 30, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("모스부츠", equiipmentOption64);

        EquiipmentOption equiipmentOption65
         = new EquiipmentOption(equipmentImageList[65], EquipmentType.Shoes, 70, 0, 70, 0, 200, "",
         0, 0, 0, 1, 0, 3, 0, 0, 35, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("루티드슈즈", equiipmentOption65);

        EquiipmentOption equiipmentOption66
         = new EquiipmentOption(equipmentImageList[66], EquipmentType.Shoes, 80, 0, 75, 0, 220, "",
         0, 0, 0, 2, 0, 4, 0, 0, 40, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("피레타부츠", equiipmentOption66);
        #endregion

        #region 장갑
        EquiipmentOption equiipmentOption67
        = new EquiipmentOption(equipmentImageList[67], EquipmentType.Glove, 10, 0, 0, 0, 0, "",
        0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("노가다 목장갑", equiipmentOption67);

        EquiipmentOption equiipmentOption68
         = new EquiipmentOption(equipmentImageList[68], EquipmentType.Glove, 20, 0, 25, 0, 50, "",
         0, 0, 0, 0, 0, 1, 1, 0, 6, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("스틸라인", equiipmentOption68);

        EquiipmentOption equiipmentOption69
         = new EquiipmentOption(equipmentImageList[69], EquipmentType.Glove, 30, 0, 30, 0, 80, "",
         0, 0, 0, 0, 0, 1, 2, 0, 10, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("실비아", equiipmentOption69);

        EquiipmentOption equiipmentOption70
         = new EquiipmentOption(equipmentImageList[70], EquipmentType.Glove, 40, 0, 40, 0, 110, "",
         0, 0, 0, 0, 0, 2, 3, 0, 14, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("클리브", equiipmentOption70);

        EquiipmentOption equiipmentOption71
         = new EquiipmentOption(equipmentImageList[71], EquipmentType.Glove, 50, 0, 50, 0, 140, "",
         0, 0, 0, 0, 0, 2, 4, 0, 18, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("황월장갑", equiipmentOption71);

        EquiipmentOption equiipmentOption72
         = new EquiipmentOption(equipmentImageList[72], EquipmentType.Glove, 60, 0, 60, 0, 170, "",
         0, 0, 0, 0, 0, 3, 5, 0, 22, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("파우", equiipmentOption72);

        EquiipmentOption equiipmentOption73
         = new EquiipmentOption(equipmentImageList[73], EquipmentType.Glove, 70, 0, 70, 0, 200, "",
         0, 0, 0, 0, 0, 3, 6, 0, 26, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("와이어스", equiipmentOption73);

        EquiipmentOption equiipmentOption74
         = new EquiipmentOption(equipmentImageList[74], EquipmentType.Glove, 80, 0, 75, 0, 220, "",
         0, 0, 0, 0, 0, 4, 7, 0, 30, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("로버", equiipmentOption74);
        #endregion

        #region 귀고리
        EquiipmentOption equiipmentOption75
        = new EquiipmentOption(equipmentImageList[75], EquipmentType.Earing, 10, 0, 0, 0, 0, "",
        0, 0, 0, 0, 1, 0, 0, 0, 0, 5, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("추 귀고리", equiipmentOption75);

        EquiipmentOption equiipmentOption76
         = new EquiipmentOption(equipmentImageList[76], EquipmentType.Earing, 20, 0, 0, 0, 0, "",
         0, 0, 0, 0, 2, 0, 0, 0, 0, 10, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("번개 귀고리", equiipmentOption76);

        EquiipmentOption equiipmentOption77
         = new EquiipmentOption(equipmentImageList[77], EquipmentType.Earing, 30, 0, 0, 0, 0, "",
         0, 0, 0, 0, 3, 0, 0, 0, 0, 15, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("사파이어 귀고리", equiipmentOption77);

        EquiipmentOption equiipmentOption78
         = new EquiipmentOption(equipmentImageList[78], EquipmentType.Earing, 40, 0, 0, 0, 0, "",
         0, 0, 0, 0, 4, 0, 0, 0, 0, 20, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("블루 문", equiipmentOption78);

        EquiipmentOption equiipmentOption79
         = new EquiipmentOption(equipmentImageList[79], EquipmentType.Earing, 50, 0, 0, 0, 0, "",
         0, 0, 0, 0, 5, 0, 0, 0, 0, 25, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("해골 귀고리", equiipmentOption79);

        EquiipmentOption equiipmentOption80
         = new EquiipmentOption(equipmentImageList[80], EquipmentType.Earing, 60, 0, 0, 0, 0, "",
         0, 0, 0, 0, 6, 0, 0, 0, 0, 30, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("크리스탈 플라워링", equiipmentOption80);

        EquiipmentOption equiipmentOption81
         = new EquiipmentOption(equipmentImageList[81], EquipmentType.Earing, 70, 0, 0, 0, 0, "",
         0, 0, 0, 0, 7, 0, 0, 0, 0, 35, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("메이플 이어링", equiipmentOption81);

        EquiipmentOption equiipmentOption82
         = new EquiipmentOption(equipmentImageList[82], EquipmentType.Earing, 80, 0, 0, 0, 0, "",
         0, 0, 0, 0, 8, 0, 0, 0, 0, 40, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("소드 이어링", equiipmentOption82);

        EquiipmentOption equiipmentOption83
         = new EquiipmentOption(equipmentImageList[83], EquipmentType.Cape, 25, 0, 0, 0, 0, "",
         0, 0, 1, 1, 1, 1, 0, 0, 6, 12, 0, 0, 0, 10);
        ItemManager.itemInstance.equipmentItemDic.Add("허름한 망토", equiipmentOption83);

        EquiipmentOption equiipmentOption84
         = new EquiipmentOption(equipmentImageList[84], EquipmentType.Cape, 42, 0, 0, 0, 0, "",
         0, 0, 2, 2, 2, 2, 0, 0, 12, 18, 0, 3, 0, 15);
        ItemManager.itemInstance.equipmentItemDic.Add("이카루스의 망토", equiipmentOption84);
        #endregion
    }
    #endregion
}
