using UnityEngine;

public enum MixBerryType
{
    BlueBerry,
    RaspBerry
}

public class MixBerry : MonoBehaviour
{
    [SerializeField] private MixBerryType type;
    private MixBerryObstacle mixBerryObstacle;

    public void Initialize(MixBerryObstacle mixBerryObstacle)
    {
        this.mixBerryObstacle = mixBerryObstacle;
    }

    private void OnDestroy()
    {
        if(type == MixBerryType.RaspBerry)
        {
            mixBerryObstacle.OnRaspBerryDestroyed();
        }
    }
}
