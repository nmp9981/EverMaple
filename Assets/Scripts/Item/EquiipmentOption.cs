using UnityEngine;

/// <summary>
/// ��� Ÿ��
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
/// ��� �ɼ�
/// </summary>
public class EquiipmentOption : MonoBehaviour
{
    //��� �̹���
    public Sprite equipmentImage;

    //��� ����
    public EquipmentType equipmentType;

    //����
    public int reqLv;
    public int reqSTR;
    public int reqDEX;
    public int reqINT;
    public int reqLUK;
    public string reqJob;

    //ü��, ����
    public int addHP;
    public int addMP;

    //����
    public int addSTR;
    public int addDEX;
    public int addINT;
    public int addLUK;

    //���ݷ�
    public int addAttack;
    public int addMagicAttack;

    //����
    public int addPhysicsArmor;
    public int addMagicArmor;

    //�̼�,����
    public int addMoveSpeed;
    public int addJumpSpeed;

    //����, ȸ��
    public int addAccuracy;
    public int addAvoid;

    //���� �ǸŰ� 
    public int sellPrice;

    //������
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
