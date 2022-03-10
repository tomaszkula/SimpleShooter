using UnityEngine;

public class TSG_DrunkMovement : MonoBehaviour, TSG_IMoveable
{
    [Header("Variables")]
    [SerializeField] float moveSpeed = 0f;
    [SerializeField] TSG_MinMax movementRange = new TSG_MinMax(0f, 0f);
    [SerializeField] TSG_MinMax oneDirectionMoveDuration = new TSG_MinMax(0f, 0f);

    float defaultXPosition = 0f;
    float xPosition = 0f;
    float direction = 0f;
    float oneDirectionMoveTime = 0f;

    [Header("Components")]
    Transform myTransform = null;

    private void Awake()
    {
        myTransform = transform;
    }

    private void OnEnable()
    {
        defaultXPosition = myTransform.position.x;
        xPosition = 0f;
    }

    public void Move()
    {
        updateDirection();
        moveForward();
        moveHorizontal();
    }

    private void updateDirection()
    {
        if(oneDirectionMoveTime > 0f)
        {
            oneDirectionMoveTime -= Time.deltaTime;
        }
        else
        {
            oneDirectionMoveTime = oneDirectionMoveDuration.Random;
            direction = getDirection();
        }
    }

    private void moveForward()
    {
        Vector3 _position = myTransform.position;
        _position += moveSpeed * Time.deltaTime * myTransform.forward;
        myTransform.transform.position = _position;
    }

    private void moveHorizontal()
    {
        xPosition += direction * moveSpeed * Time.deltaTime;
        xPosition = Mathf.Clamp(xPosition, movementRange.Min, movementRange.Max);
        if (movementRange.IsInRange(xPosition) == false)
        {
            direction = -direction;
        }

        Vector3 _position = myTransform.position;
        _position.x = defaultXPosition + xPosition;
        myTransform.position = _position;
    }

    private float getDirection()
    {
        float _value = Random.value;
        if(_value < 0.4f)
        {
            return 1f;
        }
        else if(_value < 0.8f)
        {
            return -1f;
        }
        else
        {
            return 0f;
        }
    }
}
