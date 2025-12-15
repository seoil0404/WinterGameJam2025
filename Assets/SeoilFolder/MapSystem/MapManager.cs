using System.Collections.Generic;
using UnityEngine;

public enum MapType
{
    Tangerine,
    Void
}

public class MapManager : MonoBehaviour
{
    public static MapManager Instance { get; private set; }

    public static float TangerineLength { get; private set; }
    public static float RecentMapPosition { get; private set; } = 0;

    [SerializeField] private Map tangerinePrefab;
    [SerializeField] private int tangerineQueueCount;

    [SerializeField] private Vector3 positionOffset;

    private Queue<Map> tangerineQueue = new();
    private int currentMapCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        TangerineLength = tangerinePrefab.Length;

        for(int index = 0; index < 100; index++)
        {
            AddMap(MapType.Tangerine);
        }
    }

    public void AddMap(MapType type)
    {
        switch(type)
        {
            case MapType.Tangerine:

                Map tangerine;

                if(tangerineQueue.Count > tangerineQueueCount)
                    tangerine = tangerineQueue.Dequeue();
                else
                    tangerine = Instantiate(tangerinePrefab, transform);

                tangerine.transform.position = positionOffset + new Vector3(0, 0, TangerineLength * currentMapCount);
                tangerineQueue.Enqueue(tangerine);

                currentMapCount++;

                break;
            case MapType.Void:

                currentMapCount++;

                break;
        }

         RecentMapPosition = TangerineLength * currentMapCount;
    }
}
