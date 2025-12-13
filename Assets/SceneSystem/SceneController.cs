using System;
using System.Collections;
using NUnit.Framework.Internal.Execution;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

#if UNITY_EDITOR
    [RuntimeInitializeOnLoadMethod]
    private static void GenerateSceneController()
    {
        GameObject sceneController = new GameObject(typeof(SceneController).Name);
        sceneController.AddComponent<SceneController>();
    }
#endif

    public static SceneController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        Instance = this;

    }

    private void Start()
    {
        AudioManager.Instance.SetBGM(AudioManager.Instance.AudioData.TestSound);
    }

    public void LoadScene(SceneType sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }
}
