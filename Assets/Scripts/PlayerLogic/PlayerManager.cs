using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour 
{
    public static PlayerManager PlayerInstance = null;

    private void Awake()
    {
        PlayerSingletonObjectLoad();
        ArrayInitAboutPlayer();
    }
   
    void PlayerSingletonObjectLoad()
    {
        if (PlayerInstance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            PlayerInstance = this; //���ڽ��� instance�� �־��ݴϴ�.
            DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
        }
        else
        {
            if (PlayerInstance != this) //instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ�
                Destroy(this.gameObject); //�� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ����
        }
    }

    /// <summary>
    /// �÷��̾� ���� �迭 �ʱ�ȭ
    /// </summary>
    void ArrayInitAboutPlayer()
    {
        for(int i = 0; i < haveConsumeItem.Length; i++)
        {
            haveConsumeItem[i] = 0;
        }
    }

    #region ���� ����
    //�̵�����
    float playerMoveSpeed = 4f;//�̵� �ӵ�
    float playerMoveSpeedRate = 100;//�̵��ӵ� ����
    float jumpForce = 5f;//������
    float jumpForceRate = 100;//������ ����
    int maxJumpCount = 2;//�ִ� ���� Ƚ��
    Vector3 playerLookDir = Vector3.left;//�÷��̾ �ٶ󺸴� ����

    //�÷��̾� �⺻ ����
    int playerLV = 1;
    int playerMaxLV = 110;
    string playerJob = "�ʺ���";
    PlayerJobClass playerJobClass = PlayerJobClass.Beginer;
    string playerName = "Aruru";
    int playerCurHP;
    int playerMaxHP = 50;
    int playerCurMP;
    int playerMaxMP = 5;
    int playerCurExp = 0;
    int playerRequireExp = 12;
    int playerMeso = 0;

    //�÷��̾� ����
    int playerAPPoint = 0;
    int playerSTR = 4;
    int playerDEX = 5;
    int playerINT = 4;
    int playerLUK = 12;

    int playerAddSTR = 0;
    int playerAddDEX = 0;
    int playerAddINT = 0;
    int playerAddLUK = 0;


    int weaponConst = 36;//���� ���
    int playerAttack = 10;//�÷��̾� ���ݷ�
    int playerStatAttack;//�÷��̾� ���� ���ݷ�
    int workmanship = 10;//���õ�
    int criticalProbably = 0;//ũ��Ƽ�� Ȯ��
    int criticalDamage = 100;//ũ��Ƽ�� ������
    int playerAttackSpeed = 500;//���� �ӵ�
    float playerAttackSkillSpeed = 0.7f;//��ų ���� �ӵ�
    float throwObjectMaxDist = 6;//��Ÿ�

    int playerPhysicsArmor = 0;//���� ����
    int playerStatPhysicsArmor = 4;//���� ���� ����
    int playerMagicPower = 4;//����
    int playerMagicArmor = 0;//���� ����
    int playerStatMagicArmor = 4;//���� ���� ����

    int playerAccurary = 38;//���߷�
    int playerAvoid = 18;//ȸ����
    int playerDexterity = 17;//������

    int playerAddAccurary = 0;//���߷� ������
    int playerAddAvoid = 0;//ȸ���� ������

    int playerSkillPoint;//���� ��ų ����Ʈ
    int totalUseSkillPoint;//�� ��� ��ų ����Ʈ

    int rateIncreaseGetMeso = 0;//�޼� ������
    int rateArmorMeso = 0;//�����
    bool isActiveMesoGuard = false;//�޼� ���� Ȱ��ȭ ����
    bool isShadowPartner = false;//��������Ʈ�� �������ΰ�?

    bool isPlayerDie = false;//ĳ���Ͱ� ����ߴ°�?

    string curMapName = "Map0";
    bool isVillage = true;

    int shootDragNum = 0;//���� ǥâ�� ��ȣ
    public int[] dragAttackPower = new int[10]//ǥâ ���ݷ�
    {
        15,17,17,19,19,21,21,23,25,27
    };
    public int[] dragUpgradeLV = new int[12]//ǥâ ���׷��̵� ����
    {
        10,15,20,25,30,35,40,50,70,85,111,200
    };

    public int[] haveConsumeItem = new int[30];

    //�� ������ � ��� ���� �ִ��� ������ ����
    public Dictionary<EquipmentType, EquiipmentOption> playerSetEquipment = new Dictionary<EquipmentType, EquiipmentOption>(){
        { EquipmentType.Claw,new EquiipmentOption(null,EquipmentType.Claw, 0,0,0,0,0,"",
            0,0,0,0,0,0,-1,0,0,0,0,0,0,0,0)},
        { EquipmentType.Knife, new EquiipmentOption(null,EquipmentType.Knife, 0,0,0,0,0,"",
            0,0,0,0,0,0,-1,0,0,0,0,0,0,0,0)},
        { EquipmentType.Hat,new EquiipmentOption(null,EquipmentType.Hat, 0,0,0,0,0,"",
            0,0,0,0,0,0,-1,0,0,0,0,0,0,0,0)},
        { EquipmentType.Up,new EquiipmentOption(null,EquipmentType.Up, 0,0,0,0,0,"",
            0,0,0,0,0,0,-1,0,0,0,0,0,0,0,0)},
        { EquipmentType.Down,new EquiipmentOption(null,EquipmentType.Down, 0,0,0,0,0,"",
            0,0,0,0,0,0,-1,0,0,0,0,0,0,0,0)},
        { EquipmentType.Shoes,new EquiipmentOption(null,EquipmentType.Shoes, 0,0,0,0,0,"",
            0,0,0,0,0,0,-1,0,0,0,0,0,0,0,0)},
        { EquipmentType.Glove,new EquiipmentOption(null,EquipmentType.Glove, 0,0,0,0,0,"",
            0,0,0,0,0,0,-1,0,0,0,0,0,0,0,0)},
        { EquipmentType.Earing,new EquiipmentOption(null,EquipmentType.Earing, 0,0,0,0,0,"",
            0,0,0,0,0,0,-1,0,0,0,0,0,0,0,0)},
        { EquipmentType.Cape,new EquiipmentOption(null,EquipmentType.Cape, 0,0,0,0,0,"",
            0,0,0,0,0,0,-1,0,0,0,0,0,0,0,0)}
    };

    //�ʱ� �䱸 ����ġ
    public int[] ealryRequireExpArray = new int[15]
    {
        12,12,20,36,60,92,130,180,270,480,720,1100,1480,1880,2470
    };

    #region �̵� ���� ����
    public float PlayerMoveSpeed {  get { return playerMoveSpeed; } set { playerMoveSpeed = value; } }
    public float PlayerMoveSpeedRate { get { return playerMoveSpeedRate; }set { playerMoveSpeedRate = value; } }
    public float JumpForce { get { return jumpForce; } set { jumpForce = value; } }
    public float JumpForceRate { get { return jumpForceRate; }set { jumpForceRate = value; } }
    public int MaxJumpCount { get { return maxJumpCount; } set { maxJumpCount = value; } }
    public Vector3 PlayerLookDir { get { return playerLookDir; } set { playerLookDir = value; } }
    #endregion

    #region �÷��̾� �⺻ ����
    public int PlayerLV { get { return playerLV; } set { playerLV = value; } }
    public int PlayerMaxLV { get { return playerMaxLV; } set { playerMaxLV = value; } }
    public string PlayerJob { get { return playerJob; } set { playerJob = value; } }
    public PlayerJobClass PlayerJOBEnum { get { return playerJobClass; } set { playerJobClass = value; } }
    public string PlayerName { get { return playerName; } set { playerName = value; } }
    public int PlayerCurHP { get { return playerCurHP; } set {playerCurHP = value; } }
    public int PlayerMaxHP { get {return playerMaxHP; } set {playerMaxHP = value; } }
    public int PlayerCurMP { get { return playerCurMP; } set { playerCurMP = value; } }
    public int PlayerMaxMP { get { return playerMaxMP; } set { playerMaxMP = value; } }
    public int PlayerCurExp { get { return playerCurExp; } set {playerCurExp = value; } }
    public int PlayerRequireExp { get {return playerRequireExp; } set {playerRequireExp=value; } }
    public int PlayerMeso { get { return playerMeso; } set { playerMeso = value; } }
    #endregion

    //�÷��̾� ����
    #region �÷��̾� �⺻ ����
    public int PlayerAPPoint { get { return playerAPPoint; } set { playerAPPoint = value; } }
    public int PlayerSTR { get { return playerSTR; } set { playerSTR = value; }}
    public int PlayerDEX { get { return playerDEX; } set { playerDEX = value; } }
    public int PlayerINT { get { return playerINT; } set { playerINT = value; } }
    public int PlayerLUK { get { return playerLUK; } set { playerLUK = value; } }

    public int PlayerAddSTR { get { return playerAddSTR; } set { playerAddSTR = value; } }
    public int PlayerAddDEX { get { return playerAddDEX; } set { playerAddDEX = value; } }
    public int PlayerAddINT { get { return playerAddINT; } set { playerAddINT = value; } }
    public int PlayerAddLUK { get { return playerAddLUK; } set { playerAddLUK = value; } }
    #endregion

    public int WeaponConst { get { return weaponConst; } set { weaponConst = value; } }
    public int PlayerAttack { get { return playerAttack; } set { playerAttack = value; } }
    public int PlayerStatAttack { get { return playerStatAttack; } set { playerStatAttack = value; } }
    public int Workmanship {  get { return workmanship; } set { workmanship = value; } }
    public int CriticalProbably { get { return criticalProbably; }set { criticalProbably = value; } }
    public int CriticalDamagee { get { return criticalDamage; } set { criticalDamage = value; } }
    public int PlayerAttackSpeed { get { return playerAttackSpeed; } set { playerAttackSpeed = value; } }
    public float PlayerAttackSkillSpeed { get { return playerAttackSkillSpeed; } set { playerAttackSkillSpeed = value; } }
    public float ThrowObjectMaxDist { get { return throwObjectMaxDist; } set { throwObjectMaxDist = value; } }

    public int PlayerSkillPoint { get { return playerSkillPoint; } set { playerSkillPoint = value; } }
    public int TotalUseSkillPoint { get { return totalUseSkillPoint; } set { totalUseSkillPoint = value; } }

    public int PlayerPhysicsArmor { get { return playerPhysicsArmor; } set { playerPhysicsArmor = value; }}
    public int PlayerStatPhysicsArmor { get { return playerStatPhysicsArmor; } set { playerStatPhysicsArmor = value; } }
    public int PlayerMagicPower { get { return playerMagicPower; }set { playerMagicPower = value; } }
    public int PlayerMagicArmor { get { return playerMagicArmor; } set { playerMagicArmor = value; } }
    public int PlayerStatMagicArmor { get { return playerStatMagicArmor; } set { playerStatMagicArmor = value; } }
    public int PlayerAccurary { get { return playerAccurary; } set { playerAccurary = value; } }
    public int PlayerAvoid { get { return playerAvoid; } set { playerAvoid = value; } }
    public int PlayerDexterity { get { return playerDexterity; } set { playerDexterity = value; } }

    public int RateIncreaseGetMeso { get { return rateIncreaseGetMeso; } set { rateIncreaseGetMeso = value; } }
    public int RateArmorMeso { get { return rateArmorMeso; } set { rateArmorMeso = value; } }
    public bool IsActiveMesoGuard { get { return isActiveMesoGuard; } set { isActiveMesoGuard = value; } }
    public bool IsShadowPartner { get { return isShadowPartner; } set { isShadowPartner = value; } }

    public int PlayerAddAccurary { get { return playerAddAccurary; } set { playerAddAccurary = value; } }
    public int PlayerAddAvoid { get { return playerAddAvoid; } set { playerAddAvoid = value; } }

    public bool IsPlayerDie { get { return isPlayerDie; } set { isPlayerDie = value; } }

    #region �ʰ���
    public string CurMapName {  get { return curMapName; } set { curMapName = value; } }
    public bool IsVillage { get { return isVillage; } set { isVillage = value; } }
    #endregion

    #region ǥâ ����
    public int ShootDragNum { get { return shootDragNum; } set { shootDragNum = value; } }
    #endregion

    #endregion
}
