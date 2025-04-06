using UnityEngine;

public class InputKeyManager : MonoBehaviour
{
    [SerializeField]
    PlayerMove playerMove;
    void Update()
    {
        InputPlayerMove();
    }

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
}
