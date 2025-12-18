using UnityEngine;

public class EggRabTarget : Entity
{
	public void Awake()
	{
	}
	protected override void Kill()
    {
        EggRabManager.Instance.TargetGenerate(this.transform.gameObject);
    }
}
