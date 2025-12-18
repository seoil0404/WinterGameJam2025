using System;
using UnityEngine;
using System.Collections.Generic;
public class AutoReturn : MonoBehaviour
{
	private ObjectPool m_pool;
	private float m_returnTime;
	private bool m_isActive;

	private void Awkae()
	{
		m_isActive = false;
	}
	public void Init( float pReturnTime)
	{
		//m_pool = pPool;
		m_returnTime = pReturnTime;
		m_isActive = true;
	}

	private void Update()
	{
		if (!m_isActive) return;
		m_returnTime -= Time.deltaTime;
		if (m_returnTime <= 0)
		{
			//m_pool.Return(gameObject);
			//m_isActive = false;
			Destroy(gameObject);
		}
	}
}