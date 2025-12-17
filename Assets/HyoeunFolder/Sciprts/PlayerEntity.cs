using System.Collections;
using UnityEngine;

public class PlayerEntity : Entity
{
	protected override void Kill()
	{
		GetComponent<Animator>().SetBool("Death", true);
		PlayerController.Instance.GameOver();
	}

	private void OnCollisionEnter(Collision pCollision)
	{
		Obstacle collsion;
		if (pCollision.transform.TryGetComponent<Obstacle>(out collsion))
		{
			Kill();
		}
	}
}
