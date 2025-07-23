using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquiipmentUI : MonoBehaviour
{
    //�� ��� ������ �̹��� ��ġ ����
    public List<Image> equipmentTypeImage = new List<Image>();
    public List<Sprite> dragImageList = new List<Sprite>();

    [SerializeField]
    StatUI statUI;

    private void Start()
    {
        InitEquipmentSet();
    }

    /// <summary>
    /// �ʱ� ��� ����
    /// </summary>
    void InitEquipmentSet()
    {
        EquiipmentOption initWeapon = ItemManager.itemInstance.equipmentItemDic["������ ���"];
        PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Knife] = initWeapon;
        PlayerManager.PlayerInstance.PlayerAttack = initWeapon.addAttack;
        equipmentTypeImage[0].sprite = initWeapon.equipmentImage;
    }

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
        Sprite eauipSP = null;
       
        switch (equipmentOption.equipmentType)
        {
            case EquipmentType.Knife:
                eauipSP = equipmentTypeImage[0].sprite;
                equipmentTypeImage[0].sprite = equipmentOption.equipmentImage;
                break;
            case EquipmentType.Claw:
                eauipSP = equipmentTypeImage[0].sprite;
                equipmentTypeImage[0].sprite = equipmentOption.equipmentImage;
                break;
            case EquipmentType.Hat:
                eauipSP = equipmentTypeImage[1].sprite;
                equipmentTypeImage[1].sprite = equipmentOption.equipmentImage;
                break;
            case EquipmentType.Up:
                eauipSP = equipmentTypeImage[2].sprite;
                equipmentTypeImage[2].sprite = equipmentOption.equipmentImage;
                break;
            case EquipmentType.Down:
                eauipSP = equipmentTypeImage[3].sprite;
                equipmentTypeImage[3].sprite = equipmentOption.equipmentImage;
                break;
            case EquipmentType.Glove:
                eauipSP = equipmentTypeImage[4].sprite;
                equipmentTypeImage[4].sprite = equipmentOption.equipmentImage;
                break;
            case EquipmentType.Shoes:
                eauipSP = equipmentTypeImage[5].sprite;
                equipmentTypeImage[5].sprite = equipmentOption.equipmentImage;
                break;
            case EquipmentType.Earing:
                eauipSP = equipmentTypeImage[6].sprite;
                equipmentTypeImage[6].sprite = equipmentOption.equipmentImage;
                break;
            case EquipmentType.Cape:
                eauipSP = equipmentTypeImage[7].sprite;
                equipmentTypeImage[7].sprite = equipmentOption.equipmentImage;
                break;
            default:
                break;
        }

        //������ �� �ɷ�ġ�� ����
        if (eauipSP!=null)
        {
            #region ������ �� �ɷ�ġ ����
            //������ ��� ����
            PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType] = null;

            //���� ����
            PlayerManager.PlayerInstance.PlayerAddSTR -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addSTR;
            PlayerManager.PlayerInstance.PlayerAddDEX -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addDEX;
            PlayerManager.PlayerInstance.PlayerAddINT -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addINT;
            PlayerManager.PlayerInstance.PlayerAddLUK -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addLUK;

            //���ݷ� ����
            PlayerManager.PlayerInstance.PlayerAttack -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addAttack;
            PlayerManager.PlayerInstance.PlayerMagicPower -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addMagicAttack;

            //ü��, ���� ����
            PlayerManager.PlayerInstance.PlayerMaxHP -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addHP;
            PlayerManager.PlayerInstance.PlayerMaxMP -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addMP;

            //����
            PlayerManager.PlayerInstance.PlayerPhysicsArmor -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addPhysicsArmor;
            PlayerManager.PlayerInstance.PlayerMagicArmor -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addMagicArmor;

            //�̵� ����
            PlayerManager.PlayerInstance.PlayerMoveSpeedRate -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addMoveSpeed;
            PlayerManager.PlayerInstance.JumpForceRate -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addJumpSpeed;

            //����, ȸ��
            PlayerManager.PlayerInstance.PlayerAddAccurary -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addAccuracy;
            PlayerManager.PlayerInstance.PlayerAddAvoid -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addAvoid;
            #endregion
        }


        //���� ������ ���� �ٸ� ���
        if (PlayerManager.PlayerInstance.PlayerJOBConfigEnum == PlayerJobConfig.NightLoad)//�ƴ� ����
        {
            if (equipmentOption.equipmentType == EquipmentType.Knife)
            {
                PlayerManager.PlayerInstance.PlayerAddLUK -= PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Claw].addLUK;
                PlayerManager.PlayerInstance.PlayerAttack -= PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Claw].addAttack;
            }
        }
        if (PlayerManager.PlayerInstance.PlayerJOBConfigEnum == PlayerJobConfig.Shadower)//�ܰ� ����
        {
            if (equipmentOption.equipmentType == EquipmentType.Claw)
            {
                PlayerManager.PlayerInstance.PlayerAddLUK -= PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Knife].addLUK;
                PlayerManager.PlayerInstance.PlayerAttack -= PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Knife].addAttack;
            }
        }

        //��� ����
        PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType] = equipmentOption;
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
        PlayerManager.PlayerInstance.PlayerMoveSpeedRate += equipmentOption.addMoveSpeed;
        PlayerManager.PlayerInstance.JumpForceRate += equipmentOption.addJumpSpeed;

        //����, ȸ��
        PlayerManager.PlayerInstance.PlayerAddAccurary += equipmentOption.addAccuracy;
        PlayerManager.PlayerInstance.PlayerAddAvoid += equipmentOption.addAvoid;
        #endregion

        //���� ����
        if (equipmentOption.equipmentType == EquipmentType.Claw)
            PlayerManager.PlayerInstance.PlayerJOBConfigEnum = PlayerJobConfig.NightLoad;

        if (equipmentOption.equipmentType == EquipmentType.Knife)
            PlayerManager.PlayerInstance.PlayerJOBConfigEnum = PlayerJobConfig.Shadower;

        //����â �ݿ�
        statUI.ShowCharacterBasicStat();
        statUI.ShowCharacterDetailStat();
    }

    /// <summary>
    /// ��� �ɷ�ġ ����
    /// </summary>
    /// <param name="equipmentOption"></param>
    public void MinusEquipmentOption(EquiipmentOption equipmentOption)
    {
        //������ ��� ����
        PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType] = null;

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

        #region �ɷ�ġ ����
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
        PlayerManager.PlayerInstance.PlayerMoveSpeedRate -= equipmentOption.addMoveSpeed;
        PlayerManager.PlayerInstance.JumpForceRate -= equipmentOption.addJumpSpeed;

        //����, ȸ��
        PlayerManager.PlayerInstance.PlayerAddAccurary -= equipmentOption.addAccuracy;
        PlayerManager.PlayerInstance.PlayerAddAvoid -= equipmentOption.addAvoid;

        #endregion

        //����â �ݿ�
        statUI.ShowCharacterBasicStat();
        statUI.ShowCharacterDetailStat();
    }

    /// <summary>
    /// ������ ��� ����
    /// </summary>
    public void CancelEquipmentInstallaion(string objType)
    {
        EquiipmentOption equipmentOption = null;
        Sprite equipSP = null;
        //�̹��� ��ü
        switch (objType)
        {
            case "WeaponImage":
                if (PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Knife].equipmentImage == null && PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Claw].equipmentImage != null)
                    equipmentOption = PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Claw];
                else if(PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Claw].equipmentImage == null && PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Knife].equipmentImage != null)
                    equipmentOption= PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Knife];
                equipSP = equipmentTypeImage[0].sprite;
                equipmentTypeImage[0].sprite = null;
                break;
            case "HatImage":
                if (PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Hat].equipmentImage != null)
                    equipmentOption = PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Hat];
                equipSP = equipmentTypeImage[1].sprite;
                equipmentTypeImage[1].sprite = null;
                break;
            case "UPClothesImage":
                if (PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Up].equipmentImage != null)
                    equipmentOption = PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Up];
                equipSP = equipmentTypeImage[2].sprite;
                equipmentTypeImage[2].sprite = null;
                break;
            case "DownClothesImage":
                if (PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Down].equipmentImage != null)
                    equipmentOption = PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Down];
                equipSP = equipmentTypeImage[3].sprite;
                equipmentTypeImage[3].sprite = null;
                break;
            case "GloveImage":
                if (PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Glove].equipmentImage != null)
                    equipmentOption = PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Glove];
                equipSP = equipmentTypeImage[4].sprite;
                equipmentTypeImage[4].sprite = null;
                break;
            case "ShoesImage":
                if (PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Shoes].equipmentImage != null)
                    equipmentOption = PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Shoes];
                equipSP = equipmentTypeImage[5].sprite;
                equipmentTypeImage[5].sprite = null;
                break;
            case "EaringImage":
                if (PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Earing].equipmentImage != null)
                    equipmentOption = PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Earing];
                equipSP = equipmentTypeImage[6].sprite;
                equipmentTypeImage[6].sprite = null;
                break;
            case "CapeImage":
                if (PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Cape].equipmentImage != null)
                    equipmentOption = PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Cape];
                equipSP = equipmentTypeImage[7].sprite;
                equipmentTypeImage[7].sprite = null;
                break;
            default:
                break;
        }
        //�ش� ��� �ɷ�ġ ����
        if (equipSP != null)
        {
            MinusEquipmentOption(equipmentOption);
        }
    }
    /// <summary>
    /// ǥâ �̹��� ����
    /// </summary>
    /// <param name="dragNum"></param>
    public void ChangeDragImage(int dragNum)
    {
        equipmentTypeImage[8].sprite = dragImageList[dragNum];
    }
}
