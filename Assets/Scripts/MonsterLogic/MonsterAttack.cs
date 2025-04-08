using UnityEngine;

public class MonsterInfo : MonoBehaviour
{
    public int monsterLv;
    public float monsterMaxHP;
    public int monsterExp;
    public int monsterMeso;

    int monsterCurHP;
}


public class MonsterAttack : MonsterInfo
{
    
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
