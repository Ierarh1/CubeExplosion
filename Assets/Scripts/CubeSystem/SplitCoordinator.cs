using UnityEngine;

public class SplitCoordinator : MonoBehaviour
{
    [SerializeField] private CubeLifeCycle _spawner;
    [SerializeField] private CubeExploder _exploder;
    [SerializeField] private float _chanceDivider = 2f;

    private Cube[] children;

    private void OnEnable() => 
        Cube.Clicked += OnCubeClicked;
    private void OnDisable() => 
        Cube.Clicked -= OnCubeClicked;

    private void OnCubeClicked(Cube cube)
    {
        if (Random.value >= cube.SplitChance)
        { 
            return;
        }

        float childrenChance = cube.SplitChance / _chanceDivider;

        children = _spawner.SpawnChildren(cube, childrenChance);
       
        _exploder.Explode(cube.transform.position, children);
    }
}
