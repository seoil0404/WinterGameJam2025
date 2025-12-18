using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class EggRabManager : MonoBehaviour
{
    public static EggRabManager Instance;

    [SerializeField] private GameObject m_targetPrefeb;
	[SerializeField] private int m_targetCount;
	[SerializeField] private int m_targetXSpawnpointCount;
	[SerializeField] private int m_targetYSpawnpointCount;
    [SerializeField] private float m_playingTime;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text leftTimeText;
    [SerializeField] private EggLabGameOverView eggLabGameOverViewPrefab;

    private bool isEnd = false;

    private PlayerController m_player;
    private List<GameObject> m_targets;
    private int property_m_score;
    private int m_score
    {
        get => property_m_score;
        set
        {
            property_m_score = value;
            scoreText.text = value.ToString();
        }
    }
    private float m_leftPlayingTime;

    public int Score => m_score;

    public void Miss()
    {
        m_score -= 2;
        if(m_score < 0)m_score = 0;
    }
    private void Awake()
    {
        m_targets = new List<GameObject>();
        Instance = this;
        m_score = 0;
        m_leftPlayingTime = 0;
    }
	private void Update()
	{
		m_leftPlayingTime += Time.deltaTime;
        leftTimeText.text = Mathf.FloorToInt(m_playingTime - m_leftPlayingTime).ToString();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneController.Instance.LoadScene(SceneType.Titlemain);
        }

        if(m_leftPlayingTime > m_playingTime && !isEnd)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isEnd = true;

            Instantiate(eggLabGameOverViewPrefab);
        }
	}
	private void Start()
	{
		m_player = PlayerController.Instance;

		for (int i = 0; i < m_targetCount; i++)
		{
			TargetGenerate();
		}
	}
	public void TargetGenerate()
	{
		Vector3 position = GetRandomPos();
		m_targets.Add(Instantiate(m_targetPrefeb, position, Quaternion.identity));
	}
	public void TargetGenerate(GameObject pTarget)
    {
        m_targets.Remove(pTarget);
        Destroy(pTarget);
        Vector3 position = GetRandomPos();
        m_targets.Add(Instantiate(m_targetPrefeb, position, Quaternion.identity));
        m_score += 3;
    }
    private Vector3 GetRandomPos()
    {
        Vector3 randomPos = Vector3.zero;
        for(int j = 0; j < 100; j++ )
        {
            bool isMatch = false;

            randomPos.x = Random.Range(0-m_targetXSpawnpointCount/2, m_targetXSpawnpointCount/2);
            randomPos.y = Random.Range(3, m_targetYSpawnpointCount);
            for (int i = 0; i < m_targets.Count; i++)
            {
                if (randomPos == m_targets[i].transform.position)isMatch = true;
            }
            if (!isMatch) break;
        }
        randomPos += new Vector3(0, m_player.transform.position.y, 0);
        return randomPos;
    }
}
