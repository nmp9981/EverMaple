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

    //플레이어 기본 정보
    int playerLV = 200;
    string playerJob = "Night Load";
    string playerName = "Aruru";
    float playerCurHP;
    float playerMaxHP = 3000;
    float playerCurMP;
    float playerMaxMP = 3000;
    float playerCurExp = 0;
    float playerRequireExp = 20250413;

    #region 이동 관련 변수
    public float PlayerMoveSpeed {  get { return playerMoveSpeed; } set { playerMoveSpeed = value; } }
    public float JumpForce { get { return jumpForce; } set { jumpForce = value; } }
    public int MaxJumpCount { get { return maxJumpCount; } set { maxJumpCount = value; } }
    #endregion

    #region 플레이어 기본 정보
    public int PlayerLV { get { return playerLV; } set { playerLV = value; } }
    public string PlayerJob { get { return playerJob; } set { playerJob = value; } }
    public string PlayerName { get { return playerName; } set { PlayerName = value; } }
    public float PlayerCurHP { get { return playerCurHP; } set {PlayerCurHP = value; } }
    public float PlayerMaxHP { get {return playerMaxHP; } set {playerMaxHP = value; } }
    public float PlayerCurMP { get { return playerCurMP; } set { playerCurMP = value; } }
    public float PlayerMaxMP { get { return playerMaxMP; } set { playerMaxMP = value; } }
    public float PlayerCurExp { get { return playerCurExp; } set {playerCurExp = value; } }
    public float PlayerRequireExp { get {return playerRequireExp; } set {playerCurExp=value; } }
    #endregion


    #endregion
}
