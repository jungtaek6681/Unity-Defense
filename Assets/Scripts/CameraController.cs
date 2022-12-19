using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private float moveSpeed;
	[SerializeField]
	public float zoomSpeed;

	[SerializeField]
	private float padding;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Confined;
	}

	private void Update()
	{
		Move();
		Zoom();
	}

	private void Move()
	{
		Vector2 pos = Input.mousePosition;

		if (0 <= pos.x && pos.x <= padding)
			transform.Translate(-moveSpeed * Time.deltaTime, 0f, 0f, Space.World);
		if (Screen.width - padding <= pos.x && pos.x <= Screen.width)
			transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f, Space.World);

		if (0 <= pos.y && pos.y <= padding)
			transform.Translate(0f, 0f, -moveSpeed * Time.deltaTime, Space.World);
		if (Screen.height - padding <= pos.y && pos.y <= Screen.height)
			transform.Translate(0f, 0f, moveSpeed * Time.deltaTime, Space.World);
	}

	private void Zoom()
	{
		float scroll = Input.GetAxis("Mouse ScrollWheel");

		transform.Translate(0f, 0f, scroll * zoomSpeed * Time.deltaTime, Space.Self);
	}
}
