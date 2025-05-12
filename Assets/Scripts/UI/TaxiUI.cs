using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaxiUI : MonoBehaviour
{
    [SerializeField]
    GameObject taxiUI1;
    [SerializeField]
    GameObject taxiUI2;

    [SerializeField]
    MapManager mapManager;

    public List<GameObject> taxiButtonSet = new List<GameObject>();

    //�ý� ����
    int taxiPrice = 0;
    //�̵��� ���� 
    int moveVillageIndex = 0;

    void Awake()
    {
        StoreButtonBinding();
    }

    private void OnEnable()
    {
        taxiUI1.SetActive(true);
        taxiUI2.SetActive(false);
        SettingTaxiUI();
    }

    /// <summary>
    /// ���� ��ư ���ε�
    /// </summary>
    void StoreButtonBinding()
    {
        foreach (Button btn in gameObject.GetComponentsInChildren<Button>(true))
        {
            string gmName = btn.name;

            //���� Ȯ��
            if (gmName.Contains("Check"))
            {
                btn.onClick.AddListener(MoveToVillageThroughTaxi);
            }

            //���� ��ư
            if (gmName.Contains("MoveVillage"))
            {
                taxiButtonSet.Add(btn.gameObject);

                switch (taxiButtonSet.Count - 1)
                {
                    case 0:
                        taxiButtonSet[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    $"�����ױ� {800 + 200 * taxiButtonSet.Count}�޼�";
                        break;
                    case 1:
                        taxiButtonSet[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    $"��׽ý� {800 + 200 * taxiButtonSet.Count}�޼�";
                        break;
                    case 2:
                        taxiButtonSet[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    $"�����Ͼ� {800 + 200 * taxiButtonSet.Count}�޼�";
                        break;
                    case 3:
                        taxiButtonSet[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    $"�丮�� {800 + 200 * taxiButtonSet.Count}�޼�";
                        break;
                    case 4:
                        taxiButtonSet[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    $"Ŀ�׽�Ƽ {800 + 200 * taxiButtonSet.Count}�޼�";
                        break;
                    case 5:
                        taxiButtonSet[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    $"�����ǿ�� {800 + 200 * taxiButtonSet.Count}�޼�";
                        break;
                    default:
                        break;
                }
                btn.onClick.AddListener(delegate { SettingMoveToGoalVillage(int.Parse(gmName.Substring(gmName.Length-1))); });
            }
        }
    }
    //�ý� UI1����
    public void SettingTaxiUI()
    {
        for(int idx = 0; idx < taxiButtonSet.Count; idx++)
        {
            if (idx == (int)MapManager.playerMapLocal)
            {
                taxiButtonSet[idx].gameObject.SetActive(false);
            }
        }
    }
    //�ýø� ���� ������ �̵�
    public void MoveToVillageThroughTaxi()
    {
        taxiPrice = 1000 + 200 * moveVillageIndex;
        //�޼� ����
        if (PlayerManager.PlayerInstance.PlayerMeso - taxiPrice < 0)
            return;
        PlayerManager.PlayerInstance.PlayerMeso -= taxiPrice;

        switch (moveVillageIndex)
        {
            case 0:
                mapManager.MoveToPortal(0, mapManager.villageList[moveVillageIndex]);
                break;
            case 1:
                mapManager.MoveToPortal(3, mapManager.villageList[moveVillageIndex]);
                break;
            case 2:
                mapManager.MoveToPortal(12, mapManager.villageList[moveVillageIndex]);
                break;
            case 3:
                mapManager.MoveToPortal(25, mapManager.villageList[moveVillageIndex]);
                break;
            case 4:
                mapManager.MoveToPortal(36, mapManager.villageList[moveVillageIndex]);
                break;
            case 5:
                mapManager.MoveToPortal(49, mapManager.villageList[moveVillageIndex]);
                break;
            default:
                break;
        }
        //UIâ �ݱ�
        CloseTaxiTab();
    }
    //�ý� UI2����
    public void SettingMoveToGoalVillage(int villageNumber)
    {
        taxiUI1.SetActive(false);
        taxiUI2.SetActive(true);

        moveVillageIndex = villageNumber;
        taxiUI2.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text =
            $"����� {1000+200*villageNumber}�޼��Դϴ�. \n�̵��Ͻðڽ��ϱ�?";
    }

    //�ý��� �ݱ�
    public void CloseTaxiTab()
    {
        for (int idx = 0; idx < taxiButtonSet.Count; idx++)
        {
            taxiButtonSet[idx].gameObject.SetActive(true);
        }
        this.gameObject.SetActive(false);
    }
}
