using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
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
            ThrowObjectFunction throwObj = throwObjectFulling.MakeObj(0).GetComponent<ThrowObjectFunction>();
            throwObj.hitNum = i;
            throwObj.startPos = player.transform.position;
            await UniTask.Delay(PlayerManager.PlayerInstance.PlayerAttackSpeed/3);
        }
    }

    
}
