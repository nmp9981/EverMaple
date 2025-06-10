using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField]
    PlayerInfoUI playerInfoUI;//�÷��̾� UI

    public void GetPlayerExp(int getExp)
    {
        PlayerManager.PlayerInstance.PlayerCurExp += getExp;
        playerInfoUI.ShowPlayerEXPBar();
        playerInfoUI.ShowGetExpMessage(getExp);
        PlayereLevelUP();
    }

    /// <summary>
    /// ĳ���� ������
    /// </summary>
    void PlayereLevelUP()
    {
        if (PlayerManager.PlayerInstance.PlayerCurExp >= PlayerManager.PlayerInstance.PlayerRequireExp)
        {
            //����
            if (PlayerManager.PlayerInstance.PlayerLV >= PlayerManager.PlayerInstance.PlayerMaxLV)
                return;
            
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

            //AP ����
            PlayerManager.PlayerInstance.PlayerAPPoint += 5;
            //SP ����
            PlayerManager.PlayerInstance.PlayerSkillPoint += 3;

            //������ ���
            PlayerAnimation.LevelUPAnim();
        }
    }
}
