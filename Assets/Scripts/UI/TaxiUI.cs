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

    //택시 가격
    int taxiPrice = 0;
    //이동할 마을 
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
    /// 상점 버튼 바인딩
    /// </summary>
    void StoreButtonBinding()
    {
        foreach (Button btn in gameObject.GetComponentsInChildren<Button>(true))
        {
            string gmName = btn.name;

            //최종 확인
            if (gmName.Contains("Check"))
            {
                btn.onClick.AddListener(MoveToVillageThroughTaxi);
            }

            //마을 버튼
            if (gmName.Contains("MoveVillage"))
            {
                taxiButtonSet.Add(btn.gameObject);

                switch (taxiButtonSet.Count - 1)
                {
                    case 0:
                        taxiButtonSet[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    $"리스항구 {800 + 200 * taxiButtonSet.Count}메소";
                        break;
                    case 1:
                        taxiButtonSet[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    $"헤네시스 {800 + 200 * taxiButtonSet.Count}메소";
                        break;
                    case 2:
                        taxiButtonSet[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    $"엘리니아 {800 + 200 * taxiButtonSet.Count}메소";
                        break;
                    case 3:
                        taxiButtonSet[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    $"페리온 {800 + 200 * taxiButtonSet.Count}메소";
                        break;
                    case 4:
                        taxiButtonSet[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    $"커닝시티 {800 + 200 * taxiButtonSet.Count}메소";
                        break;
                    case 5:
                        taxiButtonSet[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    $"슬리피우드 {800 + 200 * taxiButtonSet.Count}메소";
                        break;
                    default:
                        break;
                }
                btn.onClick.AddListener(delegate { SettingMoveToGoalVillage(int.Parse(gmName.Substring(gmName.Length-1))); });
            }
        }
    }
    //택시 UI1세팅
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
    //택시를 통해 마을로 이동
    public void MoveToVillageThroughTaxi()
    {
        taxiPrice = 1000 + 200 * moveVillageIndex;
        //메소 부족
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
        //UI창 닫기
        CloseTaxiTab();
    }
    //택시 UI2세팅
    public void SettingMoveToGoalVillage(int villageNumber)
    {
        taxiUI1.SetActive(false);
        taxiUI2.SetActive(true);

        moveVillageIndex = villageNumber;
        taxiUI2.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text =
            $"요금은 {1000+200*villageNumber}메소입니다. \n이동하시겠습니까?";
    }

    //택시탭 닫기
    public void CloseTaxiTab()
    {
        for (int idx = 0; idx < taxiButtonSet.Count; idx++)
        {
            taxiButtonSet[idx].gameObject.SetActive(true);
        }
        this.gameObject.SetActive(false);
    }
}
