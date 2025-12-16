using System.Collections;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoadTutorialScene());
    }

    private IEnumerator LoadTutorialScene()
    {
        yield return new WaitForSeconds(13f);

        SceneController.Instance.LoadScene(SceneType.TutorialScene);
    }
}