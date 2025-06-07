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
            0, 0, 0, 0, 0, 0, 35, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�ʵ� ���", equiipmentOption3);

        EquiipmentOption equiipmentOption4
            = new EquiipmentOption(equipmentImageList[4], EquipmentType.Knife, 25, 0, 35, 0, 75, "",
            0, 0, 0, 0, 0, 0, 40, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("��ġ��", equiipmentOption4);

        EquiipmentOption equiipmentOption5
            = new EquiipmentOption(equipmentImageList[5], EquipmentType.Knife, 30, 0, 40, 0, 90, "",
            0, 0, 0, 0, 0, 0, 45, 0, 0, 0, 0, 0, 0, 0);
        ItemManager.itemInstance.equipmentItemDic.Add("�����ܵ�", equiipmentOption5);
    }
    #endregion
}
