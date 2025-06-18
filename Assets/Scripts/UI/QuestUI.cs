using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    [SerializeField]
    Image npcImage;
    [SerializeField]
    TextMeshProUGUI npcMainText;

    private void OnEnable()
    {
        QuestMain();
    }

    /// <summary>
    /// 퀘스트 NPC 보이기
    /// </summary>
    /// <param name="spriteRen"></param>
    public void QuestMain()
    {
        npcImage.sprite = NPCCommon.npcSprite;
        npcMainText.text = "1 더하기 1은 창문";//TODO : 퀘 DB에서 가져올 예정

        //퀘스트 상태에 따라 다른 스크립트 출력
        switch (NPCCommon.npcObj.questState)
        {
            case 0:
                break;
        }
    }
    /// <summary>
    /// 퀘스트 창 닫기
    /// </summary>
    public void QuestCloseButton()
    {
        gameObject.SetActive(false);
    }
}
