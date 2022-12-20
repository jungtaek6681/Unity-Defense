using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{
	private Renderer render;

	public Tower tower;

	[SerializeField]
	private Color normal;

	[SerializeField]
	private Color mouseOver;

	private void Awake()
	{
		render = GetComponent<Renderer>();
	}

	private void Start()
	{
		render.material.color = normal;
	}

	private void OnMouseOver()
	{
		render.material.color = mouseOver;
	}

	private void OnMouseExit()
	{
		render.material.color = normal;
	}

	private void OnMouseUpAsButton()
	{
		if (null == tower)
			BuildManager.Instance.Build(this);
	}
}
