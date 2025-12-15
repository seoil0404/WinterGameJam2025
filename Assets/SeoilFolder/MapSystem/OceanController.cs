using UnityEngine;

public class OceanController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, playerTransform.position.z);
    }
}
