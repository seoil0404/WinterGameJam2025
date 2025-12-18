using UnityEngine;

public class TutorialManager : MonoBehaviour
{
	public static TutorialManager Instance;

	[SerializeField] private TutorialScript[] m_tutorialScripts;
	[SerializeField] private Canvas m_tutorialCanvasPrefab;
	[SerializeField] private Vector3 m_spwanPoint;
	private TutorialCanvas m_tutorialCanvas;
	private int m_leftTutorialCount;

	public void ReLoadTutorial()
	{
		PlayerPrefs.SetFloat("TutorialX", m_spwanPoint.x);
		PlayerPrefs.SetFloat("TutorialY", m_spwanPoint.y);
		PlayerPrefs.SetFloat("TutorialZ", m_spwanPoint.z);
		PlayerPrefs.SetInt("TutorialLevel", m_leftTutorialCount - 1);

		SceneController.Instance.LoadSceneWithoutFade(SceneType.TutorialScene);

	}
	private void Awake()
	{
		m_leftTutorialCount = PlayerPrefs.GetInt("TutorialLevel");
		Instance = this;
		m_tutorialCanvas = Instantiate(m_tutorialCanvasPrefab).GetComponent<TutorialCanvas>();
	}
	private void Start()
	{
		StartNextTutorial(this.transform.position);
	}
	public void Update()
	{
		
	}
	public void StartNextTutorial(Vector3 pSpwanPoint)
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Time.timeScale = 0;

		if (m_leftTutorialCount < m_tutorialScripts.Length)
		{
			m_tutorialCanvas.SetTutorial(m_tutorialScripts[m_leftTutorialCount]);
			m_spwanPoint = pSpwanPoint;
			m_leftTutorialCount++;
		}
		else
		{
			Time.timeScale = 1;
			SceneController.Instance.LoadScene(SceneType.Titlemain);
		}
	}

	public void ReSpwan(GameObject pPlayer)
	{
		pPlayer.transform.position = m_spwanPoint;
	}

}
