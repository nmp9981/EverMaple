using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ĳ���� ���� Ŭ����
/// </summary>
public enum PlayerJobClass
{
    Beginer,
    Log,
    Assassin,
    Thief,
    Hermit,
    ThiefMaster,
    NightLoad,
    Shadower,
    Count
}

public class JobUpgradeNPC : MonoBehaviour
{
    [SerializeField]
    PlayerInfoUI playerInfoUI;

    [SerializeField]
    List<Sprite> npcSprite = new List<Sprite>();

    [SerializeField]
    GameObject successUpgradeObj;
    [SerializeField]
    GameObject failUpgradeObj;

    private void Start()
    {
        BindingUI();
    }
    /// <summary>
    /// ���� UI ���ε�
    /// </summary>
    void BindingUI()
    {
        foreach (Button btn in gameObject.GetComponentsInChildren<Button>(true))
        {
            string btnName = btn.gameObject.name;

            switch (btnName)
            {
                case "LogButton":
                    btn.onClick.AddListener(LogUpgrade);
                    break;
                case "Close":
                    btn.onClick.AddListener(CloseJobUpgradeUI);
                    break;
                case "AssassinButton":
                    btn.onClick.AddListener(AssasinUpgrade);
                    break;
                case "TheifButton":
                    btn.onClick.AddListener(ThiefUpgrade);
                    break;
                case "34Upgrade":
                    btn.onClick.AddListener(Upgrade3rd4th);
                    break;
                default:
                    break;
            }
        }
    }
    /// <summary>
    /// ���� UIâ �ݱ�
    /// </summary>
    public void CloseJobUpgradeUI()
    {
        foreach(Transform tr in gameObject.GetComponentInChildren<Transform>(true))
        {
            tr.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// �α� ����
    /// </summary>
    public void LogUpgrade()
    {
        if (PlayerManager.PlayerInstance.PlayerLV >= 8 && PlayerManager.PlayerInstance.PlayerJOBEnum == PlayerJobClass.Beginer)
        {
            PlayerManager.PlayerInstance.PlayerJOBEnum = PlayerJobClass.Log;
            playerInfoUI.ShowPlayerJob("�α�");
            SuccessUpgrade(0, "�α�");

            //ü��, ���� ���ʽ�, ������ SP����
            PlayerManager.PlayerInstance.PlayerSkillPoint += 3*(PlayerManager.PlayerInstance.PlayerLV-8);
            PlayerManager.PlayerInstance.PlayerMaxHP += 300;
            PlayerManager.PlayerInstance.PlayerMaxMP += 200;

            PlayerManager.PlayerInstance.PlayerCurHP = PlayerManager.PlayerInstance.PlayerMaxHP;
            PlayerManager.PlayerInstance.PlayerCurMP = PlayerManager.PlayerInstance.PlayerMaxMP;

            playerInfoUI.ShowPlayerHPBar();
            playerInfoUI.ShowPlayerMPBar();
        }
        else
        {
            FailUpgrade(0);
        }
        
    }

    /// <summary>
    /// ��ؽ� ����
    /// </summary>
    public void AssasinUpgrade()
    {
        if (PlayerManager.PlayerInstance.PlayerLV >= 25 && PlayerManager.PlayerInstance.PlayerJOBEnum == PlayerJobClass.Log
            && PlayerManager.PlayerInstance.TotalUseSkillPoint>=52)
        {
            PlayerManager.PlayerInstance.PlayerJOBEnum = PlayerJobClass.Assassin;
            playerInfoUI.ShowPlayerJob("��ؽ�");
            SuccessUpgrade(1, "��ؽ�");
        }
        else
        {
            FailUpgrade(1);
        }
            
    }

    /// <summary>
    /// ���� ����
    /// </summary>
    public void ThiefUpgrade()
    {
        if (PlayerManager.PlayerInstance.PlayerLV >= 25 && PlayerManager.PlayerInstance.PlayerJOBEnum == PlayerJobClass.Log
            && PlayerManager.PlayerInstance.TotalUseSkillPoint >= 52)
        {
            PlayerManager.PlayerInstance.PlayerJOBEnum = PlayerJobClass.Thief;
            playerInfoUI.ShowPlayerJob("����");
            SuccessUpgrade(1, "����");
        }
        else{
            FailUpgrade(1);
        }
            
    }

    /// <summary>
    /// 3,4�� ����
    /// </summary>
    public void Upgrade3rd4th()
    {
        switch (PlayerManager.PlayerInstance.PlayerJOBEnum)
        {
            case PlayerJobClass.Assassin:
                if (PlayerManager.PlayerInstance.PlayerLV >= 55
                    && PlayerManager.PlayerInstance.TotalUseSkillPoint >= 143)
                {
                    PlayerManager.PlayerInstance.PlayerJOBEnum = PlayerJobClass.Hermit;
                    playerInfoUI.ShowPlayerJob("���");
                    SuccessUpgrade(2, "���");
                }
                else
                {
                    FailUpgrade(2);
                }
                break;
            case PlayerJobClass.Hermit:
                if (PlayerManager.PlayerInstance.PlayerLV >= 90
                    && PlayerManager.PlayerInstance.TotalUseSkillPoint >= 249)
                {
                    PlayerManager.PlayerInstance.PlayerJOBEnum = PlayerJobClass.NightLoad;
                    playerInfoUI.ShowPlayerJob("����Ʈ�ε�");
                    SuccessUpgrade(2, "����Ʈ�ε�");
                }
                else
                {
                    FailUpgrade(2);
                }
                break;
            case PlayerJobClass.Thief:
                if (PlayerManager.PlayerInstance.PlayerLV >= 55
                    && PlayerManager.PlayerInstance.TotalUseSkillPoint >= 143)
                {
                    PlayerManager.PlayerInstance.PlayerJOBEnum = PlayerJobClass.ThiefMaster;
                    playerInfoUI.ShowPlayerJob("����������");
                    SuccessUpgrade(2, "����������");
                }
                else
                {
                    FailUpgrade(2);
                }
                break;
            case PlayerJobClass.ThiefMaster:
                if (PlayerManager.PlayerInstance.PlayerLV >= 95
                    && PlayerManager.PlayerInstance.TotalUseSkillPoint >= 249)
                {
                    PlayerManager.PlayerInstance.PlayerJOBEnum = PlayerJobClass.Shadower;
                    playerInfoUI.ShowPlayerJob("������");
                    SuccessUpgrade(2, "������");
                }
                else
                {
                    FailUpgrade(2);
                }
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// ���� ����
    /// </summary>
    void SuccessUpgrade(int dim, string jobName)
    {
        successUpgradeObj.SetActive(true);
        successUpgradeObj.transform.GetChild(0).transform.GetChild(3).GetComponent<Image>().sprite = npcSprite[dim];
        successUpgradeObj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"�������� {jobName}�̶��\n�׸��� �ణ�� SP�� ��������ٳ�";
        PlayerManager.PlayerInstance.PlayerSkillPoint += 1;
    }
    /// <summary>
    /// ���� ����
    /// </summary>
    void FailUpgrade(int dim)
    {
        failUpgradeObj.SetActive(true);
        failUpgradeObj.transform.GetChild(0).transform.GetChild(3).GetComponent<Image>().sprite = npcSprite[dim];
        failUpgradeObj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"�� �Ҹ����� ���� SP�� �ִ��� \n������ �������� ������ Ȯ���ϱ� �ٶ��";
    }
}
