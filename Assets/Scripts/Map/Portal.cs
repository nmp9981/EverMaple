using UnityEngine;

public class Portal : MapManager
{
    [SerializeField]
    int nextPortalNode;//���� ��Ż ��ȣ

    [SerializeField]
    int nextMapNum;//���� �� ��ȣ

    //��Ż ��� ���� ����
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
    /// ��Ż�� �̵��������� üũ
    /// </summary>
    public void CheckToPortal()
    {
        //��Ż Ȱ��ȭ�� ��쿡�� �̵� ����
        if (!isAblePortal) return;
        //��Ż�� ���� �� �̵�
        MoveToPortal(nextPortalNode, nextMapNum);
    }
}
