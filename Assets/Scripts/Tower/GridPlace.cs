using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlace : MonoBehaviour
{
	[SerializeField]
	private TowerPlace towerPlace;

	[SerializeField]
	private Vector2Int gridSize;
	[SerializeField]
	private float placeSize;

	private void Start()
	{
		for (int y = 0; y < gridSize.y; y++)
		{
			for (int x = 0; x < gridSize.x; x++)
			{
				TowerPlace place = Instantiate(towerPlace, transform);
				place.transform.localPosition = new Vector3((x + 0.5f) * placeSize, 0, (y + 0.5f) * placeSize);
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		Gizmos.matrix = transform.localToWorldMatrix;

		for (int y = 0; y < gridSize.y; y++)
		{
			for (int x = 0; x < gridSize.x; x++)
			{
				var position = new Vector3((x + 0.5f) * placeSize, 0, (y + 0.5f) * placeSize);
				Gizmos.DrawWireCube(position, new Vector3(placeSize, 0, placeSize));
			}
		}
	}
}
