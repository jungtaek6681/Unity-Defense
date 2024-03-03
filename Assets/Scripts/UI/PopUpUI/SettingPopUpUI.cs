using UnityEngine;
using UnityEngine.UI;

public class SettingPopUpUI : PopUpUI
{
    private void Start()
    {
        GetUI<Button>("SaveButton").onClick.AddListener(Save);
        GetUI<Button>("BackButton").onClick.AddListener(Close);
    }

    public void Save()
    {
        ConfirmPopUpUI ui = Manager.UI.ShowPopUpUI<ConfirmPopUpUI>();
        ui.OkButton.onClick.AddListener(Ok);
    }

    public void Ok()
    {
        Debug.Log("Save");
        Close();
    }
}
