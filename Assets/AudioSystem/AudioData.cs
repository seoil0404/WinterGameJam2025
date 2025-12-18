using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "Scriptable Objects/AudioData")]
public class AudioData : ScriptableObject
{
    [SerializeField] private AudioClip testSound;
    [SerializeField] private AudioClip eggDestroy;
    [SerializeField] private AudioClip gameOver;
    [SerializeField] private AudioClip mainBGM;
    [SerializeField] private AudioClip abocadoExplosion;
    [SerializeField] private AudioClip applePeel;
    [SerializeField] private AudioClip coconutExplosion;
    [SerializeField] private AudioClip waterMelonExplosion;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip shoot;
    [SerializeField] private AudioClip walk;
    [SerializeField] private AudioClip titleBGM;

    public AudioClip Jump => jump;
    public AudioClip Shoot => shoot;
    public AudioClip Walk => walk;
    public AudioClip TestSound => testSound;
    public AudioClip EggDestroy => eggDestroy;
    public AudioClip GameOver => gameOver;
    public AudioClip MainBGM => mainBGM;
    public AudioClip AbocadoExplosion => abocadoExplosion;
    public AudioClip ApplePeel => applePeel;
    public AudioClip CoconutExplosion => coconutExplosion;
    public AudioClip WaterMelonExplosion => waterMelonExplosion;
    public AudioClip TitleBGM => titleBGM;
}
