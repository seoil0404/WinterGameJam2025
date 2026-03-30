using UnityEngine;

public class TutorialManager : MonoBehaviour
{
	public static TutorialManager Instance;

	[SerializeField] private TutorialScript[] m_tutorialScripts;
	[SerializeField] private Canvas m_tutorialCanvasPrefab;
	[SerializeField] private Vector3 m_spwanPoint;
	[SerializeField] private GameObject m_tutorialMenuPrefab;
	[SerializeField] private GameObject m_menu;
	private TutorialCanvas m_tutorialCanvas;
	private int m_leftTutorialCount;

	public void ReLoadTutorial()
	{
		PlayerPrefs.SetFloat("TutorialX", m_spwanPoint.x);
		PlayerPrefs.SetFloat("TutorialY", m_spwanPoint.y);
		PlayerPrefs.SetFloat("TutorialZ", m_spwanPoint.z);
		PlayerPrefs.SetInt("TutorialLevel", m_leftTutorialCount - 1);
		print($"Tutorial Reset SpawnPoint {m_spwanPoint}, {PlayerPrefs.GetFloat("TutorialX")},{PlayerPrefs.GetFloat("TutorialY")},{PlayerPrefs.GetFloat("TutorialZ")}");
		SceneController.Instance.LoadSceneWithoutFade(SceneType.TutorialScene);
		print("Reload Tutorial  !!");

	}
	private void Awake()
	{
		m_leftTutorialCount = PlayerPrefs.GetInt("TutorialLevel");
		Debug.Log($"Tutorial Level : {PlayerPrefs.GetInt("TutorialLevel")}");
		Instance = this;
		m_tutorialCanvas = Instantiate(m_tutorialCanvasPrefab).GetComponent<TutorialCanvas>();
	}
	private void Start()
	{
		StartNextTutorial(new Vector3(PlayerPrefs.GetFloat("TutorialX"), PlayerPrefs.GetFloat("TutorialY"), PlayerPrefs.GetFloat("TutorialZ")));
	}
	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			TutorialExit();
			return;
			if (m_menu != null)
			{
				Destroy(m_menu);
				return;
			}
			m_menu = Instantiate(m_tutorialMenuPrefab);
		}
	}
	public void StartNextTutorial(Vector3 pSpwanPoint)
	{

		if (m_leftTutorialCount < m_tutorialScripts.Length)
		{
			m_tutorialCanvas.SetTutorial(m_tutorialScripts[m_leftTutorialCount]);
			m_spwanPoint = pSpwanPoint;
			m_leftTutorialCount++;
		}
		else
		{
			TutorialExit();
		}
		print("Next Tutorial !!");
		Debug.Log($"Tutorial Level : {PlayerPrefs.GetInt("TutorialLevel")} : {m_leftTutorialCount} {pSpwanPoint}");


		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Time.timeScale = 0;
	}

	private void TutorialExit()
	{
		Time.timeScale = 1;
		SceneController.Instance.LoadScene(SceneType.Titlemain);
	}
}
