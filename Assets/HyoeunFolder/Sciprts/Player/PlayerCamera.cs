using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	public static PlayerCamera Instance { get; private set; }

    [SerializeField] private Transform m_targetTransform;

	[Header("Offset")]
	[SerializeField] private Vector3 positionOffset;
	[SerializeField] private Vector3 rotationOffset;

	private Transform m_player;
	private float m_mouseSens;

	private float m_changeTime;
	private float m_lerpChangeTime;
	private bool m_isLerpChanging;

	private bool m_canRotate;

	private float m_mouseX;
	private float m_mouseY;

	private bool m_isPlayerAlive;

	public void PlayerDeath()
	{
		m_isPlayerAlive = true;
	}
	private void Awake()
	{
		Instance = this;
		m_mouseX = 0;
		m_mouseY = 0;
		m_canRotate = false;
		m_lerpChangeTime = 0;
		m_isPlayerAlive = false;
	}
	public void Init(float pSens, float pChangeTime, Vector3 pStartPos, Transform pPlayer)
	{
		m_player = pPlayer;
		m_mouseSens = pSens;
		m_changeTime = pChangeTime;
		this.transform.position = pStartPos;
	}
	public void SetTarget(Transform pTarget, bool pRotation)
    {
		m_lerpChangeTime = 0;

		m_targetTransform = pTarget;
		m_canRotate = pRotation;

		m_isLerpChanging = true;
    }
	private void Update()
	{
		if (m_isPlayerAlive) return;
		if (Vector3.Distance(m_targetTransform.position, this.transform.position) > 0.1f)
		{
			m_lerpChangeTime += Time.deltaTime;
			float time = m_lerpChangeTime / m_changeTime;
			transform.position = Vector3.Lerp(transform.position, m_targetTransform.position, time);
			transform.rotation = Quaternion.Lerp(transform.rotation, m_targetTransform.rotation, time);
		}
		else this.transform.position = m_targetTransform.position;

		if(m_canRotate)
		{
			AimingCam();
		}
	}
	private void AimingCam()
	{
		m_mouseX += Input.GetAxisRaw("Mouse X") * Time.deltaTime * m_mouseSens;
		m_mouseY -= Input.GetAxisRaw("Mouse Y") * Time.deltaTime * m_mouseSens;

		m_mouseY = Mathf.Clamp(m_mouseY, -25f, 25f);
		m_mouseX = Mathf.Clamp(m_mouseX, -40f, 40f);

		transform.transform.rotation = Quaternion.Euler(m_mouseY, m_mouseX, 0);
	}
}
