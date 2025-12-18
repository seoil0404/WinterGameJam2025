using UnityEngine;

public class TutorialManager : MonoBehaviour
{
	public static TutorialManager Instance;

	[SerializeField] private TutorialScript[] m_tutorialScripts;
	[SerializeField] private Canvas m_tutorialCanvasPrefab;
	[SerializeField] private Vector3 m_spwanPoint;
	private TutorialCanvas m_tutorialCanvas;
	private int m_leftTutorialCount;

	private void Awake()
	{
		m_leftTutorialCount = 0;
		Instance = this;
		m_tutorialCanvas = Instantiate(m_tutorialCanvasPrefab).GetComponent<TutorialCanvas>();
	}
	private void Start()
	{
		StartNextTutorial();
	}

	public void StartNextTutorial()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = false;
		Time.timeScale = 0;

		m_tutorialCanvas.gameObject.SetActive(true);

		m_tutorialCanvas.SetTutorial(m_tutorialScripts[m_leftTutorialCount]);
		m_spwanPoint = m_tutorialScripts[m_tutorialScripts.Length].SpwanPoint;
		m_leftTutorialCount++;

	}

}
