using UnityEngine;

public class SS_PhysicalForwardMovement : MonoBehaviour, SS_IMoveable
{
    [Header("Variables")]
    [SerializeField] float moveSpeed = 0f;

    [Header("Component")]
    Transform myTransform = null;
    Rigidbody myRigidbody = null;

    private void Awake()
    {
        myTransform = transform;
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        myRigidbody.velocity = moveSpeed * myTransform.forward;
    }
}
