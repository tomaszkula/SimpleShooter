using UnityEngine;

public class SS_DestroyerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider _other)
    {
        SS_IDestroyable _iDestroyable = _other?.GetComponent<SS_IDestroyable>();
        _iDestroyable?.Destroy();
    }
}
