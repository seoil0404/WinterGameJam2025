using System.Collections.Generic;
using System;
using UnityEngine;

public class MixBerryObstacle : Obstacle
{
    [SerializeField] private MixBerry blueBerry;
    [SerializeField] private MixBerry raspBerry;
    [SerializeField] private float xInterval;
    [SerializeField] private float yInterval;

    private const int RaspBerryCount = 3;
    private int currentRaspBerryCount = RaspBerryCount;

    private List<MixBerry> blueBerryList = new();

    public override float SpawnWeight => 1;

    public override void Initialize(float position)
    {
        transform.position = new Vector3(0, 16.4f, position);

        List<(int x, int y)> pool = new List<(int, int)>();

        for (int x = -3; x <= 3; x++)
            for (int y = -2; y <= 2; y++)
                pool.Add((x, y));

        for(int index = 0; index < RaspBerryCount; index++)
        {
            int randomIndex = UnityEngine.Random.Range(0, pool.Count);
            GenerateRaspBerry(pool[randomIndex]);
            pool.RemoveAt(randomIndex);
        }

        foreach(var coordinate in pool)
            GenerateBlueBerry(coordinate);
    }

    private void GenerateRaspBerry((int x, int y) coordinate)
    {
        MixBerry newBerry = Instantiate(raspBerry, transform);
        newBerry.Initialize(this);
        newBerry.transform.localPosition = new Vector3(xInterval * coordinate.x, yInterval * coordinate.y, 0);
    }

    private void GenerateBlueBerry((int x, int y) coordinate)
    {
        MixBerry newBerry = Instantiate(blueBerry, transform);
        newBerry.Initialize(this);
        newBerry.transform.localPosition = new Vector3(xInterval * coordinate.x, yInterval * coordinate.y, 0);
        blueBerryList.Add(newBerry);
    }

    public void OnRaspBerryDestroyed()
    {
        currentRaspBerryCount--;

        if(currentRaspBerryCount == 0)
        {
            DestroyObstacle();
        }
    }

    private void DestroyObstacle()
    {
        foreach(MixBerry mixBerry in blueBerryList)
        {
            Destroy(mixBerry.gameObject);
        }

        Destroy(gameObject);
    }
}
