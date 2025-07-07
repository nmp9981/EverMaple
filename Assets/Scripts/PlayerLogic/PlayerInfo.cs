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
        PlayerManager.PlayerInstance.PlayerCurExp += (getExp*300);
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
            int nextReauireExp = SettingRequireExp(PlayerManager.PlayerInstance.PlayerLV);
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
            //SP ����(��, �ʺ����϶��� SP���� ������)
            if(PlayerManager.PlayerInstance.PlayerLV>=9 && PlayerManager.PlayerInstance.PlayerJOBEnum != PlayerJobClass.Beginer)
                PlayerManager.PlayerInstance.PlayerSkillPoint += 3;

            //ǥâ ���׷��̵�
            UpgradeDrag();

            //����Ʈ ������Ʈ
            foreach(var quest in QuestDataBase.questDataList)
            {
                if(PlayerManager.PlayerInstance.PlayerLV>= quest.reqLv)
                {
                    if(quest.questState==0)
                        quest.questState = 1;
                }
            }

            //������ ���
            PlayerAnimation.LevelUPAnim();
            //����
            SoundManager._sound.PlaySfx(23);
        }
    }

    /// <summary>
    /// ǥâ ���׷��̵�
    /// </summary>
    void UpgradeDrag()
    {
        if (PlayerManager.PlayerInstance.PlayerLV >= 86)
        {
            return;
        }
        if (PlayerManager.PlayerInstance.PlayerLV >= PlayerManager.PlayerInstance.dragUpgradeLV[PlayerManager.PlayerInstance.ShootDragNum+1])
        {
            PlayerManager.PlayerInstance.ShootDragNum += 1;
            equiipmentUI.ChangeDragImage(PlayerManager.PlayerInstance.ShootDragNum);
        }
    }
    /// <summary>
    /// �䱸 ����ġ ����
    /// </summary>
    int SettingRequireExp(int lv)
    {
        int reqExp = 0;
        if(lv>=100)
            reqExp = PlayerManager.PlayerInstance.PlayerRequireExp * 110 / 100;
        else if (lv >= 25 && lv<100)
            reqExp = PlayerManager.PlayerInstance.PlayerRequireExp * 105 / 100;
        else if(lv<25 && lv>=15)
            reqExp = PlayerManager.PlayerInstance.PlayerRequireExp * 115 / 100;
        else
            reqExp = PlayerManager.PlayerInstance.ealryRequireExpArray[PlayerManager.PlayerInstance.PlayerLV];
        return reqExp;
    }
}
