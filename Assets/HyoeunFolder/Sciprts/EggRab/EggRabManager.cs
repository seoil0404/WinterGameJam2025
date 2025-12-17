using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class EggRabManager : MonoBehaviour
{
    public static EggRabManager Instance;

    public GameObject TargetPrefeb;
    public int TargetCount;
    public int TargetXSpawnpointCount;
    public int TargetYSpawnpointCount;
    private List<GameObject> Targets;
    private void Awake()
    {
        Targets = new List<GameObject>();
        Instance = this;
        for (int i = 0; i < TargetCount; i++)
        {
            TargetGenerate();
        }
    }
	public void TargetGenerate()
	{
		Vector3 position = GetRandomPos();
		Targets.Add(Instantiate(TargetPrefeb, position, Quaternion.identity));
	}
	public void TargetGenerate(GameObject pTarget)
    {
        GameObject target = null;
        foreach (GameObject i in Targets)
        {
            if (i == pTarget)
            {
                target = i;
                break;
            }
            Destroy(target);
        }
        Vector3 position = GetRandomPos();
        Targets.Add(Instantiate(TargetPrefeb, position, Quaternion.identity));
    }
    private Vector3 GetRandomPos()
    {
        Vector3 randomPos = Vector3.zero;
        for(int j = 0; j < 100; j++ )
        {
            bool isMatch = false;

            randomPos.x = Random.Range(0, TargetXSpawnpointCount);
            randomPos.y = Random.Range(0, TargetYSpawnpointCount);
            for (int i = 0; i < Targets.Count; i++)
            {
                if (randomPos == Targets[i].transform.position)isMatch = true;
            }
            if (!isMatch) break;
        }
        Debug.Log($"{randomPos}");
        return randomPos;
    }
    
}
