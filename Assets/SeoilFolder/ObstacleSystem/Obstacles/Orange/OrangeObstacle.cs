using UnityEngine;

public class OrangeObstacle : Obstacle
{
    public override float SpawnWeight => 1;

    public override void Initialize(float position)
    {
        //SetRandomLinedPosition(position);

        transform.position = new Vector3(0, 15.5f, position);

        transform.Rotate(0, UnityEngine.Random.Range(0, 2) * 180, 0);
    }
}
