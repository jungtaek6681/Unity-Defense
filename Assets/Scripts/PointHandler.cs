using UnityEngine;
using UnityEngine.InputSystem;

public class PointHandler : MonoBehaviour
{
    private Vector2 pointer;

    private void Click()
    {
        Ray ray = Camera.main.ScreenPointToRay(pointer);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Debug.DrawRay(ray.origin, ray.direction * hitInfo.distance, Color.red, 0.1f);
            BuildingPoint buildingPoint = hitInfo.collider.GetComponent<BuildingPoint>();
            buildingPoint?.Build();
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * int.MaxValue, Color.red, 0.1f);
        }
    }

    private void OnPointer(InputValue value)
    {
        pointer = value.Get<Vector2>();
    }

    private void OnClick(InputValue value)
    {
        if (value.isPressed)
        {
            Click();
        }
    }
}
