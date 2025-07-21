using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

//���� ����
public enum AttackRange
{
    Near,
    Far,
    Count
}

public static class SkillLvManager
{
    public static int hasteLv;
    public static int boosterLv;
    public static int shadowPartnerLv;
    public static int mesoUpLv;
    public static int mesoGuardLv;
    public static int mapleWarriorLv;
}
public class SkillManager : MonoBehaviour
{
    GameObject player;
    PlayerInfoUI playerInfoUI;
    PlayerAttack playerAttack;
    ThrowObjectFulling throwObjectFulling;
    SkillEffectManager skillEffectManager;

    //ĳ���� ũ��
    Bounds playerBound = default;

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerBound = player.GetComponent<BoxCollider2D>().bounds;
        playerInfoUI = GameObject.Find("UserInfo").GetComponent<PlayerInfoUI>();
        playerAttack = player.GetComponent<PlayerAttack>();
        throwObjectFulling = GetComponent<ThrowObjectFulling>();
        skillEffectManager = GetComponent<SkillEffectManager>();
    }

    /// <summary>
    /// MP �Ҹ�
    /// </summary>
    public void DecreasePlayerMP(int spendMP)
    {
        PlayerManager.PlayerInstance.PlayerCurMP = Mathf.Max(0, PlayerManager.PlayerInstance.PlayerCurMP - spendMP);
        playerInfoUI.ShowPlayerMPBar();
    }
    /// <summary>
    /// HP �Ҹ�
    /// </summary>
    public void DecreasePlayerHP(int spendHP)
    {
        PlayerManager.PlayerInstance.PlayerCurHP = Mathf.Max(0, PlayerManager.PlayerInstance.PlayerCurHP - spendHP);
        playerInfoUI.ShowPlayerHPBar();
    }

    #region ���� ��ų
    //��Ű ����
    public async UniTask LuckySeven(int hitNum)
    {
        //���� ����
        if (PlayerManager.PlayerInstance.PlayerAttackWeapon == AttachWeapon.Knife)
            return;

        //��ų ���� 0
        if (SkillDamageCalCulate.LuckySevenLv == 0)
            return;

        //MP�˻�
        int spendMP = 6 + SkillDamageCalCulate.LuckySevenLv / 2;
        if (PlayerManager.PlayerInstance.PlayerCurMP < spendMP)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(spendMP);

        //���� ���
        PlayerAnimation.AttackAnim();

        //������ ��Ʈ�� ����
        if (PlayerManager.PlayerInstance.IsShadowPartner)
            hitNum *= 2;

        //����Ʈ
        skillEffectManager.PlaySkillAnimation("LuckySeven", 0.5f, 0);

        //����
        SoundManager._sound.PlaySfx(4);

        for (int i = 0; i < hitNum; i++)
        {
            ThrowObjectFunction throwObj = throwObjectFulling.MakeObj(PlayerManager.PlayerInstance.ShootDragNum).GetComponent<ThrowObjectFunction>();
            throwObj.transform.position = player.transform.position + 0.5f * PlayerManager.PlayerInstance.PlayerLookDir;
            throwObj.startPos = throwObj.transform.position;
            throwObj.hitNum = i;

            if(i>=hitNum/2)
                throwObj.skillCoefficient = (SkillDamageCalCulate.LuckySevenCoff*SkillDamageCalCulate.ShadowPartnerCoff)/100;
            else
                throwObj.skillCoefficient = SkillDamageCalCulate.LuckySevenCoff;

            await UniTask.Delay(PlayerManager.PlayerInstance.PlayerAttackSpeed/4);
        }
    }
    //Ʈ���� ���ο�
    public async UniTask TripleThrow(int hitNum)
    {
        //���� ����
        if (PlayerManager.PlayerInstance.PlayerAttackWeapon == AttachWeapon.Knife)
            return;

        //��ų ���� 0
        if (SkillDamageCalCulate.TripleThrowLv == 0)
            return;

        //MP�˻�
        int spendMP = 10 + (SkillDamageCalCulate.TripleThrowLv + 2) / 3;
        if (PlayerManager.PlayerInstance.PlayerCurMP < spendMP)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(spendMP);

        //���� ���
        PlayerAnimation.AttackAnim();

        //������ ��Ʈ�� ����
        if (PlayerManager.PlayerInstance.IsShadowPartner)
            hitNum *= 2;

        //����Ʈ
        skillEffectManager.PlaySkillAnimation("TripleThrow", 0.5f, 0);

        //����
        SoundManager._sound.PlaySfx(15);

        for (int i = 0; i < hitNum; i++)
        {
            ThrowObjectFunction throwObj = throwObjectFulling.MakeObj(PlayerManager.PlayerInstance.ShootDragNum).GetComponent<ThrowObjectFunction>();
            throwObj.transform.position = player.transform.position + 0.5f * PlayerManager.PlayerInstance.PlayerLookDir;
            throwObj.startPos = throwObj.transform.position;
            throwObj.hitNum = i;

            if (i >= hitNum / 2)
                throwObj.skillCoefficient = (SkillDamageCalCulate.TripleThrowCoff * SkillDamageCalCulate.ShadowPartnerCoff) / 100;
            else
                throwObj.skillCoefficient = SkillDamageCalCulate.TripleThrowCoff;

            await UniTask.Delay(PlayerManager.PlayerInstance.PlayerAttackSpeed / 6);
        }
    }

    //���� ����
    public async UniTask DoubleStep(int hitNum)
    {
        //���� ����
        if (PlayerManager.PlayerInstance.PlayerAttackWeapon == AttachWeapon.Claw)
            return;

        //��ų ���� 0
        if (SkillDamageCalCulate.DoubleStepLv == 0)
            return;

        //MP�˻�
        int spendMP = 7 + (SkillDamageCalCulate.DoubleStepLv+1) / 3;
        if (PlayerManager.PlayerInstance.PlayerCurMP < spendMP)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(spendMP);

        //���� ���
        PlayerAnimation.AttackAnim();

        //���� ���� ũ��
        float attackBoundSize = 3f;

        //�÷��̾ �ٶ󺸴� ����
        Vector3 lookDir = PlayerManager.PlayerInstance.PlayerLookDir;
        //���� ���� ����
        Bounds attackBound = playerAttack.SettingAttackArea(lookDir, attackBoundSize);

        //����Ʈ
        if(lookDir.x<0)//����
            skillEffectManager.PlaySkillAnimation("DoubleStep", 0.5f, 0);
        else//������
            skillEffectManager.PlaySkillAnimation("DoubleStep2", 0.5f, 0);

        //����
        SoundManager._sound.PlaySfx(3);

        //�÷��̾�κ��� ���� �����̿� �ִ� ���� ���ϱ�
        GameObject nearMob = PlayerAttackCommon.NearMonserFromPlayer(lookDir, player.transform.position, attackBoundSize * 2);

        //���Ͱ� ������ �Ʒ� ������ ���������ʰ� �ߴ�
        if (nearMob == null)
        {
            return;
        }
       
        //���Ͱ� ĳ������ ���� �ݰ� ���� �ִ°�?
        Bounds nearMobArea = nearMob.GetComponent<Collider2D>().bounds;
        if (PlayerAttackCommon.IsMonsterInPlayerAttackArea(nearMobArea, attackBound))
        {
            for (int i = 1; i <= hitNum; i++)
            {
                PlayerAttackCommon.PlayerAttackToOneMonster(nearMob, SkillDamageCalCulate.DoubleStepCoff, i);
                await UniTask.Delay(PlayerManager.PlayerInstance.PlayerAttackSpeed / 5);
            }               
        }
    }
    //������ ��ο�
    public async UniTask Savageblow(int hitNum)
    {
        //���� ����
        if (PlayerManager.PlayerInstance.PlayerAttackWeapon == AttachWeapon.Claw)
            return;

        //��ų ���� 0
        if (SkillDamageCalCulate.SavageblowLv == 0)
            return;

        //MP�˻�
        int spendMP = 9* ((SkillDamageCalCulate.SavageblowLv+9) / 10);
        if (PlayerManager.PlayerInstance.PlayerCurMP < spendMP)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(spendMP);

        //���� ���
        PlayerAnimation.AttackAnim();

        //���� ���� ũ��
        float attackBoundSize = 3f;

        //�÷��̾ �ٶ󺸴� ����
        Vector3 lookDir = PlayerManager.PlayerInstance.PlayerLookDir;
        //���� ���� ����
        Bounds attackBound = playerAttack.SettingAttackArea(lookDir, attackBoundSize);

        //����Ʈ
        skillEffectManager.PlaySkillAnimation("SavageBlow", 0.5f,0);

        //����
        SoundManager._sound.PlaySfx(11);

        //�÷��̾�κ��� ���� �����̿� �ִ� ���� ���ϱ�
        GameObject nearMob = PlayerAttackCommon.NearMonserFromPlayer(lookDir, player.transform.position, attackBoundSize * 2);

        //���Ͱ� ������ �Ʒ� ������ ���������ʰ� �ߴ�
        if (nearMob == null)
        {
            return;
        }

        //���Ͱ� ĳ������ ���� �ݰ� ���� �ִ°�?
        Bounds nearMobArea = nearMob.GetComponent<Collider2D>().bounds;
        if (PlayerAttackCommon.IsMonsterInPlayerAttackArea(nearMobArea, attackBound))
        {
            for (int i = 1; i <= hitNum; i++)
            {
                PlayerAttackCommon.PlayerAttackToOneMonster(nearMob, SkillDamageCalCulate.SavageblowCoff, i);
                SoundManager._sound.PlaySfx(12);
                await UniTask.Delay(PlayerManager.PlayerInstance.PlayerAttackSpeed / 6);
            }
        }
    }
    //���
    public async UniTask Avenger(int hitNum)
    {
        //���� ����
        if (PlayerManager.PlayerInstance.PlayerAttackWeapon == AttachWeapon.Knife)
            return;

        //��ų ���� 0
        if (SkillDamageCalCulate.AvengerLv == 0)
            return;

        //MP�˻�
        int spendMP = 9+7 * ((SkillDamageCalCulate.AvengerLv + 9 )/ 10);
        if (PlayerManager.PlayerInstance.PlayerCurMP < spendMP)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(spendMP);

        //���� ���
        PlayerAnimation.AttackAnim();

        //������ ��Ʈ�� ����
        if (PlayerManager.PlayerInstance.IsShadowPartner)
            hitNum *= 2;

        //����Ʈ
        skillEffectManager.PlaySkillAnimation("Avenger", -0.5f, 0);

        //����
        SoundManager._sound.PlaySfx(14);

        for (int i = 0; i < hitNum; i++)
        {
            ThrowAvengerFunction throwObj = throwObjectFulling.MakeObj(10).GetComponent<ThrowAvengerFunction>();
            throwObj.transform.position = player.transform.position + 0.5f * PlayerManager.PlayerInstance.PlayerLookDir;
            throwObj.startPos = throwObj.transform.position;
            throwObj.hitNum = i;
            throwObj.skillCoefficient = SkillDamageCalCulate.AvengerCoff;

            if(i==0)
                throwObj.skillCoefficient = SkillDamageCalCulate.AvengerCoff;
            else
                throwObj.skillCoefficient = (SkillDamageCalCulate.AvengerCoff*SkillDamageCalCulate.ShadowPartnerCoff)/100;

            await UniTask.Delay(PlayerManager.PlayerInstance.PlayerAttackSpeed / 4);
        }
    }

    //�θ޶� ����
    public async UniTask BumerangStep(int hitNum)
    {
        //���� ����
        if (PlayerManager.PlayerInstance.PlayerAttackWeapon == AttachWeapon.Claw)
            return;

        //��ų ���� 0
        if (SkillDamageCalCulate.BumerangStepLv == 0)
            return;

        //MP�˻�
        int spendMP = 13 + 3 * ((SkillDamageCalCulate.BumerangStepLv + 5 )/ 6);
        if (PlayerManager.PlayerInstance.PlayerCurMP < spendMP)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(spendMP);

        //���� ���
        PlayerAnimation.AttackAnim();

        //����Ʈ
        skillEffectManager.PlaySkillAnimation("BumerangStep", 2f, 0);

        //����
        SoundManager._sound.PlaySfx(8);

        BumerangStepClass throwObj = throwObjectFulling.MakeObj(11).GetComponent<BumerangStepClass>();
        throwObj.transform.position = player.transform.position + 0.5f * PlayerManager.PlayerInstance.PlayerLookDir;
        throwObj.startPos = throwObj.transform.position;
        throwObj.skillCoefficient = SkillDamageCalCulate.BumerangStepCoff;
    }
    //�ú���
    public async UniTask Thieves()
    {
        //���� ����
        if (PlayerManager.PlayerInstance.PlayerAttackWeapon == AttachWeapon.Claw)
            return;

        //��ų ���� 0
        if (SkillDamageCalCulate.ThievesLv == 0)
            return;

        //MP�˻�
        int spendMP = 10 * ((SkillDamageCalCulate.ThievesLv + 9)/ 10);
        if (PlayerManager.PlayerInstance.PlayerCurMP < spendMP)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(spendMP);

        //���� ���
        PlayerAnimation.AttackAnim();

        //���� ���� ũ��
        float attackXSize = 16f;
        float attackYSize = 3f;

        //�÷��̾ �ٶ󺸴� ����
        Vector3 lookDir = PlayerManager.PlayerInstance.PlayerLookDir;

        //��ų ������
        Vector3 skillStartPos = player.transform.position - attackXSize * 0.5f * lookDir;

        //����Ʈ
        skillEffectManager.PlaySkillAnimation("Thivse", 0.01f, 0);

        //����
        SoundManager._sound.PlaySfx(17);

        //�÷��̾�κ��� ���� �����̿� �ִ� ���͵� ���ϱ�
        List<GameObject> nearMobList 
            = PlayerAttackCommon.TargetMonstersFromPlayer(lookDir, skillStartPos, attackXSize, attackYSize,SkillDamageCalCulate.ThivseTargetNum );

        //���Ͱ� ������ �Ʒ� ������ ���������ʰ� �ߴ�
        if (nearMobList == null)
        {
            return;
        }

        //���͵� ����
        int thivseCount = 0;
        foreach(var nearMob in nearMobList)
        {
            thivseCount += 1;
            skillEffectManager.PlayThivseSkillAnimation("Thivse", thivseCount,nearMob.transform.position ,0, 0.5f);
            PlayerAttackCommon.PlayerAttackToOneMonster(nearMob, SkillDamageCalCulate.ThievesCoff, 0);
        }
    }
    //�����
    public async UniTask Assertor()
    {
        //���� ����
        if (PlayerManager.PlayerInstance.PlayerAttackWeapon == AttachWeapon.Claw)
            return;

        //��ų ���� 0
        if (SkillDamageCalCulate.AssertorLv == 0)
            return;

        //MP�˻�
        int spendMP = 5 + 7 * ((SkillDamageCalCulate.AssertorLv+ 9) / 10);
        if (PlayerManager.PlayerInstance.PlayerCurMP < spendMP)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(spendMP);

        //���� ���
        PlayerAnimation.AttackAnim();

        //���� ���� ũ��
        float attackBoundSize = 6f;

        //�÷��̾ �ٶ󺸴� ����
        Vector3 lookDir = PlayerManager.PlayerInstance.PlayerLookDir;
        //���� ���� ����
        Bounds attackBound = playerAttack.SettingAttackArea(lookDir, attackBoundSize);

        //����Ʈ
        skillEffectManager.PlaySkillAnimation("Assertor", 0.5f, 0);

        //����
        SoundManager._sound.PlaySfx(34);

        //�÷��̾�κ��� ���� �����̿� �ִ� ���� ���ϱ�
        GameObject nearMob = PlayerAttackCommon.NearMonserFromPlayer(lookDir, player.transform.position, attackBoundSize * 2);

        //���Ͱ� ������ �Ʒ� ������ ���������ʰ� �ߴ�
        if (nearMob == null)
        {
            return;
        }

        //���� ������ �ȵ�
        RaycastHit2D hit = Physics2D.Raycast(
            new Vector2(player.transform.position.x, player.transform.position.y), 
            new Vector2(lookDir.x, lookDir.y), attackBoundSize*1.5f,1<<12);
        if (hit.collider)
        {
            return;
        }

        //���Ͱ� ĳ������ ���� �ݰ� ���� �ִ°�?
        Bounds nearMobArea = nearMob.GetComponent<Collider2D>().bounds;
        if (PlayerAttackCommon.IsMonsterInPlayerAttackArea(nearMobArea, attackBound))
        {
            player.transform.position = new Vector3(player.transform.position.x + attackBoundSize * lookDir.x, nearMobArea.center.y+0.1f, 0);
            PlayerAttackCommon.PlayerAttackToOneMonster(nearMob, SkillDamageCalCulate.AssertorCoff, 0);
        }
    }
    #endregion

    #region ���� ��ų
    public void UseHasteSkill()
    {
        //��ų�� ���� �ȹ��
        if (SkillLvManager.hasteLv <= 0)
            return;

        //MP�˻�
        int spendMP = SkillLvManager.hasteLv<=10? 15:30;
        if (PlayerManager.PlayerInstance.PlayerCurMP < spendMP)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(spendMP);
        
        //����
        SoundManager._sound.PlaySfx(18);

        //���� ����
        if (ItemManager.itemInstance.buffItemList[10].activeSelf)
            ItemManager.itemInstance.buffItemList[10].SetActive(false);
        ItemManager.itemInstance.buffItemList[10].SetActive(true);
    }

    public void UseJavelinBoosterSkill()
    {
        //��ų�� ���� �ȹ��
        if (SkillLvManager.boosterLv <= 0)
            return;

        //HP, MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 30 - SkillLvManager.boosterLv || PlayerManager.PlayerInstance.PlayerCurHP <= 30 - SkillLvManager.boosterLv)
            return;

        //HP, MP �Ҹ�
        DecreasePlayerHP(30 - SkillLvManager.boosterLv);
        DecreasePlayerMP(30 - SkillLvManager.boosterLv);

        //����
        SoundManager._sound.PlaySfx(10);

        //���� ����
        if (ItemManager.itemInstance.buffItemList[11].activeSelf)
            ItemManager.itemInstance.buffItemList[11].SetActive(false);
        ItemManager.itemInstance.buffItemList[11].SetActive(true);
    }
    public void UseDagerBoosterSkill()
    {
        //��ų�� ���� �ȹ��
        if (SkillLvManager.boosterLv <= 0)
            return;

        //HP, MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 30 - SkillLvManager.boosterLv || PlayerManager.PlayerInstance.PlayerCurHP <= 30 - SkillLvManager.boosterLv)
            return;

        //HP, MP �Ҹ�
        DecreasePlayerHP(30-SkillLvManager.boosterLv);
        DecreasePlayerMP(30 - SkillLvManager.boosterLv);

        //����
        SoundManager._sound.PlaySfx(10);

        //���� ����
        if (ItemManager.itemInstance.buffItemList[12].activeSelf)
            ItemManager.itemInstance.buffItemList[12].SetActive(false);
        ItemManager.itemInstance.buffItemList[12].SetActive(true);
    }
    public void UseShadowPartnerSkill()
    {
        //��ų�� ���� �ȹ��
        if (SkillLvManager.shadowPartnerLv <= 0)
            return;

        //MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 205-SkillLvManager.shadowPartnerLv*5)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(205 - SkillLvManager.shadowPartnerLv * 5);

        //����
        SoundManager._sound.PlaySfx(13);

        //���� ����
        if (ItemManager.itemInstance.buffItemList[13].activeSelf)
            ItemManager.itemInstance.buffItemList[13].SetActive(false);
        ItemManager.itemInstance.buffItemList[13].SetActive(true);
    }
    public void UseMesoUPSkill()
    {
        //��ų�� ���� �ȹ��
        if (SkillLvManager.mesoUpLv <= 0)
            return;

        //MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 60)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(60);

        //����
        SoundManager._sound.PlaySfx(6);

        //���� ����
        if (ItemManager.itemInstance.buffItemList[14].activeSelf)
            ItemManager.itemInstance.buffItemList[14].SetActive(false);
        ItemManager.itemInstance.buffItemList[14].SetActive(true);
    }
    public void UseMesoGuardSkill()
    {
        //��ų�� ���� �ȹ��
        if (SkillLvManager.mesoGuardLv <= 0)
            return;

        //MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 35)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(35);

        //����
        SoundManager._sound.PlaySfx(5);

        //���� ����
        if (ItemManager.itemInstance.buffItemList[15].activeSelf)
            ItemManager.itemInstance.buffItemList[15].SetActive(false);
        ItemManager.itemInstance.buffItemList[15].SetActive(true);
    }
    public void UseMapleWarriorSkill()
    {
        //��ų�� ���� �ȹ��
        if (SkillLvManager.mapleWarriorLv <= 0)
            return;

        //MP�˻�
        int spendMP = 10 * SkillLvManager.mapleWarriorLv / 5+10;
        if (PlayerManager.PlayerInstance.PlayerCurMP < spendMP)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(spendMP);

        //����
        SoundManager._sound.PlaySfx(7);

        //���� ����
        if (ItemManager.itemInstance.buffItemList[16].activeSelf)
            ItemManager.itemInstance.buffItemList[16].SetActive(false);
        ItemManager.itemInstance.buffItemList[16].SetActive(true);
    }
    #endregion
}
