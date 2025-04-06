using UnityEngine;

public class PlayerManager : MonoBehaviour 
{
    public static PlayerManager PlayerInstance = null;

    private void Awake()
    {
        PlayerSingletonObjectLoad();
    }
   
    void PlayerSingletonObjectLoad()
    {
        if (PlayerInstance == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때
        {
            PlayerInstance = this; //내자신을 instance로 넣어줍니다.
            DontDestroyOnLoad(gameObject); //OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지
        }
        else
        {
            if (PlayerInstance != this) //instance가 내가 아니라면 이미 instance가 하나 존재하고 있다는 의미
                Destroy(this.gameObject); //둘 이상 존재하면 안되는 객체이니 방금 AWake된 자신을 삭제
        }
    }
}
