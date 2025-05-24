using UnityEngine;

public class PlayerShadowMove : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void MoveLadderMotion(Vector3 playerPos)
    {
        if(this.gameObject.activeSelf)
            this.gameObject.transform.position = playerPos+ Vector3.down*0.5f;
    }
    public void MoveMotion(Vector3 playerPos, float hAxis)
    {
        if (this.gameObject.activeSelf)
        {
            this.gameObject.transform.position = playerPos- PlayerManager.PlayerInstance.PlayerLookDir * 0.7f;
            spriteRenderer.flipX = hAxis > 0 ? true : false;
        }
    }
}
