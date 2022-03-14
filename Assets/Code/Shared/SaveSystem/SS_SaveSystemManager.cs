using UnityEngine;

public class SS_SaveSystemManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] SS_GameEvent onSaveLoad = null;

    private void Start()
    {
        loadSave();
    }

    private void loadSave()
    {
        SS_SaveSystem.Load();
        onSaveLoad?.Invoke();
    }
}
