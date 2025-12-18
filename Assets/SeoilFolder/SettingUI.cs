using UnityEngine;

public class SettingUI : MonoBehaviour
{
    public static SettingUI Instance { get; private set; }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        gameObject.SetActive(false);
    }
}
