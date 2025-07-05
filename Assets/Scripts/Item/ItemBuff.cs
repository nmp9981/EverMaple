using TMPro;
using UnityEngine;

public class ItemBuff : MonoBehaviour
{
    //버프 스킬 클래스
    BuffSkill buffSkill;
    
    public int buffIdx;

    //버프 진행 여부
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
    /// 버프 지속시간, 효과 설정
    /// </summary>
    void SettingBuffDurationTimeAndEffect()
    {
        buffFullTime = 300;

        switch (buffIdx)
        {
            case 0://전사 물약
                if (!buffSkillIng[buffIdx])
                {
                    //중첩 방지
                    if (buffSkillIng[7])
                    {
                        buffSkillIng[7] = false;
                        PlayerManager.PlayerInstance.PlayerAttack -= 10;
                    }
                    PlayerManager.PlayerInstance.PlayerAttack += 5;
                    buffSkillIng[buffIdx] = true;
                }
                break;
            case 1://법사 물약
                if (!buffSkillIng[buffIdx])
                {
                    //중첩 방지
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
            case 2://명사수 물약
                if (!buffSkillIng[buffIdx])
                {
                    PlayerManager.PlayerInstance.PlayerAddAccurary += 10;
                    buffSkillIng[buffIdx] = true;
                }
                break;
            case 3://민첩 물약
                if (!buffSkillIng[buffIdx])
                {
                    PlayerManager.PlayerInstance.PlayerAddAvoid += 10;
                    buffSkillIng[buffIdx] = true;
                }
                break;
            case 4://이속 물약
                if (!buffSkillIng[buffIdx])
                {
                    PlayerManager.PlayerInstance.PlayerMoveSpeedRate += 10f;
                    buffSkillIng[buffIdx] = true;
                }
                break;
            case 5://현자 물약
                if (!buffSkillIng[buffIdx])
                {
                    //중첩 방지
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
            case 6://고목나무 수액
                if (!buffSkillIng[buffIdx])
                {
                    PlayerManager.PlayerInstance.PlayerMagicArmor += 10;
                    buffSkillIng[buffIdx] = true;
                }
                break;
            case 7://드레이크 피
                if (!buffSkillIng[buffIdx])
                {
                    //중첩 방지
                    if (buffSkillIng[0])
                    {
                        buffSkillIng[0] = false;
                        PlayerManager.PlayerInstance.PlayerAttack -= 5;
                    }
                    PlayerManager.PlayerInstance.PlayerAttack += 8;
                    buffSkillIng[buffIdx] = true;
                }
                break;
            case 8://드레이크의 고기
                if (!buffSkillIng[buffIdx])
                {
                    PlayerManager.PlayerInstance.PlayerPhysicsArmor += 10;
                    buffSkillIng[buffIdx] = true;
                }
                break;
            case 10://헤이스트
                buffFullTime = 10* SkillLvManager.hasteLv;
                if (!buffSkillIng[buffIdx])
                {
                    PlayerManager.PlayerInstance.PlayerMoveSpeedRate += (2 * SkillLvManager.hasteLv);
                    PlayerManager.PlayerInstance.JumpForceRate += (SkillLvManager.hasteLv);
                    buffSkillIng[buffIdx] = true;
                }
                skillEffectManager.PlaySkillAnimation("Haste",0,0);
                break;
            case 11://자벨린 부스터
                buffFullTime = 10 * SkillLvManager.boosterLv;
                PlayerManager.PlayerInstance.PlayerAttackSkillSpeed = 0.5f;
                skillEffectManager.PlaySkillAnimation("Booster", 0.01f, 0);
                break;
            case 12://대거 부스터
                buffFullTime = 10 * SkillLvManager.boosterLv;
                PlayerManager.PlayerInstance.PlayerAttackSkillSpeed = 0.5f;
                skillEffectManager.PlaySkillAnimation("Booster", 0.01f, 0);
                break;
            case 13://쉐도우 파트너
                buffFullTime = ((SkillLvManager.shadowPartnerLv +9)/10)*60;
                shadowObj.SetActive(true);
                buffSkill.EffectShadowPartnerSkill(true, SkillLvManager.shadowPartnerLv);
                skillEffectManager.PlaySkillAnimation("ShadowPartner", 0.01f, 0);
                break;
            case 14://메소업
                buffFullTime = 20+5* SkillLvManager.mesoUpLv;
                if(SkillLvManager.mesoUpLv <=10)
                    PlayerManager.PlayerInstance.RateIncreaseGetMeso = 3 * SkillLvManager.mesoUpLv;
                else
                    PlayerManager.PlayerInstance.RateIncreaseGetMeso = 30+2 * SkillLvManager.mesoUpLv;
                skillEffectManager.PlaySkillAnimation("MesoUP", 0.01f, 0.25f);
                break;
            case 15://메소가드
                buffFullTime = 120+ SkillLvManager.mesoGuardLv *3;
                buffSkill.EffectMasoGuardSkill(true, SkillLvManager.mesoGuardLv);
                skillEffectManager.PlaySkillAnimation("MesoGuard", 0, 0);
                break;
            case 16://메이플 용사
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
        //스탯창에도 반영
        statUIObj.ShowCharacterBasicStat();
        statUIObj.ShowCharacterDetailStat();
    }
    /// <summary>
    /// 남은 버프 시간 보이기(버프 활성화 중일때만)
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
    /// 버프 종료
    /// 1) 버프창 꺼짐
    /// 2) 효과 원래대로
    /// </summary>
    void BuffOff()
    {
        if (buffFullTime < 0)
        {
            switch (buffIdx)
            {
                case 0://전사 물약
                    if (buffSkillIng[buffIdx])
                        PlayerManager.PlayerInstance.PlayerAttack -= 5;
                    break;
                case 1://법사 물약
                    if (buffSkillIng[buffIdx])
                        PlayerManager.PlayerInstance.PlayerMagicPower -= 5;
                    break;
                case 2://명사수 물약
                    PlayerManager.PlayerInstance.PlayerAddAccurary -= 10;
                    break;
                case 3://민첩 물약
                    PlayerManager.PlayerInstance.PlayerAddAvoid -= 10;
                    break;
                case 4://이속 물약
                    PlayerManager.PlayerInstance.PlayerMoveSpeedRate -= 10;
                    break;
                case 5://현자 물약
                    if (buffSkillIng[buffIdx])
                        PlayerManager.PlayerInstance.PlayerMagicPower -= 10;
                    break;
                case 6://고목나무의 수액
                    PlayerManager.PlayerInstance.PlayerMagicArmor -= 10;
                    break;
                case 7://드레이크의 피
                    if (buffSkillIng[buffIdx])
                        PlayerManager.PlayerInstance.PlayerAttack -= 8;
                    break;
                case 8://드레이크의 고기
                    PlayerManager.PlayerInstance.PlayerPhysicsArmor -= 10;
                    break;
                case 10://헤이스트
                    PlayerManager.PlayerInstance.PlayerMoveSpeedRate -= (2 * SkillLvManager.hasteLv);
                    PlayerManager.PlayerInstance.JumpForceRate -= (SkillLvManager.hasteLv);
                    break;
                case 11://자벨린 부스터
                    PlayerManager.PlayerInstance.PlayerAttackSkillSpeed = 0.7f;
                    break;
                case 12://대거 부스터
                    PlayerManager.PlayerInstance.PlayerAttackSkillSpeed = 0.7f;
                    break;
                case 13://쉐도우 파트너
                    shadowObj.SetActive(false);
                    buffSkill.EffectShadowPartnerSkill(false, SkillLvManager.shadowPartnerLv);
                    break;
                case 14://메소업
                    PlayerManager.PlayerInstance.RateIncreaseGetMeso = 0;
                    break;
                case 15://메소가드
                    buffSkill.EffectMasoGuardSkill(false, SkillLvManager.mesoGuardLv);
                    break;
                case 16://메이플 용사
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
