using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquiipmentUI : MonoBehaviour
{
    //각 장비 유형별 이미지 위치 지정
    public List<Image> equipmentTypeImage = new List<Image>();
    public List<Sprite> dragImageList = new List<Sprite>();

    [SerializeField]
    StatUI statUI;

    private void Start()
    {
        InitEquipmentSet();
    }

    /// <summary>
    /// 초기 장비 착용
    /// </summary>
    void InitEquipmentSet()
    {
        //맨 처음에 무기 하나 들고 시작
        EquiipmentOption initWeapon = ItemManager.itemInstance.equipmentItemDic["도루코 대거"];
        PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Knife] = initWeapon;
        PlayerManager.PlayerInstance.PlayerAttack = initWeapon.addAttack;
        equipmentTypeImage[0].sprite = initWeapon.equipmentImage;
        PlayerManager.PlayerInstance.PlayerAttackWeapon = AttachWeapon.Knife;

        //나머지 장비
        EquiipmentOption initClawWeapon = new EquiipmentOption(string.Empty, null, EquipmentType.Claw, 0, 0, 0, 0, 0, "",
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Claw] = initClawWeapon;

        EquiipmentOption initHat = new EquiipmentOption(string.Empty, null, EquipmentType.Hat, 0, 0, 0, 0, 0, "",
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Hat] = initHat;
        equipmentTypeImage[1].sprite = null;

        EquiipmentOption initUP = new EquiipmentOption(string.Empty, null, EquipmentType.Up, 0, 0, 0, 0, 0, "",
           0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Up] = initUP;
        equipmentTypeImage[2].sprite = null;

        EquiipmentOption initDown = new EquiipmentOption(string.Empty, null, EquipmentType.Down, 0, 0, 0, 0, 0, "",
           0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Down] = initDown;
        equipmentTypeImage[3].sprite = null;

        EquiipmentOption initGlove = new EquiipmentOption(string.Empty, null, EquipmentType.Glove, 0, 0, 0, 0, 0, "",
           0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Glove] = initGlove;
        equipmentTypeImage[4].sprite = null;

        EquiipmentOption initShoes = new EquiipmentOption(string.Empty, null, EquipmentType.Shoes, 0, 0, 0, 0, 0, "",
           0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Shoes] = initShoes;
        equipmentTypeImage[5].sprite = null;

        EquiipmentOption initEaring = new EquiipmentOption(string.Empty, null, EquipmentType.Earing, 0, 0, 0, 0, 0, "",
           0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Earing] = initEaring;
        equipmentTypeImage[6].sprite = null;

        EquiipmentOption initCape = new EquiipmentOption(string.Empty, null, EquipmentType.Cape, 0, 0, 0, 0, 0, "",
           0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Cape] = initCape;
        equipmentTypeImage[7].sprite = null;
    }

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
    /// 매개 변수 : 장착할 장비
    /// </summary>
    public void AddEquipmentOption(EquiipmentOption equipmentOption)
    {
        //같은 장비인지 검사
        if (IsSameequipment(equipmentOption))
        {
            return;
        }

        //이미지 교체
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

        //기존에 낀 능력치는 제거
        if (!(equipmentOption.equipmentType==EquipmentType.Claw) && !(equipmentOption.equipmentType == EquipmentType.Knife))
        {
            if (eauipSP != null)
            {
                #region 기존에 낀 능력치 제거
                //스탯 제거
                PlayerManager.PlayerInstance.PlayerAddSTR -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addSTR;
                PlayerManager.PlayerInstance.PlayerAddDEX -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addDEX;
                PlayerManager.PlayerInstance.PlayerAddINT -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addINT;
                PlayerManager.PlayerInstance.PlayerAddLUK -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addLUK;

                //공격력 제거
                PlayerManager.PlayerInstance.PlayerAttack -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addAttack;
                PlayerManager.PlayerInstance.PlayerMagicPower -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addMagicAttack;

                //체력, 마나 제거
                PlayerManager.PlayerInstance.PlayerMaxHP -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addHP;
                PlayerManager.PlayerInstance.PlayerMaxMP -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addMP;

                //방어력
                PlayerManager.PlayerInstance.PlayerPhysicsArmor -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addPhysicsArmor;
                PlayerManager.PlayerInstance.PlayerMagicArmor -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addMagicArmor;

                //이동 관련
                PlayerManager.PlayerInstance.PlayerMoveSpeedRate -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addMoveSpeed;
                PlayerManager.PlayerInstance.JumpForceRate -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addJumpSpeed;

                //명중, 회피
                PlayerManager.PlayerInstance.PlayerAddAccurary -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addAccuracy;
                PlayerManager.PlayerInstance.PlayerAddAvoid -= PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].addAvoid;

                #endregion
            }
        }


        //무기 종류가 서로 다른 경우
        if (equipmentOption.equipmentType == EquipmentType.Claw || equipmentOption.equipmentType == EquipmentType.Knife)
        {
            if (PlayerManager.PlayerInstance.PlayerAttackWeapon == AttachWeapon.Claw)//아대 장착
            {
                PlayerManager.PlayerInstance.PlayerAddLUK -= PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Claw].addLUK;
                PlayerManager.PlayerInstance.PlayerAttack -= PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Claw].addAttack;
            }
            if (PlayerManager.PlayerInstance.PlayerAttackWeapon == AttachWeapon.Knife)//단검 장착
            {
                PlayerManager.PlayerInstance.PlayerAddLUK -= PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Knife].addLUK;
                PlayerManager.PlayerInstance.PlayerAttack -= PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Knife].addAttack;
            }
        }

        //장비 장착
        PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType] = equipmentOption;
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
        PlayerManager.PlayerInstance.PlayerMoveSpeedRate += equipmentOption.addMoveSpeed;
        PlayerManager.PlayerInstance.JumpForceRate += equipmentOption.addJumpSpeed;

        //명중, 회피
        PlayerManager.PlayerInstance.PlayerAddAccurary += equipmentOption.addAccuracy;
        PlayerManager.PlayerInstance.PlayerAddAvoid += equipmentOption.addAvoid;
        #endregion

        //장착 무기
        if (equipmentOption.equipmentType == EquipmentType.Claw)
            PlayerManager.PlayerInstance.PlayerAttackWeapon = AttachWeapon.Claw;

        if (equipmentOption.equipmentType == EquipmentType.Knife)
            PlayerManager.PlayerInstance.PlayerAttackWeapon = AttachWeapon.Knife;

        //스탯창 반영
        statUI.ShowCharacterBasicStat();
        statUI.ShowCharacterDetailStat();
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

        #region 능력치 제거
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
        PlayerManager.PlayerInstance.PlayerMoveSpeedRate -= equipmentOption.addMoveSpeed;
        PlayerManager.PlayerInstance.JumpForceRate -= equipmentOption.addJumpSpeed;

        //명중, 회피
        PlayerManager.PlayerInstance.PlayerAddAccurary -= equipmentOption.addAccuracy;
        PlayerManager.PlayerInstance.PlayerAddAvoid -= equipmentOption.addAvoid;

        //장착한 장비 제거
        PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType] = null;
        #endregion

        //스탯창 반영
        statUI.ShowCharacterBasicStat();
        statUI.ShowCharacterDetailStat();
    }

    /// <summary>
    /// 장착한 장비 해제
    /// </summary>
    public void CancelEquipmentInstallaion(string objType)
    {
        EquiipmentOption equipmentOption = null;
        Sprite equipSP = null;
        //이미지 교체
        switch (objType)
        {
            case "WeaponImage":
                Debug.Log(PlayerManager.PlayerInstance.playerSetEquipment[EquipmentType.Claw].equipmentImage.name);
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
        //해당 장비 능력치 제거
        if (equipSP != null)
        {
            MinusEquipmentOption(equipmentOption);
        }
    }
    /// <summary>
    /// 표창 이미지 변경
    /// </summary>
    /// <param name="dragNum"></param>
    public void ChangeDragImage(int dragNum)
    {
        equipmentTypeImage[8].sprite = dragImageList[dragNum];
    }

    /// <summary>
    /// 같은 장비인지 검사
    /// </summary>
    /// <returns></returns>
    bool IsSameequipment(EquiipmentOption equipmentOption)
    {
        //타입 동일하고 이름 같아야함
        if (PlayerManager.PlayerInstance.PlayerAttackWeapon == AttachWeapon.Knife && equipmentOption.equipmentType == EquipmentType.Claw)
        {
            return false;
        }
        if (PlayerManager.PlayerInstance.PlayerAttackWeapon == AttachWeapon.Claw && equipmentOption.equipmentType == EquipmentType.Knife)
        {
            return false;
        }

        if (equipmentOption.name == PlayerManager.PlayerInstance.playerSetEquipment[equipmentOption.equipmentType].name)
        {
            return true;
        }
        return false;
    }
}
