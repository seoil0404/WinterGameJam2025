using UnityEngine;

public class AvocadoObstacleEntity : ObstacleEntity
{
    [SerializeField] private Vector3 offset;

    protected override void Kill()
    {
        base.Kill();

        EffectManager.Instance.GenerateEffect(
            EffectManager.Instance.EffectData.AbocadoExplosion, 
            transform.position + offset
            );

        AudioManager.Instance.PlaySFX(AudioManager.Instance.AudioData.AbocadoExplosion);
    }
}
