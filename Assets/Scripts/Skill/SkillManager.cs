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
        //MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 16)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(16);

        //���� ���
        PlayerAnimation.AttackAnim();

        //������ ��Ʈ�� ����
        if (PlayerManager.PlayerInstance.IsShadowPartner)
            hitNum *= 2;

        //����Ʈ
        skillEffectManager.PlaySkillAnimation("LuckySeven", 0.5f, 0);

        for (int i = 0; i < hitNum; i++)
        {
            ThrowObjectFunction throwObj = throwObjectFulling.MakeObj(0).GetComponent<ThrowObjectFunction>();
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
        //MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 20)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(20);

        //���� ���
        PlayerAnimation.AttackAnim();

        //������ ��Ʈ�� ����
        if (PlayerManager.PlayerInstance.IsShadowPartner)
            hitNum *= 2;

        //����Ʈ
        skillEffectManager.PlaySkillAnimation("TripleThrow", 0.5f, 0);

        for (int i = 0; i < hitNum; i++)
        {
            ThrowObjectFunction throwObj = throwObjectFulling.MakeObj(0).GetComponent<ThrowObjectFunction>();
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
        //MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 14)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(14);

        //���� ���
        PlayerAnimation.AttackAnim();

        //���� ���� ũ��
        float attackBoundSize = 3f;

        //�÷��̾ �ٶ󺸴� ����
        Vector3 lookDir = PlayerManager.PlayerInstance.PlayerLookDir;
        //���� ���� ����
        Bounds attackBound = playerAttack.SettingAttackArea(lookDir, attackBoundSize);

        //����Ʈ
        skillEffectManager.PlaySkillAnimation("DoubleStep", 0.5f, 0);

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
        //MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 27)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(27);

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
                await UniTask.Delay(PlayerManager.PlayerInstance.PlayerAttackSpeed / 8);
            }
        }
    }
    //���
    public async UniTask Avenger(int hitNum)
    {
        //MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 30)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(30);

        //���� ���
        PlayerAnimation.AttackAnim();

        //������ ��Ʈ�� ����
        if (PlayerManager.PlayerInstance.IsShadowPartner)
            hitNum *= 2;

        //����Ʈ
        skillEffectManager.PlaySkillAnimation("Avenger", -0.5f, 0);

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
        //MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 26)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(26);

        //���� ���
        PlayerAnimation.AttackAnim();

        //����Ʈ
        skillEffectManager.PlaySkillAnimation("BumerangStep", 2f, 0);

        BumerangStepClass throwObj = throwObjectFulling.MakeObj(11).GetComponent<BumerangStepClass>();
        throwObj.transform.position = player.transform.position + 0.5f * PlayerManager.PlayerInstance.PlayerLookDir;
        throwObj.startPos = throwObj.transform.position;
        throwObj.skillCoefficient = SkillDamageCalCulate.BumerangStepCoff;
    }
    //�ú���
    public async UniTask Thieves()
    {
        //MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 25)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(25);

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

        //�÷��̾�κ��� ���� �����̿� �ִ� ���͵� ���ϱ�
        List<GameObject> nearMobList = PlayerAttackCommon.TargetMonstersFromPlayer(lookDir, skillStartPos, attackXSize, attackYSize, 5);

        //���Ͱ� ������ �Ʒ� ������ ���������ʰ� �ߴ�
        if (nearMobList == null)
        {
            return;
        }

        //���͵� ����
        foreach(var nearMob in nearMobList)
        {
            PlayerAttackCommon.PlayerAttackToOneMonster(nearMob, SkillDamageCalCulate.ThievesCoff, 0);
        }
    }
    //�����
    public async UniTask Assertor()
    {
        //MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 25)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(25);

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
        //MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 30)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(30);

        //���� ����
        if (ItemManager.itemInstance.buffItemList[10].activeSelf)
            ItemManager.itemInstance.buffItemList[10].SetActive(false);
        ItemManager.itemInstance.buffItemList[10].SetActive(true);
    }

    public void UseJavelinBoosterSkill()
    {
        //HP, MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 10 || PlayerManager.PlayerInstance.PlayerCurHP <= 10)
            return;

        //HP, MP �Ҹ�
        DecreasePlayerHP(10);
        DecreasePlayerMP(10);

        //���� ����
        if (ItemManager.itemInstance.buffItemList[11].activeSelf)
            ItemManager.itemInstance.buffItemList[11].SetActive(false);
        ItemManager.itemInstance.buffItemList[11].SetActive(true);
    }
    public void UseDagerBoosterSkill()
    {
        //HP, MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 10 || PlayerManager.PlayerInstance.PlayerCurHP <= 10)
            return;

        //HP, MP �Ҹ�
        DecreasePlayerHP(10);
        DecreasePlayerMP(10);

        //���� ����
        if (ItemManager.itemInstance.buffItemList[12].activeSelf)
            ItemManager.itemInstance.buffItemList[12].SetActive(false);
        ItemManager.itemInstance.buffItemList[12].SetActive(true);
    }
    public void UseShadowPartnerSkill()
    {
        //MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 55)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(55);

        //���� ����
        if (ItemManager.itemInstance.buffItemList[13].activeSelf)
            ItemManager.itemInstance.buffItemList[13].SetActive(false);
        ItemManager.itemInstance.buffItemList[13].SetActive(true);
    }
    public void UseMesoUPSkill()
    {
        //MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 60)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(60);

        //���� ����
        if (ItemManager.itemInstance.buffItemList[14].activeSelf)
            ItemManager.itemInstance.buffItemList[14].SetActive(false);
        ItemManager.itemInstance.buffItemList[14].SetActive(true);
    }
    public void UseMesoGuardSkill()
    {
        //MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 35)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(35);

        //���� ����
        if (ItemManager.itemInstance.buffItemList[15].activeSelf)
            ItemManager.itemInstance.buffItemList[15].SetActive(false);
        ItemManager.itemInstance.buffItemList[15].SetActive(true);
    }
    public void UseMapleWarriorSkill()
    {
        //MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 50)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(50);

        //���� ����
        if (ItemManager.itemInstance.buffItemList[16].activeSelf)
            ItemManager.itemInstance.buffItemList[16].SetActive(false);
        ItemManager.itemInstance.buffItemList[16].SetActive(true);
    }
    #endregion
}
