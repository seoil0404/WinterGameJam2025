using UnityEngine;

[CreateAssetMenu(fileName = "EffectData", menuName = "Scriptable Objects/EffectData")]
public class EffectData : ScriptableObject
{
    [SerializeField] private Effect abocadoExplosion;
    [SerializeField] private Effect waterMelonExplosion;
    [SerializeField] private Effect appleRabitExplosion;
    [SerializeField] private Effect dust;
    [SerializeField] private Effect eggHit;
    [SerializeField] private Effect playerHit;

    public Effect AbocadoExplosion => abocadoExplosion;
    public Effect WaterMelonExplosion => waterMelonExplosion;
    public Effect AppleRabitExplosion => appleRabitExplosion;
    public Effect Dust => dust;
    public Effect EggHit => eggHit;
    public Effect PlayerHit => playerHit;
}
