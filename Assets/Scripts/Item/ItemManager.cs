using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 아이템 속성
/// </summary>
public enum ItemAttribute{
    Equipment,
    consume,
    Count
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

    #region 아이템 데이터
    //필드에 떨어진 아이템들
    public List<GameObject> fieldDropItems = new List<GameObject>();

    //장비, 소비 아이템 목록들
    public List<GameObject> equipmentItems = new List<GameObject>();
    public List<GameObject> consumeItems = new List<GameObject>();
    #endregion
}
