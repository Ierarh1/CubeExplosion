using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _cameraTransform; 
    [SerializeField] private InputHandler _inputHandler;

    private Rigidbody _rigidbody;

    private void Awake() => 
        _rigidbody = GetComponent<Rigidbody>();

    private void FixedUpdate()
    {
        Vector2 move = _inputHandler.MoveInput;

        Vector3 direction = _cameraTransform.TransformDirection(new Vector3(move.x, 0, move.y));
        direction = Vector3.ClampMagnitude(direction, 1f);
        _rigidbody.linearVelocity = direction * _speed;
    }
}

