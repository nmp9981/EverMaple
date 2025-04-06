using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float speed = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        //입력(-1~1 반환)
        float hAxis = Input.GetAxisRaw("Horizontal");
        
        Vector3 moveVec = new Vector3(hAxis, 0, 0).normalized;//이동 방향, 정규화(대각선에서 더 빨라지는거 방지)
        transform.position += moveVec * speed * Time.deltaTime;//좌표 이동
    }
}
