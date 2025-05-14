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
    void ShowCharacterBasicStat()
    {
        nameText.text = PlayerManager.PlayerInstance.PlayerName;
        
        jobText.text = PlayerManager.PlayerInstance.PlayerJob;
        lvText.text = PlayerManager.PlayerInstance.PlayerLV.ToString();
        hpText.text = $"{PlayerManager.PlayerInstance.PlayerCurHP} / {PlayerManager.PlayerInstance.PlayerMaxHP}";
        mpText.text = $"{PlayerManager.PlayerInstance.PlayerCurMP} / {PlayerManager.PlayerInstance.PlayerMaxMP}";

        float rate = (float)PlayerManager.PlayerInstance.PlayerCurExp / PlayerManager.PlayerInstance.PlayerRequireExp;
        rate = Mathf.Floor(rate*100);
        expText.text = $"{PlayerManager.PlayerInstance.PlayerCurExp} ({(int)rate})%";

        apPointText.text = PlayerManager.PlayerInstance.PlayerAPPoint.ToString();
        strText.text = PlayerManager.PlayerInstance.PlayerSTR.ToString();
        dexText.text = PlayerManager.PlayerInstance.PlayerDEX.ToString();
        intText.text = PlayerManager.PlayerInstance.PlayerINT.ToString();
        lukText.text = PlayerManager.PlayerInstance.PlayerLUK.ToString();
    }
    /// <summary>
    /// �� ���� ���̱�
    /// </summary>
    public void ShowCharacterDetailStat()
    {
        //�� ���� ���
        CalculatorDetailStat();

        int maxAttack = PlayerManager.PlayerInstance.PlayerAttack;
        int minAttack = maxAttack * PlayerManager.PlayerInstance.Workmanship/100;
        attackText.text = $"{minAttack} ~ {maxAttack}";
        physicsArmorText.text = $"{PlayerManager.PlayerInstance.PlayerPhysicsArmor}";
        magicPowerText.text = $"{PlayerManager.PlayerInstance.PlayerMagicPower}";
        magicArmorText.text = $"{PlayerManager.PlayerInstance.PlayerMagicArmor}";
        accuraryText.text = $"{PlayerManager.PlayerInstance.PlayerAccurary}";
        avoidText.text = $"{PlayerManager.PlayerInstance.PlayerAvoid}";
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

        PlayerManager.PlayerInstance.PlayerAttack += 1;
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

        PlayerManager.PlayerInstance.PlayerAttack += 2;
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

        //��Ʈ 1�� ���� 1, ����1 ����
        PlayerManager.PlayerInstance.PlayerMagicPower += 1;
        PlayerManager.PlayerInstance.PlayerMagicArmor += 1;

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

        PlayerManager.PlayerInstance.PlayerAttack += 3;
        //������ ����� ���������
        ShowCharacterBasicStat();
        ShowCharacterDetailStat();
    }
    /// <summary>
    /// ���� �ڵ� �й�
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
        PlayerManager.PlayerInstance.PlayerAttack += (3*upLukPoint+2*upDexPoint);
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
        //���� ����
        PlayerManager.PlayerInstance.PlayerPhysicsArmor =
           (3 * PlayerManager.PlayerInstance.PlayerSTR + PlayerManager.PlayerInstance.PlayerDEX) / 9;

        //���߷�
        PlayerManager.PlayerInstance.PlayerAccurary =
            (8 * PlayerManager.PlayerInstance.PlayerDEX + 5 * PlayerManager.PlayerInstance.PlayerLUK) / 10;

        //ȸ����
        PlayerManager.PlayerInstance.PlayerAvoid =
            (5 * PlayerManager.PlayerInstance.PlayerLUK) / 10;

        //������
        PlayerManager.PlayerInstance.PlayerDexterity =
          (PlayerManager.PlayerInstance.PlayerSTR+ PlayerManager.PlayerInstance.PlayerDEX
          + PlayerManager.PlayerInstance.PlayerINT + PlayerManager.PlayerInstance.PlayerLUK) / 4;
    }
    #endregion
}
