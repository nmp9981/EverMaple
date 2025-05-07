using TMPro;
using UnityEngine;

public class ItemBuff : MonoBehaviour
{
    public int buffIdx;

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
        buffFullTime = 30;
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
        if(buffFullTime < 0)
            gameObject.SetActive(false);
    }
}
