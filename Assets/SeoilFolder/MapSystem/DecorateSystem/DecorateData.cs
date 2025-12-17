using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DecorateData", menuName = "Scriptable Objects/DecorateData")]
public class DecorateData : ScriptableObject
{
    public List<Decorate> Data;
}
