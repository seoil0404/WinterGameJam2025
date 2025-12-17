using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class EggRabManager : MonoBehaviour
{
    public GameObject TargetPrefeb;
    public int TargetCount;
    public int TargetXSpawnpointCount;
    public int TargetYSpawnpointCount;
    private List<Vector3> Targets;
    private void Awake()
    {
        for (int i = 0; i < TargetCount; i++)
        {
            TargetGenerate();
        }
    }
    public void TargetGenerate()
    {
        Vector3 position = GetRandomPos();
        Instantiate(TargetPrefeb, position, Quaternion.identity);
    }
    public Vector3 GetRandomPos()
    {
        Vector3 randomPos = Vector3.zero;
        for(int j = 0; j < 100; j++ )
        {
            bool isMatch = false;

            randomPos.x = Random.Range(0, TargetXSpawnpointCount);
            randomPos.y = Random.Range(0, TargetYSpawnpointCount);

            for (int i = 0; i < TargetCount; i++)
            {
                if (randomPos == Targets[i])isMatch = true;
            }
            if (!isMatch) break;
        }
        Debug.Log("{0}");
        return randomPos;
    }
    
}
