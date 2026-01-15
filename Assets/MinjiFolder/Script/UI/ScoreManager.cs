using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    private static string MaxScore = "MaxScore";
    private static string ScoreDataKey = "ScoreData";

    [Header("UI")]
    [SerializeField] private Text scoreText;

    [Header("Score Settings")]
    [SerializeField] private float scorePerSecond = 10f;

    private float currentScore = 0f;
    private bool isPlaying = true;

    public static string ScoreData
    {
        get
        {
            if(!PlayerPrefs.HasKey(ScoreDataKey))
            {
                return "";
            }
            return PlayerPrefs.GetString(ScoreDataKey);
        }
        set
        {
            PlayerPrefs.SetString(ScoreDataKey, value);
        }
    }

	private void Awake()
	{
		Instance = this;
	}
	void Start()
    {
        currentScore = 0f;
        UpdateScoreUI();
    }

    void Update()
    {
        if (!isPlaying)
            return;

        currentScore += scorePerSecond * Time.deltaTime;
        UpdateScoreUI();
    }

    public void StartScore()
    {
        isPlaying = true;
    }

    public void StopScore()
    {
        if(GetMaxScore() < GetScore())
            PlayerPrefs.SetInt(MaxScore, GetScore());

        ScoreData += GetScore() + ",";

        isPlaying = false;
    }

    public int GetScore()
    {
        return Mathf.FloorToInt(currentScore);
    }

    public static int GetMaxScore()
    {
        if (!PlayerPrefs.HasKey(MaxScore))
        {
            PlayerPrefs.SetInt(MaxScore, 0);
            return 0;
        }
        else
            return PlayerPrefs.GetInt(MaxScore);
    }

    private void UpdateScoreUI()
    {
        scoreText.text = Mathf.FloorToInt(currentScore).ToString();
    }
}


