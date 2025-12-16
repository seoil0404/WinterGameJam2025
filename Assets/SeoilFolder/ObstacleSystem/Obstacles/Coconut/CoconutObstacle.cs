using System.Collections;
using UnityEngine;

public class CoconutObstacle : Obstacle
{
    [SerializeField] private ParticleSystem coconutVFX;
    [SerializeField] private ParticleSystem coconutDust;
    [SerializeField] private float groundOffset = 10.5f;
    [SerializeField] private float fallOffset;

    public override float SpawnWeight => 1;

    public override void Initialize(float position)
    {
        SetRandomLinedPosition(position);

        SyncPosition();
    }

    public void OnGround()
    {
        Destroy(coconutVFX.gameObject);
        StartCoroutine(DestroyDust(Instantiate(coconutDust.gameObject)));
    }

    private IEnumerator DestroyDust(GameObject coconutDust)
    {
        coconutDust.transform.position = transform.position;

        yield return new WaitForSeconds(2f);
        Destroy(coconutDust);
    }

    private void Update()
    {
        if(transform.position.y > 10.5)
            SyncPosition();
    }

    private void SyncPosition()
    {
        float yPosition;

        if (PlayerController.Instance != null)
            yPosition = transform.position.z - PlayerController.Instance.transform.position.z + groundOffset;
        else 
            yPosition = transform.position.z - CubeController.Instance.transform.position.z + groundOffset - fallOffset;

        transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);

        if (yPosition <= groundOffset)
            OnGround();
    }
}
