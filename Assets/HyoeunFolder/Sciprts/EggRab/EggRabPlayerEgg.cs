using UnityEngine;

public class EggRabPlayerEgg : Egg
{
	public override void Init(Vector3 pDir, float pSpeed, int pDamage)
	{
		GetComponent<Rigidbody>().AddForce(pDir * pSpeed, ForceMode.Impulse);
		m_damage = pDamage;
	}
	private void OnTriggerEnter(Collider pCollsion)
	{
		EggRabTarget target;
		if (pCollsion.transform.TryGetComponent<EggRabTarget>(out target))
		{
			target.GiveDamage(m_damage);
			Destroy(this.gameObject);
		}
		else if (!pCollsion.transform.CompareTag("Player"))
		{
			Destroy(this.gameObject);
		}
		else return;

		//EffectManager.Instance.GenerateEffect(EffectManager.Instance.EffectData.EggHit, transform.position);
		//AudioManager.Instance.PlaySFX(AudioManager.Instance.AudioData.EggDestroy);
	}

}
