using UnityEngine;

/// <summary>
/// 장비 타입
/// </summary>
public enum EquipmentType
{
    Claw,
    Knife,
    Hat,
    Up,
    Down,
    Glove,
    Shoes,
    Cape,
    Earing,
    Count
}

/// <summary>
/// 장비 옵션
/// </summary>
public class EquiipmentOption : MonoBehaviour
{
    //장비 이미지
    public Sprite equipmentImage;

    //장비 유형
    public EquipmentType equipmentType;

    //제한
    public int reqLv;
    public int reqSTR;
    public int reqDEX;
    public int reqINT;
    public int reqLUK;
    public string reqJob;

    //체력, 마나
    public int addHP;
    public int addMP;

    //스탯
    public int addSTR;
    public int addDEX;
    public int addINT;
    public int addLUK;

    //공격력
    public int addAttack;
    public int addMagicAttack;

    //방어력
    public int addPhysicsArmor;
    public int addMagicArmor;

    //이속,점프
    public int addMoveSpeed;
    public int addJumpSpeed;

    //명중, 회피
    public int addAccuracy;
    public int addAvoid;

    //상점 판매가 
    public int sellPrice;

    //생성자
    public EquiipmentOption(Sprite Esprite, EquipmentType EequipmentType, int EreqLV, int EreqSTR,int EreqDEX,int EreqINT,int EreqLUK,
        string EreqJob, int EaddHP, int EaddMP, int EaddSTR, int EaddDEX, int EaddINT, int EaddLUK, 
        int EaddAttack, int EaddMagicAttack, int EaddPArmor,int EaddMArmor,int EaddMove, int EaddJump, int EaddAcc, int EaddAvoid, int EsellPrice)
    {
        equipmentImage = Esprite;
        equipmentType = EequipmentType;

        reqLv = EreqLV;
        reqSTR = EreqSTR;
        reqDEX = EreqDEX;
        reqINT = EreqINT;
        reqLUK = EreqLUK;
        reqJob = EreqJob;

        addHP = EaddHP;
        addMP = EaddMP;

        addSTR = EaddSTR;
        addDEX = EaddDEX;
        addINT = EaddINT;
        addLUK = EaddLUK;

        addAttack = EaddAttack;
        addMagicAttack = EaddMagicAttack;

        addPhysicsArmor = EaddPArmor;
        addMagicArmor = EaddMArmor;

        addMoveSpeed = EaddMove;
        addJumpSpeed = EaddJump;

        addAccuracy = EaddAcc;
        addAvoid = EaddAvoid;

        sellPrice = EsellPrice;
    }
}
