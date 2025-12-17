using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public GameObject pauseUI;
    public bool title = false;
    public GameObject SettingUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {

    }

    public void closeUi()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }
}

