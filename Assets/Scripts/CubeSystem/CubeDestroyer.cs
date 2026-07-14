using System;
using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;

    public event Action<Cube> CubeClicked;

    private void OnEnable() =>
        _spawner.CubeSpawned += OnCubeSpawned;
    private void OnDisable() =>
        _spawner.CubeSpawned -= OnCubeSpawned;

    private void OnCubeSpawned(Cube cube) =>
        cube.Clicked += OnCubeClicked;

    private void OnCubeClicked(Cube cube)
    {
        cube.Clicked -= OnCubeClicked;

        CubeClicked?.Invoke(cube);

        Destroy(cube.gameObject);
    }
}
