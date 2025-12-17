using UnityEngine;

public class PlayerEgg : Egg
{
	public override void Init(Vector3 pDir, float pSpeed, int pDamage)
	{
		m_speed = pSpeed;
		m_direction = pDir;
		m_damage = pDamage;
	}
	private void Update()
	{
		this.transform.position += m_direction * m_speed * Time.deltaTime;
	}
	private void OnTriggerEnter(Collider pCollsion)
	{
        Obstacle collsion;
        if (pCollsion.transform.TryGetComponent<Obstacle>(out collsion))
        {
            ObstacleEntity entity;
            if (pCollsion.TryGetComponent<ObstacleEntity>(out entity)) entity.GiveDamage(m_damage);
            Destroy(this.gameObject);
        }
        else if (!pCollsion.transform.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
        else return;

        EffectManager.Instance.GenerateEffect(EffectManager.Instance.EffectData.EggHit, transform.position);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.AudioData.EggDestroy);
    }

}
