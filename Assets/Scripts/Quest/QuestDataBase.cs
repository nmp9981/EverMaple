using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 퀘스트 데아터
/// </summary>
public class QuestData
{
    public int questNum;//퀘스트 번호
    public int prevQuestNum;//선행 퀘스트 번호
    public int reqLv;//요구 레벨
    public int questState = 0;//퀘 상태, 1:시작, 2:진행중, 3:완료, 4:클리어

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

    public QuestData(int questNum, int prevQuestNum, int reqLv, int questState, string startScript, string[] questSctipt, string notFinishScript, string finishScript, int[] reqmonsterNum, int[] reqMonsterCount, int[] reqMonsterGoalCount, int rewardExp, int rewardMeso, string rewardItem)
    {
        this.questNum = questNum;
        this.prevQuestNum = prevQuestNum;
        this.reqLv = reqLv;
        this.questState = questState;
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
    public static QuestDataBase questInstance;//싱글톤

    public List<QuestData> questDataList = new List<QuestData>();

    private void Start()
    {
        EnrollQuestData();
    }

    /// <summary>
    /// 퀘스트 데이터
    /// </summary>
    void EnrollQuestData()
    {
        string[] questSctipt0 = new string[2]{
            "내가 수련을 도와주지!",
            "파란 달팽이 5마리를 잡아와"
        };
        int[] reqmonsterNum0 = new int[1]{ 0};
        int[] reqMonsterCount0 = new int[1] {0 };
        int[] reqMonsterGoalCount0 = new int[1] { 5 };
        QuestData questData0
            = new QuestData(0,-1,1,0,"1더하기1은 창문",questSctipt0,"좀만 힘내","잘했다. 다음 수련으로 가즈아",
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
            = new QuestData(1, 0, 2, 0, "1더하기1은 창문", questSctipt1, "좀만 힘내", "잘했다. 한번만더 가즈아",
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
            = new QuestData(2, 1, 3, 0, "1더하기1은 창문", questSctipt2, "좀만 힘내", "잘했다. 초반에 폐사하면 안되니까 훈지좀 해줄게",
            reqmonsterNum2, reqMonsterCount2, reqMonsterGoalCount2,
            100, 4000, string.Empty);
        questDataList.Add(questData2);
    }
}
