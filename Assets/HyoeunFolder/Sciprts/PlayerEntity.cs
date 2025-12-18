using System.Collections;
using UnityEngine;

public class PlayerEntity : Entity
{
	private bool m_isDeath;

	private void Awake()
	{
		m_isDeath = false;
	}
	protected override void Kill()
	{
		if (m_isDeath) return;
		m_isDeath = true;
		GetComponent<Animator>().SetBool("Death", true);
		PlayerController.Instance.GameOver();
		GameManager.Instance.GameOver();
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
