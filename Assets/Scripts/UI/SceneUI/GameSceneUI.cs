using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneUI : BaseUI
{
    [SerializeField] GameScene gameScene;

    [SerializeField] WindowUI testWindowUI;

    private void Start()
    {
        GetUI<Button>("PauseButton").onClick.AddListener(gameScene.Pause);
        GetUI<Button>("RestartButton").onClick.AddListener(gameScene.Restart);
        GetUI<Button>("TimeScaleButton").onClick.AddListener(gameScene.ChangeTimeScale);
        GetUI<Button>("TestWindowButton").onClick.AddListener(ShowTestWindow);
    }

    private void OnEnable()
    {
        SetLife(gameScene.Life);
        gameScene.OnLifeChanged += SetLife;

        SetGold(gameScene.Gold);
        gameScene.OnGoldChanged += SetGold;

        SetTimeScale(Time.timeScale);
        gameScene.OnTimeScaleChanged += SetTimeScale;
    }

    private void OnDisable()
    {
        gameScene.OnLifeChanged -= SetLife;
        gameScene.OnGoldChanged -= SetGold;
        gameScene.OnTimeScaleChanged -= SetTimeScale;
    }

    private void SetLife(int life)
    {
        GetUI<TMP_Text>("LifeValue").text = $"{life}";
    }

    private void SetGold(int gold)
    {
        GetUI<TMP_Text>("GoldValue").text = $"{gold}";
    }

    private void SetTimeScale(float timeScale)
    {
        GetUI<TMP_Text>("TimeScaleValue").text = $"X{timeScale}";
    }

    private void ShowTestWindow()
    {
        Manager.UI.ShowWindowUI(testWindowUI);
    }
}
