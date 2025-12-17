using UnityEngine;

public class BananaManager : MonoBehaviour
{
    public static BananaManager Instance {  get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void GenerateBanana()
    {
        Obstacle banana = Instantiate(ObstacleManager.Instance.ObstacleData.BananaObstacle);
        banana.Initialize(MapManager.RecentMapPosition + MapManager.TangerineLength / 2);
    }
}
