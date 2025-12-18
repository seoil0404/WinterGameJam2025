using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ObjectPool
{
	private Queue<GameObject> m_pool;
	private GameObject m_prefab;
	private Transform m_parent;

	private bool m_isActivePool;

	public ObjectPool(GameObject pPrefab)
	{
		m_prefab = pPrefab;
	}

	public void Init(int pPoolSize = 20)
	{
		m_pool = new Queue<GameObject>(pPoolSize);
		m_parent = new GameObject($"{m_prefab.name} Pool").transform;
		m_isActivePool = true;

		for (int i = 0; i < pPoolSize; i++)
		{
			GameObject obj = GameObject.Instantiate(m_prefab, m_parent);
			obj.SetActive(false);
			m_pool.Enqueue(obj);
		}
	}

	public GameObject Get()
	{
		if (!m_isActivePool) return null;

		if (m_pool.Any())
		{
			GameObject obj = m_pool.Dequeue();
			obj.transform.parent = null;
			obj.SetActive(true);
			return obj;
		}

		Debug.LogWarning("Pool Size Over");
		return GameObject.Instantiate(m_prefab);
	}

	public void Return(GameObject pObj)
	{
		if (!m_isActivePool)
		{
			GameObject.Destroy(pObj);
			return;
		}

		pObj.SetActive(false);
		m_pool.Enqueue(pObj);
		pObj.transform.parent = m_parent;
	}

	public void Clear()
	{
		GameObject.Destroy(m_parent.gameObject);
		m_pool.Clear();
		m_pool = null;
		m_isActivePool = false;
	}
}
