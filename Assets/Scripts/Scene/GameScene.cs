using UnityEngine;
using UnityEngine.Events;

public class GameScene : MonoBehaviour
{
    [SerializeField] PausePopUpUI pausePopUpUI;

    public event UnityAction<float> OnTimeScaleChanged;

    [SerializeField] int life;
    public int Life { get { return life; } private set { life = value; OnLifeChanged?.Invoke(value); } }
    public event UnityAction<int> OnLifeChanged;

    [SerializeField] int gold;
    public int Gold { get { return gold; } private set { gold = value; OnGoldChanged?.Invoke(value); } }
    public event UnityAction<int> OnGoldChanged;

    public void Pause()
    {
        Manager.UI.ShowPopUpUI(pausePopUpUI);
    }

    public void Restart()
    {
        Debug.Log("Restart");
    }

    public void ChangeTimeScale()
    {
        Time.timeScale = Time.timeScale % 3 + 1;
        OnTimeScaleChanged?.Invoke(Time.timeScale);
    }
}
