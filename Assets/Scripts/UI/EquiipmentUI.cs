using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class EquiipmentUI : MonoBehaviour
{
    //각 장비 유형별 이미지 위치 지정
    public List<Image> equipmentTypeImage = new List<Image>();
    //각 부위별 어떤 장비를 끼고 있는지 데이터 보관
    public Dictionary<EquipmentType, EquiipmentOption> playerSetEquipment = new Dictionary<EquipmentType, EquiipmentOption>(); 

    [SerializeField]
    StatUI statUI;

    /// <summary>
    /// 해당 장비를 착용할 수 있는지 체크
    /// </summary>
    /// <param name="equipmentOption"></param>
    public bool CheckAbleUseEquipment(EquiipmentOption equipmentOption)
    {
        //레벨 체크
        if (PlayerManager.PlayerInstance.PlayerLV < equipmentOption.reqLv)
            return false;

        //스탯 체크
        if (PlayerManager.PlayerInstance.PlayerSTR + PlayerManager.PlayerInstance.PlayerAddSTR < equipmentOption.reqSTR)
            return false;
        if (PlayerManager.PlayerInstance.PlayerDEX + PlayerManager.PlayerInstance.PlayerAddDEX < equipmentOption.reqDEX)
            return false;
        if (PlayerManager.PlayerInstance.PlayerINT + PlayerManager.PlayerInstance.PlayerAddINT < equipmentOption.reqINT)
            return false;
        if (PlayerManager.PlayerInstance.PlayerLUK + PlayerManager.PlayerInstance.PlayerAddLUK < equipmentOption.reqLUK)
            return false;

        //직업 체크

        return true;
    }

    /// <summary>
    /// 장비 능력치 추가
    /// </summary>
    public void AddEquipmentOption(EquiipmentOption equipmentOption)
    {
        //이미지 교체
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

        //기존에 낀 능력치는 제거
        if (playerSetEquipment[equipmentOption.equipmentType] != null)
        {
            #region 기존에 낀 능력치 제거
            //스탯 제거
            PlayerManager.PlayerInstance.PlayerAddSTR -= playerSetEquipment[equipmentOption.equipmentType].addSTR;
            PlayerManager.PlayerInstance.PlayerAddDEX -= playerSetEquipment[equipmentOption.equipmentType].addDEX;
            PlayerManager.PlayerInstance.PlayerAddINT -= playerSetEquipment[equipmentOption.equipmentType].addINT;
            PlayerManager.PlayerInstance.PlayerAddLUK -= playerSetEquipment[equipmentOption.equipmentType].addLUK;

            //공격력 제거
            PlayerManager.PlayerInstance.PlayerAttack -= playerSetEquipment[equipmentOption.equipmentType].addAttack;
            PlayerManager.PlayerInstance.PlayerMagicPower -= playerSetEquipment[equipmentOption.equipmentType].addMagicAttack;

            //체력, 마나 제거
            PlayerManager.PlayerInstance.PlayerMaxHP -= playerSetEquipment[equipmentOption.equipmentType].addHP;
            PlayerManager.PlayerInstance.PlayerMaxMP -= playerSetEquipment[equipmentOption.equipmentType].addMP;

            //방어력
            PlayerManager.PlayerInstance.PlayerPhysicsArmor -= playerSetEquipment[equipmentOption.equipmentType].addPhysicsArmor;
            PlayerManager.PlayerInstance.PlayerMagicArmor -= playerSetEquipment[equipmentOption.equipmentType].addMagicArmor;

            //이동 관련
            PlayerManager.PlayerInstance.PlayerMoveSpeed -= playerSetEquipment[equipmentOption.equipmentType].addMoveSpeed;
            PlayerManager.PlayerInstance.JumpForce -= playerSetEquipment[equipmentOption.equipmentType].addJumpSpeed;

            //명중, 회피
            PlayerManager.PlayerInstance.PlayerAddAccurary -= playerSetEquipment[equipmentOption.equipmentType].addAccuracy;
            PlayerManager.PlayerInstance.PlayerAddAvoid -= playerSetEquipment[equipmentOption.equipmentType].addAvoid;
            #endregion
        }

        //장비 장착
        playerSetEquipment[equipmentOption.equipmentType] = equipmentOption;

        #region 능력치 추가
        //스탯 추가
        PlayerManager.PlayerInstance.PlayerAddSTR += equipmentOption.addSTR;
        PlayerManager.PlayerInstance.PlayerAddDEX += equipmentOption.addDEX;
        PlayerManager.PlayerInstance.PlayerAddINT += equipmentOption.addINT;
        PlayerManager.PlayerInstance.PlayerAddLUK += equipmentOption.addLUK;

        //공격력 추가
        PlayerManager.PlayerInstance.PlayerAttack += equipmentOption.addAttack;
        PlayerManager.PlayerInstance.PlayerMagicPower += equipmentOption.addMagicAttack;

        //체력, 마나 추가
        PlayerManager.PlayerInstance.PlayerMaxHP += equipmentOption.addHP;
        PlayerManager.PlayerInstance.PlayerMaxMP += equipmentOption.addMP;

        //방어력
        PlayerManager.PlayerInstance.PlayerPhysicsArmor += equipmentOption.addPhysicsArmor;
        PlayerManager.PlayerInstance.PlayerMagicArmor += equipmentOption.addMagicArmor;

        //이동 관련
        PlayerManager.PlayerInstance.PlayerMoveSpeed += equipmentOption.addMoveSpeed;
        PlayerManager.PlayerInstance.JumpForce += equipmentOption.addJumpSpeed;

        //명중, 회피
        PlayerManager.PlayerInstance.PlayerAddAccurary += equipmentOption.addAccuracy;
        PlayerManager.PlayerInstance.PlayerAddAvoid += equipmentOption.addAvoid;

        #endregion
    }

    /// <summary>
    /// 장비 능력치 제거
    /// </summary>
    /// <param name="equipmentOption"></param>
    public void MinusEquipmentOption(EquiipmentOption equipmentOption)
    {
        //이미지 교체
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

        #region 능력치 추가
        //스탯 추가
        PlayerManager.PlayerInstance.PlayerAddSTR -= equipmentOption.addSTR;
        PlayerManager.PlayerInstance.PlayerAddDEX -= equipmentOption.addDEX;
        PlayerManager.PlayerInstance.PlayerAddINT -= equipmentOption.addINT;
        PlayerManager.PlayerInstance.PlayerAddLUK -= equipmentOption.addLUK;

        //공격력 추가
        PlayerManager.PlayerInstance.PlayerAttack -= equipmentOption.addAttack;
        PlayerManager.PlayerInstance.PlayerMagicPower -= equipmentOption.addMagicAttack;

        //체력, 마나 추가
        PlayerManager.PlayerInstance.PlayerMaxHP -= equipmentOption.addHP;
        PlayerManager.PlayerInstance.PlayerMaxMP -= equipmentOption.addMP;

        //방어력
        PlayerManager.PlayerInstance.PlayerPhysicsArmor -= equipmentOption.addPhysicsArmor;
        PlayerManager.PlayerInstance.PlayerMagicArmor -= equipmentOption.addMagicArmor;

        //이동 관련
        PlayerManager.PlayerInstance.PlayerMoveSpeed -= equipmentOption.addMoveSpeed;
        PlayerManager.PlayerInstance.JumpForce -= equipmentOption.addJumpSpeed;

        //명중, 회피
        PlayerManager.PlayerInstance.PlayerAddAccurary -= equipmentOption.addAccuracy;
        PlayerManager.PlayerInstance.PlayerAddAvoid -= equipmentOption.addAvoid;

        #endregion
    }
}
