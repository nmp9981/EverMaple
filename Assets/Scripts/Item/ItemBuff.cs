using TMPro;
using UnityEngine;

public class ItemBuff : MonoBehaviour
{
    //���� ��ų Ŭ����
    BuffSkill buffSkill;
    
    public int buffIdx;

    //���� ���� ����
    private bool[] buffSkillIng = new bool[17]
    {
        false, false, false, false, false, false,
         false, false, false, false, false, false,
          false, false, false, false, false
    };

    [SerializeField]
    SkillEffectManager skillEffectManager;
    [SerializeField]
    GameObject shadowObj;
    [SerializeField]
    StatUI statUIObj;
    [SerializeField]
    TextMeshProUGUI timeText;
    float buffFullTime;

    private void Awake()
    {
        buffSkill = new BuffSkill();
    }
    private void OnEnable()
    {
        SettingBuffDurationTimeAndEffect();
    }
    private void Update()
    {
        ShowBuffRestTime();
    }

    /// <summary>
    /// ���� ���ӽð�, ȿ�� ����
    /// </summary>
    void SettingBuffDurationTimeAndEffect()
    {
        buffFullTime = 300;

        switch (buffIdx)
        {
            case 0://���� ����
                if (!buffSkillIng[buffIdx])
                {
                    //��ø ����
                    if (buffSkillIng[7])
                    {
                        buffSkillIng[7] = false;
                        PlayerManager.PlayerInstance.PlayerAttack -= 10;
                    }
                    PlayerManager.PlayerInstance.PlayerAttack += 5;
                    buffSkillIng[buffIdx] = true;
                }
                break;
            case 1://���� ����
                if (!buffSkillIng[buffIdx])
                {
                    //��ø ����
                    if (buffSkillIng[5] || buffSkillIng[6])
                    {
                        buffSkillIng[5] = false;
                        buffSkillIng[6] = false;
                        PlayerManager.PlayerInstance.PlayerMagicPower -= 10;
                    }
                    PlayerManager.PlayerInstance.PlayerMagicPower += 5;
                    buffSkillIng[buffIdx] = true;
                }
                break;
            case 2://���� ����
                if (!buffSkillIng[buffIdx])
                {
                    PlayerManager.PlayerInstance.PlayerAddAccurary += 10;
                    buffSkillIng[buffIdx] = true;
                }
                break;
            case 3://��ø ����
                if (!buffSkillIng[buffIdx])
                {
                    PlayerManager.PlayerInstance.PlayerAddAvoid += 10;
                    buffSkillIng[buffIdx] = true;
                }
                break;
            case 4://�̼� ����
                if (!buffSkillIng[buffIdx])
                {
                    PlayerManager.PlayerInstance.PlayerMoveSpeedRate += 10f;
                    buffSkillIng[buffIdx] = true;
                }
                break;
            case 5://���� ����
                if (!buffSkillIng[buffIdx])
                {
                    //��ø ����
                    if (buffSkillIng[1])
                    {
                        buffSkillIng[1] = false;
                        PlayerManager.PlayerInstance.PlayerMagicPower -= 5;
                    }
                    if (buffSkillIng[6])
                    {
                        buffSkillIng[6] = false;
                        PlayerManager.PlayerInstance.PlayerMagicPower -= 10;
                    }

                    PlayerManager.PlayerInstance.PlayerMagicPower += 10;
                    buffSkillIng[buffIdx] = true;
                }
                break;
            case 6://��񳪹� ����
                if (!buffSkillIng[buffIdx])
                {
                    PlayerManager.PlayerInstance.PlayerMagicArmor += 10;
                    buffSkillIng[buffIdx] = true;
                }
                break;
            case 7://�巹��ũ ��
                if (!buffSkillIng[buffIdx])
                {
                    //��ø ����
                    if (buffSkillIng[0])
                    {
                        buffSkillIng[0] = false;
                        PlayerManager.PlayerInstance.PlayerAttack -= 5;
                    }
                    PlayerManager.PlayerInstance.PlayerAttack += 8;
                    buffSkillIng[buffIdx] = true;
                }
                break;
            case 8://�巹��ũ�� ���
                if (!buffSkillIng[buffIdx])
                {
                    PlayerManager.PlayerInstance.PlayerPhysicsArmor += 10;
                    buffSkillIng[buffIdx] = true;
                }
                break;
            case 10://���̽�Ʈ
                buffFullTime = 10* SkillLvManager.hasteLv;
                if (!buffSkillIng[buffIdx])
                {
                    PlayerManager.PlayerInstance.PlayerMoveSpeedRate += (2 * SkillLvManager.hasteLv);
                    PlayerManager.PlayerInstance.JumpForceRate += (SkillLvManager.hasteLv);
                    buffSkillIng[buffIdx] = true;
                }
                skillEffectManager.PlaySkillAnimation("Haste",0,0);
                break;
            case 11://�ں��� �ν���
                buffFullTime = 10 * SkillLvManager.boosterLv;
                PlayerManager.PlayerInstance.PlayerAttackSkillSpeed = 0.5f;
                skillEffectManager.PlaySkillAnimation("Booster", 0.01f, 0);
                break;
            case 12://��� �ν���
                buffFullTime = 10 * SkillLvManager.boosterLv;
                PlayerManager.PlayerInstance.PlayerAttackSkillSpeed = 0.5f;
                skillEffectManager.PlaySkillAnimation("Booster", 0.01f, 0);
                break;
            case 13://������ ��Ʈ��
                buffFullTime = ((SkillLvManager.shadowPartnerLv +9)/10)*60;
                shadowObj.SetActive(true);
                buffSkill.EffectShadowPartnerSkill(true, SkillLvManager.shadowPartnerLv);
                skillEffectManager.PlaySkillAnimation("ShadowPartner", 0.01f, 0);
                break;
            case 14://�޼Ҿ�
                buffFullTime = 20+5* SkillLvManager.mesoUpLv;
                if(SkillLvManager.mesoUpLv <=10)
                    PlayerManager.PlayerInstance.RateIncreaseGetMeso = 3 * SkillLvManager.mesoUpLv;
                else
                    PlayerManager.PlayerInstance.RateIncreaseGetMeso = 30+2 * SkillLvManager.mesoUpLv;
                skillEffectManager.PlaySkillAnimation("MesoUP", 0.01f, 0.25f);
                break;
            case 15://�޼Ұ���
                buffFullTime = 120+ SkillLvManager.mesoGuardLv *3;
                buffSkill.EffectMasoGuardSkill(true, SkillLvManager.mesoGuardLv);
                skillEffectManager.PlaySkillAnimation("MesoGuard", 0, 0);
                break;
            case 16://������ ���
                buffFullTime = 30* SkillLvManager.mapleWarriorLv;
                if (!buffSkillIng[buffIdx])
                {
                    buffSkill.EffextMapleWarriorSkill(true, SkillLvManager.mapleWarriorLv);
                    buffSkillIng[buffIdx] = true;
                }
                skillEffectManager.PlaySkillAnimation("MapleWarrior", 0.01f, 3.25f);
                break;
            default:
                break;
        }
        //����â���� �ݿ�
        statUIObj.ShowCharacterBasicStat();
        statUIObj.ShowCharacterDetailStat();
    }
    /// <summary>
    /// ���� ���� �ð� ���̱�(���� Ȱ��ȭ ���϶���)
    /// </summary>
    void ShowBuffRestTime()
    {
        if (!gameObject.activeSelf)
            return;
        buffFullTime -= Time.deltaTime;
        timeText.text = Mathf.Floor(buffFullTime).ToString();

        BuffOff();
    }
    /// <summary>
    /// ���� ����
    /// 1) ����â ����
    /// 2) ȿ�� �������
    /// </summary>
    void BuffOff()
    {
        if (buffFullTime < 0)
        {
            switch (buffIdx)
            {
                case 0://���� ����
                    if (buffSkillIng[buffIdx])
                        PlayerManager.PlayerInstance.PlayerAttack -= 5;
                    break;
                case 1://���� ����
                    if (buffSkillIng[buffIdx])
                        PlayerManager.PlayerInstance.PlayerMagicPower -= 5;
                    break;
                case 2://���� ����
                    PlayerManager.PlayerInstance.PlayerAddAccurary -= 10;
                    break;
                case 3://��ø ����
                    PlayerManager.PlayerInstance.PlayerAddAvoid -= 10;
                    break;
                case 4://�̼� ����
                    PlayerManager.PlayerInstance.PlayerMoveSpeedRate -= 10;
                    break;
                case 5://���� ����
                    if (buffSkillIng[buffIdx])
                        PlayerManager.PlayerInstance.PlayerMagicPower -= 10;
                    break;
                case 6://��񳪹��� ����
                    PlayerManager.PlayerInstance.PlayerMagicArmor -= 10;
                    break;
                case 7://�巹��ũ�� ��
                    if (buffSkillIng[buffIdx])
                        PlayerManager.PlayerInstance.PlayerAttack -= 8;
                    break;
                case 8://�巹��ũ�� ���
                    PlayerManager.PlayerInstance.PlayerPhysicsArmor -= 10;
                    break;
                case 10://���̽�Ʈ
                    PlayerManager.PlayerInstance.PlayerMoveSpeedRate -= (2 * SkillLvManager.hasteLv);
                    PlayerManager.PlayerInstance.JumpForceRate -= (SkillLvManager.hasteLv);
                    break;
                case 11://�ں��� �ν���
                    PlayerManager.PlayerInstance.PlayerAttackSkillSpeed = 0.7f;
                    break;
                case 12://��� �ν���
                    PlayerManager.PlayerInstance.PlayerAttackSkillSpeed = 0.7f;
                    break;
                case 13://������ ��Ʈ��
                    shadowObj.SetActive(false);
                    buffSkill.EffectShadowPartnerSkill(false, SkillLvManager.shadowPartnerLv);
                    break;
                case 14://�޼Ҿ�
                    PlayerManager.PlayerInstance.RateIncreaseGetMeso = 0;
                    break;
                case 15://�޼Ұ���
                    buffSkill.EffectMasoGuardSkill(false, SkillLvManager.mesoGuardLv);
                    break;
                case 16://������ ���
                    buffSkill.EffextMapleWarriorSkill(false, SkillLvManager.mapleWarriorLv);
                    break;
                default:
                    break;
            }
            buffSkillIng[buffIdx] = false;
            statUIObj.ShowCharacterBasicStat();
            statUIObj.ShowCharacterDetailStat();
            gameObject.SetActive(false);
        }
    }
}
