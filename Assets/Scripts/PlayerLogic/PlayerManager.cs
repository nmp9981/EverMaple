using UnityEngine;

public class PlayerManager : MonoBehaviour 
{
    public static PlayerManager PlayerInstance = null;

    private void Awake()
    {
        PlayerSingletonObjectLoad();
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

    #region 변수 모음
    //이동관련
    float playerMoveSpeed = 4f;//이동 속도
    float jumpForce = 5f;//점프력
    int maxJumpCount = 2;//최대 점프 횟수
    Vector3 playerLookDir = Vector3.left;//플레이어가 바라보는 방향

    //플레이어 기본 정보
    int playerLV = 200;
    string playerJob = "Night Load";
    string playerName = "Aruru";
    int playerCurHP;
    int playerMaxHP = 3000;
    int playerCurMP;
    int playerMaxMP = 2000;
    int playerCurExp = 0;
    int playerRequireExp = 40;

    int playerAttack = 80;//플레이어 공격력
    int workmanship = 60;//숙련도
    int criticalProbably = 50;//크리티컬 확률
    int playerAttackSpeed = 500;//공격 속도
    float throwObjectMaxDist = 8;//사거리

    string curMapName = "Map2";

    #region 이동 관련 변수
    public float PlayerMoveSpeed {  get { return playerMoveSpeed; } set { playerMoveSpeed = value; } }
    public float JumpForce { get { return jumpForce; } set { jumpForce = value; } }
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
    #endregion

    public int PlayerAttack { get { return playerAttack; } set { playerAttack = value; } }
    public int Workmanship {  get { return workmanship; } set { workmanship = value; } }
    public int CriticalProbably { get { return criticalProbably; }set { criticalProbably = value; } }
    public int PlayerAttackSpeed { get { return playerAttackSpeed; } set { playerAttackSpeed = value; } }
    public float ThrowObjectMaxDist { get { return throwObjectMaxDist; } set { throwObjectMaxDist = value; } }

    #region 맵관련
    public string CurMapName {  get { return curMapName; } set { curMapName = value; } }
    #endregion
    #endregion
}
