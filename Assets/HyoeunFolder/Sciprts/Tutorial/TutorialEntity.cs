using UnityEngine;

public class TutorialEntity : Entity
{
	private bool m_isTutorialPlaying;

	private void Awake()
	{
		m_isTutorialPlaying = false;
	}
	private void OnTriggerEnter(Collider collision)
	{
		if (m_isTutorialPlaying) return;
		PlayerPrefs.SetFloat("TutorialX", this.transform.position.x);
		PlayerPrefs.SetFloat("TutorialY", this.transform.position.y);
		PlayerPrefs.SetFloat("TutorialZ", this.transform.position.z);
		if (collision.transform.CompareTag("Player"))TutorialManager.Instance.StartNextTutorial(this.transform.position);
	}
}
