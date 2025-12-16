using UnityEngine;

public class CherryObstacle : Obstacle
{
    public override float SpawnWeight => 1; 
    
    public override void Initialize(float position)
    {
        transform.position = new Vector3(-6.6f, 12.37f, position);
    }
}
