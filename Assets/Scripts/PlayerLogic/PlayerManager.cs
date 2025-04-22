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
    Vector3 playerLookDir = Vector3.left;//�÷��̾ �ٶ󺸴� ����

    //�÷��̾� �⺻ ����
    int playerLV = 200;
    string playerJob = "Night Load";
    string playerName = "Aruru";
    int playerCurHP;
    int playerMaxHP = 3000;
    int playerCurMP;
    int playerMaxMP = 2000;
    int playerCurExp = 0;
    int playerRequireExp = 40;

    int playerAttack = 80;//�÷��̾� ���ݷ�
    int workmanship = 60;//���õ�
    int criticalProbably = 50;//ũ��Ƽ�� Ȯ��
    int playerAttackSpeed = 500;//���� �ӵ�
    float throwObjectMaxDist = 8;//��Ÿ�

    string curMapName = "Map2";

    #region �̵� ���� ����
    public float PlayerMoveSpeed {  get { return playerMoveSpeed; } set { playerMoveSpeed = value; } }
    public float JumpForce { get { return jumpForce; } set { jumpForce = value; } }
    public int MaxJumpCount { get { return maxJumpCount; } set { maxJumpCount = value; } }
    public Vector3 PlayerLookDir { get { return playerLookDir; } set { playerLookDir = value; } }
    #endregion

    #region �÷��̾� �⺻ ����
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

    #region �ʰ���
    public string CurMapName {  get { return curMapName; } set { curMapName = value; } }
    #endregion
    #endregion
}
