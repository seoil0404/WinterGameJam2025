using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "Scriptable Objects/AudioData")]
public class AudioData : ScriptableObject
{
    [SerializeField] private AudioClip testSound;

    public AudioClip TestSound => testSound;
}
