using UnityEngine;

public class GameOverView : MonoBehaviour
{
    public void Continue()
    {
        SceneController.Instance.LoadScene(SceneType.MainScene);
    }

    public void Exit()
    {
        SceneController.Instance.LoadScene(SceneType.Titlemain);
    }
}
