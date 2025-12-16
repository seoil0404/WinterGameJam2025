using UnityEngine;

public class TestObstacle : Obstacle
{
    public override float SpawnWeight => 1;

    public override void Initialize(float position)
    {
        SetRandomLinedPosition(position);
    }
}
