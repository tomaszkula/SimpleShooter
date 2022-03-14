using UnityEngine;

public class SS_Player : MonoBehaviour
{
	[Header("Components")]
	SS_IMoveable iMoveable = null;
	SS_IShooter iShooter = null;

    private void Awake()
    {
		iMoveable = GetComponent<SS_IMoveable>();
		iShooter = GetComponent<SS_IShooter>();
    }

    private void Update()
	{
		iMoveable?.Move();
		iShooter?.Shoot();
	}
}