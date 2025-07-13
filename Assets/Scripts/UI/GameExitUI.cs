using UnityEngine;

public class GameExitUI : MonoBehaviour
{
    /// <summary>
    /// 게임 나가기
    /// </summary>
    public void ExitGame()
    {
#if UNITY_EDITOR //에디터에서
        UnityEditor.EditorApplication.isPlaying = false;
#else //나머지
        Application.Quit(); // 어플리케이션 종료
#endif
    }

    /// <summary>
    /// 게임 종료 취소
    /// </summary>
    public void CancelExitGame()
    {
        gameObject.SetActive(false);
    }
}
