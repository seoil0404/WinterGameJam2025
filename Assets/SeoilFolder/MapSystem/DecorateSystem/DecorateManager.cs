using UnityEngine;

public class DecorateManager : MonoBehaviour
{
    public static DecorateManager Instance { get; private set; }

    [SerializeField] private DecorateData decorateData;
    [SerializeField] private float xInterval;

    private int currentDecorateIndex = 0;

    private int directionIndex = 0;

    private void Awake()
    {
        Instance = this;
        currentDecorateIndex = Random.Range(0, decorateData.Data.Count);
        directionIndex = Random.Range(0, 2);
    }

    public void GenerateDecorate()
    {
        currentDecorateIndex = (currentDecorateIndex + Random.Range(1, 3)) % decorateData.Data.Count;
        Decorate decorate = Instantiate(decorateData.Data[currentDecorateIndex]);

        if(directionIndex % 2 == 0)
        {
            decorate.transform.position = new Vector3(-xInterval, -12, MapManager.RecentMapPosition);
        }
        else
        {
            decorate.transform.position = new Vector3(xInterval, -12, MapManager.RecentMapPosition);
        }

        directionIndex++;
    }
}
