using Cysharp.Threading.Tasks;
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

    //ĳ���� ũ��
    Bounds playerBound = default;

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerBound = player.GetComponent<BoxCollider2D>().bounds;
        playerInfoUI = GameObject.Find("UserInfo").GetComponent<PlayerInfoUI>();
        playerAttack = player.GetComponent<PlayerAttack>();
        throwObjectFulling = GetComponent<ThrowObjectFulling>();
    }

    /// <summary>
    /// MP �Ҹ�
    /// </summary>
    private void DecreasePlayerMP(int spendMP)
    {
        PlayerManager.PlayerInstance.PlayerCurMP = Mathf.Max(0, PlayerManager.PlayerInstance.PlayerCurMP - spendMP);
        playerInfoUI.ShowPlayerMPBar();
    }
   
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

        for (int i = 0; i < hitNum; i++)
        {
            ThrowObjectFunction throwObj = throwObjectFulling.MakeObj(0).GetComponent<ThrowObjectFunction>();
            throwObj.transform.position = player.transform.position + 0.5f * PlayerManager.PlayerInstance.PlayerLookDir;
            throwObj.startPos = throwObj.transform.position;
            throwObj.hitNum = i;
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

        for (int i = 0; i < hitNum; i++)
        {
            ThrowObjectFunction throwObj = throwObjectFulling.MakeObj(0).GetComponent<ThrowObjectFunction>();
            throwObj.transform.position = player.transform.position + 0.5f * PlayerManager.PlayerInstance.PlayerLookDir;
            throwObj.startPos = throwObj.transform.position;
            throwObj.hitNum = i;
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
    public async UniTask Avenger()
    {
        //MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 30)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(30);

        //���� ���
        PlayerAnimation.AttackAnim();

        ThrowAvengerFunction throwObj = throwObjectFulling.MakeObj(10).GetComponent<ThrowAvengerFunction>();
        throwObj.transform.position = player.transform.position + 0.5f * PlayerManager.PlayerInstance.PlayerLookDir;
        throwObj.startPos = throwObj.transform.position;
        throwObj.hitNum = 0;
        throwObj.skillCoefficient = SkillDamageCalCulate.AvengerCoff;
    }

    public async UniTask BumerangStep(int hitNum)
    {
        //MP�˻�
        if (PlayerManager.PlayerInstance.PlayerCurMP < 26)
            return;

        //MP �Ҹ�
        DecreasePlayerMP(26);

        //���� ���
        PlayerAnimation.AttackAnim();

        for (int i = 0; i < hitNum; i++)
        {
            ThrowObjectFunction throwObj = throwObjectFulling.MakeObj(0).GetComponent<ThrowObjectFunction>();
            throwObj.transform.position = player.transform.position + 0.5f * PlayerManager.PlayerInstance.PlayerLookDir;
            throwObj.startPos = throwObj.transform.position;
            throwObj.hitNum = i;
            throwObj.skillCoefficient = SkillDamageCalCulate.TripleThrowCoff;

            await UniTask.Delay(PlayerManager.PlayerInstance.PlayerAttackSpeed / 6);
        }
    }
}
