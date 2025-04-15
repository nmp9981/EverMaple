using UnityEngine;

//플레이어 상태
public enum PlayerState
{
    Stand,
    AttackReady,
    Walk,
    Jump,
    AttackSwing,
    AttackStab,
    Dead,
    Count
}

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    public static Animator animator;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("IsWalk", false);
        animator.SetBool("IsJump", false);
    }
  
    public static void MoveAnim()
    {
        AttackResetAnim();
        animator.SetBool("IsWalk", true);
    }
    public static void StandAnim()
    {
        animator.SetBool("IsWalk", false);
        animator.SetBool("IsJump", false);
        AttackResetAnim();
    }
    public static void JumpAnim()
    {
        animator.SetBool("IsJump", true);
    }
    public static void AttackAnim()
    {
        animator.SetInteger("Attack", 1);
    }
    public static void AttackResetAnim()
    {
        animator.SetInteger("Attack", 0);
    }
}
