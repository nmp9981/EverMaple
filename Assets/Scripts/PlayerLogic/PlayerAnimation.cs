using UnityEngine;

//플레이어 상태
public enum PlayerState
{
    Stand,
    AttackReady,
    Walk,
    Jump,
    AttackSwing,
    AttackStab,
    Dead,
    Count
}

public class PlayerAnimation : MonoBehaviour
{
    Animation animation;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
