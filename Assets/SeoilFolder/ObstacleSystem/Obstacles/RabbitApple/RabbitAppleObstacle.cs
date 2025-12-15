using UnityEngine;

public class RabbitAppleObstacle : Obstacle
{
    public override void Initialize(float position)
    {
        transform.position = new Vector3(-5, 12.59f, position);
    }
}
