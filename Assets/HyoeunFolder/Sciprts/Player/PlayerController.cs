using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), (typeof(CapsuleCollider)), (typeof(Animator)))]
public partial class PlayerController : MonoBehaviour
{
	private Rigidbody m_rigidbody;
	private Animator m_animator;
	private CapsuleCollider m_collider;
	private void Awake()
	{
		m_rigidbody = GetComponent<Rigidbody>();
		m_animator = GetComponent<Animator>();

		MovementAwake();
	}
	private void Update()
	{
		Move();
		Jump();
	}
}
