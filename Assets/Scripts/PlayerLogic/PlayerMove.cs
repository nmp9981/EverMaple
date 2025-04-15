using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{ 
    int jumpCount = 0;
    float distance;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid = null;

   
    [SerializeField] LayerMask layerMask = 0;
   
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        distance = GetComponent<BoxCollider2D>().bounds.extents.y + 0.05f;//플레이어 발밑까지 감지
    }

    void Update()
    {
        CheckGround();
    }

    /// <summary>
    /// 캐릭터 이동
    /// </summary>
    /// <param name="hAxis">좌우 이동량</param>
    /// <param name="vAxis">상하 이동량</param>
    public void Move(float hAxis, float vAxis)
    {
        //이동량이 없음
        if (hAxis == 0 && vAxis == 0)
        {
            PlayerAnimation.StandAnim();
            return;
        }
        
        //사다리 타는 중인가?
        if (Ladder.isPlayerinLadder)
        {
            rigid.gravityScale = 0;//중력끄기
            Vector3 moveVec = new Vector3(hAxis, vAxis, 0).normalized;//이동 방향
            transform.position += moveVec * PlayerManager.PlayerInstance.PlayerMoveSpeed * Time.deltaTime;//실제 이동
            if (vAxis != 0)
            {
                PlayerAnimation.LadderAnim();
            }
        }
        else
        {
            rigid.gravityScale = 1;//중력켜기
            Vector3 moveVec = new Vector3(hAxis, 0, 0).normalized;//이동 방향
            transform.position += moveVec * PlayerManager.PlayerInstance.PlayerMoveSpeed * Time.deltaTime;//실제 이동
            spriteRenderer.flipX = hAxis > 0 ? true : false;//이동방향을 바라보게
            PlayerAnimation.MoveAnim();
        }
    }

    /// <summary>
    /// 점프
    /// </summary>
    public void TryJump()
    {
        if (jumpCount < PlayerManager.PlayerInstance.MaxJumpCount)//점프 횟수 남음
        {
            jumpCount++;
            rigid.linearVelocity = Vector3.up * PlayerManager.PlayerInstance.JumpForce;
            PlayerAnimation.JumpAnim();
        }
    }

    /// <summary>
    /// 땅에 닿았는지 체크
    /// </summary>
    void CheckGround()
    {
        //사다리 타는중에는 작동안함
        if (Ladder.isPlayerinLadder)
        {
            jumpCount = 0;
            return;
        }

        if (rigid.linearVelocity.y < 0)//낙하할 때만
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, distance, layerMask);
            
            //맞은 물체가 없음
            if(hit.collider == null)
            {
                return;
            }

            //발밑에 땅이 닿으면 점프 초기화
            if (hit.collider.gameObject.CompareTag("Ground"))
            {
                jumpCount = 0;
            }
        }

    }

}
