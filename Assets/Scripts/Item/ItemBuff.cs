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
    /// ���� ���ӽð�, ȿ�� ����
    /// </summary>
    void SettingBuffDurationTimeAndEffect()
    {
        buffFullTime = 30;
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
        if(buffFullTime < 0)
            gameObject.SetActive(false);
    }
}
