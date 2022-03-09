using UnityEngine;

public class TSG_SaveSystemManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] TSG_GameEvent onSaveLoad = null;

    private void Start()
    {
        loadSave();
    }

    private void loadSave()
    {
        TSG_SaveSystem.Load();
        onSaveLoad?.Invoke();
    }
}
