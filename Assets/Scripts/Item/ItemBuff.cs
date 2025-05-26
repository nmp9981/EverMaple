using TMPro;
using UnityEngine;

public class ItemBuff : MonoBehaviour
{
    //���� ��ų Ŭ����
    BuffSkill buffSkill = new BuffSkill();
    
    public int buffIdx;

    [SerializeField]
    SkillEffectManager skillEffectManager;
    [SerializeField]
    GameObject shadowObj;
    [SerializeField]
    StatUI statUIObj;
    [SerializeField]
    TextMeshProUGUI timeText;
    float buffFullTime;

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
                PlayerManager.PlayerInstance.PlayerAttack += 10;
                break;
            case 1://���� ����
                PlayerManager.PlayerInstance.PlayerMagicPower += 5;
                break;
            case 2://���� ����
                PlayerManager.PlayerInstance.PlayerAddAccurary += 10;
                break;
            case 3://��ø ����
                PlayerManager.PlayerInstance.PlayerAddAvoid += 10;
                break;
            case 4://�̼� ����
                PlayerManager.PlayerInstance.PlayerMoveSpeedRate += 10f;
                break;
            case 10://���̽�Ʈ
                buffFullTime = 10* buffSkill.hasteLv;
                PlayerManager.PlayerInstance.PlayerMoveSpeedRate += (2*buffSkill.hasteLv);
                PlayerManager.PlayerInstance.JumpForceRate += (buffSkill.hasteLv);
                skillEffectManager.PlaySkillAnimation("Haste",0,0);
                break;
            case 11://�ں��� �ν���
                buffFullTime = 10 * buffSkill.boosterLv;
                PlayerManager.PlayerInstance.PlayerAttackSkillSpeed = 0.5f;
                break;
            case 12://��� �ν���
                buffFullTime = 10 * buffSkill.boosterLv;
                PlayerManager.PlayerInstance.PlayerAttackSkillSpeed = 0.5f;
                break;
            case 13://������ ��Ʈ��
                buffFullTime = ((buffSkill.shadowPartnerLv+9)/10)*60;
                shadowObj.SetActive(true);
                buffSkill.EffectShadowPartnerSkill(true, buffSkill.shadowPartnerLv);
                skillEffectManager.PlaySkillAnimation("ShadowPartner", 0.01f, 0);
                break;
            case 14://�޼Ҿ�
                buffFullTime = 20+5*buffSkill.mesoUpLv;
                if(buffSkill.mesoUpLv<=10)
                    PlayerManager.PlayerInstance.RateIncreaseGetMeso = 3 * buffSkill.mesoUpLv;
                else
                    PlayerManager.PlayerInstance.RateIncreaseGetMeso = 30+2 * buffSkill.mesoUpLv;

                break;
            case 15://�޼Ұ���
                buffFullTime = 120+buffSkill.mesoGuardLv*3;
                buffSkill.EffectMasoGuardSkill(true, buffSkill.mesoGuardLv);
                skillEffectManager.PlaySkillAnimation("MesoGuard", 0, 0);
                break;
            case 16://������ ���
                buffFullTime = 30*buffSkill.mapleWarriorLv;
                buffSkill.EffextMapleWarriorSkill(true, buffSkill.mapleWarriorLv);
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
                    PlayerManager.PlayerInstance.PlayerAttack -= 10;
                    break;
                case 1://���� ����
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
                case 10://���̽�Ʈ
                    PlayerManager.PlayerInstance.PlayerMoveSpeedRate -= (2 * buffSkill.hasteLv);
                    PlayerManager.PlayerInstance.JumpForceRate -= (buffSkill.hasteLv);
                    break;
                case 11://�ں��� �ν���
                    PlayerManager.PlayerInstance.PlayerAttackSkillSpeed = 0.7f;
                    break;
                case 12://��� �ν���
                    PlayerManager.PlayerInstance.PlayerAttackSkillSpeed = 0.7f;
                    break;
                case 13://������ ��Ʈ��
                    shadowObj.SetActive(false);
                    buffSkill.EffectShadowPartnerSkill(false, buffSkill.shadowPartnerLv);
                    break;
                case 14://�޼Ҿ�
                    PlayerManager.PlayerInstance.RateIncreaseGetMeso = 0;
                    break;
                case 15://�޼Ұ���
                    buffSkill.EffectMasoGuardSkill(false, buffSkill.mesoGuardLv);
                    break;
                case 16://������ ���
                    buffSkill.EffextMapleWarriorSkill(false, buffSkill.mapleWarriorLv);
                    break;
                default:
                    break;
            }
            statUIObj.ShowCharacterBasicStat();
            statUIObj.ShowCharacterDetailStat();
            gameObject.SetActive(false);
        }
    }
}
