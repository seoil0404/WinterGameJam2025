using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialData : MonoBehaviour
{
	private void Awake()
	{
		PlayerPrefs.SetFloat("TutorialX", 0f);
		PlayerPrefs.SetFloat("TutorialY", 13f);
		PlayerPrefs.SetFloat("TutorialZ", -32.8f);
		PlayerPrefs.SetInt("TutorialLevel", 0);
		Debug.Log(new Vector3(PlayerPrefs.GetFloat("TutorialX"), PlayerPrefs.GetFloat("TutorialY"), PlayerPrefs.GetFloat("TutorialZ")));
		Debug.Log(PlayerPrefs.GetInt("TutorialLevel"));
	}
}
