using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseUI.activeSelf)
            {
                Cursor.lockState = CursorLockMode.Locked; 
            }
            pauseUI.SetActive(!pauseUI.activeSelf);
        }
    }
}
