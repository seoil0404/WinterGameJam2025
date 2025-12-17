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
		if(pCollsion.transform.CompareTag("HitableObject"))
        {
            pCollsion.GetComponent<Entity>().GiveDamage(m_damage);
            Destroy(this.gameObject);
        }
        else if(!pCollsion.transform.CompareTag("Player"))
        {
            Destroy(this.gameObject);
		}
	}

}
