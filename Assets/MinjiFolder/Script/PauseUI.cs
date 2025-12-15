using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public GameObject pauseUI;
    public bool title = false;
    public GameObject SettingUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        DontDestroyOnLoad(pauseUI);
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(SettingUI);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !title)
        {
            //PauseUI.SetActive(!PauseUI.activeSelf);
        }
    }
    public void closeUi()
    {
        pauseUI.SetActive(false);
    }
}

