using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField]
    PlayerInfoUI playerInfoUI;//�÷��̾� UI

    public void GetPlayerExp(int getExp)
    {
        PlayerManager.PlayerInstance.PlayerCurExp += getExp;
        playerInfoUI.ShowPlayerEXPBar();
        PlayereLevelUP();
    }

    /// <summary>
    /// ĳ���� ������
    /// </summary>
    void PlayereLevelUP()
    {
        if (PlayerManager.PlayerInstance.PlayerCurExp >= PlayerManager.PlayerInstance.PlayerRequireExp)
        {
            //������
            PlayerManager.PlayerInstance.PlayerCurExp -= PlayerManager.PlayerInstance.PlayerRequireExp;
            PlayerManager.PlayerInstance.PlayerLV += 1;
            playerInfoUI.ShowPlayerLV();

            //�䱸����ġ ����
            int nextReauireExp = PlayerManager.PlayerInstance.PlayerRequireExp*105/100;
            PlayerManager.PlayerInstance.PlayerRequireExp = nextReauireExp;
            playerInfoUI.ShowPlayerEXPBar();

            //HP,MP
            PlayerManager.PlayerInstance.PlayerMaxHP += 20;
            PlayerManager.PlayerInstance.PlayerMaxMP += 15;

            PlayerManager.PlayerInstance.PlayerCurHP = PlayerManager.PlayerInstance.PlayerMaxHP;
            PlayerManager.PlayerInstance.PlayerCurMP = PlayerManager.PlayerInstance.PlayerMaxMP;

            playerInfoUI.ShowPlayerHPBar();
            playerInfoUI.ShowPlayerMPBar();

            //TODO : ���ݷ����� (�׽�Ʈ�� �ӽ��ڵ�� ���� ���￹��)
            PlayerManager.PlayerInstance.PlayerAttack += 50;
        }
    }
}
