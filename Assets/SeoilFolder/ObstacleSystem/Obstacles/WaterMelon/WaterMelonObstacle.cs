using UnityEngine;

public class WaterMelonObstacle : Obstacle
{
    public override float SpawnWeight => 1;

    public override void Initialize(float position)
    {
        transform.position = new Vector3(0, 17.5f, position);
    }
}
