using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject pauseUI;

    private bool isPaused = false;

    private void Start()
    {
        // 시작 시 Pause UI 비활성화
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Pause 버튼 클릭 시 호출
    /// </summary>
    public void PauseGame()
    {
        if (isPaused)
            return;

        isPaused = true;
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }

    /// <summary>
    /// Resume 버튼 클릭 시 호출
    /// </summary>
    public void ResumeGame()
    {
        if (!isPaused)
            return;

        isPaused = false;
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }
}
