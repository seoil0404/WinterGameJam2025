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
    [SerializeField] private Map voidTangerinePrefab;
    [SerializeField] private int tangerineQueueCount;

    [SerializeField] private Vector3 positionOffset;

    private Queue<Map> tangerineQueue = new();
    private Queue<Map> voidTangerineQueue = new();
    private int currentMapCount = 0;

    private void Awake()
    {
        Instance = this;

        TangerineLength = tangerinePrefab.Length;
    }

    public Map AddMap(MapType type)
    {
        RecentMapPosition = TangerineLength * currentMapCount;

        Map map;

        switch (type)
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

                map = tangerine;

                break;

            case MapType.Void:

                Map voidTangerine;

                if (tangerineQueue.Count > tangerineQueueCount)
                    voidTangerine = voidTangerineQueue.Dequeue();
                else
                    voidTangerine = Instantiate(voidTangerinePrefab, transform);

                voidTangerine.transform.position = positionOffset + new Vector3(0, 0, TangerineLength * currentMapCount);
                voidTangerineQueue.Enqueue(voidTangerine);

                currentMapCount++;

                map = voidTangerine;

                break;
            default:
                map = new();
                break;
        }

        return map;
    }
}
