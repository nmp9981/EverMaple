using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class EquiipmentUI : MonoBehaviour
{
    //�� ��� ������ �̹��� ��ġ ����
    public List<Image> equipmentTypeImage = new List<Image>();
    //�� ������ � ��� ���� �ִ��� ������ ����
    public Dictionary<EquipmentType, EquiipmentOption> playerSetEquipment = new Dictionary<EquipmentType, EquiipmentOption>(); 

    [SerializeField]
    StatUI statUI;

    /// <summary>
    /// �ش� ��� ������ �� �ִ��� üũ
    /// </summary>
    /// <param name="equipmentOption"></param>
    public bool CheckAbleUseEquipment(EquiipmentOption equipmentOption)
    {
        //���� üũ
        if (PlayerManager.PlayerInstance.PlayerLV < equipmentOption.reqLv)
            return false;

        //���� üũ
        if (PlayerManager.PlayerInstance.PlayerSTR + PlayerManager.PlayerInstance.PlayerAddSTR < equipmentOption.reqSTR)
            return false;
        if (PlayerManager.PlayerInstance.PlayerDEX + PlayerManager.PlayerInstance.PlayerAddDEX < equipmentOption.reqDEX)
            return false;
        if (PlayerManager.PlayerInstance.PlayerINT + PlayerManager.PlayerInstance.PlayerAddINT < equipmentOption.reqINT)
            return false;
        if (PlayerManager.PlayerInstance.PlayerLUK + PlayerManager.PlayerInstance.PlayerAddLUK < equipmentOption.reqLUK)
            return false;

        //���� üũ

        return true;
    }

    /// <summary>
    /// ��� �ɷ�ġ �߰�
    /// </summary>
    public void AddEquipmentOption(EquiipmentOption equipmentOption)
    {
        //�̹��� ��ü
        switch (equipmentOption.equipmentType)
        {
            case EquipmentType.Knife:
                equipmentTypeImage[0].sprite = equipmentOption.equipmentImage;
                break;
            case EquipmentType.Claw:
                equipmentTypeImage[0].sprite = equipmentOption.equipmentImage;
                break;
            case EquipmentType.Hat:
                equipmentTypeImage[1].sprite = equipmentOption.equipmentImage;
                break;
            case EquipmentType.Up:
                equipmentTypeImage[2].sprite = equipmentOption.equipmentImage;
                break;
            case EquipmentType.Down:
                equipmentTypeImage[3].sprite = equipmentOption.equipmentImage;
                break;
            case EquipmentType.Glove:
                equipmentTypeImage[4].sprite = equipmentOption.equipmentImage;
                break;
            case EquipmentType.Shoes:
                equipmentTypeImage[5].sprite = equipmentOption.equipmentImage;
                break;
            case EquipmentType.Earing:
                equipmentTypeImage[6].sprite = equipmentOption.equipmentImage;
                break;
            case EquipmentType.Cape:
                equipmentTypeImage[7].sprite = equipmentOption.equipmentImage;
                break;
            default:
                break;
        }

        //������ �� �ɷ�ġ�� ����
        if (playerSetEquipment[equipmentOption.equipmentType] != null)
        {
            #region ������ �� �ɷ�ġ ����
            //���� ����
            PlayerManager.PlayerInstance.PlayerAddSTR -= playerSetEquipment[equipmentOption.equipmentType].addSTR;
            PlayerManager.PlayerInstance.PlayerAddDEX -= playerSetEquipment[equipmentOption.equipmentType].addDEX;
            PlayerManager.PlayerInstance.PlayerAddINT -= playerSetEquipment[equipmentOption.equipmentType].addINT;
            PlayerManager.PlayerInstance.PlayerAddLUK -= playerSetEquipment[equipmentOption.equipmentType].addLUK;

            //���ݷ� ����
            PlayerManager.PlayerInstance.PlayerAttack -= playerSetEquipment[equipmentOption.equipmentType].addAttack;
            PlayerManager.PlayerInstance.PlayerMagicPower -= playerSetEquipment[equipmentOption.equipmentType].addMagicAttack;

            //ü��, ���� ����
            PlayerManager.PlayerInstance.PlayerMaxHP -= playerSetEquipment[equipmentOption.equipmentType].addHP;
            PlayerManager.PlayerInstance.PlayerMaxMP -= playerSetEquipment[equipmentOption.equipmentType].addMP;

            //����
            PlayerManager.PlayerInstance.PlayerPhysicsArmor -= playerSetEquipment[equipmentOption.equipmentType].addPhysicsArmor;
            PlayerManager.PlayerInstance.PlayerMagicArmor -= playerSetEquipment[equipmentOption.equipmentType].addMagicArmor;

            //�̵� ����
            PlayerManager.PlayerInstance.PlayerMoveSpeed -= playerSetEquipment[equipmentOption.equipmentType].addMoveSpeed;
            PlayerManager.PlayerInstance.JumpForce -= playerSetEquipment[equipmentOption.equipmentType].addJumpSpeed;

            //����, ȸ��
            PlayerManager.PlayerInstance.PlayerAddAccurary -= playerSetEquipment[equipmentOption.equipmentType].addAccuracy;
            PlayerManager.PlayerInstance.PlayerAddAvoid -= playerSetEquipment[equipmentOption.equipmentType].addAvoid;
            #endregion
        }

        //��� ����
        playerSetEquipment[equipmentOption.equipmentType] = equipmentOption;

        #region �ɷ�ġ �߰�
        //���� �߰�
        PlayerManager.PlayerInstance.PlayerAddSTR += equipmentOption.addSTR;
        PlayerManager.PlayerInstance.PlayerAddDEX += equipmentOption.addDEX;
        PlayerManager.PlayerInstance.PlayerAddINT += equipmentOption.addINT;
        PlayerManager.PlayerInstance.PlayerAddLUK += equipmentOption.addLUK;

        //���ݷ� �߰�
        PlayerManager.PlayerInstance.PlayerAttack += equipmentOption.addAttack;
        PlayerManager.PlayerInstance.PlayerMagicPower += equipmentOption.addMagicAttack;

        //ü��, ���� �߰�
        PlayerManager.PlayerInstance.PlayerMaxHP += equipmentOption.addHP;
        PlayerManager.PlayerInstance.PlayerMaxMP += equipmentOption.addMP;

        //����
        PlayerManager.PlayerInstance.PlayerPhysicsArmor += equipmentOption.addPhysicsArmor;
        PlayerManager.PlayerInstance.PlayerMagicArmor += equipmentOption.addMagicArmor;

        //�̵� ����
        PlayerManager.PlayerInstance.PlayerMoveSpeed += equipmentOption.addMoveSpeed;
        PlayerManager.PlayerInstance.JumpForce += equipmentOption.addJumpSpeed;

        //����, ȸ��
        PlayerManager.PlayerInstance.PlayerAddAccurary += equipmentOption.addAccuracy;
        PlayerManager.PlayerInstance.PlayerAddAvoid += equipmentOption.addAvoid;

        #endregion
    }

    /// <summary>
    /// ��� �ɷ�ġ ����
    /// </summary>
    /// <param name="equipmentOption"></param>
    public void MinusEquipmentOption(EquiipmentOption equipmentOption)
    {
        //�̹��� ��ü
        switch (equipmentOption.equipmentType)
        {
            case EquipmentType.Knife:
                equipmentTypeImage[0].sprite = null;
                break;
            case EquipmentType.Claw:
                equipmentTypeImage[0].sprite = null;
                break;
            case EquipmentType.Hat:
                equipmentTypeImage[1].sprite = null;
                break;
            case EquipmentType.Up:
                equipmentTypeImage[2].sprite = null;
                break;
            case EquipmentType.Down:
                equipmentTypeImage[3].sprite = null;
                break;
            case EquipmentType.Glove:
                equipmentTypeImage[4].sprite = null;
                break;
            case EquipmentType.Shoes:
                equipmentTypeImage[5].sprite = null;
                break;
            case EquipmentType.Earing:
                equipmentTypeImage[6].sprite = null;
                break;
            case EquipmentType.Cape:
                equipmentTypeImage[7].sprite =null;
                break;
            default:
                break;
        }

        #region �ɷ�ġ �߰�
        //���� �߰�
        PlayerManager.PlayerInstance.PlayerAddSTR -= equipmentOption.addSTR;
        PlayerManager.PlayerInstance.PlayerAddDEX -= equipmentOption.addDEX;
        PlayerManager.PlayerInstance.PlayerAddINT -= equipmentOption.addINT;
        PlayerManager.PlayerInstance.PlayerAddLUK -= equipmentOption.addLUK;

        //���ݷ� �߰�
        PlayerManager.PlayerInstance.PlayerAttack -= equipmentOption.addAttack;
        PlayerManager.PlayerInstance.PlayerMagicPower -= equipmentOption.addMagicAttack;

        //ü��, ���� �߰�
        PlayerManager.PlayerInstance.PlayerMaxHP -= equipmentOption.addHP;
        PlayerManager.PlayerInstance.PlayerMaxMP -= equipmentOption.addMP;

        //����
        PlayerManager.PlayerInstance.PlayerPhysicsArmor -= equipmentOption.addPhysicsArmor;
        PlayerManager.PlayerInstance.PlayerMagicArmor -= equipmentOption.addMagicArmor;

        //�̵� ����
        PlayerManager.PlayerInstance.PlayerMoveSpeed -= equipmentOption.addMoveSpeed;
        PlayerManager.PlayerInstance.JumpForce -= equipmentOption.addJumpSpeed;

        //����, ȸ��
        PlayerManager.PlayerInstance.PlayerAddAccurary -= equipmentOption.addAccuracy;
        PlayerManager.PlayerInstance.PlayerAddAvoid -= equipmentOption.addAvoid;

        #endregion
    }
}
