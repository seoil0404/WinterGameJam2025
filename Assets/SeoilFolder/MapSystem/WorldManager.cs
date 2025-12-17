using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance { get; private set; }

    [SerializeField] private Transform playerTransform;

    [SerializeField] private float loadDistance;
    [SerializeField] private bool generateObstacle;

    private int voidStack = 0;

    public int VoidStack => voidStack;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        MapManager.Instance.AddMap(MapType.Tangerine);
        MapManager.Instance.AddMap(MapType.Tangerine);
        //MapManager.Instance.AddMap(MapType.Tangerine);
    }

    private void Update()
    {
        if(playerTransform.position.z >= MapManager.RecentMapPosition - loadDistance)
        {
            if(!generateObstacle)
            {
                MapManager.Instance.AddMap(MapType.Tangerine);
                MapManager.Instance.AddMap(MapType.Tangerine);
                return;
            }

            if(UnityEngine.Random.Range(0, 12) == 0 && voidStack == 0)
            {
                voidStack++;
                MapManager.Instance.AddMap(MapType.Tangerine);
                MapManager.Instance.AddMap(MapType.Void);
            }
            else
            {
                MapManager.Instance.AddMap(MapType.Tangerine);
                MapManager.Instance.AddMap(MapType.Tangerine);
                ObstacleManager.Instance.GenerateObstacle();
                voidStack = 0;
            }
        }
    }
}
