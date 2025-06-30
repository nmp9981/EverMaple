using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StatUI : MonoBehaviour, IDragHandler
{
    //���� ������Ʈ
    [SerializeField]
    GameObject detailStatObject;

    //UI��ġ
    private RectTransform rectTransform;

    //�ؽ�Ʈ ����
    TextMeshProUGUI nameText;
    TextMeshProUGUI jobText;
    TextMeshProUGUI lvText;
    TextMeshProUGUI hpText;
    TextMeshProUGUI mpText;
    TextMeshProUGUI expText;

    TextMeshProUGUI apPointText;
    TextMeshProUGUI strText;
    TextMeshProUGUI dexText;
    TextMeshProUGUI intText;
    TextMeshProUGUI lukText;

    TextMeshProUGUI attackText;
    TextMeshProUGUI physicsArmorText;
    TextMeshProUGUI magicPowerText;
    TextMeshProUGUI magicArmorText;
    TextMeshProUGUI accuraryText;
    TextMeshProUGUI avoidText;
    TextMeshProUGUI dexterityText;
    TextMeshProUGUI moveSpeedText;
    TextMeshProUGUI jumpText;

    //��ư ����
    Button autoStatDivideButton;
    Button upSTRButton;
    Button upDEXButton;
    Button upINTButton;
    Button upLUKButton;
    Button detailButton;

    #region Unity �Լ�
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        BindingStatText();
        BindingStatButton();

        PlayerManager.PlayerInstance.PlayerStatAttack = CalculatorStatAttack();
    }
    
    private void OnEnable()
    {
        ShowCharacterBasicStat();
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }
    
    #endregion

    #region ���ε�
    /// <summary>
    /// �ؽ�Ʈ ���ε�
    /// </summary>
    void BindingStatText()
    {
        foreach(TextMeshProUGUI txt in gameObject.GetComponentsInChildren<TextMeshProUGUI>(true))
        {
            string name = txt.gameObject.name;
            switch (name)
            {
                case "nameText":
                    nameText = txt;
                    break;
                case "jobText":
                    jobText = txt;
                    break;
                case "lvText":
                    lvText = txt;
                    break;
                case "HPText":
                    hpText = txt;
                    break;
                case "MPText":
                    mpText = txt;
                    break;
                case "EXPText":
                    expText = txt;
                    break;
                case "APPoint":
                    apPointText = txt;
                    break;
                case "STRPoint":
                    strText = txt;
                    break;
                case "DexPoint":
                    dexText = txt;
                    break;
                case "IntPoint":
                    intText = txt;
                    break;
                case "LUKPoint":
                    lukText = txt;
                    break;
                case "attackText":
                    attackText = txt;
                    break;
                case "phyarmorText":
                    physicsArmorText = txt;
                    break;
                case "MagicPower":
                    magicPowerText= txt;
                    break;
                case "magicarmorText":
                    magicArmorText = txt;
                    break;
                case "accuracyText":
                    accuraryText = txt;
                    break;
                case "avoidText":
                    avoidText = txt;
                    break;
                case "dexterityText":
                    dexterityText = txt;
                    break;
                case "moveSpeed":
                    moveSpeedText = txt;
                    break;
                case "jumpPower":
                    jumpText = txt;
                    break;
                default:
                    break;
            }
        }
    }
    /// <summary>
    /// ��ư ���ε�
    /// </summary>
    void BindingStatButton()
    {
        foreach (Button btn in gameObject.GetComponentsInChildren<Button>(true))
        {
            string name = btn.gameObject.name;
            switch (name)
            {
                case "AutoDivide":
                    autoStatDivideButton = btn;
                    autoStatDivideButton.onClick.AddListener(AutoDivideStat);
                    break;
                case "STRUP":
                    upSTRButton = btn;
                    upSTRButton.onClick.AddListener(UpSTRStat);
                    break;
                case "DEXUP":
                    upDEXButton = btn;
                    upDEXButton.onClick.AddListener(UpDEXStat);
                    break;
                case "INTUP":
                    upINTButton = btn;
                    upINTButton.onClick.AddListener(UpINTStat);
                    break;
                case "LUKUP":
                    upLUKButton = btn;
                    upLUKButton.onClick.AddListener(UpLUKStat);
                    break;
                case "Detail":
                    detailButton = btn;
                    detailButton.onClick.AddListener(OnOffCharacterDetailStat);
                    break;
                default:
                    break;
            }
        }
    }
    #endregion

    #region ���� ���̱�
    /// <summary>
    /// �⺻ ���� ���̱�
    /// </summary>
    public void ShowCharacterBasicStat()
    {
        nameText.text = PlayerManager.PlayerInstance.PlayerName;
        
        jobText.text = PlayerManager.PlayerInstance.PlayerJob;
        lvText.text = PlayerManager.PlayerInstance.PlayerLV.ToString();
        hpText.text = $"{PlayerManager.PlayerInstance.PlayerCurHP} / {PlayerManager.PlayerInstance.PlayerMaxHP}";
        mpText.text = $"{PlayerManager.PlayerInstance.PlayerCurMP} / {PlayerManager.PlayerInstance.PlayerMaxMP}";

        float rate = (float)PlayerManager.PlayerInstance.PlayerCurExp / PlayerManager.PlayerInstance.PlayerRequireExp;
        rate = Mathf.Floor(rate*100);
        expText.text = $"{PlayerManager.PlayerInstance.PlayerCurExp} ({(int)rate})%";

        //�� ���� ����
        int totalLUK = PlayerManager.PlayerInstance.PlayerLUK + PlayerManager.PlayerInstance.PlayerAddLUK;
        int totalDEX = PlayerManager.PlayerInstance.PlayerDEX + PlayerManager.PlayerInstance.PlayerAddDEX;
        int totalSTR = PlayerManager.PlayerInstance.PlayerSTR + PlayerManager.PlayerInstance.PlayerAddSTR;
        int totalINT = PlayerManager.PlayerInstance.PlayerINT + PlayerManager.PlayerInstance.PlayerAddINT;

        apPointText.text = PlayerManager.PlayerInstance.PlayerAPPoint.ToString();
        strText.text = $"{totalSTR} ({PlayerManager.PlayerInstance.PlayerSTR} + {PlayerManager.PlayerInstance.PlayerAddSTR})";
        dexText.text = $"{totalDEX} ({PlayerManager.PlayerInstance.PlayerDEX} + {PlayerManager.PlayerInstance.PlayerAddDEX})";
        intText.text = $"{totalINT} ({PlayerManager.PlayerInstance.PlayerINT} + {PlayerManager.PlayerInstance.PlayerAddINT})";
        lukText.text = $"{totalLUK} ({PlayerManager.PlayerInstance.PlayerLUK} + {PlayerManager.PlayerInstance.PlayerAddLUK})";
    }
    /// <summary>
    /// �� ���� ���̱�
    /// </summary>
    public void ShowCharacterDetailStat()
    {
        //�� ���� ���
        CalculatorDetailStat();

        //����
        PlayerManager.PlayerInstance.PlayerStatAttack = CalculatorStatAttack();

        int maxAttack = PlayerManager.PlayerInstance.PlayerStatAttack;
        int minAttack = maxAttack * PlayerManager.PlayerInstance.Workmanship/100;
        attackText.text = $"{minAttack} ~ {maxAttack}";
        physicsArmorText.text = $"{PlayerManager.PlayerInstance.PlayerPhysicsArmor+ PlayerManager.PlayerInstance.PlayerStatPhysicsArmor}";
        magicPowerText.text = $"{PlayerManager.PlayerInstance.PlayerMagicPower}";
        magicArmorText.text = $"{PlayerManager.PlayerInstance.PlayerMagicArmor}";
        accuraryText.text = $"{PlayerManager.PlayerInstance.PlayerAccurary+ PlayerManager.PlayerInstance.PlayerAddAccurary}";
        avoidText.text = $"{PlayerManager.PlayerInstance.PlayerAvoid + PlayerManager.PlayerInstance.PlayerAddAvoid}";
        dexterityText.text = $"{PlayerManager.PlayerInstance.PlayerDexterity}";
        moveSpeedText.text = $"{PlayerManager.PlayerInstance.PlayerMoveSpeedRate}%";
        jumpText.text = $"{PlayerManager.PlayerInstance.JumpForceRate}%";
    }
    #endregion

    #region Button
    /// <summary>
    /// �� ���� ���̱� ��ư
    /// </summary>
    public void OnOffCharacterDetailStat()
    {
        if (detailStatObject.activeSelf)
            detailStatObject.SetActive(false);
        else
        {
            detailStatObject.SetActive(true);
            ShowCharacterDetailStat();
        }
    }
    /// <summary>
    /// ���� ����
    /// </summary>
    public void UpSTRStat()
    {
        //���� AP����Ʈ�� ����
        if (PlayerManager.PlayerInstance.PlayerAPPoint <= 0)
            return;

        PlayerManager.PlayerInstance.PlayerAPPoint -= 1;
        PlayerManager.PlayerInstance.PlayerSTR += 1;

        PlayerManager.PlayerInstance.PlayerStatAttack = CalculatorStatAttack();
        //������ ����� ���������
        ShowCharacterBasicStat();
        ShowCharacterDetailStat();
    }
    public void UpDEXStat()
    {
        //���� AP����Ʈ�� ����
        if (PlayerManager.PlayerInstance.PlayerAPPoint <= 0)
            return;

        PlayerManager.PlayerInstance.PlayerAPPoint -= 1;
        PlayerManager.PlayerInstance.PlayerDEX += 1;

        PlayerManager.PlayerInstance.PlayerStatAttack = CalculatorStatAttack();
        //������ ����� ���������
        ShowCharacterBasicStat();
        ShowCharacterDetailStat();
    }
    public void UpINTStat()
    {
        //���� AP����Ʈ�� ����
        if (PlayerManager.PlayerInstance.PlayerAPPoint <= 0)
            return;

        PlayerManager.PlayerInstance.PlayerAPPoint -= 1;
        PlayerManager.PlayerInstance.PlayerINT += 1;

        PlayerManager.PlayerInstance.PlayerStatAttack = CalculatorStatAttack();
        //������ ����� ���������
        ShowCharacterBasicStat();
        ShowCharacterDetailStat();
    }
    public void UpLUKStat()
    {
        //���� AP����Ʈ�� ����
        if (PlayerManager.PlayerInstance.PlayerAPPoint <= 0)
            return;

        PlayerManager.PlayerInstance.PlayerAPPoint -= 1;
        PlayerManager.PlayerInstance.PlayerLUK += 1;

        PlayerManager.PlayerInstance.PlayerStatAttack = CalculatorStatAttack();
        //������ ����� ���������
        ShowCharacterBasicStat();
        ShowCharacterDetailStat();
    }
    /// <summary>
    /// ���� �ڵ� �й� (������)
    /// </summary>
    public void AutoDivideStat()
    {
        //���� AP����Ʈ�� ����
        if (PlayerManager.PlayerInstance.PlayerAPPoint <= 0)
            return;

        //���� AP����Ʈ
        int restPoint = PlayerManager.PlayerInstance.PlayerAPPoint;

        //�й�
        int upDexPoint = restPoint / 5;
        int upLukPoint = restPoint - upDexPoint;
        PlayerManager.PlayerInstance.PlayerDEX += upDexPoint;
        PlayerManager.PlayerInstance.PlayerLUK += upLukPoint;

        //���
        PlayerManager.PlayerInstance.PlayerStatAttack = CalculatorStatAttack();
        PlayerManager.PlayerInstance.PlayerAPPoint = 0;

        //������ ����� ���������
        ShowCharacterBasicStat();
        ShowCharacterDetailStat();
    }

    /// <summary>
    /// �󼼽��� ���
    /// TODO : ��, ��ų�� �ö󰡴� ��ġ�� ����ؾ���
    /// </summary>
    void CalculatorDetailStat()
    {
        //�� ���� ����
        int totalLUK = PlayerManager.PlayerInstance.PlayerLUK + PlayerManager.PlayerInstance.PlayerAddLUK;
        int totalDEX = PlayerManager.PlayerInstance.PlayerDEX + PlayerManager.PlayerInstance.PlayerAddDEX;
        int totalSTR = PlayerManager.PlayerInstance.PlayerSTR + PlayerManager.PlayerInstance.PlayerAddSTR;
        int totalINT = PlayerManager.PlayerInstance.PlayerINT + PlayerManager.PlayerInstance.PlayerAddINT;

        //��Ʈ 1�� ���� 1, ����1 ����
        PlayerManager.PlayerInstance.PlayerMagicPower = totalINT;

        //���� ����
        PlayerManager.PlayerInstance.PlayerStatPhysicsArmor = (3 * totalSTR + totalDEX) / 9;

        //���� ����
        PlayerManager.PlayerInstance.PlayerMagicArmor  = totalINT;

        //���߷�
        PlayerManager.PlayerInstance.PlayerAccurary = (8 * totalDEX + 5 * totalLUK) / 10;
            
        //ȸ����
        PlayerManager.PlayerInstance.PlayerAvoid = (5 * totalLUK) / 10;

        //������
        PlayerManager.PlayerInstance.PlayerDexterity =
          (totalSTR+totalDEX+totalINT+totalLUK) / 4;
    }
    /// <summary>
    /// ���� ��� (������)
    /// </summary>
    int CalculatorStatAttack()
    {
        int totalLUK = PlayerManager.PlayerInstance.PlayerLUK + PlayerManager.PlayerInstance.PlayerAddLUK;
        int totalDEX = PlayerManager.PlayerInstance.PlayerDEX + PlayerManager.PlayerInstance.PlayerAddDEX;
        int totalSTR = PlayerManager.PlayerInstance.PlayerSTR + PlayerManager.PlayerInstance.PlayerAddSTR;
        int statTotal = (totalLUK* PlayerManager.PlayerInstance.WeaponConst / 10)+ totalDEX + totalSTR;

        int dragAttack = PlayerManager.PlayerInstance.dragAttackPower[PlayerManager.PlayerInstance.ShootDragNum];
        int totalAttack = PlayerManager.PlayerInstance.PlayerAttack + dragAttack;
        int finalAttack = (statTotal * totalAttack)/100;
        return finalAttack;
    }
    #endregion
}
