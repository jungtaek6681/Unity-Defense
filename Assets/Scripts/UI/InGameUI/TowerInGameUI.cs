using UnityEngine;
using UnityEngine.UI;

public class TowerInGameUI : InGameUI
{
    [SerializeField] BuildInGameUI buildInGameUI;

    private void Start()
    {
        GetUI<Button>("ArcherButton").onClick.AddListener(BuildMenu);
        GetUI<Button>("CannonButton").onClick.AddListener(BuildMenu);
        GetUI<Button>("MageButton").onClick.AddListener(BuildMenu);
    }

    private void BuildMenu()
    {
        Manager.UI.ShowInGameUI(buildInGameUI);
    }
}
