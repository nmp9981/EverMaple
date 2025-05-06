using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// ������ �Ӽ�
/// </summary>
public enum ItemAttribute{
    Equipment,
    consume,
    Count
}

/// <summary>
/// �Һ� ������ �Ӽ�
/// </summary>
public enum ConsumeAttribute
{
    HPPosion,
    MPPosion,
    BuffPosion,
    Etc,
    Count
}

/// <summary>
/// �Һ� ������ �Ӽ�
/// </summary>
public struct ConsumeItem
{
    public Sprite sprite;//�̹���
    public string name;//�̸�
    public int count;//����Ҵ���
}

public class ItemManager : MonoBehaviour
{
    public static ItemManager itemInstance;

    [SerializeField]
    UIMouseClick uiMouseClick;

    [SerializeField]
    PlayerInfoUI playerInfoUI;
    [SerializeField]
    ItemUI itemUI;

    private void Awake()
    {
        ItemSingletonObjectLoad();
    }

    void ItemSingletonObjectLoad()
    {
        if (itemInstance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            itemInstance = this; //���ڽ��� instance�� �־��ݴϴ�.
            DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
        }
        else
        {
            if (itemInstance != this) //instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ�
                Destroy(this.gameObject); //�� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ����
        }
    }
    /// <summary>
    /// �ʵ忡 �ִ� �����۵� �ı�
    /// </summary>
    public void ClearItemInFeild()
    {
        foreach(var item in fieldDropItems)
        {
            Destroy(item.gameObject);
        }
        fieldDropItems.Clear();
    }

    public void GetConsumeItem()
    {

    }

    /// <summary>
    /// HP���� ���, AŰ ����
    /// </summary>
    public void EnrollHPPosion(string itemName)
    {
        Sprite posionSprite = null;
        string posionCountText = string.Empty;
        switch (itemName)
        {
            case "��������":
                //�̹���, ���� ���� ǥ��
                UseHPPosionIndex = 0;
                posionSprite = consumeItems[UseHPPosionIndex].sprite;
                posionCountText = consumeItems[UseHPPosionIndex].count.ToString();
                HealHPAmount = 50;
                break;
            case "��Ȳ����":
                //�̹���, ���� ���� ǥ��
                UseHPPosionIndex = 1;
                posionSprite = consumeItems[UseHPPosionIndex].sprite;
                posionCountText = consumeItems[UseHPPosionIndex].count.ToString();
                HealHPAmount = 150;
                break;
            case "�Ͼ�����":
                //�̹���, ���� ���� ǥ��
                UseHPPosionIndex = 2;
                posionSprite = consumeItems[UseHPPosionIndex].sprite;
                posionCountText = consumeItems[UseHPPosionIndex].count.ToString();
                HealHPAmount = 300;
                break;
            case "����":
                //�̹���, ���� ���� ǥ��
                UseHPPosionIndex = 5;
                posionSprite = consumeItems[UseHPPosionIndex].sprite;
                posionCountText = consumeItems[UseHPPosionIndex].count.ToString();
                HealHPAmount = 1000;
                break;
            case "���޹�":
                //�̹���, ���� ���� ǥ��
                UseHPPosionIndex = 7;
                posionSprite = consumeItems[UseHPPosionIndex].sprite;
                posionCountText = consumeItems[UseHPPosionIndex].count.ToString();
                HealHPAmount = 2000;
                break;
            default:
                break;
        }

        //HP������ �ƴ�
        if (posionSprite == null)
            return;

        //AŰ�� ���
        keySlotImage[0].transform.GetChild(0).GetComponent<Image>().sprite = posionSprite;
        keySlotImage[0].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = posionCountText;
    }
    /// <summary>
    /// MP���� ���, DŰ ����
    /// </summary>
    public void EnrollMPPosion(string itemName)
    {
        Sprite posionSprite = null;
        string posionCountText = string.Empty;
        switch (itemName)
        {
            case "�Ķ�����":
                //�̹���, ���� ���� ǥ��
                UseMPPosionIndex = 3;
                posionSprite = consumeItems[UseMPPosionIndex].sprite;
                posionCountText = consumeItems[UseMPPosionIndex].count.ToString();
                HealMPAmount = 100;
                break;
            case "����������":
                //�̹���, ���� ���� ǥ��
                UseMPPosionIndex = 4;
                posionSprite = consumeItems[UseMPPosionIndex].sprite;
                posionCountText = consumeItems[UseMPPosionIndex].count.ToString();
                HealMPAmount = 300;
                break;
            case "������":
                //�̹���, ���� ���� ǥ��
                UseMPPosionIndex = 6;
                posionSprite = consumeItems[UseMPPosionIndex].sprite;
                posionCountText = consumeItems[UseMPPosionIndex].count.ToString();
                HealMPAmount = 800;
                break;
            case "�Ϻ���":
                //�̹���, ���� ���� ǥ��
                UseMPPosionIndex = 8;
                posionSprite = consumeItems[UseMPPosionIndex].sprite;
                posionCountText = consumeItems[UseMPPosionIndex].count.ToString();
                HealMPAmount = 2000;
                break;
            default:
                break;
        }

        //MP������ �ƴ�
        if (posionSprite == null)
            return;

        //DŰ�� ���
        keySlotImage[1].transform.GetChild(0).GetComponent<Image>().sprite = posionSprite;
        keySlotImage[1].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = posionCountText;
    }
    /// <summary>
    /// ������ ���
    /// TODO : ������ ��� ���� �� �ۼ�
    /// </summary>
    public void EnrollElixerPosion(string itemName)
    {
        return;

        Sprite posionSprite = null;
        string posionCountText = string.Empty;
        switch (itemName)
        {
            case "������":
                //�̹���, ���� ���� ǥ��
                posionSprite = consumeItems[0].sprite;
                posionCountText = consumeItems[0].count.ToString();
                break;
            case "�Ŀ�������":
                //�̹���, ���� ���� ǥ��
                posionSprite = consumeItems[1].sprite;
                posionCountText = consumeItems[1].count.ToString();
                break;         
            default:
                break;
        }

        //�������� �ƴ�
        if (posionSprite == null)
            return;

        //FŰ�� ���
        keySlotImage[2].transform.GetChild(0).GetComponent<Image>().sprite = posionSprite;
        keySlotImage[2].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = posionCountText;
    }
    /// <summary>
    /// ���� ���
    /// </summary>
    public void EnrollBuffPosion(string itemName, string inputKey)
    {
        Sprite posionSprite = null;
        string posionCountText = string.Empty;
        switch (itemName)
        {
            case "���繰��":
                UseBuffPosionIndex = 9;
                break;
            case "���繰��":
                UseBuffPosionIndex = 10;
                break;
            case "��������":
                UseBuffPosionIndex = 11;
                break;
            case "��ø����":
                UseBuffPosionIndex = 12;
                break;
            case "�̼ӹ���":
                UseBuffPosionIndex = 13;
                break;
            default:
                break;
        }
        //�̹���, ���� ���� ǥ��
        if(UseBuffPosionIndex >=9 && UseBuffPosionIndex <= 13)
        {
            posionSprite = consumeItems[UseBuffPosionIndex].sprite;
            posionCountText = consumeItems[UseBuffPosionIndex].count.ToString();
        }
        
        //MP������ �ƴ�
        if (posionSprite == null)
            return;

        //Ű ���(����Ű �߿� �Է� ����)
        int outNum = int.TryParse(inputKey, out outNum)?outNum+7 :-1;
        if (outNum == -1)//����Ű�� �ƴ�
            return;

        keySlotImage[outNum].transform.GetChild(0).GetComponent<Image>().sprite = posionSprite;
        keySlotImage[outNum].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = posionCountText;

        //��ϵ� Ű�� �̹� �ִ��� �˻�
        if (keySlotBuffItems.ContainsKey(outNum))
            keySlotBuffItems[outNum] = UseBuffPosionIndex;
        else//�Է�Ű, ���� ������ �ε���
            keySlotBuffItems.Add(outNum,UseBuffPosionIndex);
    }

    /// <summary>
    /// ������ ���
    /// TODO : ���� ��ȯ ����� ���� ���� ���� �ڿ� ����
    /// </summary>
    public void UseConsumeItem()
    {
        GameObject clickObj = uiMouseClick.clickedConsumeObject;
        string objName = clickObj.GetComponent<Image>().sprite.name;

        switch (objName)
        {
            case "��������":
                UseHPPosion(0,50,false);
                break;
            case "��Ȳ����":
                UseHPPosion(1, 150, false);
                break;
            case "�Ͼ�����":
                UseHPPosion(2, 300, false);
                break;
            case "����":
                UseHPPosion(5, 1000, false);
                break;
            case "���޹�":
                UseHPPosion(7, 2000, false);
                break;
            case "�Ķ�����":
                UseMPPosion(3, 100, false);
                break;
            case "����������":
                UseMPPosion(4, 300, false);
                break;
            case "������":
                UseMPPosion(6, 800, false);
                break;
            case "�Ϻ���":
                UseMPPosion(8, 2000, false);
                break;
            case "���繰��":
                UseBuffPosion(9, false);
                break;
            case "���繰��":
                UseBuffPosion(10, false);
                break;
            case "��������":
                UseBuffPosion(11, false);
                break;
            case "��ø����":
                UseBuffPosion(12, false);
                break;
            case "�̼ӹ���":
                UseBuffPosion(13, false);
                break;
            case "������ȯ�ֹ���":
                UseMoveVillagePosion();
                break;
            default:
                break;
        }
    }

    public void UseHPPosion(int itemIndex, int hpAmount, bool inputKey)
    {
        //���� �̵��
        if (!consumeItems.ContainsKey(itemIndex))
            return;

        ConsumeItem consumeItem = consumeItems[itemIndex];
        //������ ����
        if (consumeItem.count < 1)
            return;

        //Ű�Է��� ���� ȸ��
        if (inputKey)
            hpAmount = HealHPAmount;

        //���� �ϳ� ���
        consumeItem.count -= 1;
        consumeItems[itemIndex] = consumeItem;
        keySlotImage[0].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = consumeItem.count.ToString();

        //ȸ��
        PlayerManager.PlayerInstance.PlayerCurHP 
            = Mathf.Min(PlayerManager.PlayerInstance.PlayerMaxHP, PlayerManager.PlayerInstance.PlayerCurHP + hpAmount);

        //UI�ݿ�
        playerInfoUI.ShowPlayerHPBar();
        itemUI.ShowConsumeInItemInventory();

    }
    public void UseMPPosion(int itemIndex, int mpAmount, bool inputKey)
    {
        //���� �̵��
        if (!consumeItems.ContainsKey(itemIndex))
            return;

        ConsumeItem consumeItem = consumeItems[itemIndex];
        //������ ����
        if (consumeItem.count < 1)
            return;

        //Ű�Է��� ���� ȸ��
        if (inputKey)
            mpAmount = HealMPAmount;

        //���� �ϳ� ���
        consumeItem.count -= 1;
        consumeItems[itemIndex] = consumeItem;
        keySlotImage[1].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = consumeItem.count.ToString();

        //ȸ��
        PlayerManager.PlayerInstance.PlayerCurMP
            = Mathf.Min(PlayerManager.PlayerInstance.PlayerMaxMP, PlayerManager.PlayerInstance.PlayerCurMP + mpAmount);

        //UI�ݿ�
        playerInfoUI.ShowPlayerMPBar();
        itemUI.ShowConsumeInItemInventory();
    }

    public void UseBuffPosion(int itemIndex, bool inputKey)
    {
        //���� �̵��
        if (!consumeItems.ContainsKey(itemIndex))
            return;

        ConsumeItem consumeItem = consumeItems[itemIndex];
        //������ ����
        if (consumeItem.count < 1)
            return;

        //���� �ϳ� ���
        consumeItem.count -= 1;
        consumeItems[itemIndex] = consumeItem;

        //�ʿ��Ѱ� : �Ű �Է��ߴ��� ����
        foreach(var item in keySlotImage)
        {
            string useItemName = item.transform.GetChild(0).GetComponent<Image>().sprite.name;
            if (consumeItems[itemIndex].name == useItemName)
                item.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = consumeItem.count.ToString();
        }

        //���� ȿ��
        EffectBuffPosion(itemIndex);
        //UI�ݿ�
        itemUI.ShowConsumeInItemInventory();
    }
    public void UseBuffItem(int inputKey)
    {
        int itemIndex = keySlotBuffItems[inputKey];
        //���� �̵��
        if (!consumeItems.ContainsKey(itemIndex))
            return;

        ConsumeItem consumeItem = consumeItems[itemIndex];
        //������ ����
        if (consumeItem.count < 1)
            return;

        //���� �ϳ� ���
        consumeItem.count -= 1;
        consumeItems[itemIndex] = consumeItem;

        //���� ȿ��
        EffectBuffPosion(itemIndex);
        //UI�ݿ�
        itemUI.ShowConsumeInItemInventory();
    }
    /// <summary>
    /// ���� ���� ȿ��
    /// </summary>
    void EffectBuffPosion(int itemIdx)
    {

    }

    public void UseMoveVillagePosion()
    {

    }

    #region ������ ������
    public const string consumeTag = "ConsumeItem";

    //�ʵ忡 ������ �����۵�
    public List<GameObject> fieldDropItems = new List<GameObject>();

    //���, �Һ� ������ ��ϵ�
    public List<GameObject> equipmentItems = new List<GameObject>();
    public Dictionary<int, ConsumeItem> consumeItems = new Dictionary<int, ConsumeItem>();
    public List<Sprite> consumeItemImage = new List<Sprite>();

    //Ű���� �� ���ε�
    public List<GameObject> keySlotImage = new List<GameObject>();
    //���� ������ (�Է� Ű, ������ �ε���)
    public Dictionary<int,int> keySlotBuffItems = new Dictionary<int,int>();

    //ȸ��
    private int useHPPosionIndex = -1;
    private int useMPPosionIndex = -1;
    private int useBuffPosionIndex = -1;
    private int healHPAmount = 0;
    private int healMPAmount = 0;
    public int UseHPPosionIndex { get { return useHPPosionIndex; } set { useHPPosionIndex = value; } }
    public int UseMPPosionIndex { get { return useMPPosionIndex; } set { useMPPosionIndex = value; } }
    public int UseBuffPosionIndex { get { return useBuffPosionIndex; } set { useBuffPosionIndex = value; } }
    public int HealHPAmount { get { return healHPAmount; } set { healHPAmount = value; } }
    public int HealMPAmount { get { return healMPAmount; } set { healMPAmount = value; } }
    #endregion
}
