using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : MonoBehaviour
{
    Image hpBarGage;
    TextMeshProUGUI hpText;

    private void Awake()
    {
        ImageBinding();
       
    }

    private void Start()
    {
        ShowPlayerHPBar();
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
                default:
                    break;
            }
        }
    }
    public void ShowPlayerHPBar()
    {
        hpBarGage.fillAmount = (float)PlayerManager.PlayerInstance.PlayerCurHP / PlayerManager.PlayerInstance.PlayerMaxHP;
        hpText.text = $"HP. {PlayerManager.PlayerInstance.PlayerCurHP} / {PlayerManager.PlayerInstance.PlayerMaxHP}";
    }
}
