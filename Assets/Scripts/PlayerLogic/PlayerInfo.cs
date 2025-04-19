using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField]
    PlayerInfoUI playerInfoUI;//플레이어 UI

    public void GetPlayerExp(int getExp)
    {
        PlayerManager.PlayerInstance.PlayerCurExp += getExp;
        playerInfoUI.ShowPlayerEXPBar();
        PlayereLevelUP();
    }

    /// <summary>
    /// 캐릭터 레벨업
    /// </summary>
    void PlayereLevelUP()
    {
        if (PlayerManager.PlayerInstance.PlayerCurExp >= PlayerManager.PlayerInstance.PlayerRequireExp)
        {
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

            //TODO : 공격력증가 (테스트용 임시코드로 추후 지울예정)
            PlayerManager.PlayerInstance.PlayerAttack += 50;
        }
    }
}
