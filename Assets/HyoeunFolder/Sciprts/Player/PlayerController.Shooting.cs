using Unity.VisualScripting;
using UnityEngine;

public partial class PlayerController
{
	[Space(20)]
	[Header("Shooting")]
	[SerializeField] private GameObject m_eggPrefab;
	[SerializeField] private float m_eggSpeed;
	[SerializeField] private float m_eggDelay;
	[SerializeField] private int m_eggDamage;
	private float m_leftEggDelay;
	private bool m_isAiming;
	private void ShootingAwake()
	{
		m_leftEggDelay = 0;
		m_isAiming = false;
	}

	private void ShootingUpdate()
	{
		m_leftEggDelay -= Time.deltaTime;
		if(Input.GetMouseButtonDown(1))
		{
			Debug.Log("aming");
			m_isAiming = true;
			AimingCamera();
		}
		else if(Input.GetMouseButtonUp(1))
		{
			Debug.Log("anaming");
			m_isAiming = false;
			DefaultCamera();
		}

		if(m_leftEggDelay <= 0 && m_isAiming)
		{
			if(Input.GetMouseButton(0))
			{
				Shoot();
				m_leftEggDelay = m_eggDelay;
				m_animator.SetTrigger("Egg");
			}
		}
	}
	private void Shoot()
	{
		Debug.Log("shoot");
		Vector3 eggPos = m_player.transform.position + new Vector3(0.2f, 0.5f, 0);
		Vector3 targetPos = GetCameraAimPointFromMuzzle(20f);

		Vector3 dir = (targetPos - eggPos).normalized * m_eggSpeed;

		GameObject egg = Instantiate(m_eggPrefab, eggPos, Quaternion.identity);
		egg.GetComponent<PlayerEgg>().Init(dir, m_eggSpeed, m_eggDamage);
	}
	private Vector3 GetCameraAimPointFromMuzzle(float pMaxDistance = 20)
	{
		Vector3 point = Vector3.zero;

		Ray targetRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit target;
		Vector3 targetPos;
		if (Physics.Raycast(targetRay, out target, pMaxDistance, LayerMask.GetMask("Map", "HitableObject")))
		{
			targetPos = target.point;
		}
		else
		{
			targetPos = targetRay.origin + targetRay.direction * pMaxDistance;
		}
		return targetPos;
	}
}
