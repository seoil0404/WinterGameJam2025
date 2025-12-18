using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public static TitleManager Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        AudioManager.Instance.SetBGM(AudioManager.Instance.AudioData.TitleBGM);
	}
}
