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
        //���� ���
        PlayerAnimation.AttackAnim();

        //MP �Ҹ�
        DecreasePlayerMP(16);

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

    //���� ����
    public async UniTask DoubleStep(int hitNum)
    {
        //���� ���
        PlayerAnimation.AttackAnim();

        //MP �Ҹ�
        DecreasePlayerMP(14);

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
                PlayerAttackCommon.PlayerAttackToOneMonster(nearMob, 140,i);
                await UniTask.Delay(PlayerManager.PlayerInstance.PlayerAttackSpeed / 5);
            }               
        }
    }
}
