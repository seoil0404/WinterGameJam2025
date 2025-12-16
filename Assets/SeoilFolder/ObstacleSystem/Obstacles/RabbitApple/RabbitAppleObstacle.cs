using UnityEngine;

public class RabbitAppleObstacle : Obstacle
{
    public override float SpawnWeight => 1;

    public override void Initialize(float position)
    {
        transform.position = new Vector3(-5, 12.59f, position);
    }
}
