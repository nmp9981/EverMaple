using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorldMapUI : MonoBehaviour
{
    [SerializeField]
    RectTransform posObj;

    List<Vector2> worldNodeList = new List<Vector2>();


    private void Awake()
    {
        EnrollWorldMapNode();
    }

    private void OnEnable()
    {
        //���� ���� ����ó��
        int nodeNum = Mathf.Min(MapAndProtalList.curMapNum,21);
        posObj.anchoredPosition = worldNodeList[nodeNum]+Vector2.up*50f;
    }
    /// <summary>
    /// ����� ��� ���
    /// </summary>
    void EnrollWorldMapNode()
    {
        foreach (var node in gameObject.GetComponentsInChildren<RectTransform>())
        {
            if (node.gameObject.name.Contains("Node"))
            {
                worldNodeList.Add(node.anchoredPosition);
            }
        }
    }
}
