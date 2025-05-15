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
    /// ���� ���ӽð�, ȿ�� ����
    /// </summary>
    void SettingBuffDurationTimeAndEffect()
    {
        buffFullTime = 300;

        switch (buffIdx)
        {
            case 0://���� ����
                PlayerManager.PlayerInstance.PlayerAttack += 10;
                break;
            case 1://���� ����
                PlayerManager.PlayerInstance.PlayerMagicPower += 5;
                break;
            case 2://���� ����
                PlayerManager.PlayerInstance.PlayerAddAccurary += 10;
                break;
            case 3://��ø ����
                PlayerManager.PlayerInstance.PlayerAddAvoid += 10;
                break;
            case 4://�̼� ����
                PlayerManager.PlayerInstance.PlayerMoveSpeedRate += 10f;
                break;
            default:
                break;
        }
        //����â���� �ݿ�
        statUIObj.ShowCharacterDetailStat();
    }
    /// <summary>
    /// ���� ���� �ð� ���̱�(���� Ȱ��ȭ ���϶���)
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
    /// ���� ����
    /// 1) ����â ����
    /// 2) ȿ�� �������
    /// </summary>
    void BuffOff()
    {
        if (buffFullTime < 0)
        {
            switch (buffIdx)
            {
                case 0://���� ����
                    PlayerManager.PlayerInstance.PlayerAttack -= 10;
                    break;
                case 1://���� ����
                    PlayerManager.PlayerInstance.PlayerMagicPower -= 5;
                    break;
                case 2://���� ����
                    PlayerManager.PlayerInstance.PlayerAddAccurary -= 10;
                    break;
                case 3://��ø ����
                    PlayerManager.PlayerInstance.PlayerAddAvoid -= 10;
                    break;
                case 4://�̼� ����
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
