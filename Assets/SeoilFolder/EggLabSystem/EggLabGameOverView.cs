using UnityEngine;

public class EggLabGameOverView : MonoBehaviour
{
    public void Continue()
    {
        SceneController.Instance.LoadScene(SceneType.minji);
    }

    public void Exit()
    {
        SceneController.Instance.LoadScene(SceneType.Titlemain);
    }
}
