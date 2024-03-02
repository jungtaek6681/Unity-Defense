using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] EventSystem defaultEventSystem;

    [SerializeField] Canvas popUpCanvas;
    [SerializeField] Image popUpBlocker;

    private Stack<PopUpUI> popUpStack = new Stack<PopUpUI>();
    private float prevTimeScale;

    public void Init()
    {

    }

    public void EnsureEventSystem()
    {
        if (EventSystem.current != null)
            return;

        Instantiate(defaultEventSystem);
    }

    public T ShowPopUpUI<T>(T popUpUI) where T : PopUpUI
    {
        if (popUpStack.Count > 0)
        {
            PopUpUI topUI = popUpStack.Peek();
            topUI.gameObject.SetActive(false);
        }
        else
        {
            popUpBlocker.gameObject.SetActive(true);
            prevTimeScale = Time.timeScale;
            Time.timeScale = 0f;
        }

        T ui = Instantiate(popUpUI, popUpCanvas.transform);
        popUpStack.Push(ui);
        return ui;
    }

    public void ClosePopUpUI()
    {
        PopUpUI ui = popUpStack.Pop();
        Destroy(ui.gameObject);

        if (popUpStack.Count > 0)
        {
            PopUpUI topUI = popUpStack.Peek();
            topUI.gameObject.SetActive(true);
        }
        else
        {
            popUpBlocker.gameObject.SetActive(false);
            Time.timeScale = prevTimeScale;
        }
    }

    public void ClearPopUpUI()
    {
        while (popUpStack.Count > 0)
        {
            ClosePopUpUI();
        }
    }
}
