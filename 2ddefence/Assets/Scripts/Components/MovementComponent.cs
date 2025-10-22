using UnityEngine;

public class MovementComponent : MonoBehaviour
{

    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] Vector3 _moveDirection = Vector3.right;
    private bool _isMoving = true;

    // Update is called once per frame
    void Update()
    {
        if (_isMoving)
        {
            transform.position += _moveDirection * _moveSpeed * Time.deltaTime;
        }
    }
    public void SetDirection(Vector3 direction)
    {
        _moveDirection = direction;
    }

    public void StartMoving()
    {
        _isMoving = true;
    }
    public void StopMoving()
    {
        _isMoving = false;
    }
}
