using UnityEngine;

public class TutorialPauseCanvas : MonoBehaviour
{
	public void TutorialExit()
	{
		Time.timeScale = 1;
		SceneController.Instance.LoadScene(SceneType.Titlemain);
	}
}
