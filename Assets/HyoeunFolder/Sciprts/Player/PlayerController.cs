using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), (typeof(CapsuleCollider)), (typeof(Animator)))]
public partial class PlayerController : MonoBehaviour
{
	public static PlayerController Instance { get; private set; }

	private GameObject m_player;

	private PlayerCamera m_playerCamera;

	private Rigidbody m_rigidbody;
	private Animator m_animator;
	private CapsuleCollider m_collider;

	private bool m_isPlayingGame;

	public void GameOver()
	{
		m_playerCamera.PlayerDeath();
		m_isPlayingGame = false;

	}
	private void Awake()
	{
		m_isPlayingGame = true;
		Instance = this;
		m_rigidbody = GetComponent<Rigidbody>();
		m_animator = GetComponent<Animator>();
		m_collider = GetComponent<CapsuleCollider>();
		m_player = this.transform.gameObject;

		MovementAwake();
		ShootingAwake();
	}

	private void Start()
	{
		m_playerCamera = PlayerCamera.Instance;
		CameraStart();

	}
	private void Update()
	{
		if (!m_isPlayingGame) return;
		MovementUpdate();
		ShootingUpdate();
		CameraUpdate();
	}
}
