using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    public abstract void Initialize(float position);

    protected void SetRandomLinedPosition(float position)
    {
        transform.position = new Vector3(
            UnityEngine.Random.Range(-1, 2) * ObstacleManager.Instance.HorizontalInterval + ObstacleManager.Instance.ObstacleOffset.x, 
            ObstacleManager.Instance.ObstacleOffset.y,
            position + ObstacleManager.Instance.ObstacleOffset.z);
    }
}