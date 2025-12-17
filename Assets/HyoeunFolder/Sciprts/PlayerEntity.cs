using System.Collections;
using UnityEngine;

public class PlayerEntity : Entity
{
	protected override void Kill()
	{
		GetComponent<Animator>().SetBool("Death", true);
		StartCoroutine(DeathTime());
	}

	private void OnCollisionEnter(Collision pCollision)
	{
		Obstacle collsion;
		if (pCollision.transform.TryGetComponent<Obstacle>(out collsion))
		{
			DeathTime();
			Destroy(this.gameObject);
		}
	}
	private IEnumerator DeathTime()
	{
		yield return new WaitForSeconds(5);
		base.Kill();
	}
}
