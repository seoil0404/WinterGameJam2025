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
		WorldManager.Instance.GenerateTutorialMap();
	}
	public void Update()
	{
		if(Input.GetKeyDown(KeyCode.Tab))StartNextTutorial();
	}
	public void StartNextTutorial()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = false;
		Time.timeScale = 0;
		if (m_leftTutorialCount < m_tutorialScripts.Length)
		{
			m_tutorialCanvas.SetTutorial(m_tutorialScripts[m_leftTutorialCount]);
			m_spwanPoint = m_tutorialScripts[m_leftTutorialCount].SpwanPoint;
			m_leftTutorialCount++;
		}
		else SceneController.Instance.LoadScene(SceneType.Titlemain);
	}

	public void ReSpwan(GameObject pPlayer)
	{
		pPlayer.transform.position = m_spwanPoint;
	}

}
