using System;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public partial class PlayerController
{
	[Header("Movement")]
	[SerializeField] private float m_moveSpeed;
	[SerializeField] private float m_hMoveSpeed;
	[SerializeField] private float m_jumpPorce;

	[SerializeField] private Vector3 m_tiptoe;

	private bool m_isGrounded;
   private void MovementAwake()
   {
		m_isGrounded = true;
   }

   private void Move()
   {
		float h = Input.GetAxisRaw("Horizontal");

		m_rigidbody.linearVelocity = new Vector3(h * m_hMoveSpeed, m_rigidbody.linearVelocity.y, m_moveSpeed);
	}

	private void Jump()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			m_collider.height = m_collider.height / 2;
			m_animator.SetBool("Sit", true);
			m_rigidbody.AddForce(Vector3.up * m_jumpPorce, ForceMode.Impulse);


		}
	}
	private void Sit()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			m_collider.height = m_collider.height / 2;
			m_animator.SetBool("Sit", true);
		}
		else if (Input.GetKeyUp(KeyCode.LeftShift)) 
		{
			m_collider.height = m_collider.height / 2;
			m_animator.SetBool("Sit", true);
		}

	}
}
