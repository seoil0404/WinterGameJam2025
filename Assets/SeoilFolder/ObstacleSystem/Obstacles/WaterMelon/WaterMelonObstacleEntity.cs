using UnityEngine;

public class WaterMelonObstacleEntity : ObstacleEntity
{
    [SerializeField] private Vector3 offset;

    protected override void Kill()
    {
        base.Kill();

        EffectManager.Instance.GenerateEffect(
            EffectManager.Instance.EffectData.WaterMelonExplosion,
            transform.position + offset
            );
    }
}
