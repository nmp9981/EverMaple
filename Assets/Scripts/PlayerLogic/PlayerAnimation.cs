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
        animator.SetBool("IsLadder", false);
    }
  
    public static void MoveAnim()
    {
        AttackResetAnim();
        animator.SetBool("IsLadder", false);
        animator.SetBool("IsWalk", true);
    }
    public static void StandAnim()
    {
        animator.SetBool("IsWalk", false);
        animator.SetBool("IsJump", false);
        if (animator.GetBool("IsLadder"))
        {
            animator.SetBool("IsLadder", true);
        }
        else
        {
            animator.SetBool("IsLadder", false);
        }
        AttackResetAnim();
    }
    public static void JumpAnim()
    {
        animator.SetBool("IsLadder", false);
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
    public static void LadderAnim()
    {
        animator.SetBool("IsJump", false);
        animator.SetBool("IsWalk", false);
        animator.SetBool("IsLadder", true);
    }
    public static void LevelUPAnim()
    {
        animator.transform.position += Vector3.up * 3f;
        animator.Play("LevelUP");
        animator.transform.position -= Vector3.up * 3f;
    }
}
