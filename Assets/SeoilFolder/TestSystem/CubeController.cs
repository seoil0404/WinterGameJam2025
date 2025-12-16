using UnityEngine;

public class CubeController : MonoBehaviour
{
    public static CubeController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}
