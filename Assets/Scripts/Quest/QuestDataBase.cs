using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����Ʈ ������
/// </summary>
public class QuestData
{
    public int questNum;//����Ʈ ��ȣ
    public int prevQuestNum;//���� ����Ʈ ��ȣ
    public int reqLv;//�䱸 ����
    public int questState = 0;//�� ����, 1:����, 2:������, 3:�Ϸ�, 4:Ŭ����

    //��ũ��Ʈ ����
    public string startScript;//���� ��ũ��Ʈ
    public string[] questSctipt;//����Ʈ ��ũ��Ʈ
    public string notFinishScript;//�� �̿Ϸ� ��ũ��Ʈ
    public string finishScript;//�� �Ϸ� ��ũ��Ʈ

    //�䱸����
    public int[] reqmonsterNum;//���� ��ȣ
    public int[] reqMonsterCount;//���� ī��Ʈ
    public int[] reqMonsterGoalCount;//���� ��ǥ ī��Ʈ

    //����
    public int rewardExp;//���� ����ġ
    public int rewardMeso;//���� �޼�
    public string rewardItem;//���� ������

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
    public static QuestDataBase questInstance;//�̱���

    public List<QuestData> questDataList = new List<QuestData>();

    private void Start()
    {
        EnrollQuestData();
    }

    /// <summary>
    /// ����Ʈ ������
    /// </summary>
    void EnrollQuestData()
    {
        string[] questSctipt0 = new string[2]{
            "���� ������ ��������!",
            "�Ķ� ������ 5������ ��ƿ�"
        };
        int[] reqmonsterNum0 = new int[1]{ 0};
        int[] reqMonsterCount0 = new int[1] {0 };
        int[] reqMonsterGoalCount0 = new int[1] { 5 };
        QuestData questData0
            = new QuestData(0,-1,1,0,"1���ϱ�1�� â��",questSctipt0,"���� ����","���ߴ�. ���� �������� �����",
            reqmonsterNum0,reqMonsterCount0, reqMonsterGoalCount0,
            30, 1500,string.Empty);
        questDataList.Add(questData0);

        string[] questSctipt1 = new string[1]{
            "�̹����� ���� ������ 10���� ��ƿ�"
        };
        int[] reqmonsterNum1 = new int[1] { 1 };
        int[] reqMonsterCount1 = new int[1] { 0 };
        int[] reqMonsterGoalCount1 = new int[1] { 10 };
        QuestData questData1
            = new QuestData(1, 0, 2, 0, "1���ϱ�1�� â��", questSctipt1, "���� ����", "���ߴ�. �ѹ����� �����",
            reqmonsterNum1, reqMonsterCount1, reqMonsterGoalCount1,
            50, 2500, string.Empty);
        questDataList.Add(questData1);

        string[] questSctipt2 = new string[1]{
            "�̹����� ������ 10����, ��Ȳ���� 15������ ��ƿ�"
        };
        int[] reqmonsterNum2 = new int[2] { 3,4 };
        int[] reqMonsterCount2 = new int[2] { 0,0 };
        int[] reqMonsterGoalCount2 = new int[2] { 10,15 };
        QuestData questData2
            = new QuestData(2, 1, 3, 0, "1���ϱ�1�� â��", questSctipt2, "���� ����", "���ߴ�. �ʹݿ� ����ϸ� �ȵǴϱ� ������ ���ٰ�",
            reqmonsterNum2, reqMonsterCount2, reqMonsterGoalCount2,
            100, 4000, string.Empty);
        questDataList.Add(questData2);
    }
}
