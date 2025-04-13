using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : MonoBehaviour
{
    //HP ����
    Image hpBarGage;
    TextMeshProUGUI hpText;

    //MP ����
    Image mpBarGage;
    TextMeshProUGUI mpText;

    //Exp����
    Image expBarGage;
    TextMeshProUGUI expText;

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
    /// �̹��� ���ε�
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
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// ĳ���� �ɷ�ġ �ʱ� ����
    /// </summary>
    void InitUserInfoSetting()
    {
        PlayerManager.PlayerInstance.PlayerCurHP = PlayerManager.PlayerInstance.PlayerMaxHP;
        PlayerManager.PlayerInstance.PlayerCurMP = PlayerManager.PlayerInstance.PlayerMaxMP;
        PlayerManager.PlayerInstance.PlayerCurExp = 0;
    }

    //HP, MP, EXP�� ���̱�
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
        expText.text = $"EXP. {PlayerManager.PlayerInstance.PlayerCurExp} / {PlayerManager.PlayerInstance.PlayerRequireExp}";
    }
}
