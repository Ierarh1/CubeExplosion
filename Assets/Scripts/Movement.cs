using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _cameraTransform; 
   
    private readonly string _horizontal = "Horizontal";
    private readonly string _vertical = "Vertical";

    private Rigidbody _rigidbody;

    void Awake() => _rigidbody = GetComponent<Rigidbody>();

    void FixedUpdate()
    {
        Vector3 direction = _cameraTransform.TransformDirection(new Vector3(Input.GetAxis(_horizontal), 0, Input.GetAxis(_vertical)));

        direction = Vector3.ClampMagnitude(direction, 1f);

        _rigidbody.linearVelocity = direction * _speed;
    }
}

