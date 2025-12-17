using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpMapButton : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene("Titlemain");
    }
}
