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

    #region ���� ����
    //�̵�����
    float playerMoveSpeed = 4f;//�̵� �ӵ�
    float jumpForce = 5f;//������
    int maxJumpCount = 2;//�ִ� ���� Ƚ��

    //�÷��̾� �⺻ ����
    int playerLV = 200;
    string playerJob = "Night Load";
    string playerName = "Aruru";
    float playerCurHP;
    float playerMaxHP = 3000;
    float playerCurMP;
    float playerMaxMP = 3000;
    float playerCurExp = 0;
    float playerRequireExp = 20250413;

    #region �̵� ���� ����
    public float PlayerMoveSpeed {  get { return playerMoveSpeed; } set { playerMoveSpeed = value; } }
    public float JumpForce { get { return jumpForce; } set { jumpForce = value; } }
    public int MaxJumpCount { get { return maxJumpCount; } set { maxJumpCount = value; } }
    #endregion

    #region �÷��̾� �⺻ ����
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
