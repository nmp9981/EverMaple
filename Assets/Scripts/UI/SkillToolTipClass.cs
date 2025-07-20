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

    public SkillToolTipText(Sprite skillSprite, string skillName, string skillExplain)
    {
        this.skillSprite = skillSprite;
        this.skillName = skillName;
        this.skillExplain = skillExplain;
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
            = new SkillToolTipText(skillIconList[0], "님블바디", "명중률과 회피율을 증가시켜준다.");
        skillToolTipTextDic.Add("님블바디", skillToolTip0);

        SkillToolTipText skillToolTip1
           = new SkillToolTipText(skillIconList[1], "킨 아이즈", "수리검, 표창 등 투척 무기의 사정거리를 증가시켜준다");
        skillToolTipTextDic.Add("킨 아이즈", skillToolTip1);

        SkillToolTipText skillToolTip2
           = new SkillToolTipText(skillIconList[2], "럭키세븐", "MP를 소비하여 2개의 표창을 날려 LUK에 따른 강한 공격을 가한다. " +
           "자벨린 마스터리에 관계 없이 LUK 수치에 따라 공격한다.");
        skillToolTipTextDic.Add("럭키세븐", skillToolTip2);

        SkillToolTipText skillToolTip3
           = new SkillToolTipText(skillIconList[3], "더블 스텝", "MP를 소비하여 단 시간에 단검으로 한 번에 2번 적을 찌른다.");
        skillToolTipTextDic.Add("더블 스텝", skillToolTip3);

        SkillToolTipText skillToolTip4
           = new SkillToolTipText(skillIconList[4], "자벨린 마스터리", "표창을 더욱 잘 다룰수 있게된다.");
        skillToolTipTextDic.Add("자벨린 마스터리", skillToolTip4);

        SkillToolTipText skillToolTip5
           = new SkillToolTipText(skillIconList[5], "자벨린 부스터", "HP, MP를 소비하여 일정 시간동안 아대의 공격속도를 한 단계 상승시킨다." +
           " 아대를 장비하고 표창을 던질 경우에만 발동이 가능하다.");
        skillToolTipTextDic.Add("자벨린 부스터", skillToolTip5);

        SkillToolTipText skillToolTip6
          = new SkillToolTipText(skillIconList[6], "크리티컬 스로우", "일정 확률로 표창에 대한 크리티컬 공격이 가능해진다.");
        skillToolTipTextDic.Add("크리티컬 스로우", skillToolTip6);

        SkillToolTipText skillToolTip7
          = new SkillToolTipText(skillIconList[7], "헤이스트", "일정 시간동안 이동속도와 점프력을 증가시켜준다.");
        skillToolTipTextDic.Add("헤이스트", skillToolTip7);
    }
}
