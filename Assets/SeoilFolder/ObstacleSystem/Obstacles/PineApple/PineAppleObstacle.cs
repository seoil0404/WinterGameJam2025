using UnityEngine;

public class PineAppleObstacle : Obstacle
{
    public override void Initialize(float position)
    {
        transform.position = new Vector3(
            (UnityEngine.Random.Range(-1, 1) + 0.5f) * ObstacleManager.Instance.HorizontalInterval * 2 + ObstacleManager.Instance.ObstacleOffset.x,
            9,
            position + ObstacleManager.Instance.ObstacleOffset.z);
    }
}
