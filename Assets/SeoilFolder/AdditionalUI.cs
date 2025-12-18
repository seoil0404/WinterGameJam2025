using UnityEngine;

public class AdditionalUI : MonoBehaviour
{
    public void MoveJumpMap()
    {
        SceneController.Instance.LoadScene(SceneType.teachme);
    }

    public void MoveEggLab()
    {
        SceneController.Instance.LoadScene(SceneType.minji);
    }
}
