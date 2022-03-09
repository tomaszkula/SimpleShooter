using UnityEngine;

public class TSG_Enemy : MonoBehaviour
{
    TSG_IMoveable iMoveable = null;

    private void Awake()
    {
        iMoveable = GetComponent<TSG_IMoveable>();
    }

    private void Update()
    {
        iMoveable?.Move();
    }
}