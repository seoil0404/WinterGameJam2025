using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public partial class PlayerController
{
	[Space(20)]
	[Header("Movement")]
	[SerializeField] private float m_moveSpeed;
	[SerializeField] private float m_maxMoveSpeed;
	[SerializeField] private float m_hMoveSpeed;
	[SerializeField] private float m_sppedUpPercent;
	[SerializeField] private float m_rotateScale;
	[SerializeField] private Transform m_body;

	[Space(10)]
	[SerializeField] private float m_jumpPorce;
	[SerializeField] private float m_jumpLimitDelay;

	[Space(10)]
	[SerializeField] private float m_groundedRadius;
	[SerializeField] private float m_groundedHeight;
	[SerializeField] private LayerMask m_groundedLayer;
	[SerializeField] private Transform m_groundedTiptoe;
	private bool m_isGrounded;

	[Space(10)]
	[SerializeField] private float m_dashPorce;
	[SerializeField] private float m_dashLimitDelay;

	private bool m_isSit;
	private int m_jumpCount;
	private float m_leftJumpDelay;
	public float MoveSpeed => m_moveSpeed;
	private void MovementAwake()
	{
		m_isGrounded = true;
		m_leftJumpDelay = 0;
		m_isSit = false;
		m_jumpCount = 0;
	}
	private void MovementUpdate()
	{
		Move();
		Sit();
		GroundCheck();
		Jump();
		SpeedUp();
	}

	private void Move()
	{
		float h = Input.GetAxisRaw("Horizontal");
		m_rigidbody.linearVelocity = new Vector3(h * m_hMoveSpeed, m_rigidbody.linearVelocity.y, m_moveSpeed);

		if (m_isAiming)
		{
			
			return;
		}

		if (h > 0) m_body.rotation = Quaternion.Euler(new Vector3(0, m_rotateScale, 0));
		else if (h < 0) m_body.rotation = Quaternion.Euler(new Vector3(0, -m_rotateScale, 0));
		else m_body.rotation = Quaternion.Euler(Vector3.zero);
	}
	private void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Space) && (m_isGrounded || m_jumpCount < 2))
		{
			m_rigidbody.linearVelocity = new Vector3(m_rigidbody.linearVelocity.x, 0, m_rigidbody.linearVelocity.z);

			m_rigidbody.AddForce(Vector3.up * m_jumpPorce, ForceMode.Impulse);

			m_leftJumpDelay = m_jumpLimitDelay;
			m_isGrounded = false;
			m_jumpCount++;

			m_animator.SetBool("Sit", false);
			m_animator.SetBool("Jump", true);

			if (m_isSit) SitUp();
		}
	}
	private void GroundCheck()
	{
		m_leftJumpDelay -= Time.deltaTime;
		if (m_leftJumpDelay <= 0)
		{
			Vector3 radius = new Vector3(m_groundedRadius, m_groundedHeight, m_groundedRadius);
			m_isGrounded = Physics.CheckBox(m_groundedTiptoe.position, radius, Quaternion.identity, m_groundedLayer);
			if (m_isGrounded)
			{
				m_isGrounded = true;
				m_animator.SetBool("Jump", false);
				m_jumpCount = 0;
			}
		}
	}
	private void Sit()
	{
		if (!m_isGrounded) return;
		if (Input.GetKeyDown(KeyCode.S) && !m_isSit)
		{
			SitDown();	
		}
		else if (Input.GetKeyUp(KeyCode.S) && m_isSit)
		{
			SitUp();
		}
	}
	private void SitDown()
	{
		Vector3 scale = m_player.transform.localScale;
		m_player.transform.localScale = new Vector3(scale.x, scale.y / 1.2f, scale.z);
		m_collider.height = m_collider.height / 2;
		m_collider.center = new Vector3(0, m_collider.center.y / 2, m_collider.center.z);

		m_animator.SetBool("Sit", true);

		m_isSit = true;
	}
	private void SitUp()
	{
		Vector3 scale = m_player.transform.localScale;
		m_player.transform.localScale = new Vector3(scale.x, scale.y * 1.2f, scale.z);

		m_collider.height = m_collider.height * 2;
		m_collider.center = new Vector3(0, m_collider.center.y * 2, m_collider.center.z);

		m_animator.SetBool("Sit", false);

		m_isSit = false;
	}
	private void SpeedUp()
	{
		if (m_moveSpeed >= m_maxMoveSpeed) return;
		m_moveSpeed += m_sppedUpPercent * Time.deltaTime;
	}
}
