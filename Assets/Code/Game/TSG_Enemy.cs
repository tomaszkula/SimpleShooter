using UnityEngine;

public class TSG_Enemy : MonoBehaviour
{
    TSG_IMoveable iMoveable = null;
    TSG_IShooter iShooter = null;

    private void Awake()
    {
        iMoveable = GetComponent<TSG_IMoveable>();
        iShooter = GetComponent<TSG_IShooter>();
    }

    private void Update()
    {
        iMoveable?.Move();
        iShooter?.Shoot();
    }
}