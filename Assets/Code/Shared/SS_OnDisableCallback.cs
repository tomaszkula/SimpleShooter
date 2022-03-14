using UnityEngine;

public class SS_OnDisableCallback : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] SS_GameEvent onDisableEvent = null;

    private void OnDisable()
    {
        onDisableEvent?.Invoke(new SS_GameEventData()
        {
            GameObjectValues = new GameObject[] { gameObject }
        });
    }
}
