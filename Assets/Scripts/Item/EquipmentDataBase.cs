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
           = new EquiipmentOption(equipmentImageList[12], EquipmentType.Knife, 70, 0, 75, 0, 200, "",
           0, 0, 0, 0, 0, 5, 80, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("��õ��", equiipmentOption12);

        EquiipmentOption equiipmentOption13
           = new EquiipmentOption(equipmentImageList[13], EquipmentType.Knife, 80, 0, 80, 0, 220, "",
           0, 0, 0, 0, 0, 6, 85, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("Ŀ����", equiipmentOption13);

        EquiipmentOption equiipmentOption14
           = new EquiipmentOption(equipmentImageList[14], EquipmentType.Knife, 90, 0, 85, 0, 250, "",
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
           = new EquiipmentOption(equipmentImageList[26], EquipmentType.Claw, 70, 0, 75, 0, 200, "",
           0, 0, 0, 0, 0, 5, 36, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("ĳ���ͽ�", equiipmentOption26);

        EquiipmentOption equiipmentOption27
           = new EquiipmentOption(equipmentImageList[27], EquipmentType.Claw, 80, 0, 80, 0, 220, "",
           0, 0, 0, 0, 0, 6, 40, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("���� ũ����", equiipmentOption27);

        EquiipmentOption equiipmentOption28
           = new EquiipmentOption(equipmentImageList[28], EquipmentType.Claw, 90, 0, 85, 0, 250, "",
           0, 0, 0, 0, 0, 6, 44, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�巡�� ���� ������", equiipmentOption28);
        #endregion
    }
    #endregion
}
