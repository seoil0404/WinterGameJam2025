using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject SettingUI;

    private bool isPaused = false;

    void Start()
    {
        // 안전장치: 씬 진입 시 항상 정상 상태
        Time.timeScale = 1f;
        SettingUI.SetActive(false);
        isPaused = false;
    }

    /// <summary>
    /// 인게임 설정 버튼 클릭 시 호출
    /// </summary>
    public void OnClickInGameSetting()
    {
        if (isPaused)
            return;

        PauseGame();
    }

    /// <summary>
    /// 게임 일시정지
    /// </summary>
    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;          // 게임 정지
        SettingUI.SetActive(true);    // 설정 UI 표시
    }

    /// <summary>
    /// 게임 재개 (Resume 버튼에서 호출)
    /// </summary>
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;          // 게임 재개
        SettingUI.SetActive(false);   // 설정 UI 숨김
    }
}
