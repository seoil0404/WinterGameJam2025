using UnityEngine;
using UnityEngine.UI;

public class SettingPopup : MonoBehaviour
{
    public Toggle toggle;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void OpenSetting()
    {
        SettingUI.Instance.gameObject.SetActive(!SettingUI.Instance.gameObject.activeSelf);
    }
    public void CloseSetting()
    {
        SettingUI.Instance.gameObject.SetActive(false);
    }
    public void onFullscreenmod()
    {
        Screen.fullScreen = toggle.isOn;

    }
}