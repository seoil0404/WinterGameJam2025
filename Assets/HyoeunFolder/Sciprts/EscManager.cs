using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EscManager : MonoBehaviour
{
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Time.timeScale = 1.0f;
			SceneController.Instance.LoadScene(SceneType.Titlemain);
		}
	}
}
