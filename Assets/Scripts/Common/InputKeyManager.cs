using UnityEngine;

public class InputKeyManager : MonoBehaviour
{
    [SerializeField]
    PlayerMove playerMove;
    void Update()
    {
        InputPlayerMove();
    }
    /// <summary>
    /// �̵� Ű
    /// </summary>
    void InputPlayerMove()
    {
        //�÷��̾� �̵�
        float hAxis = Input.GetAxisRaw("Horizontal");
        playerMove.Move(hAxis);

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
