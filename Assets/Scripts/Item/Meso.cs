using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class Meso : MonoBehaviour
{
    [SerializeField]
    List<Sprite> mesoImg = new List<Sprite> ();
    SpriteRenderer spriteRenderer;

    //È¹µæ ¸Þ¼Ò
    private int getMeso;

    //ÇÃ·¹ÀÌ¾î ÅÂ±×
    const string playerTag = "Player";

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer> ();
    }
    private void OnEnable()
    {
        Invoke("MesoFlow", 0.05f);
    }
    /// <summary>
    /// ¸Þ¼Ò È¹µæ ·ÎÁ÷
    /// </summary>
    void MesoFlow()
    {
        getMeso = CalGetMeso(this.gameObject.name);
        ShowMesoImage(getMeso);
    }

    /// <summary>
    /// ¸Þ¼Ò È¹µæ
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == playerTag)
        {
            PlayerManager.PlayerInstance.PlayerMeso += getMeso;
            ItemManager.itemInstance.fieldDropItems.Remove(this.gameObject);
            Destroy(gameObject);
        }
    }

    void ShowMesoImage(int meso)
    {
        if (meso >= 1000)
        {
            spriteRenderer.sprite = mesoImg[3];
        }else if(meso >=100 && meso < 1000)
        {
            spriteRenderer.sprite = mesoImg[2];
        }else if(meso>=50 && meso < 100)
        {
            spriteRenderer.sprite=mesoImg[1];
        }
        else
        {
            spriteRenderer.sprite = mesoImg[0];
        }
    }
    /// <summary>
    /// µå¶ø ¸Þ¼Ò °è»ê
    /// </summary>
    /// <returns></returns>
    int CalGetMeso(string gameObjName)
    {
        int mobLv = int.Parse(gameObjName.Substring(5));
        int dropMeso = 0;

        if (mobLv<30)
        {
            dropMeso = (mobLv * mobLv * mobLv) / 100 - 4 * mobLv * mobLv / 10 + 6 * mobLv - 10;
        }
        else
        {
            dropMeso = (mobLv * mobLv + mobLv) / 10 - mobLv/15;
        }

        int finalDropMeso = Random.Range(dropMeso * 4 / 5, dropMeso * 6 / 5);
        return finalDropMeso;
    }
}
