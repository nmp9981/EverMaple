using UnityEngine;

public class DamageSpriteFunction : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        Invoke("EraseDamageImage", 0.5f);
        spriteRenderer.sortingOrder = InputKeyManager.orderSortNum;
    }
    /// <summary>
    /// ������ ����� : ������ 0.5�ʵڿ� ����
    /// </summary>
    void EraseDamageImage()
    {
        gameObject.SetActive(false);
    }
}
