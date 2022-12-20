using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexPlace : MonoBehaviour
{
	[SerializeField]
	private TowerPlace towerPlace;

	[SerializeField]
	private float placeSize;

	private void Start()
	{
		Instantiate(towerPlace, transform);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		Gizmos.matrix = transform.localToWorldMatrix;

		Gizmos.DrawWireSphere(Vector3.zero, placeSize);
	}
}
