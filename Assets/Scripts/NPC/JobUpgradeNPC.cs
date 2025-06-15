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
        PlayerManager.PlayerInstance.PlayerJOBEnum = PlayerJobClass.Assassin;
        playerInfoUI.ShowPlayerJob("��ؽ�");
    }

    /// <summary>
    /// ���� ����
    /// </summary>
    public void ThiefUpgrade()
    {
        PlayerManager.PlayerInstance.PlayerJOBEnum = PlayerJobClass.Thief;
        playerInfoUI.ShowPlayerJob("����");
    }

    /// <summary>
    /// 3,4�� ����
    /// </summary>
    public void Upgrade3rd4th()
    {
        switch (PlayerManager.PlayerInstance.PlayerJOBEnum)
        {
            case PlayerJobClass.Assassin:
                PlayerManager.PlayerInstance.PlayerJOBEnum = PlayerJobClass.Hermit;
                playerInfoUI.ShowPlayerJob("���");
                break;
            case PlayerJobClass.Hermit:
                PlayerManager.PlayerInstance.PlayerJOBEnum = PlayerJobClass.NightLoad;
                playerInfoUI.ShowPlayerJob("����Ʈ�ε�");
                break;
            case PlayerJobClass.Thief:
                PlayerManager.PlayerInstance.PlayerJOBEnum = PlayerJobClass.ThiefMaster;
                playerInfoUI.ShowPlayerJob("����������");
                break;
            case PlayerJobClass.ThiefMaster:
                PlayerManager.PlayerInstance.PlayerJOBEnum = PlayerJobClass.Shadower;
                playerInfoUI.ShowPlayerJob("������");
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
        successUpgradeObj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"�������� {jobName}�̶��";
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
