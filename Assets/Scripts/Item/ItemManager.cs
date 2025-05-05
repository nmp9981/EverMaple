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
                posionSprite = consumeItems[0].sprite;
                posionCountText = consumeItems[0].count.ToString();
                break;
            case "��Ȳ����":
                //�̹���, ���� ���� ǥ��
                posionSprite = consumeItems[1].sprite;
                posionCountText = consumeItems[1].count.ToString();
                break;
            case "�Ͼ�����":
                //�̹���, ���� ���� ǥ��
                posionSprite = consumeItems[2].sprite;
                posionCountText = consumeItems[2].count.ToString();
                break;
            case "����":
                //�̹���, ���� ���� ǥ��
                posionSprite = consumeItems[5].sprite;
                posionCountText = consumeItems[5].count.ToString();
                break;
            case "���޹�":
                //�̹���, ���� ���� ǥ��
                posionSprite = consumeItems[7].sprite;
                posionCountText = consumeItems[7].count.ToString();
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
                posionSprite = consumeItems[3].sprite;
                posionCountText = consumeItems[3].count.ToString();
                break;
            case "����������":
                //�̹���, ���� ���� ǥ��
                posionSprite = consumeItems[4].sprite;
                posionCountText = consumeItems[4].count.ToString();
                break;
            case "������":
                //�̹���, ���� ���� ǥ��
                posionSprite = consumeItems[6].sprite;
                posionCountText = consumeItems[6].count.ToString();
                break;
            case "�Ϻ���":
                //�̹���, ���� ���� ǥ��
                posionSprite = consumeItems[8].sprite;
                posionCountText = consumeItems[8].count.ToString();
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
        keySlotImage[12].transform.GetChild(0).GetComponent<Image>().sprite = posionSprite;
        keySlotImage[12].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = posionCountText;
    }
    /// <summary>
    /// ���� ���
    /// </summary>
    public void EnrollBuffPosion(string itemName)
    {

    }

    //������ ���
    public void UseConsumeItem(string itemName)
    {

    }
    public void UseHPPosion(string itemName)
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

    //ȸ����
    private int healHPAmount;
    private int healMPAmount;
    public int HealHPAmount { get { return healHPAmount; } set { healHPAmount = value; } }
    public int HealMPAmount { get { return healMPAmount; } set { healMPAmount = value; } }
    #endregion
}
