using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
/// �������� �Ӽ�
/// </summary>
public enum EquipmentAttribute
{
    Weapon_Knife,
    Weapon_Clow,
    Armor_Hat,
    Armor_Top,
    Armor_Bottom,
    Armor_Shoes,
    Armor_Glove,
    Armor_Earing
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

public struct EquipmentItem
{
    public Sprite sprite;//�̹���
    public string name;//�̸�
}

public class ItemManager : MonoBehaviour
{
    public static ItemManager itemInstance;
    public MoveVillage moveVillage = new MoveVillage();

    //�÷��̾ ���� ������ �ִ� ���
    public List<EquipmentItem> playerHaveEquipments = new List<EquipmentItem>();


    [SerializeField]
    UIMouseClick uiMouseClick;

    [SerializeField]
    PlayerInfoUI playerInfoUI;
    [SerializeField]
    ItemUI itemUI;

    private void Awake()
    {
        ItemSingletonObjectLoad();
        BuffItrmBinding();
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
    /// ���� ������ ���ε�
    /// </summary>
    void BuffItrmBinding()
    {
        GameObject buffUI = GameObject.Find("BuffUI");
        int buffID = 0;
        foreach(Transform tr in buffUI.GetComponentInChildren<Transform>(true))
        { 
            buffItemList.Add(tr.gameObject);
            tr.gameObject.GetComponent<ItemBuff>().buffIdx = buffID;
            buffID += 1;
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
    /// </summary>
    public void EnrollElixerPosion(string itemName)
    {
        Sprite posionSprite = null;
        string posionCountText = string.Empty;
        switch (itemName)
        {
            case "������":
                //�̹���, ���� ���� ǥ��
                UseElixerPosionIndex = 19;
                posionSprite = consumeItems[UseElixerPosionIndex].sprite;
                posionCountText = consumeItems[UseElixerPosionIndex].count.ToString();
                break;
            case "�Ŀ�������":
                //�̹���, ���� ���� ǥ��
                UseElixerPosionIndex = 20;
                posionSprite = consumeItems[UseElixerPosionIndex].sprite;
                posionCountText = consumeItems[UseElixerPosionIndex].count.ToString();
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
            case "���ڹ���":
                UseBuffPosionIndex = 15;
                break;
            case "��񳪹�����":
                UseBuffPosionIndex = 16;
                break;
            case "�巹��ũ��":
                UseBuffPosionIndex = 17;
                break;
            case "�巹��ũ�ǰ��":
                UseBuffPosionIndex = 18;
                break;
            default:
                break;
        }
        //�̹���, ���� ���� ǥ��
        if(UseBuffPosionIndex >=9 && UseBuffPosionIndex <= 18)
        {
            if (UseBuffPosionIndex != 14)
            {
                posionSprite = consumeItems[UseBuffPosionIndex].sprite;
                posionCountText = consumeItems[UseBuffPosionIndex].count.ToString();
            }
        }
        
        //���� ������ �ƴ�
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
            case "���ڹ���":
                UseBuffPosion(15, false);
                break;
            case "��񳪹�����":
                UseBuffPosion(16, false);
                break;
            case "�巹��ũ��":
                UseBuffPosion(17, false);
                break;
            case "�巹��ũ�ǰ��":
                UseBuffPosion(18, false);
                break;
            case "������":
                UseElixerPosion(19);
                break;
            case "�Ŀ�������":
                UseElixerPosion(20);
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

    /// <summary>
    /// ������ ���
    /// </summary>
    public void UseElixerPosion(int itemIndex)
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
        keySlotImage[1].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = consumeItem.count.ToString();

        int hpAmount = (itemIndex==19)? PlayerManager.PlayerInstance.PlayerMaxHP/2:PlayerManager.PlayerInstance.PlayerMaxHP;
        int mpAmount = (itemIndex == 19) ? PlayerManager.PlayerInstance.PlayerMaxMP / 2 : PlayerManager.PlayerInstance.PlayerMaxMP;

        //ȸ��
        PlayerManager.PlayerInstance.PlayerCurHP
           = Mathf.Min(PlayerManager.PlayerInstance.PlayerMaxHP, PlayerManager.PlayerInstance.PlayerCurHP + hpAmount);
        PlayerManager.PlayerInstance.PlayerCurMP
            = Mathf.Min(PlayerManager.PlayerInstance.PlayerMaxMP, PlayerManager.PlayerInstance.PlayerCurMP + mpAmount);

        //UI�ݿ�
        playerInfoUI.ShowPlayerHPBar();
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
    /// <summary>
    /// ���� ������ ���
    /// </summary>
    /// <param name="inputKey"></param>
    public void UseBuffItem(int inputKey)
    {
        //���� ������ �ε���
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
        keySlotImage[inputKey].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = consumeItem.count.ToString();

        //���� ȿ��
        EffectBuffPosion(itemIndex);
        //UI�ݿ�
        itemUI.ShowConsumeInItemInventory();
    }
    /// <summary>
    /// ���� Ȱ��ȭ
    /// �̹� �����ִ� ���¸� ���� �����
    /// </summary>
    void EffectBuffPosion(int itemIdx)
    {
        switch (itemIdx)
        {
            case 9:
                if(buffItemList[0].activeSelf)
                    buffItemList[0].SetActive(false);
                buffItemList[0].SetActive(true);
                break;
            case 10:
                if (buffItemList[1].activeSelf)
                    buffItemList[1].SetActive(false);
                buffItemList[1].SetActive(true);
                break;
            case 11:
                if (buffItemList[2].activeSelf)
                    buffItemList[2].SetActive(false);
                buffItemList[2].SetActive(true);
                break;
            case 12:
                if (buffItemList[3].activeSelf)
                    buffItemList[3].SetActive(false);
                buffItemList[3].SetActive(true);
                break;
            case 13:
                if (buffItemList[4].activeSelf)
                    buffItemList[4].SetActive(false);
                buffItemList[4].SetActive(true);
                break;
            case 15:
                if (buffItemList[5].activeSelf)
                    buffItemList[5].SetActive(false);
                buffItemList[5].SetActive(true);
                break;
            case 16:
                if (buffItemList[6].activeSelf)
                    buffItemList[6].SetActive(false);
                buffItemList[6].SetActive(true);
                break;
            case 17:
                if (buffItemList[7].activeSelf)
                    buffItemList[7].SetActive(false);
                buffItemList[7].SetActive(true);
                break;
            case 18:
                if (buffItemList[8].activeSelf)
                    buffItemList[8].SetActive(false);
                buffItemList[8].SetActive(true);
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// ���� ��ȯ �ֹ���
    /// </summary>
    public void UseMoveVillagePosion()
    {
        //�ֹ��� �̵��
        if (!consumeItems.ContainsKey(14))
            return;

        ConsumeItem consumeItem = consumeItems[14];
        //�ֹ����� ����
        if (consumeItem.count < 1)
            return;

        //�ֹ��� �ϳ� ���
        consumeItem.count -= 1;
        consumeItems[14] = consumeItem;

        //���� ��ȯ �ֹ��� ���
        moveVillage.MoveToNearVillage();

        //UI�ݿ�
        itemUI.ShowConsumeInItemInventory();
    }

    #region ������ ������
    public const string consumeTag = "ConsumeItem";
    public const string equipmentTag = "EquipmentItem";

    //�ʵ忡 ������ �����۵�
    public List<GameObject> fieldDropItems = new List<GameObject>();

    //���, �Һ� ������ ��ϵ�
    public List<GameObject> equipmentItems = new List<GameObject>();
    public Dictionary<string, EquiipmentOption> equipmentItemDic = new Dictionary<string, EquiipmentOption>();

    public Dictionary<int, ConsumeItem> consumeItems = new Dictionary<int, ConsumeItem>();
    public List<Sprite> consumeItemImage = new List<Sprite>();

    //Ű���� �� ���ε�
    public List<GameObject> keySlotImage = new List<GameObject>();
    //���� ������ (�Է� Ű, ���� ������ �ε���)
    public Dictionary<int,int> keySlotBuffItems = new Dictionary<int,int>();
    //���� ������ ���
    public List<GameObject> buffItemList = new List<GameObject>();

    //ȸ��
    private int useHPPosionIndex = -1;
    private int useMPPosionIndex = -1;
    private int useElixerPosionIndex = -1;
    private int useBuffPosionIndex = -1;
    private int healHPAmount = 0;
    private int healMPAmount = 0;
    public int UseHPPosionIndex { get { return useHPPosionIndex; } set { useHPPosionIndex = value; } }
    public int UseMPPosionIndex { get { return useMPPosionIndex; } set { useMPPosionIndex = value; } }
    public int UseElixerPosionIndex { get { return useElixerPosionIndex; } set { useElixerPosionIndex = value; } }
    public int UseBuffPosionIndex { get { return useBuffPosionIndex; } set { useBuffPosionIndex = value; } }
    public int HealHPAmount { get { return healHPAmount; } set { healHPAmount = value; } }
    public int HealMPAmount { get { return healMPAmount; } set { healMPAmount = value; } }
    #endregion
}
