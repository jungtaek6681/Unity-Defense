using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager instance;
    public static Manager Inst { get { return instance; } }

    [SerializeField] UIManager uiManager;
    public static UIManager UI { get { return instance.uiManager; } }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {
        instance = FindObjectOfType<Manager>(true);
        if (instance == null)
        {
            Debug.LogError("Manager : Can't find singleton instance");
            return;
        }
        DontDestroyOnLoad(instance);

        UI.Init();
    }

    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }
}
