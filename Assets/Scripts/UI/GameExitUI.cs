using UnityEngine;

public class GameExitUI : MonoBehaviour
{
    /// <summary>
    /// ���� ������
    /// </summary>
    public void ExitGame()
    {
#if UNITY_EDITOR //�����Ϳ���
        UnityEditor.EditorApplication.isPlaying = false;
#else //������
        Application.Quit(); // ���ø����̼� ����
#endif
    }

    /// <summary>
    /// ���� ���� ���
    /// </summary>
    public void CancelExitGame()
    {
        gameObject.SetActive(false);
    }
}
