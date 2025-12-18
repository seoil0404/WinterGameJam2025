using System;
using System.Collections;
using DG.Tweening;
using NUnit.Framework.Internal.Execution;
using Unity.VectorGraphics;
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

    [SerializeField] private SceneFadeView sceneFadeViewPrefab; 

    private bool isMoving = false;

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
        
    }

    public void LoadScene(SceneType sceneName, float duration = 1f)
    {
        StartCoroutine(LoadScene(sceneName.ToString(), duration));
    }

    public void LoadSceneWithoutFade()
    {
        SceneManager.LoadScene(sceneName.ToString());
    }

    private IEnumerator LoadScene(string sceneName, float duration)
    {
        Instantiate(sceneFadeViewPrefab).Initialize(duration);

        yield return new WaitForSecondsRealtime(duration / 2);

        SceneManager.LoadScene(sceneName.ToString());
    }
}
