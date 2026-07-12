using UnityEngine;

public class CubeRaycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance = 100f;
    [SerializeField] private LayerMask _cubeLayerMask = ~0;

    private Ray ray;

    private void Awake()
    {
        if (_camera == null)
            _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == false)
            return;

        ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance, _cubeLayerMask)
            && hit.collider.TryGetComponent(out Cube cube))
        {
            cube.Click();
        }
    }
}
