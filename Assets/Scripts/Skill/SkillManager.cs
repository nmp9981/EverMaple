using UnityEngine;

//공격 범위
public enum AttackRange
{
    Near,
    Far,
    Count
}
public class SkillManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    void SkillAttack()
    {

    }
}
