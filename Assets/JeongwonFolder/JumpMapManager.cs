using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpMapManager : MonoBehaviour
{
    [SerializeField] private float _loadSceneTime;

	private void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	private void Update()
	{
		if(Input.GetKeyUp(KeyCode.Escape)) SceneController.Instance.LoadScene(SceneType.Titlemain);
	}
	private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(GameClear());
        
        foreach(Transform c in this.transform.GetChild(0))
        {
            c.AddComponent<Rigidbody>();
        }
        transform.AddComponent<Rigidbody>();
    }
    private IEnumerator GameClear()
    {
        yield return new WaitForSeconds(_loadSceneTime);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneController.Instance.LoadScene(SceneType.Titlemain);
    }
}
