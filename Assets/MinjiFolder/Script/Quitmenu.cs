using UnityEngine;
using UnityEngine.SceneManagement;

public class Quitmenu : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Titlemain");
    }
}