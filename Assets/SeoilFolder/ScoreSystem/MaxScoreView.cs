using UnityEngine;
using UnityEngine.UI;

public class MaxScoreView : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private void Start()
    {
        scoreText.text = ScoreManager.GetMaxScore().ToString();
    }
}