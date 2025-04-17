using UnityEngine;

public class InputKeyManager : MonoBehaviour
{
    [SerializeField]
    PlayerMove playerMove;

    [SerializeField]
    PlayerAttack playerAttack;

    //������ UI����
    public static int orderSortNum { get; set; }

    private void Awake()
    {
        orderSortNum = 8;
    }
    void Update()
    {
        InputPlayerMove();
        InputPlayerAttack();
    }
    /// <summary>
    /// �̵� Ű
    /// </summary>
    void InputPlayerMove()
    {
        //�÷��̾� �̵�
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");
        playerMove.Move(hAxis,vAxis);

        //����
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            playerMove.TryJump();
        }
    }
    /// <summary>
    /// ����Ű
    /// </summary>
    void InputPlayerAttack()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            playerAttack.BasicAttackFlow();
        }
    }
    /// <summary>
    /// ����Ű
    /// </summary>
    void InputlPlayerBuff()
    {

    }
    /// <summary>
    /// UI���
    /// </summary>
    void InputAboutUI()
    {

    }
    /// <summary>
    /// ���콺 Ŭ��
    /// </summary>
    void InputMouseClick()
    {

    }
}
