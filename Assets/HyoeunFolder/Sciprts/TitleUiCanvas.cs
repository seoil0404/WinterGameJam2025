using UnityEngine;

public class TitleUiCanvas : MonoBehaviour
{
    public void TutorialButton()
    {
        SceneController.Instance.LoadSceneWithoutFade(SceneType.TutorialScene);
		PlayerPrefs.SetFloat("TutorialX", 0);
		PlayerPrefs.SetFloat("TutorialY", 13);
		PlayerPrefs.SetFloat("TutorialZ", -32.8f);
		PlayerPrefs.SetInt("TutorialLevel", 0);
	}
}
