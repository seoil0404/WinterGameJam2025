using UnityEngine;

public class SettingManager : MonoBehaviour
{
    public static SettingManager Instance {  get; private set; }

#if UNITY_EDITOR
    [RuntimeInitializeOnLoadMethod]
    private static void GenerateSettingManager()
    {
        GameObject settingManager = new GameObject(nameof(SettingManager));
        settingManager.AddComponent<SettingManager>();
    }
#endif

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    private void Update()
    {
        if(FindAnyObjectByType<PlayerController>() != null && Input.GetKeyDown(KeyCode.Escape))
        {
            //SettingUI.Instance.gameObject.SetActive(!SettingUI.Instance.gameObject.activeSelf);
        }
            
    }
}
