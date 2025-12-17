using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance { get; private set; }

    [SerializeField] private EffectData effectData;

    public EffectData EffectData => effectData;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {

    }

    public void GenerateEffect(Effect effect, Vector3 effectPosition)
    {
        Instantiate(effect).transform.position = effectPosition;
    }
}
