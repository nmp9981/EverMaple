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
    /// Äù½ºÆ® NPC º¸ÀÌ±â
    /// </summary>
    /// <param name="spriteRen"></param>
    public void ChangeNPC(SpriteRenderer spriteRen)
    {
        npcImage.sprite = spriteRen.sprite;
    }
    /// <summary>
    /// Äù½ºÆ® Ã¢ ´Ý±â
    /// </summary>
    public void QuestCloseButton()
    {
        gameObject.SetActive(false);
    }
}
