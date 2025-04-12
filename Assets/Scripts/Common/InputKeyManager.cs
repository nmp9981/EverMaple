using UnityEngine;

public class InputKeyManager : MonoBehaviour
{
    [SerializeField]
    PlayerMove playerMove;

    //데미지 UI순서
    public static int orderSortNum { get; set; }

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
        float vAxis = Input.GetAxisRaw("Vertical");
        playerMove.Move(hAxis,vAxis);

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
