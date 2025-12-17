using UnityEngine;

public class KillPart : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        transform.position = new Vector3(0, 2, 0);
    }
}
//실패함!! 적용안되어있음