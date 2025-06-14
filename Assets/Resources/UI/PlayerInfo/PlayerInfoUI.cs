using System.Collections.Generic;
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

    //LV����
    TextMeshProUGUI lvText;

    //�޼��� ����
    List<TextMeshProUGUI> getMessageList = new List<TextMeshProUGUI>();
    int getMessageCurCount = 0;

    private void Awake()
    {
        MessageBinding();
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
    /// �޼��� ���ε�
    /// </summary>
    void MessageBinding()
    {
        GameObject messageObj = GameObject.Find("MessageUI");
        foreach (TextMeshProUGUI msg in messageObj.GetComponentsInChildren<TextMeshProUGUI>(true))
        {
            getMessageList.Add(msg);
            msg.text = string.Empty;
        }
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
                case "LvText":
                    lvText = txt;
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

    //HP, MP, EXP��, LV ���̱�
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
        string displayedExpRate = expRate.ToString("F2");//�Ҽ��� ��°�ڸ����� ǥ��
        expText.text = $"EXP. {PlayerManager.PlayerInstance.PlayerCurExp} / {PlayerManager.PlayerInstance.PlayerRequireExp} [{displayedExpRate}%]";
    }
    public void ShowPlayerLV()
    {
        lvText.text = $"Lv. {PlayerManager.PlayerInstance.PlayerLV}";
    }

    //�޼���
    public void ShowGetExpMessage(int getExp)
    {
        string message = $"����ġ�� ������ϴ� (+{getExp})";

        int getMessageIndex = getMessageCurCount % 5;
        getMessageList[getMessageIndex].text = message;
        getMessageCurCount += 1;

        if (getMessageCurCount >= 5)
        {
            Invoke("DeleteMessage", 0.01f);
        }
        else
        {
            Invoke("DeleteMessage", 0.5f);
        }
    }
    public void ShowGetMesoMessage(int getMeso)
    {
        string message = $"�޼Ҹ� ������ϴ� (+{getMeso})";

        int getMessageIndex = getMessageCurCount % 5;
        getMessageList[getMessageIndex].text = message;
        getMessageCurCount += 1;

        if (getMessageCurCount >= 5)
        {
            Invoke("DeleteMessage", 0.01f);
        }
        else
        {
            Invoke("DeleteMessage", 0.5f);
        }
    }
    public void ShowGetItemMessage(string getItem)
    {
        string message = $"�����۸� ������ϴ� ({getItem})";

        int getMessageIndex = getMessageCurCount % 5;
        getMessageList[getMessageIndex].text = message;
        getMessageCurCount += 1;

        if (getMessageCurCount >= 5)
        {
            Invoke("DeleteMessage", 0.01f);
        }
        else
        {
            Invoke("DeleteMessage", 0.5f);
        }
    }
    /// <summary>
    /// �޼��� �����
    /// </summary>
    void DeleteMessage()
    {
        getMessageCurCount = Mathf.Max(0, Mathf.Min(4, getMessageCurCount-1));
        getMessageList[getMessageCurCount].text = string.Empty;
    }
}
