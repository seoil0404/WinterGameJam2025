using UnityEngine;

public class CoconutObstacle : Obstacle
{
    public override void Initialize(float position)
    {
        SetRandomLinedPosition(position);
    }
}
