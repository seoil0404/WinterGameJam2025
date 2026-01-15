using UnityEngine;

public class SceneMover : MonoBehaviour
{
    [SerializeField] private SceneType sceneType;

    public void MoveScene()
    {
        SceneController.Instance.LoadScene(sceneType);
    }
}
