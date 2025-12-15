using UnityEngine;

public class TestObstacle : Obstacle
{
    public override void Initialize(float position)
    {
        SetRandomLinedPosition(position);
    }
}
