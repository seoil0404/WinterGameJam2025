using UnityEngine;
using UnityEngine.UI;

public class SettingPopup : MonoBehaviour
{
    public GameObject SettingUI;
    public Toggle toggle;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void OpenSetting()
    {
        SettingUI.SetActive(!SettingUI.activeSelf);
    }
    public void CloseSetting()
    {
        SettingUI.SetActive(false);
    }
    public void onFullscreenmod()
    {
        Screen.fullScreen = toggle.isOn;

    }
}