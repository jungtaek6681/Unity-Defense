using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class TowerPlace : MonoBehaviour
{
	private Renderer render;

	public Tower tower;

	[SerializeField]
	private Color normal;

	[SerializeField]
	private Color enable;

	[SerializeField]
	private Color disable;

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
		if (EventSystem.current.IsPointerOverGameObject())
		{
			render.material.color = normal;
		}
		else if (BuildManager.Instance.Energy >= BuildManager.Instance.SelectedTower.Cost)
		{
			render.material.color = enable;
		}
		else
		{
			render.material.color = disable;
		}
	}

	private void OnMouseExit()
	{
		render.material.color = normal;
	}

	private void OnMouseUpAsButton()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (null == tower)
			BuildManager.Instance.Build(this);
	}
}
