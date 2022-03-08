using UnityEngine;

public class TSG_Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0f;

    private void Update()
    {
        var pos = transform.position;
        pos.z -= moveSpeed * Time.deltaTime;
        transform.position = pos;
    }
}