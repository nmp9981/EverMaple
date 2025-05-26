using TMPro;
using UnityEngine;

public class ItemBuff : MonoBehaviour
{
    //버프 스킬 클래스
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
    /// 버프 지속시간, 효과 설정
    /// </summary>
    void SettingBuffDurationTimeAndEffect()
    {
        buffFullTime = 300;

        switch (buffIdx)
        {
            case 0://전사 물약
                PlayerManager.PlayerInstance.PlayerAttack += 10;
                break;
            case 1://법사 물약
                PlayerManager.PlayerInstance.PlayerMagicPower += 5;
                break;
            case 2://명사수 물약
                PlayerManager.PlayerInstance.PlayerAddAccurary += 10;
                break;
            case 3://민첩 물약
                PlayerManager.PlayerInstance.PlayerAddAvoid += 10;
                break;
            case 4://이속 물약
                PlayerManager.PlayerInstance.PlayerMoveSpeedRate += 10f;
                break;
            case 10://헤이스트
                buffFullTime = 10* buffSkill.hasteLv;
                PlayerManager.PlayerInstance.PlayerMoveSpeedRate += (2*buffSkill.hasteLv);
                PlayerManager.PlayerInstance.JumpForceRate += (buffSkill.hasteLv);
                skillEffectManager.PlaySkillAnimation("Haste",0,0);
                break;
            case 11://자벨린 부스터
                buffFullTime = 10 * buffSkill.boosterLv;
                PlayerManager.PlayerInstance.PlayerAttackSkillSpeed = 0.5f;
                break;
            case 12://대거 부스터
                buffFullTime = 10 * buffSkill.boosterLv;
                PlayerManager.PlayerInstance.PlayerAttackSkillSpeed = 0.5f;
                break;
            case 13://쉐도우 파트너
                buffFullTime = ((buffSkill.shadowPartnerLv+9)/10)*60;
                shadowObj.SetActive(true);
                buffSkill.EffectShadowPartnerSkill(true, buffSkill.shadowPartnerLv);
                skillEffectManager.PlaySkillAnimation("ShadowPartner", 0.01f, 0);
                break;
            case 14://메소업
                buffFullTime = 20+5*buffSkill.mesoUpLv;
                if(buffSkill.mesoUpLv<=10)
                    PlayerManager.PlayerInstance.RateIncreaseGetMeso = 3 * buffSkill.mesoUpLv;
                else
                    PlayerManager.PlayerInstance.RateIncreaseGetMeso = 30+2 * buffSkill.mesoUpLv;

                break;
            case 15://메소가드
                buffFullTime = 120+buffSkill.mesoGuardLv*3;
                buffSkill.EffectMasoGuardSkill(true, buffSkill.mesoGuardLv);
                skillEffectManager.PlaySkillAnimation("MesoGuard", 0, 0);
                break;
            case 16://메이플 용사
                buffFullTime = 30*buffSkill.mapleWarriorLv;
                buffSkill.EffextMapleWarriorSkill(true, buffSkill.mapleWarriorLv);
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
                    PlayerManager.PlayerInstance.PlayerAttack -= 10;
                    break;
                case 1://법사 물약
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
                case 10://헤이스트
                    PlayerManager.PlayerInstance.PlayerMoveSpeedRate -= (2 * buffSkill.hasteLv);
                    PlayerManager.PlayerInstance.JumpForceRate -= (buffSkill.hasteLv);
                    break;
                case 11://자벨린 부스터
                    PlayerManager.PlayerInstance.PlayerAttackSkillSpeed = 0.7f;
                    break;
                case 12://대거 부스터
                    PlayerManager.PlayerInstance.PlayerAttackSkillSpeed = 0.7f;
                    break;
                case 13://쉐도우 파트너
                    shadowObj.SetActive(false);
                    buffSkill.EffectShadowPartnerSkill(false, buffSkill.shadowPartnerLv);
                    break;
                case 14://메소업
                    PlayerManager.PlayerInstance.RateIncreaseGetMeso = 0;
                    break;
                case 15://메소가드
                    buffSkill.EffectMasoGuardSkill(false, buffSkill.mesoGuardLv);
                    break;
                case 16://메이플 용사
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
