using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatUI : MonoBehaviour
{
    //세부 오브젝트
    [SerializeField]
    GameObject detailStatObject;

    //텍스트 영역
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

    //버튼 영역
    Button autoStatDivideButton;
    Button upSTRButton;
    Button upDEXButton;
    Button upINTButton;
    Button upLUKButton;
    Button detailButton;

    private void Awake()
    {
        BindingStatText();
        BindingStatButton();
    }
    private void OnEnable()
    {
        ShowCharacterBasicStat();
    }

    #region 바인딩
    /// <summary>
    /// 텍스트 바인딩
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
    /// 버튼 바인딩
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
                    break;
                case "STRUP":
                    upSTRButton = btn;
                    break;
                case "DEXUP":
                    upDEXButton = btn;
                    break;
                case "INTUP":
                    upINTButton = btn;
                    break;
                case "LUKUP":
                    upLUKButton = btn;
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

    #region 스탯 보이기
    /// <summary>
    /// 기본 스탯 보이기
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

        apPointText.text = 0.ToString();
        strText.text = PlayerManager.PlayerInstance.PlayerSTR.ToString();
        dexText.text = PlayerManager.PlayerInstance.PlayerDEX.ToString();
        intText.text = PlayerManager.PlayerInstance.PlayerINT.ToString();
        lukText.text = PlayerManager.PlayerInstance.PlayerLUK.ToString();
    }
    /// <summary>
    /// 상세 스탯 보이기
    /// </summary>
    public void ShowCharacterDetailStat()
    {
        int maxAttack = PlayerManager.PlayerInstance.PlayerAttack;
        int minAttack = maxAttack * PlayerManager.PlayerInstance.Workmanship/100;
        attackText.text = $"{minAttack} ~ {maxAttack}";
        physicsArmorText.text = "100";
        magicPowerText.text = "30";
        magicArmorText.text = "50";
        accuraryText.text = "118";
        avoidText.text = "180";
        dexterityText.text = "130";
        moveSpeedText.text = "110";
        jumpText.text = "100";
    }
    #endregion

    #region Button
    /// <summary>
    /// 상세 스탯 보이기 버튼
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
    #endregion
}
