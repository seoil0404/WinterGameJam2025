using UnityEngine;

public class BananaObstacle : Obstacle
{
    [SerializeField] private float range;

    public override float SpawnWeight => 1;

    public override void Initialize(float position)
    {
        transform.position = new Vector3(UnityEngine.Random.Range(-1f, 1f) * range, 11, position);
    }
}
