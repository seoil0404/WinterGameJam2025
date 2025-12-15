using UnityEngine;

public class AvocadoObstacle : Obstacle
{
    public override void Initialize(float position)
    {
        transform.position = new Vector3(0, 15.98f, position);
    }
}
