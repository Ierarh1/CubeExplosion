using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _body;
    [SerializeField] private InputHandler _inputHandler;


    private void Update()
    {
        Vector2 look = _inputHandler.LookInput();

        _camera.Rotate(_speed * -look.y * Time.deltaTime * Vector3.right);
        _body.Rotate(_speed * look.x * Time.deltaTime * Vector3.up);
    }
}
