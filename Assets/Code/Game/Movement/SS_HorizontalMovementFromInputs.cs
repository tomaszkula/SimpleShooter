using UnityEngine;
using UnityEngine.EventSystems;

public class SS_HorizontalMovementFromInputs : MonoBehaviour, SS_IMoveable
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
        moveByNormalInputs();
        moveByTouchInputs();
    }

	private void moveByNormalInputs()
	{
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			moveLeft();
		}
		else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			moveRight();
		}
	}

	private void moveByTouchInputs()
	{
		if (Input.touchCount < 1)
		{
			return;
		}

		bool _didMoveLeft = false;
		bool _didMoveRight = false;

		for (int i = 0; i < Input.touchCount; i++)
		{
			Touch _touch = Input.GetTouch(i);
			if(EventSystem.current.IsPointerOverGameObject(_touch.fingerId))
            {
				return;
            }

			Vector2 _touchPosition = _touch.position;
			Vector2 _normalizedTouchPosition = normalizeTouchPosition(_touchPosition);

			if (_normalizedTouchPosition.x < 0.3f && _didMoveLeft == false)
			{
				_didMoveLeft = true;
				moveLeft();
			}
			else if (_normalizedTouchPosition.x > 0.7f && _didMoveRight == false)
			{
				_didMoveRight = true;
				moveRight();
			}
		}
	}

	private void moveLeft()
	{
		Vector3 _position = myTransform.position;
		_position += moveSpeed * Time.deltaTime * -myTransform.right;
		myTransform.position = _position;
	}

	private void moveRight()
	{
		Vector3 _position = myTransform.position;
		_position += moveSpeed * Time.deltaTime * myTransform.right;
		myTransform.position = _position;
	}

	private Vector2 normalizeTouchPosition(Vector2 _position)
	{
		Vector2 _normalizedPosition = new Vector2(_position.x / Screen.width, _position.y / Screen.height);
		return _normalizedPosition;
	}
}
