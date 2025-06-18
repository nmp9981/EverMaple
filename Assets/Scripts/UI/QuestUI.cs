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
    /// ����Ʈ NPC ���̱�
    /// </summary>
    /// <param name="spriteRen"></param>
    public void QuestMain()
    {
        npcImage.sprite = NPCCommon.npcSprite;
        npcMainText.text = "1 ���ϱ� 1�� â��";//TODO : �� DB���� ������ ����

        //����Ʈ ���¿� ���� �ٸ� ��ũ��Ʈ ���
        switch (NPCCommon.npcObj.questState)
        {
            case 0:
                break;
        }
    }
    /// <summary>
    /// ����Ʈ â �ݱ�
    /// </summary>
    public void QuestCloseButton()
    {
        gameObject.SetActive(false);
    }
}
