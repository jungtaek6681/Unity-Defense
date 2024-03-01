using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingPoint : MonoBehaviour
    , IPointerClickHandler
    , IPointerEnterHandler
    , IPointerExitHandler
{
    [SerializeField] new Renderer renderer;
    [SerializeField] Color normal;
    [SerializeField] Color highLight;

    public void Build()
    {
        Debug.Log("Build");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Build();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        renderer.material.color = highLight;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        renderer.material.color = normal;
    }
}
