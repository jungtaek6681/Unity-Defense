using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [SerializeField] EventSystem defaultEventSystem;

    public void Init()
    {

    }

    public void EnsureEventSystem()
    {
        if (EventSystem.current != null)
            return;

        Instantiate(defaultEventSystem);
    }
}
