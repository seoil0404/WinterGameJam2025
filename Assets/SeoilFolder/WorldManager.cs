using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance { get; private set; }

    [SerializeField] private Transform playerTransform;

    [SerializeField] private float loadDistance;

    private int voidStack = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(playerTransform.position.z >= MapManager.RecentMapPosition - loadDistance)
        {
            if(UnityEngine.Random.Range(0, 12) == 0 && voidStack == 0)
            {
                voidStack++;
                MapManager.Instance.AddMap(MapType.Void);
            }
            else
            {
                voidStack = 0;
                MapManager.Instance.AddMap(MapType.Tangerine);
                ObstacleManager.Instance.GenerateObstacle();
            }
        }
    }
}
