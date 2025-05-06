using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIMouseClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject enrollKwySlotObject;
    [SerializeField]
    GameObject selectKeyObject;

    //������ �Һ� ������
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
    /// ���� ��ư ���ε�
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
    /// Ű ��� ������Ʈ ����
    /// </summary>
    public void OpenSettingItemKeyWindow()
    {
        selectKeyObject.SetActive(true);
    }

    /// <summary>
    /// Ű ���
    /// </summary>
    public void SettingItemKey(string inputKey)
    {
        //HP������ A, MP������ D�� ����, �������� F�� ����
        //�̹��� �̸����� ����
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
    /// Ű ��� ���
    /// </summary>
    public void CancelEnrollKey()
    {
        enrollKwySlotObject.SetActive(false);
    }
}