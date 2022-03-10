using UnityEngine;

public class TSG_DestroyerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider _other)
    {
        TSG_IDestroyable _iDestroyable = _other?.GetComponent<TSG_IDestroyable>();
        _iDestroyable?.Destroy();
    }
}
