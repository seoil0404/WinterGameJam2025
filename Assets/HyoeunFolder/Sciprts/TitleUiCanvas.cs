using UnityEngine;

public class TitleUiCanvas : MonoBehaviour
{
    public void TutorialButton()
    {
        SceneController.Instance.LoadScene(SceneType.TutorialScene);
    }
}
