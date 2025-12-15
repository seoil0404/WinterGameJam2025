using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance { get; private set; }

    [SerializeField] private Transform playerTransform;

    [SerializeField] private float loadDistance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        Debug.Log(MapManager.RecentMapPosition - loadDistance);

        if(playerTransform.position.z >= MapManager.RecentMapPosition - loadDistance)
        {
            MapManager.Instance.AddMap(MapType.Tangerine);
        }
    }
}
