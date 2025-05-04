using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIMouseClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject enrollKwySlotObject;
    [SerializeField]
    GameObject selectKeyObject;

    RectTransform enrollKwyRectTrans;

    void Awake()
    {
        enrollKwyRectTrans = enrollKwySlotObject.GetComponent<RectTransform>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
        if(clickedObject.tag == ItemManager.consumeTag)
        {
            enrollKwySlotObject.SetActive(true);
            enrollKwyRectTrans.position = Input.mousePosition + new Vector3(30,-30,0);
        }
        else
        {
            enrollKwySlotObject.SetActive(false);
        }
    }

    /// <summary>
    /// 키 등록
    /// </summary>
    public void SettingItemKey()
    {
        //HP관련은 A, NP관련은 D로 고정, 엘릭서는 F로 고정
        selectKeyObject.SetActive(true);
    }

    /// <summary>
    /// 키 등록 취소
    /// </summary>
    public void CancelEnrollKey()
    {
        enrollKwySlotObject.SetActive(false);
    }
}