using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    GameObject playerObject;

    //�÷��̾�κ����� �Ÿ�
    float distanceXFromPlayer = 15f;
    float distanceYFromPlayer = 5f;

    private void LateUpdate()
    {
        transform.position = playerObject.transform.position 
            + Vector3.back*distanceXFromPlayer + Vector3.up* distanceYFromPlayer;
    }
}
