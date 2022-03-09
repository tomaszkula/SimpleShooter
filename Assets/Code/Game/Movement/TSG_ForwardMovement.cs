using UnityEngine;

public class TSG_ForwardMovement : MonoBehaviour, TSG_IMoveable
{
    [Header("Variables")]
    [SerializeField] float moveSpeed = 0f;

    [Header("Components")]
    Transform myTransform = null;

    private void Awake()
    {
        myTransform = transform;
    }

    public void Move()
    {
        Vector3 _position = myTransform.position;
        _position += moveSpeed * Time.deltaTime * myTransform.forward;
        myTransform.position = _position;
    }
}
