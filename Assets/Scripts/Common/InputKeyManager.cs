using System;
using UnityEngine;

public class InputKeyManager : MonoBehaviour
{
    [SerializeField]
    PlayerMove playerMove;

    [SerializeField]
    PlayerAttack playerAttack;
    [SerializeField]
    SkillManager skillManager;

    //UI바인딩
    [SerializeField]
    GameObject statUIObj;
    [SerializeField]
    GameObject skillUIObj;
    [SerializeField]
    GameObject itemUIObj;

    //데미지 UI순서
    public static int orderSortNum { get; set; }

    private void Awake()
    {
        orderSortNum = 8;
    }
    void Update()
    {
        InputPlayerMove();
        InputPortalKey();
        InputPlayerAttack();
        InputSkillKey();
        InputAboutUI();
    }
    /// <summary>
    /// 감지된 KeyCode를 반환한다.
    /// </summary>
    /// <returns>현재 틱에서 입력된 키코드를 반환</returns>
    private KeyCode DetectPressedKeyCode()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                return kcode;
            }
        }
        return KeyCode.None;
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
    /// 포탈 이동 키
    /// </summary>
    void InputPortalKey()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MapManager.isDownUpKey = true;
        }
    }
    /// <summary>
    /// 공격키
    /// </summary>
    void InputPlayerAttack()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            playerAttack.BasicAttackFlow();
        }
    }
    /// <summary>
    /// 스킬키
    /// </summary>
    async void InputSkillKey()
    {
        //어떤키라도 입력
        KeyCode keyCode = DetectPressedKeyCode();
        if (keyCode != KeyCode.None)
        {
            switch (keyCode)
            {
                case KeyCode.Z://럭키세븐
                    await skillManager.LuckySeven(2);
                    break;
                case KeyCode.X:
                    break;
                default:
                    break;
            }
        }
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(statUIObj.activeSelf)
                statUIObj.SetActive(false);
            else
                statUIObj.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (skillUIObj.activeSelf)
                skillUIObj.SetActive(false);
            else
                skillUIObj.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (itemUIObj.activeSelf)
                itemUIObj.SetActive(false);
            else
                itemUIObj.SetActive(true);
        }
    }
    /// <summary>
    /// 마우스 클릭
    /// </summary>
    void InputMouseClick()
    {

    }
}
