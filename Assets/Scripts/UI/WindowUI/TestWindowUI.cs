using UnityEngine;
using UnityEngine.UI;

public class TestWindowUI : WindowUI
{
    private void Start()
    {
        GetComponent<Image>().color = Random.ColorHSV();
        GetUI<Button>("CloseButton").onClick.AddListener(Close);
    }
}
