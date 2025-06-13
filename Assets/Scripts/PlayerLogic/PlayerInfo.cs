using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField]
    PlayerInfoUI playerInfoUI;//�÷��̾� UI
    [SerializeField]
    EquiipmentUI equiipmentUI;//��� UI

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
            int increaseHP = Random.Range(20, 25);
            int increaseMP = Random.Range(14, 17) + (PlayerManager.PlayerInstance.PlayerINT+PlayerManager.PlayerInstance.PlayerAddINT)/10;
            PlayerManager.PlayerInstance.PlayerMaxHP += increaseHP;
            PlayerManager.PlayerInstance.PlayerMaxMP += increaseMP;

            PlayerManager.PlayerInstance.PlayerCurHP = PlayerManager.PlayerInstance.PlayerMaxHP;
            PlayerManager.PlayerInstance.PlayerCurMP = PlayerManager.PlayerInstance.PlayerMaxMP;

            playerInfoUI.ShowPlayerHPBar();
            playerInfoUI.ShowPlayerMPBar();

            //AP ����
            PlayerManager.PlayerInstance.PlayerAPPoint += 5;
            //SP ����
            PlayerManager.PlayerInstance.PlayerSkillPoint += 3;

            //ǥâ ���׷��̵�
            UpgradeDrag();

            //������ ���
            PlayerAnimation.LevelUPAnim();
        }
    }

    /// <summary>
    /// ǥâ ���׷��̵�
    /// </summary>
    void UpgradeDrag()
    {
        if(PlayerManager.PlayerInstance.PlayerLV >= PlayerManager.PlayerInstance.dragUpgradeLV[PlayerManager.PlayerInstance.ShootDragNum+1])
        {
            PlayerManager.PlayerInstance.ShootDragNum += 1;
            equiipmentUI.ChangeDragImage(PlayerManager.PlayerInstance.ShootDragNum);
        }
    }
}
