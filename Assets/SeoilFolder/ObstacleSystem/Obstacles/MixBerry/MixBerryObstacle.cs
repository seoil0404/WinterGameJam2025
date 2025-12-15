using System.Collections.Generic;
using System;
using UnityEngine;

public class MixBerryObstacle : Obstacle
{
    [SerializeField] private MixBerry normalMixBerry;
    [SerializeField] private MixBerry specialMixBerry;
    [SerializeField] private float xInterval;
    [SerializeField] private float yInterval;

    private const int specialMixBerryCount = 3;

    public override void Initialize(float position)
    {
        transform.position = new Vector3(0, 19f, position);

        List<(int x, int y)> pool = new List<(int, int)>();

        for (int x = -2; x <= 2; x++)
            for (int y = -2; y <= 2; y++)
                pool.Add((x, y));

        for(int index = 0; index < specialMixBerryCount; index++)
        {
            int randomIndex = UnityEngine.Random.Range(0, pool.Count);
            GenerateSpecialBerry(pool[randomIndex]);
        }

        foreach(var coordinate in pool)
            GenerateNormalBerry(coordinate);
    }

    private void GenerateSpecialBerry((int x, int y) coordinate)
    {
        MixBerry newBerry = Instantiate(specialMixBerry, transform);
        newBerry.transform.localPosition = new Vector3(xInterval * coordinate.x, yInterval * coordinate.y, 0);
    }

    private void GenerateNormalBerry((int x, int y) coordinate)
    {
        MixBerry newBerry = Instantiate(normalMixBerry, transform);
        newBerry.transform.localPosition = new Vector3(xInterval * coordinate.x, yInterval * coordinate.y, 0);
    }
}
