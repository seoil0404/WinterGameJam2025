using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using DG.Tweening;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; set; } = null;

    public AudioData AudioData;

    [SerializeField] private AudioSource bgmPrefab;
    [SerializeField] private AudioSource sfxPrefab;

    private LinkedList<AudioSource> bgmSourcePool = new();
    private List<AudioSource> sfxSourcePool = new();

#if UNITY_EDITOR
    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        GameObject audioManager = new GameObject(typeof(AudioManager).Name);
        audioManager.AddComponent<AudioManager>();
    }
#endif

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        bgmSourcePool.AddFirst(Instantiate(bgmPrefab, transform));
    }

    public void SetBGM(AudioClip clip, float volume = 1f, float fadeDuration = 1f)
    {
        if (bgmSourcePool.Count != 0 && clip == bgmSourcePool.First.Value) return;

        bgmSourcePool.First.Value.DOKill();
        bgmSourcePool.First.Value.DOFade(0, fadeDuration);
        bgmSourcePool.AddLast(bgmSourcePool.First.Value);
        bgmSourcePool.RemoveFirst();

        if (!Mathf.Approximately(bgmSourcePool.First.Value.volume, 0))
            bgmSourcePool.AddFirst(Instantiate(bgmPrefab, transform));

        AudioSource audioSource = bgmSourcePool.First.Value;
        audioSource.clip = clip;
        audioSource.Play();
        audioSource.volume = 0;
        audioSource.DOKill();
        audioSource.DOFade(volume, fadeDuration);
    }

    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        AudioSource audioSource = GetAvailableSFXSource();
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();
    }

    private AudioSource GetAvailableSFXSource()
    {
        foreach (var sfxSource in sfxSourcePool)
        {
            if (!sfxSource.isPlaying)
                return sfxSource;
        }

        AudioSource newSource = Instantiate(sfxPrefab, transform);
        sfxSourcePool.Add(newSource);

        return newSource;
    }
}
