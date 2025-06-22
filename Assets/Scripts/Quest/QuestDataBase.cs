using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 퀘스트 데아터
/// </summary>
public class QuestData
{
    //퀘스트 기본 정보
    public int questNum;//퀘스트 번호
    public int prevQuestNum;//선행 퀘스트 번호
    public int reqLv;//요구 레벨
    public int questState = 0;//퀘 상태, 1:시작, 2:진행중, 3:완료, 4:클리어
    public string questTitle;//퀘스트 제목

    //스크립트 내용
    public string startScript;//시작 스크립트
    public string[] questSctipt;//퀘스트 스크립트
    public string notFinishScript;//퀘 미완료 스크립트
    public string finishScript;//퀘 완료 스크립트

    //요구사항
    public int[] reqmonsterNum;//몬스터 번호
    public int[] reqMonsterCount;//몬스터 카운트
    public int[] reqMonsterGoalCount;//몬스터 목표 카운트

    //보상
    public int rewardExp;//보상 겸험치
    public int rewardMeso;//보상 메소
    public string rewardItem;//보상 아이템

    //생성자
    public QuestData(int questNum, int prevQuestNum, int reqLv, int questState, string questTitle,string startScript, string[] questSctipt, string notFinishScript, string finishScript, int[] reqmonsterNum, int[] reqMonsterCount, int[] reqMonsterGoalCount, int rewardExp, int rewardMeso, string rewardItem)
    {
        this.questNum = questNum;
        this.prevQuestNum = prevQuestNum;
        this.reqLv = reqLv;
        this.questState = questState;
        this.questTitle = questTitle;
        this.startScript = startScript;
        this.questSctipt = questSctipt;
        this.notFinishScript = notFinishScript;
        this.finishScript = finishScript;
        this.reqmonsterNum = reqmonsterNum;
        this.reqMonsterCount = reqMonsterCount;
        this.reqMonsterGoalCount = reqMonsterGoalCount;
        this.rewardExp = rewardExp;
        this.rewardMeso = rewardMeso;
        this.rewardItem = rewardItem;
    }
}

public class QuestDataBase : MonoBehaviour
{
    public static List<QuestData> questDataList = new List<QuestData>();

    private void Awake()
    {
        EnrollQuestData();
    }

    /// <summary>
    /// 퀘스트 데이터
    /// </summary>
    void EnrollQuestData()
    {
        //리스항구
        string[] questSctipt0 = new string[1]{
            "내가 수련을 도와주지!\n파란 달팽이 5마리를 잡아와",
        };
        int[] reqmonsterNum0 = new int[1]{ 0};
        int[] reqMonsterCount0 = new int[1] {0 };
        int[] reqMonsterGoalCount0 = new int[1] { 5 };
        QuestData questData0
            = new QuestData(0,-1,1,1,"쿤의 수련 I","1더하기1은 창문",questSctipt0,"좀만 힘내","잘했다. 다음 수련으로 가즈아",
            reqmonsterNum0,reqMonsterCount0, reqMonsterGoalCount0,
            30, 1500,string.Empty);
        questDataList.Add(questData0);

        string[] questSctipt1 = new string[1]{
            "이번에는 빨간 달팽이 10마리 잡아와"
        };
        int[] reqmonsterNum1 = new int[1] { 1 };
        int[] reqMonsterCount1 = new int[1] { 0 };
        int[] reqMonsterGoalCount1 = new int[1] { 10 };
        QuestData questData1
            = new QuestData(1, 0, 2, 0,"쿤의 수련 II", "1더하기1은 창문", questSctipt1, "좀만 힘내", "잘했다. 한번만더 가즈아",
            reqmonsterNum1, reqMonsterCount1, reqMonsterGoalCount1,
            50, 2500, string.Empty);
        questDataList.Add(questData1);

        string[] questSctipt2 = new string[1]{
            "이번에는 슬라임 10마리, 주황버섯 15마리를 잡아와"
        };
        int[] reqmonsterNum2 = new int[2] { 3,4 };
        int[] reqMonsterCount2 = new int[2] { 0,0 };
        int[] reqMonsterGoalCount2 = new int[2] { 10,15 };
        QuestData questData2
            = new QuestData(2, 1, 3, 0, "쿤의 수련 III","1더하기1은 창문", questSctipt2, "좀만 힘내", "잘했다. 초반에 폐사하면 안되니까 훈지좀 해줄게",
            reqmonsterNum2, reqMonsterCount2, reqMonsterGoalCount2,
            100, 4000, string.Empty);
        questDataList.Add(questData2);

        //헤네시스
        string[] questSctipt3 = new string[1]{
            "마을을 위협하는 몬스터가 있어서 주민들이 피해를 보고있어\n가서 스톤골렘을 20마리, 다크 스톤골렘 30마리만 잡아와줘"
        };
        int[] reqmonsterNum3 = new int[2] { 21,22 };
        int[] reqMonsterCount3 = new int[2] { 0,0 };
        int[] reqMonsterGoalCount3 = new int[2] { 20, 30 };
        QuestData questData3
            = new QuestData(3, -1, 50, 0, "골렘 사냥", "나는 헤네시스의 장로라네", questSctipt3, "마을이 위험해!", "이제 좀 괜찮아지겠군",
            reqmonsterNum3, reqMonsterCount3, reqMonsterGoalCount3,
            5000, 20000, string.Empty);
        questDataList.Add(questData3);

        string[] questSctipt4 = new string[1]{
            "버섯이 사악하게 변한 원인은 아마 머쉬맘에 있지않을까?\n 머쉬맘 1마리 퇴치 요구"
        };
        int[] reqmonsterNum4 = new int[1] { 25 };
        int[] reqMonsterCount4 = new int[1] { 0};
        int[] reqMonsterGoalCount4 = new int[1] { 1 };
        QuestData questData4
            = new QuestData(4, 3, 55, 0, "모든 버섯들의 어머니", "나는 헤네시스의 장로라네", questSctipt4, "머쉬맘을 잠재워야해!", "고맙네, 덕분에 버섯들의 횡포가 줄어들었어",
            reqmonsterNum4, reqMonsterCount4, reqMonsterGoalCount4,
            5000, 30000, "황갑충");
        questDataList.Add(questData4);

        //엘리니아
        string[] questSctipt5 = new string[1]{
            "초록버섯이 나무에 독을 퍼뜨린다는 소식이 있네\n초록버섯 20마리만 잡아와서 혼쭐을 내줘"
        };
        int[] reqmonsterNum5 = new int[1] { 7 };
        int[] reqMonsterCount5 = new int[1] { 0 };
        int[] reqMonsterGoalCount5 = new int[1] { 20 };
        QuestData questData5
            = new QuestData(5, -1, 14, 0, "독버섯?", "이곳은 마법사의 마을 엘리니아", questSctipt5, "허허", "수고했어 오늘도",
            reqmonsterNum5, reqMonsterCount5, reqMonsterGoalCount5,
            0, 3000, string.Empty);
        questDataList.Add(questData5);

        string[] questSctipt6 = new string[1]{
            "원숭이들이 계속 주민들을 괴롭혀\n루랑, 좀비루팡을 각각 30마리만 잡아와서 혼쭐을 내줘"
        };
        int[] reqmonsterNum6 = new int[2] { 16,18 };
        int[] reqMonsterCount6 = new int[2] { 0,0 };
        int[] reqMonsterGoalCount6 = new int[2] { 30,30 };
        QuestData questData6
            = new QuestData(6, 5, 33, 0, "원숭이 사냥", "이곳은 마법사의 마을 엘리니아", questSctipt6, "허허", "수고했어 오늘도 -옥상달빛-",
            reqmonsterNum6, reqMonsterCount6, reqMonsterGoalCount6,
            0, 5000, string.Empty);
        questDataList.Add(questData6);

        //페리온
        string[] questSctipt7 = new string[1]{
            "여곳 페리온에 서식하는 엑스텀프들의 MBTI를 알고싶어 30마리만 잡아줘"
        };
        int[] reqmonsterNum7 = new int[1] {8 };
        int[] reqMonsterCount7 = new int[1] { 0};
        int[] reqMonsterGoalCount7 = new int[1] { 30};
        QuestData questData7
            = new QuestData(7, -1, 30, 0, "MBTI조사", "검술보다는 MBTI", questSctipt7, "아직 멀었나?", "이들은 아마도 ENTJ일듯",
            reqmonsterNum7, reqMonsterCount7, reqMonsterGoalCount7,
            0, 13000, string.Empty);
        questDataList.Add(questData7);

        string[] questSctipt8 = new string[1]{
            "이곳 멧돼지들때문에 길에 먼지가 많이 날리고 있어\n 와일드보어, 파이어보어를 각각 25마리씩만 잡아줘"
        };
        int[] reqmonsterNum8 = new int[2] { 11,13 };
        int[] reqMonsterCount8 = new int[2] { 0,0 };
        int[] reqMonsterGoalCount8 = new int[2] { 25,25 };
        QuestData questData8
            = new QuestData(8, -1, 35, 0, "먼지가 되어", "먼지가~~~~ 되어~~~~~ ", questSctipt8, "날아가야!!지~~~", "피할 수~~ 없는~~",
            reqmonsterNum8, reqMonsterCount8, reqMonsterGoalCount8,
            0, 15000, string.Empty);
        questDataList.Add(questData8);

        //커닝시티
        string[] questSctipt9 = new string[1]{
            "악어가죽을 써서 명품백을 만들라는데 크로코가 방해하고 있어\n 크로코 40마리를 잡아줘"
        };
        int[] reqmonsterNum9 = new int[1] {20};
        int[] reqMonsterCount9 = new int[1] { 0 };
        int[] reqMonsterGoalCount9 = new int[1] { 40 };
        QuestData questData9
            = new QuestData(9, -1, 45, 0, "명품가방", "나는 MZ소녀", questSctipt9, "나만 명품백 없어 빨리좀 퇴치해줘", "인스타에 자랑해야지",
            reqmonsterNum9, reqMonsterCount9, reqMonsterGoalCount9,
            30000, 25000, string.Empty);
        questDataList.Add(questData9);

        string[] questSctipt10 = new string[1]{
            "이번에는 명품백에 보석 박을라고\n 와일드카고 50마리를 잡아줘"
        };
        int[] reqmonsterNum10 = new int[1] { 23 };
        int[] reqMonsterCount10 = new int[1] { 0 };
        int[] reqMonsterGoalCount10 = new int[1] { 50 };
        QuestData questData10
            = new QuestData(10, 9, 70, 0, "보석장식", "나는 MZ소녀", questSctipt10, "이거 비싸보여야 가오가 살아", "인스타에 또 자랑해야지",
            reqmonsterNum10, reqMonsterCount10, reqMonsterGoalCount10,
            50000, 50000, "캐스터스");
        questDataList.Add(questData10);
    }
}
