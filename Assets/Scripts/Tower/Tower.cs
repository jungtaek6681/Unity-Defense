using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
	[Header("General")]
	[SerializeField]
	private Transform topParts;
	[SerializeField]
	private Transform bottomParts;
	public Sprite icon;

	[Header("Spec")]
	[SerializeField]
	private int damage;
	[SerializeField]
	private float range;
	[SerializeField]
	private float fireRate;
	[SerializeField]
	private int cost;

	private Enemy target;
	private float lastShootTime = 0f;

	public int Cost { get { return cost; } private set { cost = value; } }

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

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
