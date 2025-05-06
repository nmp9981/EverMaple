using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 아이템 속성
/// </summary>
public enum ItemAttribute{
    Equipment,
    consume,
    Count
}

/// <summary>
/// 소비 아이템 속성
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
/// 소비 아이템 속성
/// </summary>
public struct ConsumeItem
{
    public Sprite sprite;//이미지
    public string name;//이름
    public int count;//몇개남았는지
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
        if (itemInstance == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때
        {
            itemInstance = this; //내자신을 instance로 넣어줍니다.
            DontDestroyOnLoad(gameObject); //OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지
        }
        else
        {
            if (itemInstance != this) //instance가 내가 아니라면 이미 instance가 하나 존재하고 있다는 의미
                Destroy(this.gameObject); //둘 이상 존재하면 안되는 객체이니 방금 AWake된 자신을 삭제
        }
    }
    /// <summary>
    /// 필드에 있는 아이템들 파괴
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
    /// HP포션 등록, A키 고정
    /// </summary>
    public void EnrollHPPosion(string itemName)
    {
        Sprite posionSprite = null;
        string posionCountText = string.Empty;
        switch (itemName)
        {
            case "빨간포션":
                //이미지, 남은 개수 표시
                UseHPPosionIndex = 0;
                posionSprite = consumeItems[UseHPPosionIndex].sprite;
                posionCountText = consumeItems[UseHPPosionIndex].count.ToString();
                HealHPAmount = 50;
                break;
            case "주황포션":
                //이미지, 남은 개수 표시
                UseHPPosionIndex = 1;
                posionSprite = consumeItems[UseHPPosionIndex].sprite;
                posionCountText = consumeItems[UseHPPosionIndex].count.ToString();
                HealHPAmount = 150;
                break;
            case "하얀포션":
                //이미지, 남은 개수 표시
                UseHPPosionIndex = 2;
                posionSprite = consumeItems[UseHPPosionIndex].sprite;
                posionCountText = consumeItems[UseHPPosionIndex].count.ToString();
                HealHPAmount = 300;
                break;
            case "장어구이":
                //이미지, 남은 개수 표시
                UseHPPosionIndex = 5;
                posionSprite = consumeItems[UseHPPosionIndex].sprite;
                posionCountText = consumeItems[UseHPPosionIndex].count.ToString();
                HealHPAmount = 1000;
                break;
            case "쭈쭈바":
                //이미지, 남은 개수 표시
                UseHPPosionIndex = 7;
                posionSprite = consumeItems[UseHPPosionIndex].sprite;
                posionCountText = consumeItems[UseHPPosionIndex].count.ToString();
                HealHPAmount = 2000;
                break;
            default:
                break;
        }

        //HP물약이 아님
        if (posionSprite == null)
            return;

        //A키로 등록
        keySlotImage[0].transform.GetChild(0).GetComponent<Image>().sprite = posionSprite;
        keySlotImage[0].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = posionCountText;
    }
    /// <summary>
    /// MP포션 등록, D키 고정
    /// </summary>
    public void EnrollMPPosion(string itemName)
    {
        Sprite posionSprite = null;
        string posionCountText = string.Empty;
        switch (itemName)
        {
            case "파란포션":
                //이미지, 남은 개수 표시
                UseMPPosionIndex = 3;
                posionSprite = consumeItems[UseMPPosionIndex].sprite;
                posionCountText = consumeItems[UseMPPosionIndex].count.ToString();
                HealMPAmount = 100;
                break;
            case "마나엘릭서":
                //이미지, 남은 개수 표시
                UseMPPosionIndex = 4;
                posionSprite = consumeItems[UseMPPosionIndex].sprite;
                posionCountText = consumeItems[UseMPPosionIndex].count.ToString();
                HealMPAmount = 300;
                break;
            case "맑은물":
                //이미지, 남은 개수 표시
                UseMPPosionIndex = 6;
                posionSprite = consumeItems[UseMPPosionIndex].sprite;
                posionCountText = consumeItems[UseMPPosionIndex].count.ToString();
                HealMPAmount = 800;
                break;
            case "팥빙수":
                //이미지, 남은 개수 표시
                UseMPPosionIndex = 8;
                posionSprite = consumeItems[UseMPPosionIndex].sprite;
                posionCountText = consumeItems[UseMPPosionIndex].count.ToString();
                HealMPAmount = 2000;
                break;
            default:
                break;
        }

        //MP물약이 아님
        if (posionSprite == null)
            return;

        //D키로 등록
        keySlotImage[1].transform.GetChild(0).GetComponent<Image>().sprite = posionSprite;
        keySlotImage[1].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = posionCountText;
    }
    /// <summary>
    /// 엘릭서 등록
    /// TODO : 아이템 드랍 구현 후 작성
    /// </summary>
    public void EnrollElixerPosion(string itemName)
    {
        return;

        Sprite posionSprite = null;
        string posionCountText = string.Empty;
        switch (itemName)
        {
            case "엘릭서":
                //이미지, 남은 개수 표시
                posionSprite = consumeItems[0].sprite;
                posionCountText = consumeItems[0].count.ToString();
                break;
            case "파워엘릭서":
                //이미지, 남은 개수 표시
                posionSprite = consumeItems[1].sprite;
                posionCountText = consumeItems[1].count.ToString();
                break;         
            default:
                break;
        }

        //엘릭서가 아님
        if (posionSprite == null)
            return;

        //F키로 등록
        keySlotImage[2].transform.GetChild(0).GetComponent<Image>().sprite = posionSprite;
        keySlotImage[2].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = posionCountText;
    }
    /// <summary>
    /// 버프 등록
    /// </summary>
    public void EnrollBuffPosion(string itemName, string inputKey)
    {
        Sprite posionSprite = null;
        string posionCountText = string.Empty;
        switch (itemName)
        {
            case "전사물약":
                UseBuffPosionIndex = 9;
                break;
            case "법사물약":
                UseBuffPosionIndex = 10;
                break;
            case "명사수물약":
                UseBuffPosionIndex = 11;
                break;
            case "민첩물약":
                UseBuffPosionIndex = 12;
                break;
            case "이속물약":
                UseBuffPosionIndex = 13;
                break;
            default:
                break;
        }
        //이미지, 남은 개수 표시
        if(UseBuffPosionIndex >=9 && UseBuffPosionIndex <= 13)
        {
            posionSprite = consumeItems[UseBuffPosionIndex].sprite;
            posionCountText = consumeItems[UseBuffPosionIndex].count.ToString();
        }
        
        //MP물약이 아님
        if (posionSprite == null)
            return;

        //키 등록(숫자키 중에 입력 가능)
        int outNum = int.TryParse(inputKey, out outNum)?outNum+7 :-1;
        if (outNum == -1)//숫자키가 아님
            return;

        keySlotImage[outNum].transform.GetChild(0).GetComponent<Image>().sprite = posionSprite;
        keySlotImage[outNum].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = posionCountText;

        //등록된 키가 이미 있는지 검사
        if (keySlotBuffItems.ContainsKey(outNum))
            keySlotBuffItems[outNum] = UseBuffPosionIndex;
        else//입력키, 실제 아이템 인덱스
            keySlotBuffItems.Add(outNum,UseBuffPosionIndex);
    }

    /// <summary>
    /// 아이템 사용
    /// TODO : 마을 귀환 기능은 맵을 먼저 만든 뒤에 구현
    /// </summary>
    public void UseConsumeItem()
    {
        GameObject clickObj = uiMouseClick.clickedConsumeObject;
        string objName = clickObj.GetComponent<Image>().sprite.name;

        switch (objName)
        {
            case "빨간포션":
                UseHPPosion(0,50,false);
                break;
            case "주황포션":
                UseHPPosion(1, 150, false);
                break;
            case "하얀포션":
                UseHPPosion(2, 300, false);
                break;
            case "장어구이":
                UseHPPosion(5, 1000, false);
                break;
            case "쭈쭈바":
                UseHPPosion(7, 2000, false);
                break;
            case "파란포션":
                UseMPPosion(3, 100, false);
                break;
            case "마나엘릭서":
                UseMPPosion(4, 300, false);
                break;
            case "맑은물":
                UseMPPosion(6, 800, false);
                break;
            case "팥빙수":
                UseMPPosion(8, 2000, false);
                break;
            case "전사물약":
                UseBuffPosion(9, false);
                break;
            case "법사물약":
                UseBuffPosion(10, false);
                break;
            case "명사수물약":
                UseBuffPosion(11, false);
                break;
            case "민첩물약":
                UseBuffPosion(12, false);
                break;
            case "이속물약":
                UseBuffPosion(13, false);
                break;
            case "마을귀환주문서":
                UseMoveVillagePosion();
                break;
            default:
                break;
        }
    }

    public void UseHPPosion(int itemIndex, int hpAmount, bool inputKey)
    {
        //포션 미등록
        if (!consumeItems.ContainsKey(itemIndex))
            return;

        ConsumeItem consumeItem = consumeItems[itemIndex];
        //포션이 없음
        if (consumeItem.count < 1)
            return;

        //키입력을 통한 회복
        if (inputKey)
            hpAmount = HealHPAmount;

        //포션 하나 사용
        consumeItem.count -= 1;
        consumeItems[itemIndex] = consumeItem;
        keySlotImage[0].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = consumeItem.count.ToString();

        //회복
        PlayerManager.PlayerInstance.PlayerCurHP 
            = Mathf.Min(PlayerManager.PlayerInstance.PlayerMaxHP, PlayerManager.PlayerInstance.PlayerCurHP + hpAmount);

        //UI반영
        playerInfoUI.ShowPlayerHPBar();
        itemUI.ShowConsumeInItemInventory();

    }
    public void UseMPPosion(int itemIndex, int mpAmount, bool inputKey)
    {
        //포션 미등록
        if (!consumeItems.ContainsKey(itemIndex))
            return;

        ConsumeItem consumeItem = consumeItems[itemIndex];
        //포션이 없음
        if (consumeItem.count < 1)
            return;

        //키입력을 통한 회복
        if (inputKey)
            mpAmount = HealMPAmount;

        //포션 하나 사용
        consumeItem.count -= 1;
        consumeItems[itemIndex] = consumeItem;
        keySlotImage[1].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = consumeItem.count.ToString();

        //회복
        PlayerManager.PlayerInstance.PlayerCurMP
            = Mathf.Min(PlayerManager.PlayerInstance.PlayerMaxMP, PlayerManager.PlayerInstance.PlayerCurMP + mpAmount);

        //UI반영
        playerInfoUI.ShowPlayerMPBar();
        itemUI.ShowConsumeInItemInventory();
    }

    public void UseBuffPosion(int itemIndex, bool inputKey)
    {
        //포션 미등록
        if (!consumeItems.ContainsKey(itemIndex))
            return;

        ConsumeItem consumeItem = consumeItems[itemIndex];
        //포션이 없음
        if (consumeItem.count < 1)
            return;

        //포션 하나 사용
        consumeItem.count -= 1;
        consumeItems[itemIndex] = consumeItem;

        //필요한거 : 어떤키 입력했는지 정보
        foreach(var item in keySlotImage)
        {
            string useItemName = item.transform.GetChild(0).GetComponent<Image>().sprite.name;
            if (consumeItems[itemIndex].name == useItemName)
                item.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = consumeItem.count.ToString();
        }

        //포션 효과
        EffectBuffPosion(itemIndex);
        //UI반영
        itemUI.ShowConsumeInItemInventory();
    }
    public void UseBuffItem(int inputKey)
    {
        int itemIndex = keySlotBuffItems[inputKey];
        //포션 미등록
        if (!consumeItems.ContainsKey(itemIndex))
            return;

        ConsumeItem consumeItem = consumeItems[itemIndex];
        //포션이 없음
        if (consumeItem.count < 1)
            return;

        //포션 하나 사용
        consumeItem.count -= 1;
        consumeItems[itemIndex] = consumeItem;

        //포션 효과
        EffectBuffPosion(itemIndex);
        //UI반영
        itemUI.ShowConsumeInItemInventory();
    }
    /// <summary>
    /// 버프 포션 효과
    /// </summary>
    void EffectBuffPosion(int itemIdx)
    {

    }

    public void UseMoveVillagePosion()
    {

    }

    #region 아이템 데이터
    public const string consumeTag = "ConsumeItem";

    //필드에 떨어진 아이템들
    public List<GameObject> fieldDropItems = new List<GameObject>();

    //장비, 소비 아이템 목록들
    public List<GameObject> equipmentItems = new List<GameObject>();
    public Dictionary<int, ConsumeItem> consumeItems = new Dictionary<int, ConsumeItem>();
    public List<Sprite> consumeItemImage = new List<Sprite>();

    //키세팅 용 바인딩
    public List<GameObject> keySlotImage = new List<GameObject>();
    //버프 아이템 (입력 키, 아이템 인덱스)
    public Dictionary<int,int> keySlotBuffItems = new Dictionary<int,int>();

    //회복
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
