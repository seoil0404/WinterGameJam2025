using UnityEngine;

public class RabbitAppleObstacleEntity : ObstacleEntity
{
    [SerializeField] private Vector3 offset;

    protected override void Kill()
    {
        base.Kill();

        EffectManager.Instance.GenerateEffect(
            EffectManager.Instance.EffectData.RabbitAppleExplosion,
            transform.position + offset
            );
    }
}
