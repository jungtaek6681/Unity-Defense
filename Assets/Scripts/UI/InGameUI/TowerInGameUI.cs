using UnityEngine;
using UnityEngine.UI;

public class TowerInGameUI : InGameUI
{
    [SerializeField] TowerData archerData;
    [SerializeField] TowerData cannonData;
    [SerializeField] TowerData mageData;

    private BuildingPoint buildingPoint;

    private void Start()
    {
        GetUI<Button>("ArcherButton").onClick.AddListener(() => { BuildMenu(archerData); });
        GetUI<Button>("CannonButton").onClick.AddListener(() => { BuildMenu(cannonData); });
        GetUI<Button>("MageButton").onClick.AddListener(() => { BuildMenu(mageData); });
    }

    public void SetBuildingPoint(BuildingPoint buildingPoint)
    {
        this.buildingPoint = buildingPoint;
    }

    private void BuildMenu(TowerData towerData)
    {
        BuildInGameUI ui = Manager.UI.ShowInGameUI<BuildInGameUI>();
        ui.SetBuildingPoint(buildingPoint);
        ui.SetTowerData(towerData);
    }
}
