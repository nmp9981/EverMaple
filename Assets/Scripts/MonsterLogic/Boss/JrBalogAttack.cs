using UnityEngine;

public class JrBalogAttack : MonoBehaviour
{
    //���� �̵�
    private float monsterActionTime = 0;
    private float monsterActionCoolTime = 1f;
    
    [SerializeField]
    protected GameObject throwBall;//����ü

    MonsterAttack jrBloagObj;
    Animator anim;
    SpriteRenderer spriteRenderer;

    void Update()
    {
        MonsterActionAI();
        Timeflow();
    }
    private void OnEnable()
    {
        jrBloagObj = GetComponent<MonsterAttack>();
        anim = GetComponent<Animator>();

        //��������Ʈ ����
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;
    }

    /// <summary>
    /// ���� �ൿ AI
    /// </summary>
    void MonsterActionAI()
    {
        //�ൿ ���� (������ �ƴϰų� �ӽ����϶��� ����)
        if (monsterActionTime >= monsterActionCoolTime)
        {
            //�������� �Ǵ� (�̵� or ����)����
            int ranDivNum = (jrBloagObj.monsterCurHP < jrBloagObj.monsterMaxHP) ? 4 : 2;
            int ranNum = Random.Range(0, 8) % ranDivNum;

            switch (ranNum)
            {
                case 0://���ֱ�
                    StandState();
                    break;
                case 1://���� �ٲٸ鼭 �̵�
                    jrBloagObj.ChangeMoveDirection();
                    jrBloagObj.MoveState();
                    break;
                case 2://�����ϱ� (���� HP < Max HP �϶��� �ߵ�)
                case 3:
                    DecideMonsterAttackMethod();
                    break;
                default:
                    break;
            }
            monsterActionTime = 0;
        }
    }

    /// <summary>
    /// �ð� �帧
    /// </summary>
    void Timeflow()
    {
        monsterActionTime += Time.deltaTime;
    }

    /// <summary>
    /// ���ִ� ����
    /// </summary>
    void StandState()
    {
        jrBloagObj.monsterMoveSpeed = 0;
        anim.SetBool("IsStand", true);
        anim.SetBool("IsMove", false);
        anim.SetBool("IsHit", false);
    }

    /// <summary>
    /// ���� ����
    /// </summary>
    void AttackState(int attackNum)
    {
        anim.SetInteger("AttackNum", attackNum);
        jrBloagObj.monsterMoveSpeed = 0;
        Invoke("StandState", 0.4f);
    }

    /// <summary>
    /// ���� ���� ��� �ᵢ
    /// </summary>
    void DecideMonsterAttackMethod()
    {
        int ran = Random.Range(1, 4);
        switch (ran)
        {
            case 1:
                MonsterToPlayerAttack();
                break;
            case 2:
                MonsterToPlayerAttack();
                break;
            case 3:
                MonsterToPlayerAttack();
                break;
        }
        AttackState(ran);
    }

    //���Ͱ� ����
    void MonsterToPlayerAttack()
    { 
        //���Ͱ� �̹� ����
        if (!gameObject.activeSelf)
            return;

        //����ü ������Ʈ ����
        MonsterMagicAttack throwObj = Instantiate(throwBall).GetComponent<MonsterMagicAttack>();

        throwObj.transform.position = gameObject.transform.position + throwObj.marginYPos * Vector3.down;
        throwObj.startPos = throwObj.transform.position;
        throwObj.sideValue = 1;

        //�����
        if (throwObj.isSide)
        {
            MonsterMagicAttack throwObj2 = Instantiate(throwBall).GetComponent<MonsterMagicAttack>();
            throwObj2.transform.position = gameObject.transform.position + throwObj.marginYPos * Vector3.down;
            throwObj2.startPos = throwObj.transform.position;
            throwObj2.sideValue = -1;
        }
    }
}
