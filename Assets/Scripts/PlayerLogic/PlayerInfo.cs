using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField]
    PlayerInfoUI playerInfoUI;//플레이어 UI
    [SerializeField]
    EquiipmentUI equiipmentUI;//장비 UI

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

            //AP 증가
            PlayerManager.PlayerInstance.PlayerAPPoint += 5;
            //SP 증가(단, 초보자일때는 SP지급 못받음)
            if(PlayerManager.PlayerInstance.PlayerLV>=9 && PlayerManager.PlayerInstance.PlayerJOBEnum != PlayerJobClass.Beginer)
                PlayerManager.PlayerInstance.PlayerSkillPoint += 3;

            //표창 업그레이드
            UpgradeDrag();

            //퀘스트 업데이트
            foreach(var quest in QuestDataBase.questDataList)
            {
                if(PlayerManager.PlayerInstance.PlayerLV>= quest.reqLv)
                {
                    if(quest.questState==0)
                        quest.questState = 1;
                }
            }

            //레벨업 모션
            PlayerAnimation.LevelUPAnim();
            //사운드
            SoundManager._sound.PlaySfx(23);
        }
    }

    /// <summary>
    /// 표창 업그레이드
    /// </summary>
    void UpgradeDrag()
    {
        if (PlayerManager.PlayerInstance.PlayerLV >= 91)
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
    /// 요구 경험치 세팅
    /// </summary>
    int SettingRequireExp(int lv)
    {
        int reqExp = 0;
        if(lv>=101)
            reqExp = PlayerManager.PlayerInstance.PlayerRequireExp * 121 / 100;
        else if (lv >= 25 && lv<101)
            reqExp = PlayerManager.PlayerInstance.PlayerRequireExp * 105 / 100;
        else if(lv<25 && lv>=15)
            reqExp = PlayerManager.PlayerInstance.PlayerRequireExp * 113 / 100;
        else
            reqExp = PlayerManager.PlayerInstance.ealryRequireExpArray[PlayerManager.PlayerInstance.PlayerLV];

        return reqExp;
    }
}
