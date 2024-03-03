using UnityEngine.UI;

public class BuildInGameUI : InGameUI
{
    private void Start()
    {
        GetUI<Button>("BuildButton").onClick.AddListener(Close);
    }
}
