using UnityEngine;

public partial class PlayerController
{
	[Space(20)]
	[Header("Camera")]
	[SerializeField] private Transform m_defaultCam;
    [SerializeField] private Transform m_aimingCam;

    [SerializeField] private float m_mouseSens;
    [SerializeField] private float m_changeTime;

	public void AimingCamera()
    {
        m_playerCamera.SetTarget(m_aimingCam, true);
	}
	public void DefaultCamera()
    {
		m_playerCamera.SetTarget(m_defaultCam, false);
	}
	private void CameraStart()
    {
        DefaultCamera();
        m_playerCamera.Init(m_mouseSens, m_changeTime, m_defaultCam.position);
    }

    private void CameraUpdate()
    {
        
    }
}
