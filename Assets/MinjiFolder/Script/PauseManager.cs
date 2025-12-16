using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject settingUI;
    private bool isPaused = false;

    void Start()
    {
        Time.timeScale = 1f;
        settingUI.SetActive(false);
        isPaused = false;
    }

    public void OnClickInGameSetting()
    {
        if (isPaused)
            return;

        PauseGame();
    }

    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        print("asd");
        settingUI.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        settingUI.SetActive(false);
    }

    public void ExitGame(string sceneName)
    {
        Time.timeScale = 1f;
        isPaused = false;

        settingUI.SetActive(false);
        SceneManager.LoadScene(sceneName);
    }
}
