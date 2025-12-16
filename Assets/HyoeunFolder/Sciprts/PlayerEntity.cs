using System.Collections;
using UnityEngine;

public class PlayerEntity : Entity
{
	protected override void Kill()
	{
		GetComponent<Animator>().SetBool("Death", true);
		StartCoroutine(DeathTime());
	}

	private IEnumerator DeathTime()
	{
		yield return new WaitForSeconds(5);
		base.Kill();
	}
}
