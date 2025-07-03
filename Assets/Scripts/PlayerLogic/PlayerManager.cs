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
        if (PlayerInstance == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때
        {
            PlayerInstance = this; //내자신을 instance로 넣어줍니다.
            DontDestroyOnLoad(gameObject); //OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지
        }
        else
        {
            if (PlayerInstance != this) //instance가 내가 아니라면 이미 instance가 하나 존재하고 있다는 의미
                Destroy(this.gameObject); //둘 이상 존재하면 안되는 객체이니 방금 AWake된 자신을 삭제
        }
    }

    /// <summary>
    /// 플레이어 관련 배열 초기화
    /// </summary>
    void ArrayInitAboutPlayer()
    {
        for(int i = 0; i < haveConsumeItem.Length; i++)
        {
            haveConsumeItem[i] = 0;
        }
    }

    #region 변수 모음
    //이동관련
    float playerMoveSpeed = 4f;//이동 속도
    float playerMoveSpeedRate = 100;//이동속도 배율
    float jumpForce = 5f;//점프력
    float jumpForceRate = 100;//점프력 배율
    int maxJumpCount = 2;//최대 점프 횟수
    Vector3 playerLookDir = Vector3.left;//플레이어가 바라보는 방향

    //플레이어 기본 정보
    int playerLV = 1;
    int playerMaxLV = 110;
    string playerJob = "초보자";
    PlayerJobClass playerJobClass = PlayerJobClass.Beginer;
    string playerName = "Aruru";
    int playerCurHP;
    int playerMaxHP = 50;
    int playerCurMP;
    int playerMaxMP = 5;
    int playerCurExp = 0;
    int playerRequireExp = 12;
    int playerMeso = 0;

    //플레이어 스탯
    int playerAPPoint = 0;
    int playerSTR = 4;
    int playerDEX = 5;
    int playerINT = 4;
    int playerLUK = 12;

    int playerAddSTR = 0;
    int playerAddDEX = 0;
    int playerAddINT = 0;
    int playerAddLUK = 0;


    int weaponConst = 36;//무기 상수
    int playerAttack = 10;//플레이어 공격력
    int playerStatAttack;//플레이어 스탯 공격력
    int workmanship = 10;//숙련도
    int criticalProbably = 0;//크리티컬 확률
    int criticalDamage = 100;//크리티컬 데미지
    int playerAttackSpeed = 500;//공격 속도
    float playerAttackSkillSpeed = 0.7f;//스킬 공격 속도
    float throwObjectMaxDist = 6;//사거리

    int playerPhysicsArmor = 0;//물리 방어력
    int playerStatPhysicsArmor = 4;//물리 방어력 스탯
    int playerMagicPower = 4;//마력
    int playerMagicArmor = 0;//마법 방어력
    int playerStatMagicArmor = 4;//마법 방어력 스탯

    int playerAccurary = 38;//명중률
    int playerAvoid = 18;//회피율
    int playerDexterity = 17;//손재주

    int playerAddAccurary = 0;//명중률 증가량
    int playerAddAvoid = 0;//회피율 증가량

    int playerSkillPoint;//현재 스킬 포인트
    int totalUseSkillPoint;//총 사용 스킬 포인트

    int rateIncreaseGetMeso = 0;//메소 증가량
    int rateArmorMeso = 0;//방어율
    bool isActiveMesoGuard = false;//메소 가드 활성화 여부
    bool isShadowPartner = false;//쉐도우파트너 진행중인가?

    bool isPlayerDie = false;//캐릭터가 사망했는가?

    string curMapName = "Map0";
    bool isVillage = true;

    int shootDragNum = 0;//던질 표창의 번호
    public int[] dragAttackPower = new int[10]//표창 공격력
    {
        15,17,17,19,19,21,21,23,25,27
    };
    public int[] dragUpgradeLV = new int[12]//표창 업그레이드 레벨
    {
        10,15,20,25,30,35,40,50,70,85,111,200
    };

    public int[] haveConsumeItem = new int[30];

    //각 부위별 어떤 장비를 끼고 있는지 데이터 보관
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

    //초기 요구 겸험치
    public int[] ealryRequireExpArray = new int[15]
    {
        12,12,20,36,60,92,130,180,270,480,720,1100,1480,1880,2470
    };

    #region 이동 관련 변수
    public float PlayerMoveSpeed {  get { return playerMoveSpeed; } set { playerMoveSpeed = value; } }
    public float PlayerMoveSpeedRate { get { return playerMoveSpeedRate; }set { playerMoveSpeedRate = value; } }
    public float JumpForce { get { return jumpForce; } set { jumpForce = value; } }
    public float JumpForceRate { get { return jumpForceRate; }set { jumpForceRate = value; } }
    public int MaxJumpCount { get { return maxJumpCount; } set { maxJumpCount = value; } }
    public Vector3 PlayerLookDir { get { return playerLookDir; } set { playerLookDir = value; } }
    #endregion

    #region 플레이어 기본 정보
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

    //플레이어 스탯
    #region 플레이어 기본 스탯
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

    #region 맵관련
    public string CurMapName {  get { return curMapName; } set { curMapName = value; } }
    public bool IsVillage { get { return isVillage; } set { isVillage = value; } }
    #endregion

    #region 표창 관련
    public int ShootDragNum { get { return shootDragNum; } set { shootDragNum = value; } }
    #endregion

    #endregion
}
