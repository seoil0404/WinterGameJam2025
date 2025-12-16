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
   private void MovementUpdate()
   {
		Move();
		Sit();
		GroundCheck();
		Jump();
   }

   private void Move()
   {
		float h = Input.GetAxisRaw("Horizontal");

		m_rigidbody.linearVelocity = new Vector3(h * m_hMoveSpeed, m_rigidbody.linearVelocity.y, m_moveSpeed);
	}

	private void GroundCheck()
	{
		if(!m_isGrounded)
		{
			//if()	

			m_isGrounded = true;
			m_animator.SetBool("Jump", false);
		}
	}
	private void Jump()
	{
		if(Input.GetKeyDown(KeyCode.Space) && m_isGrounded)
		{
			m_collider.height = m_collider.height / 2;
			m_rigidbody.AddForce(Vector3.up * m_jumpPorce, ForceMode.Impulse);

			m_isGrounded = false;
			m_animator.SetBool("Sit", false);
			m_animator.SetBool("Jump", true);
		}
	}
	private void Sit()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			Vector3 scale = m_player.transform.localScale;
			m_player.transform.localScale = new Vector3(scale.x, scale.y / 1.2f, scale.z);
			m_collider.height = m_collider.height / 2;
			m_collider.center = new Vector3(0, m_collider.center.y / 2 , m_collider.center.z);

			m_animator.SetBool("Sit", true);
		}
		else if (Input.GetKeyUp(KeyCode.LeftShift)) 
		{
			Vector3 scale = m_player.transform.localScale;
			m_player.transform.localScale = new Vector3(scale.x, scale.y * 1.2f, scale.z);
			m_collider.height = m_collider.height * 2;
			m_collider.center = new Vector3(0, m_collider.center.y * 2, m_collider.center.z);

			m_animator.SetBool("Sit", false);
		}

	}
}
