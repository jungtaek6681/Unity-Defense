using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float zoomSpeed;

    [SerializeField] float padding;

    private Vector3 moveDir;
    private float zoomScroll;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        Move();
        Zoom();
    }

    private void Move()
    {
        transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);
    }

    private void Zoom()
    {
        transform.Translate(Vector3.forward * zoomScroll * zoomSpeed * Time.deltaTime, Space.Self);
    }

    private void OnPointer(InputValue value)
    {
        Vector2 mousePos = value.Get<Vector2>();

        if (-padding <= mousePos.x && mousePos.x <= padding)
        {
            moveDir.x = -1;
        }
        else if (Screen.width - padding <= mousePos.x && mousePos.x <= Screen.width + padding)
        {
            moveDir.x = 1;
        }
        else
        {
            moveDir.x = 0;
        }

        if (-padding <= mousePos.y && mousePos.y <= padding)
        {
            moveDir.z = -1;
        }
        else if (Screen.height - padding <= mousePos.y && mousePos.y <= Screen.height + padding)
        {
            moveDir.z = 1;
        }
        else
        {
            moveDir.z = 0;
        }
    }

    private void OnZoom(InputValue value)
    {
        zoomScroll = value.Get<Vector2>().y;
    }
}
