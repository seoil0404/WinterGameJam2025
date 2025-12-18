using UnityEngine;

public abstract class Egg:MonoBehaviour
{
    protected int m_damage;
    protected float m_speed;
    protected Vector3 m_direction;
    protected Rigidbody m_rigidbody;
	public virtual void Init(Vector3 pDir, float pSpeed, int pDamage)
    {
        
    }
	private void Awake()
	{
		m_rigidbody = GetComponent<Rigidbody>();
	}
}
