using TMPro;
using UnityEngine.UI;

public class BuildInGameUI : InGameUI
{
    private BuildingPoint buildingPoint;
    private TowerData towerData;

    private void Start()
    {
        GetUI<Button>("BuildButton").onClick.AddListener(Build);
    }

    public void SetBuildingPoint(BuildingPoint buildingPoint)
    {
        this.buildingPoint = buildingPoint;
    }

    public void SetTowerData(TowerData towerData)
    {
        this.towerData = towerData;
        GetUI<TMP_Text>("Name").text = towerData.name;
        GetUI<TMP_Text>("Description").text = towerData.description;
        GetUI<TMP_Text>("BuildCost").text = towerData.levels[0].buildCost.ToString();
    }

    private void Build()
    {
        buildingPoint.Build(towerData);
        Manager.UI.CloseInGameUI();
    }
}
