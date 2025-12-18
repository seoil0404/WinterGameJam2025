using UnityEngine;

public class TutorialPlayerEntity : Entity
{
	private void Awake()
	{
		transform.position = new Vector3(PlayerPrefs.GetFloat("TutorialX"), PlayerPrefs.GetFloat("TutorialY"), PlayerPrefs.GetFloat("TutorialZ"));
		Debug.Log(new Vector3(PlayerPrefs.GetFloat("TutorialX"), PlayerPrefs.GetFloat("TutorialY"), PlayerPrefs.GetFloat("TutorialZ")));
	}
	protected override void Kill()
	{
		TutorialManager.Instance.ReLoadTutorial();
	}
	private void OnCollisionEnter(Collision pCollision)
	{
		Obstacle collsion;
		if (pCollision.transform.TryGetComponent<Obstacle>(out collsion))
		{
			Kill();
		}
	}
}
