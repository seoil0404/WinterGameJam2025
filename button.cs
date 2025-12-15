using UnityEngine;
using UnityEngine.UI;

public class SettingPopup : MonoBehaviour
{
	public GameObject OptionUi;
	public Toggle toggle;

	private void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	// Setting 버튼에서 호출
	public void OpenSetting()
	{
		OptionUi.SetActive(!OptionUi.activeSelf);
	}
	public void CloseSetting()
	{
		OptionUi.SetActive(false);
	}
	public void onFullscreenmod()
	{
		Screen.fullScreen = toggle.isOn;

	}
}