using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialData : MonoBehaviour
{
	private void Awake()
	{
		if(SceneManager.GetActiveScene().name == "Titlemain")
		{
			PlayerPrefs.SetFloat("TutorialX", 0f);
			PlayerPrefs.SetFloat("TutorialY", 10.8f);
			PlayerPrefs.SetFloat("TutorialZ", -32.8f);
			PlayerPrefs.SetInt("TutorialLevel", 0);

		}
	}
}
