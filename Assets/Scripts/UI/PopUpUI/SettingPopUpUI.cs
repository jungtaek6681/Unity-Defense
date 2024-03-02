using UnityEngine;
using UnityEngine.UI;

public class SettingPopUpUI : PopUpUI
{
    [SerializeField] ConfirmPopUpUI confirmPopUpUI;

    private void Start()
    {
        GetUI<Button>("SaveButton").onClick.AddListener(Save);
        GetUI<Button>("BackButton").onClick.AddListener(Close);
    }

    public void Save()
    {
        ConfirmPopUpUI ui = Manager.UI.ShowPopUpUI(confirmPopUpUI);
        ui.OkButton.onClick.AddListener(Ok);
    }

    public void Ok()
    {
        Debug.Log("Save");
        Close();
    }
}
