using System.Collections;
using UnityEngine;

public class RandomManager : MonoBehaviour
{
    public GameObject capsul;
    private void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());
    }

    IEnumerator RandomRespawn_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
        }
    }

}