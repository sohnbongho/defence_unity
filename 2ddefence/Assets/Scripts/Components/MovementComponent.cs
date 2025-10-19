using UnityEngine;

public class MovementComponent : MonoBehaviour
{

    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] Vector3 _moveDirection = Vector3.right;
    
    // Update is called once per frame
    void Update()
    {
        transform.position += _moveDirection * _moveSpeed * Time.deltaTime;
    }
}
