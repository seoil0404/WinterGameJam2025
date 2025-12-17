using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpMapManager : MonoBehaviour
{
    [SerializeField] private float _loadSceneTime;
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
        SceneManager.LoadScene("Titlemain");
    }
}
