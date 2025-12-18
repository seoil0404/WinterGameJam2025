using UnityEngine;

public class EggRabPlayerEgg : Egg
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
	private void OnTriggerStay(Collider pCollsion)
	{

		if (!pCollsion.transform.CompareTag("Player"))
		{
			EggRabTarget target;
			EggRabManager manager;
			print("Ãæµ¹");

			if (pCollsion.transform.TryGetComponent<EggRabTarget>(out target))
			{
				target.GiveDamage(m_damage);
			}
			else
			{
				EggRabManager.Instance.Miss();
			}
			Destroy(this.gameObject);
		}
		else return;

		//EffectManager.Instance.GenerateEffect(EffectManager.Instance.EffectData.EggHit, transform.position);
		//AudioManager.Instance.PlaySFX(AudioManager.Instance.AudioData.EggDestroy);
	}

}
