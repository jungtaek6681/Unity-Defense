using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Tower : MonoBehaviour
{
	[Header("General")]
	[SerializeField]
	private Transform topParts;
	[SerializeField]
	private Transform bottomParts;

	[Header("Spec")]
	[SerializeField]
	private int damage;
	[SerializeField]
	private float range;
	[SerializeField]
	private float fireRate;

	private Enemy target;
	private float lastShootTime = 0f;

	private void Update()
	{
		FindTarget();
		Shoot();
	}


	private void FindTarget()
	{
		target = null;
		Collider[] colliders = Physics.OverlapSphere(transform.position, range);
		for (int i = 0; i < colliders.Length; i++)
		{
			target = colliders[i].GetComponent<Enemy>();
			if (null != target)
			{
				topParts.LookAt(colliders[i].transform.position);
				break;
			}
		}
	}

	private void Shoot()
	{
		if (null == target)
			return;

		if (Time.time < lastShootTime + fireRate)
			return;

		lastShootTime = Time.time;
		target.TakeDamage(damage);
	}
}
