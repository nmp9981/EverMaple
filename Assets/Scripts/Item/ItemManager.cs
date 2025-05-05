using System.Collections.Generic;
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
    public Sprite sprite;
    public string name;
    public int count;
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
    /// HP���� ���
    /// </summary>
    public void EnrollHPPosion(string itemName)
    {
        switch (itemName)
        {
            case "��������":

                break;
        }
    }
    /// <summary>
    /// MP���� ���
    /// </summary>
    public void EnrollMPPosion(string itemName)
    {

    }
    /// <summary>
    /// ������ ���
    /// </summary>
    public void EnrollElixerPosion(string itemName)
    {

    }
    /// <summary>
    /// ���� ���
    /// </summary>
    public void EnrollBuffPosion(string itemName)
    {

    }

    //������ ���
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
    public List<Image> keySlotImage = new List<Image>(); 

    //ȸ����
    private int healHPAmount;
    private int healMPAmount;
    public int HealHPAmount { get { return healHPAmount; } set { healHPAmount = value; } }
    public int HealMPAmount { get { return healMPAmount; } set { healMPAmount = value; } }
    #endregion
}
