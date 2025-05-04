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
    /// Ű ���
    /// </summary>
    public void SettingItemKey()
    {
        //HP������ A, NP������ D�� ����, �������� F�� ����
        selectKeyObject.SetActive(true);
    }

    /// <summary>
    /// Ű ��� ���
    /// </summary>
    public void CancelEnrollKey()
    {
        enrollKwySlotObject.SetActive(false);
    }
}