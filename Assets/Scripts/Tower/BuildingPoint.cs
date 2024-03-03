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

    public void Build(TowerData tower)
    {
        Destroy(gameObject);
        Instantiate(tower.prefab, transform.position, transform.rotation);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TowerInGameUI ui = Manager.UI.ShowInGameUI<TowerInGameUI>();
        ui.followTarget = transform;
        ui.followOffset = new Vector2(150, 0);
        ui.SetBuildingPoint(this);
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
