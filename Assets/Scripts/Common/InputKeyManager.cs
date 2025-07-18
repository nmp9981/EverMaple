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
    [SerializeField]
    GameObject storeUI;
    [SerializeField]
    GameObject worldMapUIObj;
    [SerializeField]
    GameObject equipmemtUIObj;
    [SerializeField]
    GameObject questManagerUIObj;
    [SerializeField]
    GameObject exitUIObj;

    //시간
    float curAttackSkillTime = 0;

    //데미지 UI순서
    public static int orderSortNum { get; set; }

    private void Awake()
    {
        orderSortNum = 8;
    }
    void Update()
    {
        if (!PlayerManager.PlayerInstance.IsPlayerDie)
        {
            InputMouseClick();
            InputPlayerMove();
            InputPortalKey();
            InputPlayerAttack();
            InputSkillKey();
            InputlPlayerBuff();
            InputItemKey();
        }
        InputAboutUI();
        TimeFlow();
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
        //쿨타임
        if (curAttackSkillTime < PlayerManager.PlayerInstance.PlayerAttackSkillSpeed)
            return;
        
        //어떤키라도 입력
        KeyCode keyCode = DetectPressedKeyCode();

        if (keyCode != KeyCode.None)
        {
            switch (keyCode)
            {
                case KeyCode.Z://럭키세븐
                    await skillManager.LuckySeven(2);
                    break;
                case KeyCode.X://더블 스텝 or 부메랑스텝
                    if(PlayerManager.PlayerInstance.PlayerJOBEnum == PlayerJobClass.Shadower)
                        await skillManager.BumerangStep(2);
                    else await skillManager.DoubleStep(2);
                    break;
                case KeyCode.C://새비지블로우 or 어벤져
                    if(PlayerManager.PlayerInstance.PlayerJOBConfigEnum == PlayerJobConfig.Shadower)
                        await skillManager.Savageblow(SkillDamageCalCulate.SavageblowHitNum);
                    else await skillManager.Avenger(1);
                    break;
                case KeyCode.V://트리플 스로우 or 어썰터
                    if (PlayerManager.PlayerInstance.PlayerJOBConfigEnum == PlayerJobConfig.Shadower)
                        await skillManager.Assertor();
                    else await skillManager.TripleThrow(3);
                    break;
                case KeyCode.B://시브즈
                    await skillManager.Thieves();
                    break;
                default:
                    break;
            }
            //스킬 쿨타임 초기화
            curAttackSkillTime = 0;
        }
    }
    /// <summary>
    /// 버프키
    /// </summary>
    void InputlPlayerBuff()
    {
        //어떤키라도 입력
        KeyCode keyCode = DetectPressedKeyCode();

        if (keyCode != KeyCode.None)
        {
            switch (keyCode)
            {
                case KeyCode.Alpha9://헤이스트
                    skillManager.UseHasteSkill();
                    break;
                case KeyCode.Alpha0://부스터
                    skillManager.UseDagerBoosterSkill();
                    break;
                case KeyCode.Minus://쉐도우파트너
                    skillManager.UseShadowPartnerSkill();
                    break;
                case KeyCode.O://메소업
                    skillManager.UseMesoUPSkill();
                    break;
                case KeyCode.P://메소가드
                    skillManager.UseMesoGuardSkill();
                    break;
                case KeyCode.Equals://메이플 용사
                    skillManager.UseMapleWarriorSkill();
                    break;
                default:
                    break;
            }
        }
    }
    /// <summary>
    /// UI기능
    /// </summary>
    void InputAboutUI()
    {
        //스탯창
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(statUIObj.activeSelf)
                statUIObj.SetActive(false);
            else
                statUIObj.SetActive(true);
        }
        //스킬창
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (skillUIObj.activeSelf)
                skillUIObj.SetActive(false);
            else
                skillUIObj.SetActive(true);
        }
        //아이템창
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (itemUIObj.activeSelf)
                itemUIObj.SetActive(false);
            else
                itemUIObj.SetActive(true);
        }
        //월드맵창
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (worldMapUIObj.activeSelf)
                worldMapUIObj.SetActive(false);
            else
                worldMapUIObj.SetActive(true);
        }
        //장비창
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (equipmemtUIObj.activeSelf)
                equipmemtUIObj.SetActive(false);
            else
                 equipmemtUIObj.SetActive(true);
        }
        //퀘스트창
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (questManagerUIObj.activeSelf)
                questManagerUIObj.SetActive(false);
            else
                questManagerUIObj.SetActive(true);
        }
        //나가기 창
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (exitUIObj.activeSelf)
                exitUIObj.SetActive(false);
            else
                exitUIObj.SetActive(true);
        }
    }
    void InputItemKey()
    {
        //상점UI가 열렸을때는 작동안함
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
        if (Input.GetKeyDown(KeyCode.F))
        {
            ItemManager.itemInstance.UseElixerPosion(ItemManager.itemInstance.UseElixerPosionIndex);
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
    /// 마우스 클릭
    /// </summary>
    void InputMouseClick()
    {
       
    }

    void TimeFlow()
    {
        curAttackSkillTime += Time.deltaTime;
    }
}
