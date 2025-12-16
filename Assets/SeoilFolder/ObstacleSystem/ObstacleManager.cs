using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager Instance { get; private set; }

    [SerializeField] private ObstacleData obstacleData;
    [SerializeField] private Vector3 obstacleOffset;
    [SerializeField] private float horizontalInterval;

    public Vector3 ObstacleOffset => obstacleOffset;
    public float HorizontalInterval => horizontalInterval;

    private int bigObstacleStack = 0;
    
    private void Awake()
    {
        Instance = this;
    }

    public void GenerateObstacle()
    {
        Instantiate(obstacleData.CoconutObstacle).Initialize(MapManager.RecentMapPosition);
        return;

        if (WorldManager.Instance.VoidStack > 0)
        {
            Obstacle selected = obstacleData.GetRandomObstacle(obstacleData.NormalObstacle);

            Instantiate(selected).Initialize(MapManager.RecentMapPosition);
        }
        else
        {
            Obstacle selected;

            if (bigObstacleStack > 0)
            {
                 selected = obstacleData.GetRandomObstacle(obstacleData.NormalObstacle);
                bigObstacleStack = 0;
            }
            else
            {
                selected = obstacleData.GetRandomObstacle(obstacleData.AllObstacles);
                if (!obstacleData.NormalObstacle.Contains(selected))
                    bigObstacleStack++;
            }

            Instantiate(selected).Initialize(MapManager.RecentMapPosition);
        }
        
    }
}
