using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
	private NavMeshAgent agent;
	private int curWayIndex = 0;

	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("WayPoint"))
		{
			if (curWayIndex >= WaveManager.Instance.WayPoints.Count - 1)
				OnArriveEndPoint();
			else
				SetNextPoint();
		}
	}

	private void OnArriveEndPoint()
	{
		WaveManager.Instance.TakeDamage(1);
		Destroy(gameObject);
	}

	private void SetNextPoint()
	{
		curWayIndex++;
		agent.destination = WaveManager.Instance.WayPoints[curWayIndex].position;
	}

	public void TakeDamage(int damage)
	{
		BuildManager.Instance.GainEnergy(1);
		Destroy(gameObject);
	}
}
