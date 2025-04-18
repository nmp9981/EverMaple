using UnityEngine;

public class Portal : MapManager
{
    [SerializeField]
    int nextPortalNode;//다음 포탈 번호

    [SerializeField]
    int nextMapNum;//다음 맵 번호

    //포탈 사용 가능 여부
    bool isAblePortal = false;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            isAblePortal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            isAblePortal = false;
        }
    }

    private void Update()
    {
        if (isDownUpKey)
        {
            CheckToPortal();
        }
    }

    /// <summary>
    /// 포탈로 이동가능한지 체크
    /// </summary>
    public void CheckToPortal()
    {
        //포탈 활성화일 경우에만 이동 가능
        if (!isAblePortal) return;
        //포탈로 다음 맵 이동
        MoveToPortal(nextPortalNode, nextMapNum);
    }
}
