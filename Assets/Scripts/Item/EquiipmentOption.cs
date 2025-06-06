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
}
