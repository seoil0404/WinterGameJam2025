using System.Collections;
using UnityEngine;

public class CutSceneScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(WaitRoadScene());
    }
    private IEnumerator WaitRoadScene()
    {
        yield return new WaitForSeconds(13);
        SceneController.Instance.LoadScene(SceneType.TutorialScene);

    }
}
