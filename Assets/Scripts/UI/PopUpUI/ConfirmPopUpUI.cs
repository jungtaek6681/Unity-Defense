using TMPro;
using UnityEditor;
using UnityEngine.UI;

public class ConfirmPopUpUI : PopUpUI
{
    public Button OkButton => GetUI<Button>("OkButton");

    private void Start()
    {
        GetUI<Button>("CancelButton").onClick.AddListener(Close);
    }
}
