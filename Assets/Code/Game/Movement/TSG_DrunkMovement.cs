using UnityEngine;

public class TSG_DrunkMovement : MonoBehaviour, TSG_IMoveable
{
    [Header("Variables")]
    [SerializeField] float moveSpeed = 0f;
    [SerializeField] TSG_MinMax movementRange = new TSG_MinMax(0f, 0f);
    [SerializeField] [Range(0f, 1f)] float mostPossibleDirectionChance = 0f;

    float xPosition = 0f;
    float mostPossibleDirection = 0f;

    [Header("Components")]
    Transform myTransform = null;

    private void Awake()
    {
        myTransform = transform;
    }

    private void Start()
    {
        mostPossibleDirection = getTotallyRandomDirection();
    }

    public void Move()
    {
        Vector3 _position = myTransform.position;
        _position += moveSpeed * Time.deltaTime * myTransform.forward;

        float _direction = getDirection();
        xPosition += _direction * moveSpeed * Time.deltaTime;
        xPosition = Mathf.Clamp(xPosition, movementRange.Min, movementRange.Max);
        if(movementRange.IsInRange(xPosition) == false)
        {
            mostPossibleDirection = -mostPossibleDirection;
        }
        _position.x = xPosition;

        myTransform.position = _position;
    }

    private float getTotallyRandomDirection()
    {
        float _value = Random.value;
        float _direction = _value > 0.5f ? 1f : -1f;
        return _direction;
    }

    private float getDirection()
    {
        float _value = Random.value;
        float _direction = _value > mostPossibleDirectionChance ? -mostPossibleDirection : mostPossibleDirection;
        return _direction;
    }
}
