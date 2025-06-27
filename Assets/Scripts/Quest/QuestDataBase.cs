using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����Ʈ ������
/// </summary>
public class QuestData
{
    //����Ʈ �⺻ ����
    public int questNum;//����Ʈ ��ȣ
    public int prevQuestNum;//���� ����Ʈ ��ȣ
    public int reqLv;//�䱸 ����
    public int questState = 0;//�� ����, 1:����, 2:������, 3:�Ϸ�, 4:Ŭ����
    public string questTitle;//����Ʈ ����

    //��ũ��Ʈ ����
    public string startScript;//���� ��ũ��Ʈ
    public string[] questSctipt;//����Ʈ ��ũ��Ʈ
    public string notFinishScript;//�� �̿Ϸ� ��ũ��Ʈ
    public string finishScript;//�� �Ϸ� ��ũ��Ʈ

    //�䱸����
    public int[] reqmonsterNum;//���� ��ȣ
    public string[] reqMonsterName;//���� �̸�
    public int[] reqMonsterCount;//���� ī��Ʈ
    public int[] reqMonsterGoalCount;//���� ��ǥ ī��Ʈ

    //����
    public int rewardExp;//���� ����ġ
    public int rewardMeso;//���� �޼�
    public string rewardItem;//���� ������

    //������
    public QuestData(int questNum, int prevQuestNum, int reqLv, int questState, string questTitle,string startScript, string[] questSctipt, string notFinishScript, string finishScript, int[] reqmonsterNum,string[] reqMonsterName, int[] reqMonsterCount, int[] reqMonsterGoalCount, int rewardExp, int rewardMeso, string rewardItem)
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
        this.reqMonsterName = reqMonsterName;
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
    /// ����Ʈ ������
    /// </summary>
    void EnrollQuestData()
    {
        //�����ױ�
        string[] questSctipt0 = new string[1]{
            "���� ������ ��������!\n�Ķ� ������ 5������ ��ƿ�",
        };
        int[] reqmonsterNum0 = new int[1]{ 0};
        string[] reqMonsterName0 = new string[1] { "�Ķ� ������"};
        int[] reqMonsterCount0 = new int[1] {0 };
        int[] reqMonsterGoalCount0 = new int[1] { 5 };
        QuestData questData0
            = new QuestData(0,-1,1,1,"���� ���� I","1���ϱ�1�� â��",questSctipt0,"���� ����","���ߴ�. ���� �������� �����",
            reqmonsterNum0, reqMonsterName0, reqMonsterCount0, reqMonsterGoalCount0,
            30, 1500,string.Empty);
        questDataList.Add(questData0);

        string[] questSctipt1 = new string[1]{
            "�̹����� ���� ������ 10���� ��ƿ�"
        };
        int[] reqmonsterNum1 = new int[1] { 1 };
        string[] reqMonsterName1 = new string[1] { "���� ������" };
        int[] reqMonsterCount1 = new int[1] { 0 };
        int[] reqMonsterGoalCount1 = new int[1] { 10 };
        QuestData questData1
            = new QuestData(1, 0, 4, 0,"���� ���� II", "1���ϱ�1�� â��", questSctipt1, "���� ����", "���ߴ�. �ѹ����� �����",
            reqmonsterNum1, reqMonsterName1,reqMonsterCount1, reqMonsterGoalCount1,
            100, 2500, string.Empty);
        questDataList.Add(questData1);

        string[] questSctipt2 = new string[1]{
            "�̹����� ������ 10����, ��Ȳ���� 15������ ��ƿ�"
        };
        int[] reqmonsterNum2 = new int[2] { 3,4 };
        string[] reqMonsterName2 = new string[2] { "������","��Ȳ����" };
        int[] reqMonsterCount2 = new int[2] { 0,0 };
        int[] reqMonsterGoalCount2 = new int[2] { 10,15 };
        QuestData questData2
            = new QuestData(2, 1, 8, 0, "���� ���� III","1���ϱ�1�� â��", questSctipt2, "���� ����", "���ߴ�. �ʹݿ� ����ϸ� �ȵǴϱ� ������ ���ٰ�",
            reqmonsterNum2,reqMonsterName2, reqMonsterCount2, reqMonsterGoalCount2,
            450, 4000, string.Empty);
        questDataList.Add(questData2);

        //��׽ý�
        string[] questSctipt3 = new string[1]{
            "������ �����ϴ� ���Ͱ� �־ �ֹε��� ���ظ� �����־�\n���� ������� 20����, ��ũ ����� 30������ ��ƿ���"
        };
        int[] reqmonsterNum3 = new int[2] { 21,22 };
        string[] reqMonsterName3 = new string[2] { "�����"," ��ũ �����" };
        int[] reqMonsterCount3 = new int[2] { 0,0 };
        int[] reqMonsterGoalCount3 = new int[2] { 20, 30 };
        QuestData questData3
            = new QuestData(3, -1, 55, 0, "�� ���", "���� ��׽ý��� ��ζ��", questSctipt3, "������ ������!", "���� �� ���������ڱ�",
            reqmonsterNum3, reqMonsterName3 ,reqMonsterCount3, reqMonsterGoalCount3,
            30000, 30000, string.Empty);
        questDataList.Add(questData3);

        string[] questSctipt4 = new string[1]{
            "������ ����ϰ� ���� ������ �Ƹ� �ӽ����� ����������?\n �ӽ��� 1���� ��ġ �䱸"
        };
        int[] reqmonsterNum4 = new int[1] { 25 };
        string[] reqMonsterName4 = new string[1] { "�ӽ���" };
        int[] reqMonsterCount4 = new int[1] { 0};
        int[] reqMonsterGoalCount4 = new int[1] { 1 };
        QuestData questData4
            = new QuestData(4, 3, 60, 0, "��� �������� ��Ӵ�", "���� ��׽ý��� ��ζ��", questSctipt4, "�ӽ����� ���������!", "����, ���п� �������� Ⱦ���� �پ�����",
            reqmonsterNum4, reqMonsterName4,reqMonsterCount4, reqMonsterGoalCount4,
            5000, 50000, "Ȳ����");
        questDataList.Add(questData4);

        //�����Ͼ�
        string[] questSctipt5 = new string[1]{
            "�ʷϹ����� ������ ���� �۶߸��ٴ� �ҽ��� �ֳ�\n�ʷϹ��� 20������ ��ƿͼ� ȥ���� ����"
        };
        int[] reqmonsterNum5 = new int[1] { 7 };
        string[] reqMonsterName5 = new string[1] { "�ʷϹ���" };
        int[] reqMonsterCount5 = new int[1] { 0 };
        int[] reqMonsterGoalCount5 = new int[1] { 20 };
        QuestData questData5
            = new QuestData(5, -1, 14, 0, "������?", "�̰��� �������� ���� �����Ͼ�", questSctipt5, "����", "�����߾� ���õ�",
            reqmonsterNum5, reqMonsterName5 ,reqMonsterCount5, reqMonsterGoalCount5,
            1800, 3000, string.Empty);
        questDataList.Add(questData5);

        string[] questSctipt6 = new string[1]{
            "�����̵��� �ҷ� �ϰŷ��� �ϰ� �־ �޼� ��ġ�� �������� �־�\n����, ��������� ���� 30������ ��ƿͼ� ȥ���� ����"
        };
        int[] reqmonsterNum6 = new int[2] { 16,18 };
        string[] reqMonsterName6 = new string[2] { "����","�������" };
        int[] reqMonsterCount6 = new int[2] { 0,0 };
        int[] reqMonsterGoalCount6 = new int[2] { 30,30 };
        QuestData questData6
            = new QuestData(6, 5, 35, 0, "�Ҽ��� ���", "�̰��� �������� ���� �����Ͼ�", questSctipt6, "����", "�����߾� ���õ� -����޺�-",
            reqmonsterNum6, reqMonsterName6,reqMonsterCount6, reqMonsterGoalCount6,
            0, 12000, string.Empty);
        questDataList.Add(questData6);

        //�丮��
        string[] questSctipt7 = new string[1]{
            "���� �丮�¿� �����ϴ� ������������ MBTI�� �˰�;� 30������ �����"
        };
        int[] reqmonsterNum7 = new int[1] {8 };
        string[] reqMonsterName7 = new string[1] { "��������" };
        int[] reqMonsterCount7 = new int[1] { 0};
        int[] reqMonsterGoalCount7 = new int[1] { 30};
        QuestData questData7
            = new QuestData(7, -1, 21, 0, "MBTI����", "�˼����ٴ� MBTI", questSctipt7, "���� �־���?", "�̵��� �Ƹ��� ENTJ�ϵ�",
            reqmonsterNum7,reqMonsterName7, reqMonsterCount7, reqMonsterGoalCount7,
            5000, 13000, string.Empty);
        questDataList.Add(questData7);

        string[] questSctipt8 = new string[1]{
            "�̰� ������鶧���� �濡 ������ ���� ������ �־�\n ���ϵ庸��, ���̾� ���� 25�������� �����"
        };
        int[] reqmonsterNum8 = new int[2] { 11,13 };
        string[] reqMonsterName8 = new string[2] { "���ϵ庸��","���̾��" };
        int[] reqMonsterCount8 = new int[2] { 0,0 };
        int[] reqMonsterGoalCount8 = new int[2] { 25,25 };
        QuestData questData8
            = new QuestData(8, -1, 30, 0, "������ �Ǿ�", "������~~~~ �Ǿ�~~~~~ ", questSctipt8, "���ư���!!��~~~", "���� ��~~ ����~~",
            reqmonsterNum8, reqMonsterName8,reqMonsterCount8, reqMonsterGoalCount8,
            0, 10000, string.Empty);
        questDataList.Add(questData8);

        //Ŀ�׽�Ƽ
        string[] questSctipt9 = new string[1]{
            "�Ǿ���� �Ἥ ��ǰ���� �����µ� ũ���ڰ� �����ϰ� �־�\n ũ���� 40������ �����"
        };
        int[] reqmonsterNum9 = new int[1] {20};
        string[] reqMonsterName9 = new string[1] { "ũ����" };
        int[] reqMonsterCount9 = new int[1] { 0 };
        int[] reqMonsterGoalCount9 = new int[1] { 40 };
        QuestData questData9
            = new QuestData(9, -1, 50, 0, "��� ��ǰ ����", "���� MZ�ҳ�", questSctipt9, "���� ��ǰ�� ���� ������ ��ġ����", "�ν�Ÿ�� �ڶ��ؾ���",
            reqmonsterNum9,reqMonsterName9, reqMonsterCount9, reqMonsterGoalCount9,
            30000, 20000, string.Empty);
        questDataList.Add(questData9);

        string[] questSctipt10 = new string[1]{
            "�̹����� ��ǰ�鿡 ���� �������\n ���ϵ�ī�� 50������ �����"
        };
        int[] reqmonsterNum10 = new int[1] { 23 };
        string[] reqMonsterName10 = new string[1] { "���ϵ�ī��" };
        int[] reqMonsterCount10 = new int[1] { 0 };
        int[] reqMonsterGoalCount10 = new int[1] { 50 };
        QuestData questData10
            = new QuestData(10, 9, 70, 0, "���� ���", "���� MZ�ҳ�", questSctipt10, "�̰� ��κ����� ������ ���", "�ν�Ÿ�� �� �ڶ��ؾ���",
            reqmonsterNum10, reqMonsterName10,reqMonsterCount10, reqMonsterGoalCount10,
            70000, 50000, "ĳ���ͽ�");
        questDataList.Add(questData10);
    }
}
