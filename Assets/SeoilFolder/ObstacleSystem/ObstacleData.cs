using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleData", menuName = "Scriptable Objects/ObstacleData")]
public class ObstacleData : ScriptableObject
{
    public Obstacle PineAppleObstacle;
    public Obstacle CoconutObstacle;
    public Obstacle CherryObstacle;
    public Obstacle BananaObstacle;

    public Obstacle OrangeObstacle;
    public Obstacle AvocadoObstacle;
    public Obstacle RabbitAppleObstacle;
    public Obstacle MixBerryObstacle;
    public Obstacle WaterMelonObstacle;

    public List<Obstacle> NormalObstacle => new List<Obstacle> { PineAppleObstacle, CoconutObstacle, CherryObstacle };
    public List<Obstacle> AllObstacles => new List<Obstacle> { PineAppleObstacle, CoconutObstacle, CherryObstacle, OrangeObstacle, AvocadoObstacle, RabbitAppleObstacle, MixBerryObstacle, WaterMelonObstacle };

    public Obstacle GetRandomObstacle(List<Obstacle> obstacles)
    {
        float totalWeight = 0f;

        for (int index = 0; index < obstacles.Count; index++)
            totalWeight += obstacles[index].SpawnWeight;

        float randomValue = Random.Range(0f, totalWeight);
        float currentWeight = 0f;

        for (int index = 0; index < obstacles.Count; index++)
        {
            currentWeight += obstacles[index].SpawnWeight;
            if (randomValue <= currentWeight)
                return obstacles[index];
        }

        return obstacles[obstacles.Count - 1];
    }
}
