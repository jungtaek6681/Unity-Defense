using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{
	private Renderer render;

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

	private void OnMouseUp()
	{
		Debug.Log("OnMouseUp");
	}

	private void OnMouseDown()
	{
		Debug.Log("OnMouseDown");
	}

	private void OnMouseEnter()
	{

		Debug.Log("OnMouseEnter");
	}

	private void OnMouseOver()
	{
		Debug.Log("OnMouseOver");
		render.material.color = mouseOver;
	}

	private void OnMouseExit()
	{
		Debug.Log("OnMouseExit");
		render.material.color = normal;
	}

	private void OnMouseDrag()
	{
		Debug.Log("OnMouseDrag");
	}

	private void OnMouseUpAsButton()
	{
		Debug.Log("OnMouseButton");
	}
}
