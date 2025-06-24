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
    GameObject tombObj;//���� ������Ʈ

    //UI��ġ
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
        PlayerOn();
    }

    /// <summary>
    /// ĳ���� ��Ȱ��ȭ
    /// </summary>
    void PlayerOff()
    {
        //��� ����
        PlayerManager.PlayerInstance.IsPlayerDie = true;
        //���� , �߷� ���� X
        playerCol.gameObject.transform.position += Vector3.up;
        playerRigid.gravityScale = 0;
        playerCol.isTrigger = true;
        //������Ʈ Ȱ��ȭ
        tombObj.SetActive(true);
        //����
        SoundManager._sound.PlaySfx(27);
    }
    /// <summary>
    /// ĳ���� Ȱ��ȭ
    /// </summary>
    void PlayerOn()
    {
        //���� , �߷� ���� O
        playerCol.isTrigger = false;
        playerRigid.gravityScale = 1;

        //HPȸ��
        PlayerManager.PlayerInstance.PlayerCurHP = 50;
        playerInfoUI.ShowPlayerHPBar();

        //��Ȱ
        PlayerManager.PlayerInstance.IsPlayerDie = false;

        //������Ʈ ��Ȱ��ȭ
        tombObj.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
