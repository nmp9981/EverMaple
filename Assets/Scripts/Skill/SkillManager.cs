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
    ThrowObjectFulling throwObjectFulling;

    private void Awake()
    {
        player = GameObject.Find("Player");
        throwObjectFulling = GetComponent<ThrowObjectFulling>();
    }

    //��ų ����
    public async UniTask LuckySeven(int hitNum)
    {
        for(int i = 0; i < hitNum; i++)
        {
            GameObject throwObj = throwObjectFulling.MakeObj(0);
            throwObj.GetComponent<ThrowObjectFunction>().hitNum = i;
            await UniTask.Delay(PlayerManager.PlayerInstance.PlayerAttackSpeed/2);
        }
    }
}
