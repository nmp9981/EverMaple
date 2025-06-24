using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDie : MonoBehaviour, IDragHandler
{
    public MoveVillage moveVillage = new MoveVillage();

    BoxCollider2D playerCol;
    Rigidbody2D playerRigid;

    [SerializeField]
    PlayerInfoUI playerInfoUI;
    [SerializeField]
    GameObject tombObj;//묘지 오브젝트

    //UI위치
    private RectTransform rectTransform;

    private void Awake()
    {
        playerCol =GameObject.Find("Player").GetComponent<BoxCollider2D>();
        playerRigid = playerCol.gameObject.GetComponent<Rigidbody2D>();
        rectTransform = GetComponent<RectTransform>();
    }
    private void OnEnable()
    {
        PlayerOff();
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
        PlayerOn();
    }

    /// <summary>
    /// 캐릭터 비활성화
    /// </summary>
    void PlayerOff()
    {
        //사망 상태
        PlayerManager.PlayerInstance.IsPlayerDie = true;
        //몬스터 , 중력 영향 X
        playerCol.gameObject.transform.position += Vector3.up;
        playerRigid.gravityScale = 0;
        playerCol.isTrigger = true;
        //오브젝트 활성화
        tombObj.SetActive(true);
        //사운드
        SoundManager._sound.PlaySfx(27);
    }
    /// <summary>
    /// 캐릭터 활성화
    /// </summary>
    void PlayerOn()
    {
        //몬스터 , 중력 영향 O
        playerCol.isTrigger = false;
        playerRigid.gravityScale = 1;

        //HP회복
        PlayerManager.PlayerInstance.PlayerCurHP = 50;
        playerInfoUI.ShowPlayerHPBar();

        //부활
        PlayerManager.PlayerInstance.IsPlayerDie = false;

        //오브젝트 비활성화
        tombObj.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
