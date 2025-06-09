using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentDataBase : MonoBehaviour
{
    //��� �̹��� ����Ʈ
    [SerializeField]
    List<Sprite> equipmentImageList = new List<Sprite>();
    
    private void Start()
    {
        EnrollEquipment();
    }

    #region ��� ���
    /// <summary>
    /// ��� ���
    /// </summary>
    void EnrollEquipment()
    {
        ItemManager.itemInstance.equipmentItemDic = new Dictionary<string, EquiipmentOption>();

        #region �ܰ�
        EquiipmentOption equiipmentOption0 
            = new EquiipmentOption(equipmentImageList[0],EquipmentType.Knife, 0,0,0,0,0,"",
            0,0,0,0,0,0,17,0,0,0,0,0,0,0);
        ItemManager.itemInstance.equipmentItemDic.Add("������ ���", equiipmentOption0);

        EquiipmentOption equiipmentOption1
            = new EquiipmentOption(equipmentImageList[1], EquipmentType.Knife, 8, 0, 0, 0, 0, "",
            0, 0, 0, 0, 0, 0, 24, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�ĸ��� ���", equiipmentOption1);

        EquiipmentOption equiipmentOption2
            = new EquiipmentOption(equipmentImageList[2], EquipmentType.Knife, 14, 0, 25, 0, 45, "",
            0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�ﰢ �ڸ��ٸ�", equiipmentOption2);
       
        EquiipmentOption equiipmentOption3
            = new EquiipmentOption(equipmentImageList[3], EquipmentType.Knife, 20, 0, 30, 0, 60, "",
            0, 0, 0, 0, 0, 1, 35, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�ʵ� ���", equiipmentOption3);

        EquiipmentOption equiipmentOption4
            = new EquiipmentOption(equipmentImageList[4], EquipmentType.Knife, 25, 0, 35, 0, 75, "",
            0, 0, 0, 0, 0, 1, 40, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("��ġ��", equiipmentOption4);

        EquiipmentOption equiipmentOption5
            = new EquiipmentOption(equipmentImageList[5], EquipmentType.Knife, 30, 0, 40, 0, 90, "",
            0, 0, 0, 0, 0, 2, 45, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�����ܵ�", equiipmentOption5);

        EquiipmentOption equiipmentOption6
            = new EquiipmentOption(equipmentImageList[6], EquipmentType.Knife, 35, 0, 45, 0, 105, "",
            0, 0, 0, 0, 0, 2, 50, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("���� ũ��", equiipmentOption6);

        EquiipmentOption equiipmentOption7
           = new EquiipmentOption(equipmentImageList[7], EquipmentType.Knife, 40, 0, 50, 0, 120, "",
           0, 0, 0, 0, 0, 3, 55, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�ݿ� �ڸ��ٸ�", equiipmentOption7);

        EquiipmentOption equiipmentOption8
           = new EquiipmentOption(equipmentImageList[8], EquipmentType.Knife, 45, 0, 55, 0, 135, "",
           0, 0, 0, 0, 0, 3, 60, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("����Ʈ", equiipmentOption8);

        EquiipmentOption equiipmentOption9
           = new EquiipmentOption(equipmentImageList[9], EquipmentType.Knife, 50, 0, 60, 0, 150, "",
           0, 0, 0, 0, 0, 4, 65, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("���񷯵�", equiipmentOption9);

        EquiipmentOption equiipmentOption10
           = new EquiipmentOption(equipmentImageList[10], EquipmentType.Knife, 55, 0, 65, 0, 165, "",
           0, 0, 0, 0, 0, 4, 70, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("��Ÿ", equiipmentOption10);

        EquiipmentOption equiipmentOption11
           = new EquiipmentOption(equipmentImageList[11], EquipmentType.Knife, 60, 0, 70, 0, 180, "",
           0, 0, 0, 0, 0, 5, 75, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("ĭ���", equiipmentOption11);

        EquiipmentOption equiipmentOption12
           = new EquiipmentOption(equipmentImageList[12], EquipmentType.Knife, 70, 0, 75, 0, 210, "",
           0, 0, 0, 0, 0, 5, 80, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("��õ��", equiipmentOption12);

        EquiipmentOption equiipmentOption13
           = new EquiipmentOption(equipmentImageList[13], EquipmentType.Knife, 80, 0, 80, 0, 240, "",
           0, 0, 0, 0, 0, 6, 85, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("Ŀ����", equiipmentOption13);

        EquiipmentOption equiipmentOption14
           = new EquiipmentOption(equipmentImageList[14], EquipmentType.Knife, 90, 0, 85, 0, 280, "",
           0, 0, 0, 0, 0, 6, 90, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�巡�� ĭ�ڸ�", equiipmentOption14);
        #endregion

        #region �ƴ�
        EquiipmentOption equiipmentOption15
           = new EquiipmentOption(equipmentImageList[15], EquipmentType.Claw, 8, 0, 0, 0, 0, "",
           0, 0, 0, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("���Ͼ�", equiipmentOption15);

        EquiipmentOption equiipmentOption16
            = new EquiipmentOption(equipmentImageList[16], EquipmentType.Claw, 14, 0, 25, 0, 45, "",
            0, 0, 0, 0, 0, 0, 14, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("Ƽź��", equiipmentOption16);

        EquiipmentOption equiipmentOption17
            = new EquiipmentOption(equipmentImageList[17], EquipmentType.Claw, 20, 0, 30, 0, 60, "",
            0, 0, 0, 0, 0, 1, 16, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�̰�", equiipmentOption17);

        EquiipmentOption equiipmentOption18
            = new EquiipmentOption(equipmentImageList[18], EquipmentType.Claw, 25, 0, 35, 0, 75, "",
            0, 0, 0, 0, 0, 1, 18, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�޹�", equiipmentOption18);

        EquiipmentOption equiipmentOption19
            = new EquiipmentOption(equipmentImageList[19], EquipmentType.Claw, 30, 0, 40, 0, 90, "",
            0, 0, 0, 0, 0, 2, 20, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("����", equiipmentOption19);

        EquiipmentOption equiipmentOption20
            = new EquiipmentOption(equipmentImageList[20], EquipmentType.Claw, 35, 0, 45, 0, 105, "",
            0, 0, 0, 0, 0, 2, 22, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�����", equiipmentOption20);

        EquiipmentOption equiipmentOption21
           = new EquiipmentOption(equipmentImageList[21], EquipmentType.Claw, 40, 0, 50, 0, 120, "",
           0, 0, 0, 0, 0, 3, 24, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("����", equiipmentOption21);

        EquiipmentOption equiipmentOption22
           = new EquiipmentOption(equipmentImageList[22], EquipmentType.Claw, 45, 0, 55, 0, 135, "",
           0, 0, 0, 0, 0, 3, 26, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("������", equiipmentOption22);

        EquiipmentOption equiipmentOption23
           = new EquiipmentOption(equipmentImageList[23], EquipmentType.Claw, 50, 0, 60, 0, 150, "",
           0, 0, 0, 0, 0, 4, 28, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�Ⱓƽ", equiipmentOption23);

        EquiipmentOption equiipmentOption24
           = new EquiipmentOption(equipmentImageList[24], EquipmentType.Claw, 55, 0, 65, 0, 165, "",
           0, 0, 0, 0, 0, 4, 30, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("Ȳ����", equiipmentOption24);

        EquiipmentOption equiipmentOption25
           = new EquiipmentOption(equipmentImageList[25], EquipmentType.Claw, 60, 0, 70, 0, 180, "",
           0, 0, 0, 0, 0, 5, 32, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�ں��Ƽ��", equiipmentOption25);

        EquiipmentOption equiipmentOption26
           = new EquiipmentOption(equipmentImageList[26], EquipmentType.Claw, 70, 0, 75, 0, 210, "",
           0, 0, 0, 0, 0, 5, 36, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("ĳ���ͽ�", equiipmentOption26);

        EquiipmentOption equiipmentOption27
           = new EquiipmentOption(equipmentImageList[27], EquipmentType.Claw, 80, 0, 80, 0, 240, "",
           0, 0, 0, 0, 0, 6, 40, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("���� ũ����", equiipmentOption27);

        EquiipmentOption equiipmentOption28
           = new EquiipmentOption(equipmentImageList[28], EquipmentType.Claw, 90, 0, 85, 0, 280, "",
           0, 0, 0, 0, 0, 6, 44, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�巡�� ���� ������", equiipmentOption28);
        #endregion

        #region ����
        EquiipmentOption equiipmentOption29
           = new EquiipmentOption(equipmentImageList[29], EquipmentType.Hat, 8, 0, 0, 0, 0, "",
           0, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("���� �Ӹ���", equiipmentOption29);

        EquiipmentOption equiipmentOption30
          = new EquiipmentOption(equipmentImageList[30], EquipmentType.Hat, 14, 0, 20, 0, 35, "",
          0, 0, 0, 0, 0, 0, 0, 0, 12, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("���� �ĵ�", equiipmentOption30);

        EquiipmentOption equiipmentOption31
         = new EquiipmentOption(equipmentImageList[31], EquipmentType.Hat, 20, 0, 25, 0, 50, "",
         0, 0, 0, 0, 0, 1, 0, 0, 15, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("����ĸ", equiipmentOption31);

        EquiipmentOption equiipmentOption32
         = new EquiipmentOption(equipmentImageList[32], EquipmentType.Hat, 30, 0, 30, 0, 80, "",
         0, 0, 0, 0, 0, 2, 0, 0, 20, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("���� ��", equiipmentOption32);

        EquiipmentOption equiipmentOption33
        = new EquiipmentOption(equipmentImageList[33], EquipmentType.Hat, 40, 0, 40, 0, 110, "",
        0, 0, 0, 0, 0, 3, 0, 0, 25, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("������", equiipmentOption33);

        EquiipmentOption equiipmentOption34
        = new EquiipmentOption(equipmentImageList[34], EquipmentType.Hat, 50, 0, 50, 0, 140, "",
        0, 0, 0, 0, 0, 4, 0, 0, 30, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("����", equiipmentOption34);

        EquiipmentOption equiipmentOption35
        = new EquiipmentOption(equipmentImageList[35], EquipmentType.Hat, 60, 0, 60, 0, 170, "",
        0, 0, 0, 0, 0, 5, 0, 0, 35, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("���̵��ĵ�", equiipmentOption35);

        EquiipmentOption equiipmentOption36
        = new EquiipmentOption(equipmentImageList[36], EquipmentType.Hat, 80, 0, 75, 0, 220, "",
        0, 0, 0, 0, 0, 7, 0, 0, 45, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�Ƿ�Ÿ��", equiipmentOption36);
        #endregion

        #region ����
        EquiipmentOption equiipmentOption37
        = new EquiipmentOption(equipmentImageList[37], EquipmentType.Up, 0, 0, 0, 0, 0, "",
        0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�Ͼ� ����Ƽ", equiipmentOption37);

        EquiipmentOption equiipmentOption38
        = new EquiipmentOption(equipmentImageList[38], EquipmentType.Up, 8, 0, 0, 0, 0, "",
        0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("���", equiipmentOption38);

        EquiipmentOption equiipmentOption39
        = new EquiipmentOption(equipmentImageList[39], EquipmentType.Up, 14, 0, 20, 0, 35, "",
        0, 0, 0, 0, 0, 1, 0, 0, 14, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("���", equiipmentOption39);

        EquiipmentOption equiipmentOption40
         = new EquiipmentOption(equipmentImageList[40], EquipmentType.Up, 20, 0, 25, 0, 50, "",
         0, 0, 0, 1, 0, 1, 0, 0, 18, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�Ŀ�", equiipmentOption40);

        EquiipmentOption equiipmentOption41
         = new EquiipmentOption(equipmentImageList[41], EquipmentType.Up, 30, 0, 30, 0, 80, "",
         0, 0, 0, 1, 0, 2, 0, 0, 27, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("����ũ", equiipmentOption41);

        EquiipmentOption equiipmentOption42
         = new EquiipmentOption(equipmentImageList[42], EquipmentType.Up, 40, 0, 40, 0, 110, "",
         0, 0, 0, 2, 0, 2, 0, 0, 36, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("��ƿ��", equiipmentOption42);

        EquiipmentOption equiipmentOption43
         = new EquiipmentOption(equipmentImageList[43], EquipmentType.Up, 50, 0, 50, 0, 140, "",
         0, 0, 0, 3, 0, 3, 0, 0, 45, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("��Ŭ����Ʈ", equiipmentOption43);

        EquiipmentOption equiipmentOption44
         = new EquiipmentOption(equipmentImageList[44], EquipmentType.Up, 60, 0, 60, 0, 170, "",
         0, 0, 0, 3, 0, 4, 0, 0, 54, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("������", equiipmentOption44);

        EquiipmentOption equiipmentOption45
         = new EquiipmentOption(equipmentImageList[45], EquipmentType.Up, 70, 0, 70, 0, 200, "",
         0, 0, 0, 4, 0, 4, 0, 0, 63, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�����ǿ�", equiipmentOption45);

        EquiipmentOption equiipmentOption46
         = new EquiipmentOption(equipmentImageList[46], EquipmentType.Up, 80, 0, 75, 0, 220, "",
         0, 0, 0, 4, 0, 5, 0, 0, 72, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�Ƕ���", equiipmentOption46);
        #endregion

        #region ����
        EquiipmentOption equiipmentOption47
        = new EquiipmentOption(equipmentImageList[47], EquipmentType.Down, 0, 0, 0, 0, 0, "",
        0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("û �ݹ���", equiipmentOption47);

        EquiipmentOption equiipmentOption48
        = new EquiipmentOption(equipmentImageList[48], EquipmentType.Down, 8, 0, 0, 0, 0, "",
        0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("��� ����", equiipmentOption48);

        EquiipmentOption equiipmentOption49
        = new EquiipmentOption(equipmentImageList[49], EquipmentType.Down, 14, 0, 20, 0, 35, "",
        0, 0, 0, 0, 0, 0, 0, 0, 11, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("��� ����", equiipmentOption49);

        EquiipmentOption equiipmentOption50
         = new EquiipmentOption(equipmentImageList[50], EquipmentType.Down, 20, 0, 25, 0, 50, "",
         0, 0, 0, 0, 0, 1, 0, 0, 15, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�Ŀ� ����", equiipmentOption50);

        EquiipmentOption equiipmentOption51
         = new EquiipmentOption(equipmentImageList[51], EquipmentType.Down, 30, 0, 30, 0, 80, "",
         0, 0, 0, 0, 0, 2, 0, 0, 22, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("����ũ ����", equiipmentOption51);

        EquiipmentOption equiipmentOption52
         = new EquiipmentOption(equipmentImageList[52], EquipmentType.Down, 40, 0, 40, 0, 110, "",
         0, 0, 0, 1, 0, 2, 0, 0, 29, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("��ƿ�� ����", equiipmentOption52);

        EquiipmentOption equiipmentOption53
         = new EquiipmentOption(equipmentImageList[53], EquipmentType.Down, 50, 0, 50, 0, 140, "",
         0, 0, 0, 1, 0, 3, 0, 0, 36, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("��Ŭ����Ʈ ����", equiipmentOption53);

        EquiipmentOption equiipmentOption54
         = new EquiipmentOption(equipmentImageList[54], EquipmentType.Down, 60, 0, 60, 0, 170, "",
         0, 0, 0, 2, 0, 3, 0, 0, 43, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("������ ����", equiipmentOption54);

        EquiipmentOption equiipmentOption55
         = new EquiipmentOption(equipmentImageList[55], EquipmentType.Down, 70, 0, 70, 0, 200, "",
         0, 0, 0, 2, 0, 4, 0, 0, 50, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�����ǿ� ����", equiipmentOption55);

        EquiipmentOption equiipmentOption56
         = new EquiipmentOption(equipmentImageList[56], EquipmentType.Down, 80, 0, 75, 0, 220, "",
         0, 0, 0, 3, 0, 5, 0, 0, 57, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�Ƕ��� ����", equiipmentOption56);
        #endregion

        #region �Ź�
        EquiipmentOption equiipmentOption57
        = new EquiipmentOption(equipmentImageList[57], EquipmentType.Shoes, 0, 0, 0, 0, 0, "",
        0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("���� �Ź�", equiipmentOption57);

        EquiipmentOption equiipmentOption58
        = new EquiipmentOption(equipmentImageList[58], EquipmentType.Shoes, 8, 0, 0, 0, 0, "",
        0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("���� ����", equiipmentOption58);

        EquiipmentOption equiipmentOption59
        = new EquiipmentOption(equipmentImageList[59], EquipmentType.Shoes, 14, 0, 20, 0, 35, "",
        0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("������ ����", equiipmentOption59);

        EquiipmentOption equiipmentOption60
         = new EquiipmentOption(equipmentImageList[60], EquipmentType.Shoes, 20, 0, 25, 0, 50, "",
         0, 0, 0, 0, 0, 1, 0, 0, 10, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("���� ����", equiipmentOption60);

        EquiipmentOption equiipmentOption61
         = new EquiipmentOption(equipmentImageList[61], EquipmentType.Shoes, 30, 0, 30, 0, 80, "",
         0, 0, 0, 0, 0, 1, 0, 0, 15, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("������", equiipmentOption61);

        EquiipmentOption equiipmentOption62
         = new EquiipmentOption(equipmentImageList[62], EquipmentType.Shoes, 40, 0, 40, 0, 110, "",
         0, 0, 0, 0, 0, 2, 0, 0, 20, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("��������", equiipmentOption62);

        EquiipmentOption equiipmentOption63
         = new EquiipmentOption(equipmentImageList[63], EquipmentType.Shoes, 50, 0, 50, 0, 140, "",
         0, 0, 0, 0, 0, 2, 0, 0, 25, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("��Ͻ���", equiipmentOption63);

        EquiipmentOption equiipmentOption64
         = new EquiipmentOption(equipmentImageList[64], EquipmentType.Shoes, 60, 0, 60, 0, 170, "",
         0, 0, 0, 1, 0, 3, 0, 0, 30, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�𽺺���", equiipmentOption64);

        EquiipmentOption equiipmentOption65
         = new EquiipmentOption(equipmentImageList[65], EquipmentType.Shoes, 70, 0, 70, 0, 200, "",
         0, 0, 0, 1, 0, 3, 0, 0, 35, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("��Ƽ�彴��", equiipmentOption65);

        EquiipmentOption equiipmentOption66
         = new EquiipmentOption(equipmentImageList[66], EquipmentType.Shoes, 80, 0, 75, 0, 220, "",
         0, 0, 0, 2, 0, 4, 0, 0, 40, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�Ƿ�Ÿ����", equiipmentOption66);
        #endregion

        #region �尩
        EquiipmentOption equiipmentOption67
        = new EquiipmentOption(equipmentImageList[67], EquipmentType.Glove, 10, 0, 0, 0, 0, "",
        0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�밡�� ���尩", equiipmentOption67);

        EquiipmentOption equiipmentOption68
         = new EquiipmentOption(equipmentImageList[68], EquipmentType.Glove, 20, 0, 25, 0, 50, "",
         0, 0, 0, 0, 0, 1, 1, 0, 6, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("��ƿ����", equiipmentOption68);

        EquiipmentOption equiipmentOption69
         = new EquiipmentOption(equipmentImageList[69], EquipmentType.Glove, 30, 0, 30, 0, 80, "",
         0, 0, 0, 0, 0, 1, 2, 0, 10, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�Ǻ��", equiipmentOption69);

        EquiipmentOption equiipmentOption70
         = new EquiipmentOption(equipmentImageList[70], EquipmentType.Glove, 40, 0, 40, 0, 110, "",
         0, 0, 0, 0, 0, 2, 3, 0, 14, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("Ŭ����", equiipmentOption70);

        EquiipmentOption equiipmentOption71
         = new EquiipmentOption(equipmentImageList[71], EquipmentType.Glove, 50, 0, 50, 0, 140, "",
         0, 0, 0, 0, 0, 2, 4, 0, 18, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("Ȳ���尩", equiipmentOption71);

        EquiipmentOption equiipmentOption72
         = new EquiipmentOption(equipmentImageList[72], EquipmentType.Glove, 60, 0, 60, 0, 170, "",
         0, 0, 0, 0, 0, 3, 5, 0, 22, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�Ŀ�", equiipmentOption72);

        EquiipmentOption equiipmentOption73
         = new EquiipmentOption(equipmentImageList[73], EquipmentType.Glove, 70, 0, 70, 0, 200, "",
         0, 0, 0, 0, 0, 3, 6, 0, 26, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("���̾", equiipmentOption73);

        EquiipmentOption equiipmentOption74
         = new EquiipmentOption(equipmentImageList[74], EquipmentType.Glove, 80, 0, 75, 0, 220, "",
         0, 0, 0, 0, 0, 4, 7, 0, 30, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�ι�", equiipmentOption74);
        #endregion

        #region �Ͱ�
        EquiipmentOption equiipmentOption75
        = new EquiipmentOption(equipmentImageList[75], EquipmentType.Earing, 10, 0, 0, 0, 0, "",
        0, 0, 0, 0, 1, 0, 0, 0, 0, 5, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�� �Ͱ�", equiipmentOption75);

        EquiipmentOption equiipmentOption76
         = new EquiipmentOption(equipmentImageList[76], EquipmentType.Earing, 20, 0, 0, 0, 0, "",
         0, 0, 0, 0, 2, 0, 0, 0, 0, 10, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("���� �Ͱ�", equiipmentOption76);

        EquiipmentOption equiipmentOption77
         = new EquiipmentOption(equipmentImageList[77], EquipmentType.Earing, 30, 0, 0, 0, 0, "",
         0, 0, 0, 0, 3, 0, 0, 0, 0, 15, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�����̾� �Ͱ�", equiipmentOption77);

        EquiipmentOption equiipmentOption78
         = new EquiipmentOption(equipmentImageList[78], EquipmentType.Earing, 40, 0, 0, 0, 0, "",
         0, 0, 0, 0, 4, 0, 0, 0, 0, 20, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("��� ��", equiipmentOption78);

        EquiipmentOption equiipmentOption79
         = new EquiipmentOption(equipmentImageList[79], EquipmentType.Earing, 50, 0, 0, 0, 0, "",
         0, 0, 0, 0, 5, 0, 0, 0, 0, 25, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�ذ� �Ͱ�", equiipmentOption79);

        EquiipmentOption equiipmentOption80
         = new EquiipmentOption(equipmentImageList[80], EquipmentType.Earing, 60, 0, 0, 0, 0, "",
         0, 0, 0, 0, 6, 0, 0, 0, 0, 30, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("ũ����Ż �ö����", equiipmentOption80);

        EquiipmentOption equiipmentOption81
         = new EquiipmentOption(equipmentImageList[81], EquipmentType.Earing, 70, 0, 0, 0, 0, "",
         0, 0, 0, 0, 7, 0, 0, 0, 0, 35, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("������ �̾", equiipmentOption81);

        EquiipmentOption equiipmentOption82
         = new EquiipmentOption(equipmentImageList[82], EquipmentType.Earing, 80, 0, 0, 0, 0, "",
         0, 0, 0, 0, 8, 0, 0, 0, 0, 40, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�ҵ� �̾", equiipmentOption82);

        EquiipmentOption equiipmentOption83
         = new EquiipmentOption(equipmentImageList[83], EquipmentType.Cape, 25, 0, 0, 0, 0, "",
         0, 0, 1, 1, 1, 1, 0, 0, 6, 12, 0, 0, 0, 10);
        ItemManager.itemInstance.equipmentItemDic.Add("�㸧�� ����", equiipmentOption83);

        EquiipmentOption equiipmentOption84
         = new EquiipmentOption(equipmentImageList[84], EquipmentType.Cape, 42, 0, 0, 0, 0, "",
         0, 0, 2, 2, 2, 2, 0, 0, 12, 18, 0, 3, 0, 15);
        ItemManager.itemInstance.equipmentItemDic.Add("��ī�罺�� ����", equiipmentOption84);
        #endregion
    }
    #endregion
}
