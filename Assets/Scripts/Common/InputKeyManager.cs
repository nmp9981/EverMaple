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
    /// 이동 키
    /// </summary>
    void InputPlayerMove()
    {
        //플레이어 이동
        float hAxis = Input.GetAxisRaw("Horizontal");
        playerMove.Move(hAxis);

        //점프
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            playerMove.TryJump();
        }
    }
    /// <summary>
    /// 공격키
    /// </summary>
    void InputPlayerAttack()
    {

    }
    /// <summary>
    /// 버프키
    /// </summary>
    void InputlPlayerBuff()
    {

    }
    /// <summary>
    /// UI기능
    /// </summary>
    void InputAboutUI()
    {

    }
    /// <summary>
    /// 마우스 클릭
    /// </summary>
    void InputMouseClick()
    {

    }
}
