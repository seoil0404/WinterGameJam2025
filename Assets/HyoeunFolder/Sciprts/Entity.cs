using UnityEngine;

public abstract class Entity:MonoBehaviour
{
    [SerializeField] private int m_maxHp;
    private int m_hp;
	private void Awake()
	{
		m_hp = m_maxHp;
	}
	public virtual void GiveDamage(int pDamage)
    {
        m_hp -= pDamage;
        if(m_hp <= 0)
        {
            m_hp = 0;
            Kill();
        }
    }
    protected virtual void Kill()
    {
        Destroy(gameObject);
    }
}
