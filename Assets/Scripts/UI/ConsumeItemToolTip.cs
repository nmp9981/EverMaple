using UnityEngine;

/// <summary>
/// 소비아이템 툴팁 클래스
/// </summary>
public class ConsumeToolTipText
{
    public Sprite itemSprite;
    public string name;
    public string itemExplain;

    public ConsumeToolTipText(Sprite itemSprite, string name, string itemExplain)
    {
        this.itemSprite = itemSprite;
        this.name = name;   
        this.itemExplain = itemExplain;
    }
}

public class ConsumeItemToolTip : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
