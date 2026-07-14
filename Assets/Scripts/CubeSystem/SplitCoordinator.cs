using UnityEngine;

public class SplitCoordinator : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private CubeDestroyer _destroyer;
    [SerializeField] private CubeExploder _exploder;
    [SerializeField] private float _chanceDivider = 2f;

    private Cube[] children;

    private void OnEnable() =>
        _destroyer.CubeClicked += OnCubeClicked;
    private void OnDisable() =>
        _destroyer.CubeClicked -= OnCubeClicked;

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
