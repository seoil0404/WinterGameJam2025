using UnityEngine;

public class TitleUiCanvas : MonoBehaviour
{
    public void TutorialButton()
    {
        SceneController.Instance.LoadSceneWithoutFade(SceneType.TutorialScene);
    }
}
