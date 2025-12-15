using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager Instance { get; private set; }

    [SerializeField] private ObstacleData obstacleData;
    [SerializeField] private Vector3 obstacleOffset;
    [SerializeField] private float horizontalInterval;

    public Vector3 ObstacleOffset => obstacleOffset;
    public float HorizontalInterval => horizontalInterval;
    
    private void Awake()
    {
        Instance = this;
    }

    public void GenerateObstacle()
    {
        Instantiate(obstacleData.StarFruitObstacle).Initialize(MapManager.RecentMapPosition);
    }
}
