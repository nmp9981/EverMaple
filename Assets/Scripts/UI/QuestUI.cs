using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    [SerializeField]
    Image npcImage;

    private void OnEnable()
    {
        npcImage.sprite = NPCCommon.npcSprite;
    }

    /// <summary>
    /// ����Ʈ NPC ���̱�
    /// </summary>
    /// <param name="spriteRen"></param>
    public void ChangeNPC(SpriteRenderer spriteRen)
    {
        npcImage.sprite = spriteRen.sprite;
    }
    /// <summary>
    /// ����Ʈ â �ݱ�
    /// </summary>
    public void QuestCloseButton()
    {
        gameObject.SetActive(false);
    }
}
