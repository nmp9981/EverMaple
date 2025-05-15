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
    int playerLV = 10;
    string playerJob = "Night Load";
    string playerName = "Aruru";
    int playerCurHP;
    int playerMaxHP = 3000;
    int playerCurMP;
    int playerMaxMP = 2000;
    int playerCurExp = 0;
    int playerRequireExp = 40;
    int playerMeso = 100000;

    //플레이어 스탯
    int playerAPPoint = 0;
    int playerSTR = 4;
    int playerDEX = 25;
    int playerINT = 4;
    int playerLUK = 37;

    int playerAttack = 70;//플레이어 공격력
    int workmanship = 60;//숙련도
    int criticalProbably = 50;//크리티컬 확률
    int playerAttackSpeed = 500;//공격 속도
    float throwObjectMaxDist = 6;//사거리

    int playerPhysicsArmor = 4;//물리 방어력
    int playerMagicPower = 4;//마력
    int playerMagicArmor = 4;//마법 방어력
    int playerAccurary = 38;//명중률
    int playerAvoid = 18;//회피율
    int playerDexterity = 17;//손재주

    int playerAddAccurary = 0;//명중률 증가량
    int playerAddAvoid = 0;//회피율 증가량

    int playerSkillPoint;//현재 스킬 포인트
    int totalUseSkillPoint;//총 사용 스킬 포인트

    string curMapName = "Map0";

    public int[] haveConsumeItem = new int[30];


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
    public string PlayerJob { get { return playerJob; } set { playerJob = value; } }
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
    public int PlayerAPPoint { get { return playerAPPoint; } set { playerAPPoint = value; } }
    public int PlayerSTR { get { return playerSTR; } set { playerSTR = value; }}
    public int PlayerDEX { get { return playerDEX; } set { playerDEX = value; } }
    public int PlayerINT { get { return playerINT; } set { playerINT = value; } }
    public int PlayerLUK { get { return playerLUK; } set { playerLUK = value; } }


    public int PlayerAttack { get { return playerAttack; } set { playerAttack = value; } }
    public int Workmanship {  get { return workmanship; } set { workmanship = value; } }
    public int CriticalProbably { get { return criticalProbably; }set { criticalProbably = value; } }
    public int PlayerAttackSpeed { get { return playerAttackSpeed; } set { playerAttackSpeed = value; } }
    public float ThrowObjectMaxDist { get { return throwObjectMaxDist; } set { throwObjectMaxDist = value; } }

    public int PlayerSkillPoint { get { return playerSkillPoint; } set { playerSkillPoint = value; } }
    public int TotalUseSkillPoint { get { return totalUseSkillPoint; } set { totalUseSkillPoint = value; } }

    public int PlayerPhysicsArmor { get { return playerPhysicsArmor; } set { playerPhysicsArmor = value; }}
    public int PlayerMagicPower { get { return playerMagicPower; }set { playerMagicPower = value; } }
    public int PlayerMagicArmor { get { return playerMagicArmor; } set { playerMagicArmor = value; } }
    public int PlayerAccurary { get { return playerAccurary; } set { playerAccurary = value; } }
    public int PlayerAvoid { get { return playerAvoid; } set { playerAvoid = value; } }
    public int PlayerDexterity { get { return playerDexterity; } set { playerDexterity = value; } }

    public int PlayerAddAccurary { get { return playerAddAccurary; } set { playerAddAccurary = value; } }
    public int PlayerAddAvoid { get { return playerAddAvoid; } set { playerAddAvoid = value; } }

    #region 맵관련
    public string CurMapName {  get { return curMapName; } set { curMapName = value; } }
    #endregion
    #endregion
}
