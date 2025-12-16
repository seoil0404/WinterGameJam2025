using UnityEngine;

public class CoconutObstacle : Obstacle
{
    [SerializeField] private ParticleSystem coconutVFX;
    [SerializeField] private float spawnHeight;

    private float fallSpeed;

    public override float SpawnWeight => 1;

    public override void Initialize(float position)
    {
        SetRandomLinedPosition(position);

        //fallSpeed = 2 * spawnHeight / (PlayerController.Instan);
    }

    public void OnGround()
    {
        Destroy(coconutVFX.gameObject);
    }

    private void Update()
    {
        if(transform.position.y < 10.5)
        {
            OnGround();
        }
    }
}
