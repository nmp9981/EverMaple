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
    [SerializeField]
    GameObject storeUI;
    [SerializeField]
    GameObject worldMapUIObj;

    //�ð�
    float curAttackSkillTime = 0;

    //������ UI����
    public static int orderSortNum { get; set; }

    private void Awake()
    {
        orderSortNum = 8;
    }
    void Update()
    {
        InputMouseClick();
        InputPlayerMove();
        InputPortalKey();
        InputPlayerAttack();
        InputSkillKey();
        InputItemKey();
        InputAboutUI();
        TimeFlow();
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
        //��Ÿ��
        if (curAttackSkillTime < PlayerManager.PlayerInstance.PlayerAttackSkillSpeed)
            return;
        
        //�Ű�� �Է�
        KeyCode keyCode = DetectPressedKeyCode();

        if (keyCode != KeyCode.None)
        {
            switch (keyCode)
            {
                case KeyCode.Z://��Ű����
                    await skillManager.LuckySeven(2);
                    break;
                case KeyCode.X://���� ����
                    await skillManager.DoubleStep(2);
                    break;
                case KeyCode.C://��������ο�
                    await skillManager.Savageblow(6);
                    break;
                case KeyCode.V://Ʈ���� ���ο�
                    await skillManager.TripleThrow(3);
                    break;
                case KeyCode.B://���
                    await skillManager.Avenger();
                    break;
                case KeyCode.N:
                    await skillManager.BumerangStep(2);
                    break;
                default:
                    break;
            }
            //��ų ��Ÿ�� �ʱ�ȭ
            curAttackSkillTime = 0;
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
        //����â
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(statUIObj.activeSelf)
                statUIObj.SetActive(false);
            else
                statUIObj.SetActive(true);
        }
        //��ųâ
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (skillUIObj.activeSelf)
                skillUIObj.SetActive(false);
            else
                skillUIObj.SetActive(true);
        }
        //������â
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (itemUIObj.activeSelf)
                itemUIObj.SetActive(false);
            else
                itemUIObj.SetActive(true);
        }
        //�����â
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (worldMapUIObj.activeSelf)
                worldMapUIObj.SetActive(false);
            else
                worldMapUIObj.SetActive(true);
        }
    }
    void InputItemKey()
    {
        //����UI�� ���������� �۵�����
        if (storeUI.activeSelf)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            ItemManager.itemInstance.UseHPPosion(ItemManager.itemInstance.UseHPPosionIndex, ItemManager.itemInstance.HealHPAmount,true);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ItemManager.itemInstance.UseMPPosion(ItemManager.itemInstance.UseMPPosionIndex, ItemManager.itemInstance.HealMPAmount, true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ItemManager.itemInstance.UseBuffItem(8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ItemManager.itemInstance.UseBuffItem(9);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ItemManager.itemInstance.UseBuffItem(10);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ItemManager.itemInstance.UseBuffItem(11);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ItemManager.itemInstance.UseBuffItem(12);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ItemManager.itemInstance.UseBuffItem(13);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            ItemManager.itemInstance.UseBuffItem(14);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            ItemManager.itemInstance.UseBuffItem(15);
        }
    }

    /// <summary>
    /// ���콺 Ŭ��
    /// </summary>
    void InputMouseClick()
    {
       
    }

    void TimeFlow()
    {
        curAttackSkillTime += Time.deltaTime;
    }
}
