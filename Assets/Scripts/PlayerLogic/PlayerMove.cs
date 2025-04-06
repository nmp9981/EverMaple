using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{ 
    [SerializeField] float jumpForce;//점프력
    [SerializeField] int maxJumpCount;//점프 최대 횟수
    float speed = 4f;
    int jumpCount = 0;

    Rigidbody2D rigid = null;

    float distance;
    [SerializeField] LayerMask layerMask = 0;
   
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        distance = GetComponent<BoxCollider2D>().bounds.extents.y + 0.05f;//플레이어 발밑까지 감지
    }

    void Update()
    {
        CheckGround();
    }
    public void Move(float hAxis)
    {
        //이동량이 없음
        if (hAxis == 0)
        {
            return;
        }
        
        Vector3 moveVec = new Vector3(hAxis, 0, 0).normalized;//이동 방향
        transform.position += moveVec * speed * Time.deltaTime;//실제 이동
    }
   
    public void TryJump()
    {
        if (jumpCount < maxJumpCount)//점프 횟수 남음
        {
            jumpCount++;
            rigid.linearVelocity = Vector3.up * jumpForce;
        }
    }
    void CheckGround()
    {
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
