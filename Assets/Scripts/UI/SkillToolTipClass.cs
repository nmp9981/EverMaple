using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 스킬 툴팁 클래스
/// </summary>
public class SkillToolTipText
{
    public Sprite skillSprite;//스킬 이미지
    public string skillName;//스킬명
    public string skillExplain;//스킬 설명
    public int masterLv;//마스터 레벨

    public SkillToolTipText(Sprite skillSprite, string skillName, string skillExplain,int masterLv)
    {
        this.skillSprite = skillSprite;
        this.skillName = skillName;
        this.skillExplain = skillExplain;
        this.masterLv = masterLv;
    }
}

public class SkillToolTipClass : MonoBehaviour
{
    public Dictionary<string, SkillToolTipText> skillToolTipTextDic = new Dictionary<string, SkillToolTipText>(); 
    public List<Sprite> skillIconList = new List<Sprite>();

    private void Start()
    {
        EnrollSkillText();
    }
    void EnrollSkillText()
    {
        SkillToolTipText skillToolTip0 
            = new SkillToolTipText(skillIconList[0], "님블바디", "명중률과 회피율을 증가시켜준다.",20);
        skillToolTipTextDic.Add("님블바디", skillToolTip0);

        SkillToolTipText skillToolTip1
           = new SkillToolTipText(skillIconList[1], "킨 아이즈", "수리검, 표창 등 투척 무기의 사정거리를 증가시켜준다",8);
        skillToolTipTextDic.Add("킨 아이즈", skillToolTip1);

        SkillToolTipText skillToolTip2
           = new SkillToolTipText(skillIconList[2], "럭키세븐", "MP를 소비하여 2개의 표창을 날려 LUK에 따른 강한 공격을 가한다. " +
           "자벨린 마스터리에 관계 없이 LUK 수치에 따라 공격한다.",20);
        skillToolTipTextDic.Add("럭키세븐", skillToolTip2);

        SkillToolTipText skillToolTip3
           = new SkillToolTipText(skillIconList[3], "더블 스텝", "MP를 소비하여 단 시간에 단검으로 한 번에 2번 적을 찌른다.",20);
        skillToolTipTextDic.Add("더블 스텝", skillToolTip3);

        SkillToolTipText skillToolTip4
           = new SkillToolTipText(skillIconList[4], "자벨린 마스터리", "표창을 더욱 잘 다룰수 있게된다.",20);
        skillToolTipTextDic.Add("자벨린 마스터리", skillToolTip4);

        SkillToolTipText skillToolTip5
           = new SkillToolTipText(skillIconList[5], "자벨린 부스터", "HP, MP를 소비하여 일정 시간동안 아대의 공격속도를 한 단계 상승시킨다." +
           " 아대를 장비하고 표창을 던질 경우에만 발동이 가능하다.",20);
        skillToolTipTextDic.Add("자벨린 부스터", skillToolTip5);

        SkillToolTipText skillToolTip6
          = new SkillToolTipText(skillIconList[6], "크리티컬 스로우", "일정 확률로 표창에 대한 크리티컬 공격이 가능해진다.",30);
        skillToolTipTextDic.Add("크리티컬 스로우", skillToolTip6);

        SkillToolTipText skillToolTip7
          = new SkillToolTipText(skillIconList[7], "헤이스트", "일정 시간동안 이동속도와 점프력을 증가시켜준다.",20);
        skillToolTipTextDic.Add("헤이스트", skillToolTip7);

        SkillToolTipText skillToolTip8
          = new SkillToolTipText(skillIconList[8], "대거 마스터리", "단검 계열 무기의 숙련도와 명중률을 상승시킨다.",20);
        skillToolTipTextDic.Add("대거 마스터리", skillToolTip8);

        SkillToolTipText skillToolTip9
          = new SkillToolTipText(skillIconList[9], "대거 부스터", "HP, MP를 소비하여 일정 시간동안 딘검의 공격속도를 한 단계 상승시킨다. " +
          "단검을 들고 있을 경우에만 발동이 가능하다.",20);
        skillToolTipTextDic.Add("대거 부스터", skillToolTip9);

        SkillToolTipText skillToolTip10
         = new SkillToolTipText(skillIconList[10], "새비지블로우", "MP를 소비하여 단검으로 적에게 최고 6연속 공격을 가한다.",30);
        skillToolTipTextDic.Add("새비지블로우", skillToolTip10);

        SkillToolTipText skillToolTip11
         = new SkillToolTipText(skillIconList[11], "알케미스트", "포션 등 회복 아이템의 효과가 상승하거나" +
         "상태변화 아이템의 적용시간이 늘어난다. 단, 엘릭서와 같이 %로 회복시켜 주는 아이템에는 적용되지 않는다",20);
        skillToolTipTextDic.Add("알케미스트", skillToolTip11);

        SkillToolTipText skillToolTip12
         = new SkillToolTipText(skillIconList[12], "쉐도우파트너", "일정 시간동안 자신과 똑같은 행동을 하는 그림자 동료를 소환해낸다. " +
         "별도의 체력은 없으며시간이 지나면 사라지게된다.",30);
        skillToolTipTextDic.Add("쉐도우파트너", skillToolTip12);

        SkillToolTipText skillToolTip13
         = new SkillToolTipText(skillIconList[13], "어벤져", "MP를 소모하여 커다란 표창을 만들어 던진다." +
         " 던져진 표창은 적을 통과하며 그 뒤의 적까지 공격할 수 있다.",30);
        skillToolTipTextDic.Add("어벤져", skillToolTip13);

        SkillToolTipText skillToolTip14
         = new SkillToolTipText(skillIconList[14], "메소업", "일정 시간동안 적으로부터 더욱 많은 메소가 떨어지도록 한다.",20);
        skillToolTipTextDic.Add("메소업", skillToolTip14);

        SkillToolTipText skillToolTip15
         = new SkillToolTipText(skillIconList[15], "어썰터", "적 한 명을 강하고 빠르게 공격한다.",30);
        skillToolTipTextDic.Add("어썰터", skillToolTip15);

        SkillToolTipText skillToolTip16
         = new SkillToolTipText(skillIconList[16], "시브즈", "동료를 소환하여 주변의 적 여러 명을 공격한다. 최대 5명까지 공격할 수 있다.",30);
        skillToolTipTextDic.Add("시브즈", skillToolTip16);

        SkillToolTipText skillToolTip17
         = new SkillToolTipText(skillIconList[17], "메소가드", "일정 시간동안 메소로 데미지의 50%를 가드한다. 데미지를 받을 때마다 비율에 따라 메소가 소비된다.",20);
        skillToolTipTextDic.Add("메소가드", skillToolTip17);

        SkillToolTipText skillToolTip18
         = new SkillToolTipText(skillIconList[18], "메이플 용사", "일정 시간동안 모든 스탯을 일정 페센트 올려준다.",20);
        skillToolTipTextDic.Add("메이플 용사", skillToolTip18);

        SkillToolTipText skillToolTip19
         = new SkillToolTipText(skillIconList[19], "트리플스로우", "한 번에 표창 3개를 던져 공격을 한다.",30);
        skillToolTipTextDic.Add("트리플스로우", skillToolTip19);

        SkillToolTipText skillToolTip20
         = new SkillToolTipText(skillIconList[20], "부메랑 스텝", "빠른 속도로 다수의 적을 두 번 벤다.",30);
        skillToolTipTextDic.Add("부메랑 스텝", skillToolTip20);
    }

    /// <summary>
    /// 각 스킬 기능들 상세 설명
    /// </summary>
    /// <returns></returns>
    public string SKillFunctionExplainDetail(string skillName, int skillLv)
    {
        string detailText = string.Empty;
        int spendMP = 0;
        int nextSpendMP = 0;
        int coff = 0;
        int nextCoff = 0;

        switch (skillName)
        {
            case "님블바디":
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                    detailText = $"명중률 +{skillLv}, 회피율 +{skillLv}\n명중률 +{skillLv+1}, 회피율 +{skillLv+1}";
                else
                    detailText = $"명중률 +{skillLv}, 회피율 +{skillLv}";
                break;
            case "킨 아이즈":
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                    detailText = $"투척 무기의 사정거리 증가: +{skillLv*0.75}\n투척 무기의 사정거리 증가: +{(skillLv+1) * 0.75}";
                else
                    detailText = $"투척 무기의 사정거리 증가: +{skillLv * 0.75}";
                break;
            case "럭키세븐":
                spendMP = 6 + skillLv / 2;
                nextSpendMP = 6 + (skillLv+1) / 2;
                coff = (skillLv==0)?0: 50 + skillLv * 5;
                nextCoff = 50 + (skillLv + 1) * 5;
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, 데미지 {coff}% x 2\nMP -{nextSpendMP}, 데미지 {nextCoff}% x 2";
                }
                else
                    detailText = $"MP -{spendMP}, 데미지 {coff}% x 2";
                break;
            case "더블 스텝":
                spendMP = 7 + (skillLv + 1) / 3;
                nextSpendMP = 7 + (skillLv + 2) / 3;
                coff = (skillLv == 0) ? 0 : 70 + (skillLv * 7) / 2;
                nextCoff = 70 + ((skillLv+1) * 7) / 2;
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, 데미지 {coff}% x 2\nMP -{nextSpendMP}, 데미지 {nextCoff}% x 2";
                }
                else
                    detailText = $"MP -{spendMP}, 데미지 {coff}% x 2";
                break;
            case "자벨린 마스터리":
                coff = (skillLv == 0) ? 0 : 15 + 5 * ((skillLv - 1) / 2);
                nextCoff = 15 + 5 * (skillLv / 2); ;
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"아대 계열의 무기 숙련도 {coff}%, 명중률 +{skillLv}\n아대 계열의 무기 숙련도 {nextCoff}%, 명중률 +{skillLv+1}";
                }
                else
                    detailText = $"아대 계열의 무기 숙련도 {coff}%, 명중률 +{skillLv}";
                break;
            case "자벨린 부스터":
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"HP -{30 - skillLv}, MP -{30 - skillLv}소비하여 아대의 공격 속도 향상 {skillLv * 10} 초 지속\n" +
                        $"HP -{29 - skillLv}, MP -{29 - skillLv}소비하여 아대의 공격 속도 향상 {skillLv * 10+10} 초 지속";
                }
                else
                    detailText = $"HP -{30-skillLv}, MP -{30-skillLv}소비하여 아대의 공격 속도 향상 {skillLv*10} 초 지속";
                break;
            case "크리티컬 스로우":
                int coffProb = skillLv<21? 2 * skillLv: 20 + skillLv;
                int nextCoffProb = (skillLv+1) < 21 ? 2 * skillLv+2 : 21 + skillLv;
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"{coffProb}%의 확률, 크리티컬 데미지 {110 + 3 * skillLv}%\n" +
                        $"{nextCoffProb}%의 확률, 크리티컬 데미지 {113 + 3 * skillLv}%";
                }
                else
                    detailText = $"{coffProb}%의 확률, 크리티컬 데미지 {110 + 3 * skillLv}%";
                break;
            case "헤이스트":
                spendMP = skillLv<=10?15:30;
                nextSpendMP = (skillLv+1 <= 10) ? 15 : 30;
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, 이동속도 +{skillLv * 2}. 점프력 +{skillLv}, {skillLv * 10}초 지속\n" +
                        $"MP -{nextSpendMP}, 이동속도 +{skillLv * 2+2}. 점프력 +{skillLv+1}, {skillLv * 10+10}초 지속";
                }
                else
                    detailText = $"MP -{spendMP}, 이동속도 +{skillLv*2}. 점프력 +{skillLv}, {skillLv*10}초 지속";
                break;
            case "대거 마스터리":
                coff = (skillLv == 0) ? 0 : 15 + 5 * ((skillLv - 1) / 2);
                nextCoff = 15 + 5 * (skillLv / 2); ;
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"단검 계열의 무기 숙련도 {coff}%, 명중률 +{skillLv}\n단검 계열의 무기 숙련도 {nextCoff}%, 명중률 +{skillLv + 1}";
                }
                else
                    detailText = $"단검 계열의 무기 숙련도 {coff}%, 명중률 +{skillLv}";
                break;
            case "대거 부스터":
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"HP -{30 - skillLv}, MP -{30 - skillLv}소비하여 단검의 공격 속도 향상 {skillLv * 10} 초 지속\n" +
                        $"HP -{29 - skillLv}, MP -{29 - skillLv}소비하여 단검의 공격 속도 향상 {skillLv * 10 + 10} 초 지속";
                }
                else
                    detailText = $"HP -{30 - skillLv}, MP -{30 - skillLv}소비하여 단검의 공격 속도 향상 {skillLv * 10} 초 지속";
                break;
            case "새비지블로우":
                spendMP = 9 * ((skillLv + 9) / 10);
                nextSpendMP = 9 * ((skillLv + 10) / 10);
                coff = 50 + skillLv;
                nextCoff = 51 + skillLv;
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, {2 * ((skillLv + 9) / 10)}번 적을 공격, 데미지 {coff}%\n" +
                        $"MP -{nextSpendMP}, {2 * ((skillLv + 10) / 10)}번 적을 공격, 데미지 {nextCoff}%";
                }
                else
                    detailText = $"MP -{spendMP}, {2 * ((skillLv + 9) / 10)}번 적을 공격, 데미지 {coff}%";
                break;
            case "알케미스트":
                coff = (skillLv<11)? 100+3 * skillLv: 130 + 2 * skillLv;
                nextCoff = (skillLv +1< 11) ?103+ 3 * skillLv : 132 + 2 * skillLv;
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"회복량 {coff}%, 적용 시간 {coff}%\n" +
                        $"회복량 {nextCoff}%, 적용 시간 {nextCoff}%";
                }
                else
                    detailText = $"회복량 {coff}%, 적용 시간 {coff}%";
                break;
            case "쉐도우파트너":
               //현재 레벨 계수
                if (skillLv < 8)
                    coff = 21;
                else if (skillLv >= 8 && skillLv <= 24)
                    coff = 14 + skillLv;
                else
                    coff = 2 * skillLv - 10;

                //다음 레벨 계수
                if (skillLv < 7)
                    nextCoff = 21;
                else if (skillLv >= 7 && skillLv <= 23)
                    nextCoff = 14 + skillLv;
                else
                    nextCoff = 2 * skillLv - 10;

                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{205 - skillLv * 5}, 데미지 {coff}%, {((skillLv + 9) / 10) * 60}초 지속\n" +
                        $"MP -{200 - skillLv * 5}, 데미지 {nextCoff}%, {((skillLv + 10) / 10) * 60}초 지속";
                }
                else
                    detailText = $"MP -{205 - skillLv * 5}, 데미지 {coff}%, {((skillLv + 9) / 10) * 60}초 지속";
                break;
            case "어벤져":
                spendMP = 9 + 7 * ((skillLv + 9) / 10);
                nextSpendMP = 9 + 7 * ((skillLv + 10) / 10);

                //현재 레벨 계수
                if (skillLv <= 10)
                    coff = 60 + 5 * skillLv;
                else if (skillLv > 20)
                    coff = 90 + 3 * skillLv;
                else
                    coff = 70 + 4 * skillLv;

                //다음 레벨 계수
                if (skillLv <= 9)
                    nextCoff = 60 + 5 * skillLv;
                else if (skillLv > 19)
                    nextCoff = 90 + 3 * skillLv;
                else
                    nextCoff = 70 + 4 * skillLv;

                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, 데미지 {coff}%, 표창 3개 소비하여 최대 {3 + (skillLv + 9) / 10}명 공격\n" +
                        $"MP -{nextSpendMP}, 데미지 {nextCoff}%, 표창 3개 소비하여 최대 {3 + (skillLv + 10) / 10}명 공격";
                }
                else
                    detailText = $"MP -{spendMP}, 데미지 {coff}%, 표창 3개 소비하여 최대 {3 + (skillLv + 9) / 10}명 공격";
                break;
            case "메소업":
                coff = (skillLv <= 10) ? 3 * skillLv : 30 + 2 * skillLv;
                nextCoff = (skillLv+1 <= 10) ? 3 * skillLv+3 : 32 + 2 * skillLv;

                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -60, 메소 드롭양 +{coff}%, {20 + 5 * skillLv}초 지속\n" +
                        $"MP -60, 메소 드롭양 +{nextCoff}%, {25 + 5 * skillLv}초 지속";
                }
                else
                    detailText = $"MP -60, 메소 드롭양 +{coff}%, {20 + 5 * skillLv}초 지속";
                break;
            case "어썰터":
                spendMP = 5 + 7 * ((skillLv + 9) / 10);
                nextSpendMP = 5 + 7 * ((skillLv + 10) / 10);
                coff = (skillLv < 21) ? 200 + skillLv * 10 : 300 + 5 * skillLv;
                nextCoff = (skillLv < 20) ? 210 + skillLv * 10 : 305 + 5 * skillLv;

                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, 데미지 {coff}%\n" +
                        $"MP -{nextSpendMP}, 데미지 {nextCoff}%";
                }
                else
                    detailText = $"MP -{spendMP}, 데미지 {coff}%";
                break;
            case "시브즈":
                spendMP = 10 * ((skillLv + 9) / 10);
                nextSpendMP = 10 * ((skillLv + 10) / 10);
                int targetNum = 2 + ((skillLv + 9) / 10);
                int nextTargetNum = 2 + ((skillLv + 10) / 10);
                coff = 160 + skillLv * 5 - targetNum*20;
                nextCoff = 165 + skillLv * 5 - nextTargetNum * 20;

                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, 데미지 {coff}%, {targetNum}명의 분신이 적을 공격\n" +
                        $"MP -{nextSpendMP}, 데미지 {nextCoff}%, {nextTargetNum}명의 분신이 적을 공격";
                }
                else
                    detailText = $"MP -{spendMP}, 데미지 {coff}%, {targetNum}명의 분신이 적을 공격";
                break;
            case "메소가드":
                coff = (skillLv < 17) ? 90 - skillLv / 2 : 98 - skillLv;
                nextCoff = (skillLv < 16) ? 90 - (skillLv + 1) / 2 : 97 - skillLv;

                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -35, 가드한 데미지의 {coff}%를 메소로 방어, {120 + skillLv * 3}초 지속\n" +
                        $"MP -35, 가드한 데미지의 {nextCoff}%를 메소로 방어, {123 + skillLv * 3}초 지속";
                }
                else
                    detailText = $"MP -35, 가드한 데미지의 {coff}%를 메소로 방어, {120 + skillLv * 3}초 지속";
                break;
            case "메이플 용사":
                spendMP = 10 * skillLv / 5 + 10;
                nextSpendMP = 10 * (skillLv+1) / 5 + 10;
                coff = (skillLv + 1) / 2;
                nextCoff = (skillLv + 2) / 2;

                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, 모든 스탯 +{coff}%, 지속시간 {30 * skillLv}초\n" +
                        $"MP -{nextSpendMP}, 모든 스탯 +{nextCoff}%, 지속시간 {30 * skillLv+30}초";
                }
                else
                    detailText = $"MP -{spendMP}, 모든 스탯 +{coff}%, 지속시간 {30 * skillLv}초";
                break;
            case "트리플스로우":
                spendMP = 10 + (skillLv + 2) / 3;
                nextSpendMP = 10 + (skillLv + 3) / 3;
                coff = (skillLv > 20) ? 120 + skillLv : 100 + 2 * skillLv;
                nextCoff = (skillLv > 20) ? 121 + skillLv : 102 + 2 * skillLv;

                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, 데미지 {coff}%\n" +
                        $"MP -{nextSpendMP}, 데미지 {nextCoff}%";
                }
                else
                    detailText = $"MP -{spendMP}, 데미지 {coff}%";
                break;
            case "부메랑 스텝":
                spendMP = 13 + 3 * ((skillLv + 5) / 6);
                nextSpendMP = 13 + 3 * ((skillLv + 6) / 6);
                coff = (skillLv > 20) ? 350 + 5 * skillLv : 250 + 10 * skillLv;
                nextCoff = (skillLv > 19) ? 355 + 5 * skillLv : 260 + 10 * skillLv;

                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, {1 + (skillLv + 9) / 10}명의 적에게 데미지 {coff}%\n" +
                        $"MP -{nextSpendMP}, {1 + (skillLv + 10) / 10}명의 적에게 데미지 {nextCoff}%";
                }
                else
                    detailText = $"MP -{spendMP}, {1 + (skillLv + 9) / 10}명의 적에게 데미지 {coff}%";
                break;
            default:
                break;
        }
        return detailText;
    }
}
