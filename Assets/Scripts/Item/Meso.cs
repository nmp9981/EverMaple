using System.Collections.Generic;
using UnityEngine;

public class Meso : MonoBehaviour
{
    PlayerInfoUI playerInfoUI;
    [SerializeField]
    List<Sprite> mesoImg = new List<Sprite> ();
    SpriteRenderer spriteRenderer;

    //ȹ�� �޼�
    private int getMeso;

    //�÷��̾� �±�
    const string playerTag = "Player";

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerInfoUI = GameObject.Find("UserInfo").GetComponent<PlayerInfoUI>();
    }
    private void OnEnable()
    {
        Invoke("MesoFlow", 0.05f);
    }
    /// <summary>
    /// �޼� ȹ�� ����
    /// </summary>
    void MesoFlow()
    {
        getMeso = CalGetMeso(this.gameObject.name);
        ShowMesoImage(getMeso);
    }

    /// <summary>
    /// �޼� ȹ��
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == playerTag)
        {
            PlayerManager.PlayerInstance.PlayerMeso += (getMeso);
            ItemManager.itemInstance.fieldDropItems.Remove(this.gameObject);
            SoundManager._sound.PlaySfx(24);
            playerInfoUI.ShowGetMesoMessage(getMeso);
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
    /// ��� �޼� ���
    /// </summary>
    /// <returns></returns>
    int CalGetMeso(string gameObjName)
    {
        int mobLv = int.Parse(gameObjName.Substring(5));
        int dropMeso = 0;

        if (mobLv < 20)
        {
            dropMeso = 2 * mobLv+2;
        }
        else if (mobLv>=20 && mobLv<30)
        {
            dropMeso = 43+(9*(mobLv-20))/2;
        }
        else
        {
            dropMeso = (mobLv * mobLv + mobLv) / 10 - mobLv/15;
        }

        int finalDropMeso = Mathf.Max(4, Random.Range(dropMeso * 4 / 5, dropMeso * 6 / 5));
        int addDropMeso = (finalDropMeso * PlayerManager.PlayerInstance.RateIncreaseGetMeso)/100;
        return finalDropMeso+ addDropMeso;
    }
}
