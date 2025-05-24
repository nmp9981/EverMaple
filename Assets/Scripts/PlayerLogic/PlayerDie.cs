using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDie : MonoBehaviour
{
    public MoveVillage moveVillage = new MoveVillage();

    [SerializeField]
    PlayerInfoUI playerInfoUI;

    //UI��ġ
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    private void OnEnable()
    {
        DecreasePlayerEXP();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }
    /// <summary>
    /// ����ġ ����
    /// </summary>
    void DecreasePlayerEXP()
    {
        //����ġ ���ҷ�
        int decreaseExp = (PlayerManager.PlayerInstance.PlayerRequireExp * 5) / 100;

        //����ġ ����
        PlayerManager.PlayerInstance.PlayerCurExp = Mathf.Max(0, PlayerManager.PlayerInstance.PlayerCurExp - decreaseExp);
        playerInfoUI.ShowPlayerEXPBar();
    }

    /// <summary>
    /// ����� ������ �̵�
    /// </summary>
    public void MoveToNearVillage()
    {
        moveVillage.MoveToNearVillage();
    }
}
