using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    [Header("UI")]
    [SerializeField] private Text scoreText;

    [Header("Score Settings")]
    [SerializeField] private float scorePerSecond = 10f;

    private float currentScore = 0f;
    private bool isPlaying = true;
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
        isPlaying = false;
    }

    public int GetScore()
    {
        return Mathf.FloorToInt(currentScore);
    }

    private void UpdateScoreUI()
    {
        scoreText.text = Mathf.FloorToInt(currentScore).ToString();
    }
}


