using UnityEngine;

[RequireComponent(typeof(ObstacleGenerator))]
public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager Instance { get; private set; }

    [SerializeField] private ObstacleData obstacleData;

    private ObstacleGenerator obstacleGenerator;
    
    private void Awake()
    {
        Instance = this;

        obstacleGenerator = GetComponent<ObstacleGenerator>();
    }
}
