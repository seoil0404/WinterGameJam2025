using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance { get; private set; }

    [SerializeField] private Transform playerTransform;

    [SerializeField] private float loadDistance;

    private int voidStack = 0;

    public int VoidStack => voidStack;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        MapManager.Instance.AddMap(MapType.Tangerine).GetComponent<AppearAnimationController>().StopAnimation();
        DecorateManager.Instance.GenerateDecorate();
        MapManager.Instance.AddMap(MapType.Tangerine);
        DecorateManager.Instance.GenerateDecorate();
        //MapManager.Instance.AddMap(MapType.Tangerine);
    }

    private void Update()
    {
        if(playerTransform.position.z >= MapManager.RecentMapPosition - loadDistance)
        {
            if(UnityEngine.Random.Range(0, 12) == 0 && voidStack == 0)
            {
                voidStack++;
                //MapManager.Instance.AddMap(MapType.Tangerine);
                MapManager.Instance.AddMap(MapType.Void);
            }
            else
            {
                MapManager.Instance.AddMap(MapType.Tangerine);
                //MapManager.Instance.AddMap(MapType.Tangerine);
                ObstacleManager.Instance.GenerateObstacle();
                BananaManager.Instance.GenerateBanana();
                voidStack = 0;
            }

            DecorateManager.Instance.GenerateDecorate();
        }
    }

    public void GenerateTutorialMap()
    {
        MapManager.Instance.AddMap(MapType.Tangerine).GetComponent<AppearAnimationController>().StopAnimation();
        ObstacleManager.Instance.GenerateObstacle(ObstacleManager.Instance.ObstacleData.BananaObstacle);

        MapManager.Instance.AddMap(MapType.Tangerine);
        ObstacleManager.Instance.GenerateObstacle(ObstacleManager.Instance.ObstacleData.CoconutObstacle);

        MapManager.Instance.AddMap(MapType.Tangerine);
        ObstacleManager.Instance.GenerateObstacle(ObstacleManager.Instance.ObstacleData.BananaObstacle);

        MapManager.Instance.AddMap(MapType.Tangerine);
        ObstacleManager.Instance.GenerateObstacle(ObstacleManager.Instance.ObstacleData.CoconutObstacle);

        MapManager.Instance.AddMap(MapType.Tangerine);
        ObstacleManager.Instance.GenerateObstacle(ObstacleManager.Instance.ObstacleData.BananaObstacle);

        MapManager.Instance.AddMap(MapType.Tangerine);
        ObstacleManager.Instance.GenerateObstacle(ObstacleManager.Instance.ObstacleData.CoconutObstacle);
    }
}
