using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFadeView : MonoBehaviour
{
    [SerializeField] private Image view;

    public Image View => view;

    public void Initialize(float duration)
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(LoadScene(duration));
    }

    private IEnumerator LoadScene(float duration)
    {
        View.color = new Color(0, 0, 0, 0);
        View.DOColor(new Color(0, 0, 0, 1), duration / 2);

        yield return new WaitForSecondsRealtime(duration / 2 + 0.5f);

        Debug.Log("DoColor");
        View.color = new Color(0, 0, 0, 1);
        View.DOColor(new Color(0, 0, 0, 0), duration / 2);
        Destroy(gameObject, duration / 2);
    }
}
