using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveManager : SingleTon<WaveManager>
{
	[Header("Way")]
	[SerializeField]
	private Transform way;
	public List<Transform> WayPoints { get; private set; }

	[Header("Enemy")]
	[SerializeField]
	private Enemy enemyPrefab;
	[SerializeField]
	private float spawnDelay;
	private Coroutine spawnRoutine;

	private void Awake()
	{
		GetWayPoints();
	}

	private void Start()
	{
		spawnRoutine = StartCoroutine(SpawnRoutine());
	}

	private void GetWayPoints()
	{
		WayPoints = new List<Transform>();
		for (int i = 0; i < way.childCount; i++)
		{
			WayPoints.Add(way.GetChild(i));
		}
	}

	private IEnumerator SpawnRoutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(spawnDelay);
			Instantiate(enemyPrefab, WayPoints.First().position, Quaternion.identity);
		}
	}
}
