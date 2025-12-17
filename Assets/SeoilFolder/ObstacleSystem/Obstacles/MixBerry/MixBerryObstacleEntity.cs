using UnityEngine;

public class MixBerryObstacleEntity : Entity
{
    [SerializeField] private Vector3 offset;

    protected override void Kill()
    {
        base.Kill();
        
        EffectManager.Instance.GenerateEffect(
            EffectManager.Instance.EffectData.RaspBerryExplosion,
            transform.position + offset
            );
    }
}
