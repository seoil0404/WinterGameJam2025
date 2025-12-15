using System;
using UnityEngine;

public partial class PlayerController
{
	[Header("Movement")]
	[SerializeField] private float m_moveSpeed;
	[SerializeField] private float m_hMoveSpeed;
	[SerializeField] private float m_jumpPorce;
   private void MovementAwake()
   {

   }

   private void Move()
   {
		float h = Input.GetAxisRaw("Horizontal");

		Console.WriteLine(h);
		m_rigidbody.linearVelocity = new Vector3(h * m_hMoveSpeed, m_rigidbody.linearVelocity.y, m_moveSpeed);
	}

	private void Jump()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			m_rigidbody.AddForce(Vector3.up * m_jumpPorce, ForceMode.Impulse);
		}
	}
}
