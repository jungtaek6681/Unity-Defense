using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PausePopUpUI : PopUpUI
{
    [SerializeField] SettingPopUpUI settingPopUpUI;
    [SerializeField] ConfirmPopUpUI confirmPopUpUI;

    private void Start()
    {
        GetUI<Button>("ResumeButton").onClick.AddListener(Close);
        GetUI<Button>("SettingButton").onClick.AddListener(Setting);
        GetUI<Button>("ExitButton").onClick.AddListener(Exit);
    }

    public void Setting()
    {
        Manager.UI.ShowPopUpUI(settingPopUpUI);
    }

    public void Exit()
    {
        ConfirmPopUpUI ui = Manager.UI.ShowPopUpUI(confirmPopUpUI);
        ui.OkButton.onClick.AddListener(Ok);
    }

    public void Ok()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
