using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 캐릭터 직업 클래스
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
    /// 전직 UI 바인딩
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
    /// 전직 UI창 닫기
    /// </summary>
    public void CloseJobUpgradeUI()
    {
        foreach(Transform tr in gameObject.GetComponentInChildren<Transform>(true))
        {
            tr.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 로그 전직
    /// </summary>
    public void LogUpgrade()
    {
        if (PlayerManager.PlayerInstance.PlayerLV >= 8 && PlayerManager.PlayerInstance.PlayerJOBEnum == PlayerJobClass.Beginer)
        {
            PlayerManager.PlayerInstance.PlayerJOBEnum = PlayerJobClass.Log;
            playerInfoUI.ShowPlayerJob("로그");
            SuccessUpgrade(0, "로그");
        }
        else
        {
            FailUpgrade(0);
        }
        
    }

    /// <summary>
    /// 어쌔신 전직
    /// </summary>
    public void AssasinUpgrade()
    {
        PlayerManager.PlayerInstance.PlayerJOBEnum = PlayerJobClass.Assassin;
        playerInfoUI.ShowPlayerJob("어쌔신");
    }

    /// <summary>
    /// 시프 전직
    /// </summary>
    public void ThiefUpgrade()
    {
        PlayerManager.PlayerInstance.PlayerJOBEnum = PlayerJobClass.Thief;
        playerInfoUI.ShowPlayerJob("시프");
    }

    /// <summary>
    /// 3,4차 전직
    /// </summary>
    public void Upgrade3rd4th()
    {
        switch (PlayerManager.PlayerInstance.PlayerJOBEnum)
        {
            case PlayerJobClass.Assassin:
                PlayerManager.PlayerInstance.PlayerJOBEnum = PlayerJobClass.Hermit;
                playerInfoUI.ShowPlayerJob("허밋");
                break;
            case PlayerJobClass.Hermit:
                PlayerManager.PlayerInstance.PlayerJOBEnum = PlayerJobClass.NightLoad;
                playerInfoUI.ShowPlayerJob("나이트로드");
                break;
            case PlayerJobClass.Thief:
                PlayerManager.PlayerInstance.PlayerJOBEnum = PlayerJobClass.ThiefMaster;
                playerInfoUI.ShowPlayerJob("시프마스터");
                break;
            case PlayerJobClass.ThiefMaster:
                PlayerManager.PlayerInstance.PlayerJOBEnum = PlayerJobClass.Shadower;
                playerInfoUI.ShowPlayerJob("섀도어");
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 전직 성공
    /// </summary>
    void SuccessUpgrade(int dim, string jobName)
    {
        successUpgradeObj.SetActive(true);
        successUpgradeObj.transform.GetChild(0).transform.GetChild(3).GetComponent<Image>().sprite = npcSprite[dim];
        successUpgradeObj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"이제부터 {jobName}이라네";
    }
    /// <summary>
    /// 전직 실패
    /// </summary>
    void FailUpgrade(int dim)
    {
        failUpgradeObj.SetActive(true);
        failUpgradeObj.transform.GetChild(0).transform.GetChild(3).GetComponent<Image>().sprite = npcSprite[dim];
        failUpgradeObj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"다 소모하지 않은 SP가 있는지 \n레벨이 부족하지 않은지 확인하길 바라네";
    }
}
