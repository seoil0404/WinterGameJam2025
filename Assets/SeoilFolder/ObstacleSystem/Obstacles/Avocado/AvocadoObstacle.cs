using UnityEngine;

public class AvocadoObstacle : Obstacle
{
    public override float SpawnWeight => 1;

    public override void Initialize(float position)
    {
        transform.position = new Vector3(0, 16.98f, position);
    }
}
