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
                nextCoff = 70 + (skillLv * 7) / 2;
                if (skillLv < skillToolTipTextDic[skillName].masterLv)
                {
                    detailText = $"MP -{spendMP}, 데미지 {coff}% x 2\nMP -{nextSpendMP}, 데미지 {nextCoff}% x 2";
                }
                else
                    detailText = $"MP -{spendMP}, 데미지 {coff}% x 2";
                break;
            default:
                break;
        }
        return detailText;
    }
}
