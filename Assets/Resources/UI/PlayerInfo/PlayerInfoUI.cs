using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : MonoBehaviour
{
    //HP 관련
    Image hpBarGage;
    TextMeshProUGUI hpText;

    //MP 관련
    Image mpBarGage;
    TextMeshProUGUI mpText;

    //Exp관련
    Image expBarGage;
    TextMeshProUGUI expText;

    //LV관련
    TextMeshProUGUI lvText;

    private void Awake()
    {
        ImageBinding();
    }

    private void Start()
    {
        InitUserInfoSetting();
        ShowPlayerHPBar();
        ShowPlayerMPBar();
        ShowPlayerEXPBar();
    }

    /// <summary>
    /// 이미지 바인딩
    /// </summary>
    void ImageBinding()
    {
        foreach(Image img in gameObject.GetComponentsInChildren<Image>())
        {
            string imgObjectName = img.gameObject.name;
            switch (imgObjectName)
            {
                case "PlayerHPbar":
                    hpBarGage = img;
                    break;
                case "PlayerMPbar":
                    mpBarGage = img;
                    break;
                case "PlayerEXPbar":
                   expBarGage = img;
                    break;
                default:
                    break;
            }
        }
        foreach (TextMeshProUGUI txt in gameObject.GetComponentsInChildren<TextMeshProUGUI>())
        {
            string txtObjectName = txt.gameObject.name;
            switch (txtObjectName)
            {
                case "PlayerHPText":
                    hpText = txt;
                    break;
                case "PlayerMPText":
                    mpText = txt;
                    break;
                case "PlayerEXPText":
                    expText = txt;
                    break;
                case "LvText":
                    lvText = txt;
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// 캐릭터 능력치 초기 설정
    /// </summary>
    void InitUserInfoSetting()
    {
        PlayerManager.PlayerInstance.PlayerCurHP = PlayerManager.PlayerInstance.PlayerMaxHP;
        PlayerManager.PlayerInstance.PlayerCurMP = PlayerManager.PlayerInstance.PlayerMaxMP;
        PlayerManager.PlayerInstance.PlayerCurExp = 0;
    }

    //HP, MP, EXP바, LV 보이기
    public void ShowPlayerHPBar()
    {
        hpBarGage.fillAmount = (float)PlayerManager.PlayerInstance.PlayerCurHP / PlayerManager.PlayerInstance.PlayerMaxHP;
        hpText.text = $"HP. {PlayerManager.PlayerInstance.PlayerCurHP} / {PlayerManager.PlayerInstance.PlayerMaxHP}";
    }
    public void ShowPlayerMPBar()
    {
        mpBarGage.fillAmount = (float)PlayerManager.PlayerInstance.PlayerCurMP / PlayerManager.PlayerInstance.PlayerMaxMP;
        mpText.text = $"MP. {PlayerManager.PlayerInstance.PlayerCurMP} / {PlayerManager.PlayerInstance.PlayerMaxMP}";
    }
    public void ShowPlayerEXPBar()
    {
        expBarGage.fillAmount = (float)PlayerManager.PlayerInstance.PlayerCurExp / PlayerManager.PlayerInstance.PlayerRequireExp;
        float expRate = Mathf.Round(expBarGage.fillAmount * 10000) * 0.01f;
        string displayedExpRate = expRate.ToString("F2");//소수점 둘째자리까지 표기
        expText.text = $"EXP. {PlayerManager.PlayerInstance.PlayerCurExp} / {PlayerManager.PlayerInstance.PlayerRequireExp} [{displayedExpRate}%]";
    }
    public void ShowPlayerLV()
    {
        lvText.text = $"Lv. {PlayerManager.PlayerInstance.PlayerLV}";
    }
}
