using TMPro;
using UnityEngine;

public class ItemBuff : MonoBehaviour
{
    public int buffIdx;

    [SerializeField]
    StatUI statUIObj;
    [SerializeField]
    TextMeshProUGUI timeText;
    float buffFullTime;

    private void OnEnable()
    {
        SettingBuffDurationTimeAndEffect();
    }
    private void Update()
    {
        ShowBuffRestTime();
    }

    /// <summary>
    /// 버프 지속시간, 효과 설정
    /// </summary>
    void SettingBuffDurationTimeAndEffect()
    {
        buffFullTime = 300;

        switch (buffIdx)
        {
            case 0://전사 물약
                PlayerManager.PlayerInstance.PlayerAttack += 10;
                break;
            case 1://법사 물약
                PlayerManager.PlayerInstance.PlayerMagicPower += 5;
                break;
            case 2://명사수 물약
                PlayerManager.PlayerInstance.PlayerAddAccurary += 10;
                break;
            case 3://민첩 물약
                PlayerManager.PlayerInstance.PlayerAddAvoid += 10;
                break;
            case 4://이속 물약
                PlayerManager.PlayerInstance.PlayerMoveSpeedRate += 10f;
                break;
            default:
                break;
        }
        //스탯창에도 반영
        statUIObj.ShowCharacterDetailStat();
    }
    /// <summary>
    /// 남은 버프 시간 보이기(버프 활성화 중일때만)
    /// </summary>
    void ShowBuffRestTime()
    {
        if (!gameObject.activeSelf)
            return;
        buffFullTime -= Time.deltaTime;
        timeText.text = Mathf.Floor(buffFullTime).ToString();

        BuffOff();
    }
    /// <summary>
    /// 버프 종료
    /// 1) 버프창 꺼짐
    /// 2) 효과 원래대로
    /// </summary>
    void BuffOff()
    {
        if (buffFullTime < 0)
        {
            switch (buffIdx)
            {
                case 0://전사 물약
                    PlayerManager.PlayerInstance.PlayerAttack -= 10;
                    break;
                case 1://법사 물약
                    PlayerManager.PlayerInstance.PlayerMagicPower -= 5;
                    break;
                case 2://명사수 물약
                    PlayerManager.PlayerInstance.PlayerAddAccurary -= 10;
                    break;
                case 3://민첩 물약
                    PlayerManager.PlayerInstance.PlayerAddAvoid -= 10;
                    break;
                case 4://이속 물약
                    PlayerManager.PlayerInstance.PlayerMoveSpeedRate -= 10;
                    break;
                default:
                    break;
            }
            statUIObj.ShowCharacterDetailStat();
            gameObject.SetActive(false);
        }
    }
}
