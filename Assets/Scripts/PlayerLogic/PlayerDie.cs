using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDie : MonoBehaviour
{
    public MoveVillage moveVillage = new MoveVillage();

    [SerializeField]
    PlayerInfoUI playerInfoUI;

    //UI위치
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
    /// 경험치 감소
    /// </summary>
    void DecreasePlayerEXP()
    {
        //경험치 감소량
        int decreaseExp = (PlayerManager.PlayerInstance.PlayerRequireExp * 5) / 100;

        //경험치 감소
        PlayerManager.PlayerInstance.PlayerCurExp = Mathf.Max(0, PlayerManager.PlayerInstance.PlayerCurExp - decreaseExp);
        playerInfoUI.ShowPlayerEXPBar();
    }

    /// <summary>
    /// 가까운 마을로 이동
    /// </summary>
    public void MoveToNearVillage()
    {
        moveVillage.MoveToNearVillage();
    }
}
