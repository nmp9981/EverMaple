using UnityEngine;

public class JrBalogAttack : MonoBehaviour
{
    //몬스터 이동
    private float monsterActionTime = 0;
    private float monsterActionCoolTime = 1.5f;
    
    [SerializeField]
    protected GameObject throwBall;//투사체
    [SerializeField]
    protected GameObject throwBall2;//투사체

    [SerializeField]
    private Animator animSelf;
    [SerializeField]
    private Animator animToPlayer;

    GameObject player;
    MonsterAttack jrBloagObj;
    Animator anim;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        MonsterActionAI();
        Timeflow();
    }
    private void OnEnable()
    {
        jrBloagObj = GetComponent<MonsterAttack>();
        anim = GetComponent<Animator>();

        //스프라이트 관련
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;
    }

    /// <summary>
    /// 몬스터 행동 AI
    /// </summary>
    void MonsterActionAI()
    {
        //행동 결정 (보스가 아니거나 머쉬맘일때만 적용)
        if (monsterActionTime >= monsterActionCoolTime)
        {
            //서있을지 또는 (이동 or 공격)할지
            int ranDivNum = (jrBloagObj.monsterCurHP < jrBloagObj.monsterMaxHP) ? 4 : 2;
            int ranNum = Random.Range(0, 8) % ranDivNum;

            switch (ranNum)
            {
                case 0://서있기
                    StandState();
                    break;
                case 1://방향 바꾸면서 이동
                    jrBloagObj.ChangeMoveDirection();
                    jrBloagObj.MoveState();
                    break;
                case 2://공격하기 (현재 HP < Max HP 일때만 발동)
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
    /// 시간 흐름
    /// </summary>
    void Timeflow()
    {
        monsterActionTime += Time.deltaTime;
    }

    /// <summary>
    /// 서있는 상태
    /// </summary>
    void StandState()
    {
        jrBloagObj.monsterMoveSpeed = 0;
        anim.SetBool("IsStand", true);
        anim.SetBool("IsMove", false);
        anim.SetBool("IsHit", false);
    }

    /// <summary>
    /// 공격 상태
    /// </summary>
    void AttackState(int attackNum)
    {
        string playName = "MonsterAttack" + attackNum.ToString();
        anim.Play(playName);
        jrBloagObj.monsterMoveSpeed = 0;
        Invoke("StandState", 0.4f);
    }

    /// <summary>
    /// 몬스터 공격 방식 결정
    /// </summary>
    void DecideMonsterAttackMethod()
    {
        //공격 스킬 결정
        int ran = Random.Range(1, 4);
        switch (ran)
        {
            case 1:
                MonsterToMeteo();
                break;
            case 2:
                MonsterToFireBall();
                break;
            case 3:
                MonsterToClaw();
                break;
        }
        AttackState(ran);
    }

    //할퀴기
    void MonsterToClaw()
    { 
        //몬스터가 이미 죽음
        if (!gameObject.activeSelf)
            return;

        //이펙트 재생
        animSelf.Play("Attack31");

        //투사체 오브젝트 생성
        MonsterMagicAttack throwObj = Instantiate(throwBall2).GetComponent<MonsterMagicAttack>();

        throwObj.transform.position = gameObject.transform.position + throwObj.marginYPos * Vector3.down;
        throwObj.startPos = throwObj.transform.position;
        throwObj.sideValue = 1;

        //양방향
        if (throwObj.isSide)
        {
            MonsterMagicAttack throwObj2 = Instantiate(throwBall).GetComponent<MonsterMagicAttack>();
            throwObj2.transform.position = gameObject.transform.position + throwObj.marginYPos * Vector3.down;
            throwObj2.startPos = throwObj.transform.position;
            throwObj2.sideValue = -1;
        }

        //플레이어 이펙트 재생
        animToPlayer.transform.position = player.transform.position + Vector3.up*2;
        animToPlayer.Play("Attack32");
    }
    //메테오
    void MonsterToMeteo()
    {
        //몬스터가 이미 죽음
        if (!gameObject.activeSelf)
            return;

        //이펙트 재생
        animSelf.Play("Attack11");

        //투사체 오브젝트 생성
        MonsterMagicAttack throwObj = Instantiate(throwBall2).GetComponent<MonsterMagicAttack>();

        throwObj.transform.position = gameObject.transform.position + throwObj.marginYPos * Vector3.down;
        throwObj.startPos = throwObj.transform.position;
        throwObj.sideValue = 1;

        //양방향
        if (throwObj.isSide)
        {
            MonsterMagicAttack throwObj2 = Instantiate(throwBall).GetComponent<MonsterMagicAttack>();
            throwObj2.transform.position = gameObject.transform.position + throwObj.marginYPos * Vector3.down;
            throwObj2.startPos = throwObj.transform.position;
            throwObj2.sideValue = -1;
        }
        //플레이어 이펙트 재생
        animToPlayer.transform.position = player.transform.position;
        animToPlayer.Play("Attack12");
    }
    //불덩이 던지기
    void MonsterToFireBall()
    {
        //몬스터가 이미 죽음
        if (!gameObject.activeSelf)
            return;

        //투사체 오브젝트 생성
        MonsterMagicAttack throwObj = Instantiate(throwBall).GetComponent<MonsterMagicAttack>();

        throwObj.transform.position = gameObject.transform.position + throwObj.marginYPos * Vector3.down;
        throwObj.startPos = throwObj.transform.position;
        throwObj.moveSpeed = 3;
        throwObj.sideValue = 1;

        //양방향
        if (throwObj.isSide)
        {
            MonsterMagicAttack throwObj2 = Instantiate(throwBall).GetComponent<MonsterMagicAttack>();
            throwObj2.transform.position = gameObject.transform.position + throwObj.marginYPos * Vector3.down;
            throwObj2.startPos = throwObj.transform.position;
            throwObj2.sideValue = -1;
        }
    }
}
