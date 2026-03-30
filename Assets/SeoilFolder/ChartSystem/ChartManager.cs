using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using System.Text;

public class ChartManager : MonoBehaviour
{
    [SerializeField] private Text scoreDataView;
    [SerializeField] private ChartScrollController chartScrollController;

    private List<int> scoreData = new();

    private void Start()
    {
        var scoreDataString = ScoreManager.ScoreData;
        scoreData = scoreDataString
                                .Split(',')
                                .Where(t => t.Length > 0)
                                .Select(t => int.Parse(t))
                                .ToList();

        scoreData.Sort();
        scoreData.Reverse();

        StringBuilder sb = new StringBuilder();
        for(int index = 0; index < scoreData.Count; index++)
        {
            sb.AppendLine($"Rank {index + 1} : {scoreData[index]}");
        }

        chartScrollController.MaxY = scoreData.Count * 80;
        scoreDataView.rectTransform.sizeDelta = new Vector2(scoreDataView.rectTransform.sizeDelta.x, scoreData.Count * 80);
        scoreDataView.text = sb.ToString();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneController.Instance.LoadScene(SceneType.Titlemain);
        }
    }
}
