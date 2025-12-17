using UnityEngine;

public class ObstacleEntity : Entity
{
    public override void GiveDamage(int pDamage)
    {
        base.GiveDamage(pDamage);
        Debug.Log("Damage recieved");
    }
}
