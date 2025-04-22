using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

//���� ����
public enum AttackRange
{
    Near,
    Far,
    Count
}
public class SkillManager : MonoBehaviour
{
    GameObject player;
    PlayerInfoUI playerInfoUI;
    ThrowObjectFulling throwObjectFulling;

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerInfoUI = GameObject.Find("UserInfo").GetComponent<PlayerInfoUI>();
        throwObjectFulling = GetComponent<ThrowObjectFulling>();
    }

    //��ų ����
    public async UniTask LuckySeven(int hitNum)
    {
        //���� ���
        PlayerAnimation.AttackAnim();

        //MP �Ҹ�
        DecreasePlayerMP(16);

        for (int i = 0; i < hitNum; i++)
        {
            ThrowObjectFunction throwObj = throwObjectFulling.MakeObj(0).GetComponent<ThrowObjectFunction>();
            throwObj.transform.position = player.transform.position + 0.5f * PlayerManager.PlayerInstance.PlayerLookDir;
            throwObj.startPos = throwObj.transform.position;
            throwObj.hitNum = i;

            await UniTask.Delay(PlayerManager.PlayerInstance.PlayerAttackSpeed/4);
        }
    }

    /// <summary>
    /// MP �Ҹ�
    /// </summary>
    private void DecreasePlayerMP(int spendMP)
    {
        PlayerManager.PlayerInstance.PlayerCurMP = Mathf.Max(0, PlayerManager.PlayerInstance.PlayerCurMP - spendMP);
        playerInfoUI.ShowPlayerMPBar();
    }
}
