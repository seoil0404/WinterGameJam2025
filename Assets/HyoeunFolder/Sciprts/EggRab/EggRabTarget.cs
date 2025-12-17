using UnityEngine;

public class EggRabTarget : Entity
{
    protected override void Kill()
    {
        EggRabManager.Instance.TargetGenerate(this.gameObject);
    }
}
