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
        //�Է�(-1~1 ��ȯ)
        float hAxis = Input.GetAxisRaw("Horizontal");
        
        Vector3 moveVec = new Vector3(hAxis, 0, 0).normalized;//�̵� ����, ����ȭ(�밢������ �� �������°� ����)
        transform.position += moveVec * speed * Time.deltaTime;//��ǥ �̵�
    }
}
