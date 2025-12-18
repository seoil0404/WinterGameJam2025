using UnityEngine;

public class AudioSettingManager : MonoBehaviour
{
    public static AudioSettingManager Instance { get; private set; }

    public float BGMRate { get; private set; } = 1;
    public float SFXRate { get; private set; } = 1;

    private void Awake()
    {
        Instance = this;
    }

    public void SetBGMRate(float bgmRate)
    {
        BGMRate = bgmRate;
        AudioManager.Instance.SyncBGM(bgmRate);
    }

    public void SetSFXRate(float sfxRate)
    {
        SFXRate = sfxRate;
    }
}
