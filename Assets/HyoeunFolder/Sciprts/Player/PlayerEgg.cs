using UnityEngine;

public class PlayerEgg:MonoBehaviour
{
    private int m_damage;
    public void Init(Vector3 pDir, float pSpeed, int pDamage)
    {
        GetComponent<Rigidbody>().AddForce(pDir * pSpeed, ForceMode.Impulse);
        m_damage = pDamage;
    }
	private void OnTriggerEnter(Collider pCollsion)
	{
        Obstacle collsion;
		if (pCollsion.transform.TryGetComponent<Obstacle>(out collsion))
        {
            ObstacleEntity entity;
            if(pCollsion.TryGetComponent<ObstacleEntity>(out entity))entity.GiveDamage(m_damage);
            Destroy(this.gameObject);
        }
        else if(!pCollsion.transform.CompareTag("Player"))
        {
            Destroy(this.gameObject);
		}
	}

}
