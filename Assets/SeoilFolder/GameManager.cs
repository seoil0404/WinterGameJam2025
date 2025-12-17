using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        AudioManager.Instance.SetBGM(AudioManager.Instance.AudioData.MainBGM);
    }

    public void GameOver()
    {

    }
}
