using UnityEngine;

[CreateAssetMenu(fileName = "EffectData", menuName = "Scriptable Objects/EffectData")]
public class EffectData : ScriptableObject
{
    [SerializeField] private Effect abocadoExplosion;
    [SerializeField] private Effect waterMelonExplosion;
    [SerializeField] private Effect appleRabitExplosion;
    [SerializeField] private Effect raspBerryExplosion;
    [SerializeField] private Effect dust;
    [SerializeField] private Effect eggHit;
    [SerializeField] private Effect playerHit;
    [SerializeField] private Effect coconutPosition;
    [SerializeField] private Effect jump;

    public Effect AbocadoExplosion => abocadoExplosion;
    public Effect WaterMelonExplosion => waterMelonExplosion;
    public Effect RabbitAppleExplosion => appleRabitExplosion;
    public Effect RaspBerryExplosion => raspBerryExplosion;
    public Effect Dust => dust;
    public Effect EggHit => eggHit;
    public Effect PlayerHit => playerHit;
    public Effect CoconutPosition => coconutPosition;
    public Effect Jump => jump;
}
