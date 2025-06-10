using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField]
    PlayerInfoUI playerInfoUI;//플레이어 UI

    public void GetPlayerExp(int getExp)
    {
        PlayerManager.PlayerInstance.PlayerCurExp += getExp;
        playerInfoUI.ShowPlayerEXPBar();
        playerInfoUI.ShowGetExpMessage(getExp);
        PlayereLevelUP();
    }

    /// <summary>
    /// 캐릭터 레벨업
    /// </summary>
    void PlayereLevelUP()
    {
        if (PlayerManager.PlayerInstance.PlayerCurExp >= PlayerManager.PlayerInstance.PlayerRequireExp)
        {
            //만렙
            if (PlayerManager.PlayerInstance.PlayerLV >= PlayerManager.PlayerInstance.PlayerMaxLV)
                return;
            
            //레벨업
            PlayerManager.PlayerInstance.PlayerCurExp -= PlayerManager.PlayerInstance.PlayerRequireExp;
            PlayerManager.PlayerInstance.PlayerLV += 1;
            playerInfoUI.ShowPlayerLV();

            //요구경험치 증가
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

            //AP 증가
            PlayerManager.PlayerInstance.PlayerAPPoint += 5;
            //SP 증가
            PlayerManager.PlayerInstance.PlayerSkillPoint += 3;

            //레벨업 모션
            PlayerAnimation.LevelUPAnim();
        }
    }
}
