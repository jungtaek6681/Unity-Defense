using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelectUI : MonoBehaviour
{
	[SerializeField]
	private TowerElementUI towerUIPrefab;

	[SerializeField]
	private List<Tower> towers;

	private void Start()
	{
		for (int i = 0; i < towers.Count; i++)
		{
			TowerElementUI element = Instantiate(towerUIPrefab, transform);
			element.SetTower(towers[i]);
		}
	}
}
