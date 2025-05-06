using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIMouseClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject enrollKwySlotObject;
    [SerializeField]
    GameObject selectKeyObject;

    //선택한 소비 아이템
    public GameObject clickedConsumeObject = null;
    RectTransform enrollKwyRectTrans;

    void Awake()
    {
        enrollKwyRectTrans = enrollKwySlotObject.GetComponent<RectTransform>();
        SlotButtonBinding();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
        if(clickedObject.tag == ItemManager.consumeTag)
        {
            clickedConsumeObject = clickedObject;
            enrollKwySlotObject.SetActive(true);
            enrollKwyRectTrans.position = Input.mousePosition + new Vector3(30,-30,0);
        }
        else
        {
            clickedConsumeObject = null;
            enrollKwySlotObject.SetActive(false);
        }
    }

    /// <summary>
    /// 슬롯 버튼 바인딩
    /// </summary>
    void SlotButtonBinding()
    {
        foreach (Button btn in selectKeyObject.GetComponentsInChildren<Button>())
        {
            string btnName = btn.gameObject.name;
            if (!btn.name.Contains("Key"))
                continue;

            btn.onClick.AddListener(delegate { SettingItemKey(btnName.Substring(3)); });
        }
    }

    /// <summary>
    /// 키 등록 오브젝트 열기
    /// </summary>
    public void OpenSettingItemKeyWindow()
    {
        selectKeyObject.SetActive(true);
    }

    /// <summary>
    /// 키 등록
    /// </summary>
    public void SettingItemKey(string inputKey)
    {
        //HP관련은 A, MP관련은 D로 고정, 엘릭서는 F로 고정
        //이미지 이름으로 구분
        string itemName = clickedConsumeObject.GetComponent<Image>().sprite.name;
        switch (inputKey)
        {
            case "A":
                ItemManager.itemInstance.EnrollHPPosion(itemName);
                break;
            case "D":
                ItemManager.itemInstance.EnrollMPPosion(itemName);
                break;
            case "F":
                ItemManager.itemInstance.EnrollElixerPosion(itemName);
                break;
            default:
                ItemManager.itemInstance.EnrollBuffPosion(itemName,inputKey);
                break;
        }
    }

    /// <summary>
    /// 키 등록 취소
    /// </summary>
    public void CancelEnrollKey()
    {
        enrollKwySlotObject.SetActive(false);
    }
}