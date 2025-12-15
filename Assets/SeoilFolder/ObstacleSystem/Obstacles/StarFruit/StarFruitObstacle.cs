using UnityEngine;

public class StarFruitObstacle : Obstacle
{
    [SerializeField] private float heightOffset;
    [SerializeField] private float fallSpeed;

    public override void Initialize(float position)
    {
        SetRandomLinedPosition(position);
        transform.position = new Vector3(transform.position.x, heightOffset, transform.position.z);
    }

    private void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        if (transform.position.y < 0)
            Destroy(gameObject);
    }
}
