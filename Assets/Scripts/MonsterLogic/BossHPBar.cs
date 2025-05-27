using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPBar : MonoBehaviour
{
    [SerializeField]
    List<Sprite> bossImage = new List<Sprite>();
    [SerializeField]
    Image bossHPBar;
    [SerializeField]
    Image bossProfileImage;

    /// <summary>
    /// ���� ������ �̹��� ����
    /// </summary>
    /// <param name="bossNum"></param>
    public void SettingBossProfileImage(int bossNum)
    {
        switch (bossNum)
        {
            case 25:
                bossProfileImage.sprite = bossImage[0];
                break;
            case 26:
                bossProfileImage.sprite = bossImage[1];
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// ���� HP�� ���̱�
    /// </summary>
    /// <param name="curHP"></param>
    /// <param name="fullHP"></param>
    public void ShowBossHPBar(int curHP, int fullHP)
    {
        bossHPBar.fillAmount = Mathf.Max(0, (float)(curHP / fullHP));

        //���� ���
        if(bossHPBar.fillAmount<=0)
            gameObject.SetActive(false);
    }
}
