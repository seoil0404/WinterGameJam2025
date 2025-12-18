using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public void StartGame()
    {
        SceneController.Instance.LoadScene(SceneType.CutScene);
    }
}