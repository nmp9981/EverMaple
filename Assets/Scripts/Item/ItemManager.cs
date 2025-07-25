using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
/// 장비아이템 속성
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
/// 소비 아이템 속성
/// </summary>
public struct ConsumeItem
{
    public Sprite sprite;//이미지
    public string name;//이름
    public int count;//몇개남았는지
}

public struct EquipmentItem
{
    public Sprite sprite;//이미지
    public string name;//이름
}

public class ItemManager : MonoBehaviour
{
    public static ItemManager itemInstance;
    public MoveVillage moveVillage = new MoveVillage();

    //플레이어가 현재 가지고 있는 장비
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
    /// 버프 아이템 바인딩
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

    /// <summary>
    /// HP포션 등록, A키 고정
    /// </summary>
    public void EnrollHPPosion(string itemName)
    {
        Sprite posionSprite = null;
        string posionCountText = string.Empty;
        switch (itemName)
        {
            case "빨간 포션":
                //이미지, 남은 개수 표시
                UseHPPosionIndex = 0;
                posionSprite = consumeItems[UseHPPosionIndex].sprite;
                posionCountText = consumeItems[UseHPPosionIndex].count.ToString();
                HealHPAmount = 50;
                break;
            case "주황 포션":
                //이미지, 남은 개수 표시
                UseHPPosionIndex = 1;
                posionSprite = consumeItems[UseHPPosionIndex].sprite;
                posionCountText = consumeItems[UseHPPosionIndex].count.ToString();
                HealHPAmount = 150;
                break;
            case "하얀 포션":
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
            case "파란 포션":
                //이미지, 남은 개수 표시
                UseMPPosionIndex = 3;
                posionSprite = consumeItems[UseMPPosionIndex].sprite;
                posionCountText = consumeItems[UseMPPosionIndex].count.ToString();
                HealMPAmount = 100;
                break;
            case "마나 엘릭서":
                //이미지, 남은 개수 표시
                UseMPPosionIndex = 4;
                posionSprite = consumeItems[UseMPPosionIndex].sprite;
                posionCountText = consumeItems[UseMPPosionIndex].count.ToString();
                HealMPAmount = 300;
                break;
            case "맑은 물":
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
    /// </summary>
    public void EnrollElixerPosion(string itemName)
    {
        Sprite posionSprite = null;
        string posionCountText = string.Empty;
        switch (itemName)
        {
            case "엘릭서":
                //이미지, 남은 개수 표시
                UseElixerPosionIndex = 19;
                posionSprite = consumeItems[UseElixerPosionIndex].sprite;
                posionCountText = consumeItems[UseElixerPosionIndex].count.ToString();
                break;
            case "파워 엘릭서":
                //이미지, 남은 개수 표시
                UseElixerPosionIndex = 20;
                posionSprite = consumeItems[UseElixerPosionIndex].sprite;
                posionCountText = consumeItems[UseElixerPosionIndex].count.ToString();
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
            case "전사의 물약":
                UseBuffPosionIndex = 9;
                break;
            case "마법사의 물약":
                UseBuffPosionIndex = 10;
                break;
            case "명사수의 물약":
                UseBuffPosionIndex = 11;
                break;
            case "민첩함의 물약":
                UseBuffPosionIndex = 12;
                break;
            case "속도 향상의 물약":
                UseBuffPosionIndex = 13;
                break;
            case "현자의 물약":
                UseBuffPosionIndex = 15;
                break;
            case "고목나무의 수액":
                UseBuffPosionIndex = 16;
                break;
            case "드레이크의 피":
                UseBuffPosionIndex = 17;
                break;
            case "드레이크의 고기":
                UseBuffPosionIndex = 18;
                break;
            default:
                break;
        }
        //이미지, 남은 개수 표시
        if(UseBuffPosionIndex >=9 && UseBuffPosionIndex <= 18)
        {
            if (UseBuffPosionIndex != 14)
            {
                posionSprite = consumeItems[UseBuffPosionIndex].sprite;
                posionCountText = consumeItems[UseBuffPosionIndex].count.ToString();
            }
        }
        
        //버프 물약이 아님
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
    /// </summary>
    public void UseConsumeItem()
    {
        GameObject clickObj = uiMouseClick.clickedConsumeObject;
        string objName = clickObj.GetComponent<Image>().sprite.name;

        switch (objName)
        {
            case "빨간 포션":
                UseHPPosion(0,50,false);
                break;
            case "주황 포션":
                UseHPPosion(1, 150, false);
                break;
            case "하얀 포션":
                UseHPPosion(2, 300, false);
                break;
            case "장어구이":
                UseHPPosion(5, 1000, false);
                break;
            case "쭈쭈바":
                UseHPPosion(7, 2000, false);
                break;
            case "파란 포션":
                UseMPPosion(3, 100, false);
                break;
            case "마나 엘릭서":
                UseMPPosion(4, 300, false);
                break;
            case "맑은 물":
                UseMPPosion(6, 800, false);
                break;
            case "팥빙수":
                UseMPPosion(8, 2000, false);
                break;
            case "전사의 물약":
                UseBuffPosion(9, false);
                break;
            case "마법사의 물약":
                UseBuffPosion(10, false);
                break;
            case "명사수의 물약":
                UseBuffPosion(11, false);
                break;
            case "민첩함의 물약":
                UseBuffPosion(12, false);
                break;
            case "속도 향상의 물약":
                UseBuffPosion(13, false);
                break;
            case "마을 귀환 주문서":
                UseMoveVillagePosion();
                break;
            case "현자의 물약":
                UseBuffPosion(15, false);
                break;
            case "고목나무의 수액":
                UseBuffPosion(16, false);
                break;
            case "드레이크의 피":
                UseBuffPosion(17, false);
                break;
            case "드레이크의 고기":
                UseBuffPosion(18, false);
                break;
            case "엘릭서":
                UseElixerPosion(19);
                break;
            case "파워 엘릭서":
                UseElixerPosion(20);
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

        //사운드
        SoundManager._sound.PlaySfx(30);

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

        //사운드
        SoundManager._sound.PlaySfx(30);

        //UI반영
        playerInfoUI.ShowPlayerMPBar();
        itemUI.ShowConsumeInItemInventory();
    }

    /// <summary>
    /// 엘릭서 사용
    /// </summary>
    public void UseElixerPosion(int itemIndex)
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
        keySlotImage[2].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = consumeItem.count.ToString();

        int hpAmount = (itemIndex==19)? PlayerManager.PlayerInstance.PlayerMaxHP/2:PlayerManager.PlayerInstance.PlayerMaxHP;
        int mpAmount = (itemIndex == 19) ? PlayerManager.PlayerInstance.PlayerMaxMP / 2 : PlayerManager.PlayerInstance.PlayerMaxMP;

        //회복
        PlayerManager.PlayerInstance.PlayerCurHP
           = Mathf.Min(PlayerManager.PlayerInstance.PlayerMaxHP, PlayerManager.PlayerInstance.PlayerCurHP + hpAmount);
        PlayerManager.PlayerInstance.PlayerCurMP
            = Mathf.Min(PlayerManager.PlayerInstance.PlayerMaxMP, PlayerManager.PlayerInstance.PlayerCurMP + mpAmount);

        //사운드
        SoundManager._sound.PlaySfx(31);

        //UI반영
        playerInfoUI.ShowPlayerHPBar();
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
        //사운드
        SoundManager._sound.PlaySfx(32);
        //UI반영
        itemUI.ShowConsumeInItemInventory();
    }
    /// <summary>
    /// 버프 아이템 사용
    /// </summary>
    /// <param name="inputKey"></param>
    public void UseBuffItem(int inputKey)
    {
        //실제 아이템 인덱스
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
        keySlotImage[inputKey].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = consumeItem.count.ToString();

        //포션 효과
        EffectBuffPosion(itemIndex);
        //UI반영
        itemUI.ShowConsumeInItemInventory();
    }
    /// <summary>
    /// 버프 활성화
    /// 이미 켜져있는 상태면 끄고 재시작
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
    /// 마을 귀환 주문서
    /// </summary>
    public void UseMoveVillagePosion()
    {
        //주문서 미등록
        if (!consumeItems.ContainsKey(14))
            return;

        ConsumeItem consumeItem = consumeItems[14];
        //주문서가 없음
        if (consumeItem.count < 1)
            return;

        //주문서 하나 사용
        consumeItem.count -= 1;
        consumeItems[14] = consumeItem;

        //마을 귀환 주문서 사용
        moveVillage.MoveToNearVillage();

        //UI반영
        itemUI.ShowConsumeInItemInventory();
    }

    #region 아이템 데이터
    public const string consumeTag = "ConsumeItem";
    public const string equipmentTag = "EquipmentItem";

    //필드에 떨어진 아이템들
    public List<GameObject> fieldDropItems = new List<GameObject>();

    //장비, 소비 아이템 목록들
    public List<GameObject> equipmentItems = new List<GameObject>();
    public Dictionary<string, EquiipmentOption> equipmentItemDic = new Dictionary<string, EquiipmentOption>();

    public Dictionary<int, ConsumeItem> consumeItems = new Dictionary<int, ConsumeItem>();
    public Dictionary<string, ConsumeToolTipText> consumeItemToolTipDic = new Dictionary<string, ConsumeToolTipText>();
    public List<Sprite> consumeItemImage = new List<Sprite>();

    //키세팅 용 바인딩
    public List<GameObject> keySlotImage = new List<GameObject>();
    //버프 아이템 (입력 키, 실제 아이템 인덱스)
    public Dictionary<int,int> keySlotBuffItems = new Dictionary<int,int>();
    //버프 아이템 사용
    public List<GameObject> buffItemList = new List<GameObject>();

    //회복
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
