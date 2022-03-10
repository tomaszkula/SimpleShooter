using UnityEngine;

public class TSG_OnDisableCallback : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] TSG_GameEvent onDisableEvent = null;

    private void OnDisable()
    {
        onDisableEvent?.Invoke(new TSG_GameEventData()
        {
            GameObjectValues = new GameObject[] { gameObject }
        });
    }
}
