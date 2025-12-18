using UnityEngine;

[CreateAssetMenu(fileName = "TutorialScript", menuName = "Scriptable Objects/TutorialScript")]
public class TutorialScript : ScriptableObject
{
    public string[] Scripts;
    public string Quest;
    public Vector3 SpwanPoint;
}
