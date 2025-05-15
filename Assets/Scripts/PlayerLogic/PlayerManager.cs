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

    //�÷��̾� ����
    int playerAPPoint = 0;
    int playerSTR = 4;
    int playerDEX = 25;
    int playerINT = 4;
    int playerLUK = 37;

    int playerAttack = 70;//�÷��̾� ���ݷ�
    int workmanship = 60;//���õ�
    int criticalProbably = 50;//ũ��Ƽ�� Ȯ��
    int playerAttackSpeed = 500;//���� �ӵ�
    float throwObjectMaxDist = 6;//��Ÿ�

    int playerPhysicsArmor = 4;//���� ����
    int playerMagicPower = 4;//����
    int playerMagicArmor = 4;//���� ����
    int playerAccurary = 38;//���߷�
    int playerAvoid = 18;//ȸ����
    int playerDexterity = 17;//������

    int playerAddAccurary = 0;//���߷� ������
    int playerAddAvoid = 0;//ȸ���� ������

    int playerSkillPoint;//���� ��ų ����Ʈ
    int totalUseSkillPoint;//�� ��� ��ų ����Ʈ

    string curMapName = "Map0";

    public int[] haveConsumeItem = new int[30];


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

    //�÷��̾� ����
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

    #region �ʰ���
    public string CurMapName {  get { return curMapName; } set { curMapName = value; } }
    #endregion
    #endregion
}
