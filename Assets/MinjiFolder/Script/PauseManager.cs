using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject SettingUI;

    private bool isPaused = false;

    void Start()
    {
        Time.timeScale = 1f;
        SettingUI.SetActive(false);
        isPaused = false;
    }
    public void OnClickInGameSetting()
    {
        if (isPaused)
            return;

        PauseGame();
    }

    /// 게임 일시정지

    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;   
        SettingUI.SetActive(true);    
    }
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;  
        SettingUI.SetActive(false);  
    }
}
