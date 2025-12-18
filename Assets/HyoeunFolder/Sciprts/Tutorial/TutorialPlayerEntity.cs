using UnityEngine;

public class TutorialPlayerEntity : Entity
{

	protected override void Kill()
	{
		TutorialManager.Instance.ReSpwan(this.gameObject);
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
