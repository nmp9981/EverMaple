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

    //UI���ε�
    [SerializeField]
    GameObject statUIObj;
    [SerializeField]
    GameObject skillUIObj;
    [SerializeField]
    GameObject itemUIObj;

    //������ UI����
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
    /// ������ KeyCode�� ��ȯ�Ѵ�.
    /// </summary>
    /// <returns>���� ƽ���� �Էµ� Ű�ڵ带 ��ȯ</returns>
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
    /// ��Ż �̵� Ű
    /// </summary>
    void InputPortalKey()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MapManager.isDownUpKey = true;
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
    /// ��ųŰ
    /// </summary>
    async void InputSkillKey()
    {
        //�Ű�� �Է�
        KeyCode keyCode = DetectPressedKeyCode();
        if (keyCode != KeyCode.None)
        {
            switch (keyCode)
            {
                case KeyCode.Z://��Ű����
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
    /// ���콺 Ŭ��
    /// </summary>
    void InputMouseClick()
    {

    }
}
