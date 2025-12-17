using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Score Settings")]
    [SerializeField] private float scorePerSecond = 10f;

    private float currentScore = 0f;
    private bool isPlaying = true;

    void Start()
    {
        currentScore = 0f;
        UpdateScoreUI();
    }

    void Update()
    {
        if (!isPlaying)
            return;

        // 시간 기반 점수 증가
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
        scoreText.text = Mathf.FloorToInt(currentScore).ToString("0000");
    }
}


