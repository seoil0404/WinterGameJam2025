using System.Collections.Generic;
using UnityEngine;

public enum MapType
{
    Tangerine,
    Void
}

public class MapManager : MonoBehaviour
{
    [SerializeField] private Map tangerinePrefab;
    [SerializeField] private int tangerineQueueCount;

    [SerializeField] private Vector3 positionOffset;

    private float tangerineLength;

    private Queue<Map> tangerineQueue = new();
    private int currentMapCount = 0;

    private void Start()
    {
        tangerineLength = tangerinePrefab.Length;

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

                tangerine.transform.position = positionOffset + new Vector3(0, 0, -tangerineLength * currentMapCount);
                tangerineQueue.Enqueue(tangerine);

                currentMapCount++;

                break;
            case MapType.Void:

                currentMapCount++;

                break;
        }
    }
}
