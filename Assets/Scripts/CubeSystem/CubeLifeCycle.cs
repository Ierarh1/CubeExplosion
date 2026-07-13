using UnityEngine;

public class CubeLifeCycle : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _minSplitCount = 2;
    [SerializeField] private int _maxSplitCount = 6;
    [SerializeField] private float _offsetFactor = 0.35f;
    [SerializeField] private float _scaleFactor = 0.5f;

    [Header("Инициализация спавна")]
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _startScale = Vector3.one;
    [SerializeField] private float _startSplitChance = 1f;
    [SerializeField] private int _amountCube;

    private void OnEnable() =>
        Cube.Clicked += OnCubeClicked;
    private void OnDisable() =>
        Cube.Clicked -= OnCubeClicked;

    private void Start()
    {
        for (int i = 0; i < _amountCube; i++)
        {
            Vector3 spawnPos = _startPosition + new Vector3(i, i, i);

            Spawn(spawnPos, _startScale, _startSplitChance);
        }
    }

    public Cube[] SpawnChildren(Cube parent, float childrenSplitChance)
    {
        int count = Random.Range(_minSplitCount, _maxSplitCount + 1);
        Cube[] children = new Cube[count];

        Vector3 center = parent.transform.position;

        Vector3 parentScale = parent.transform.localScale;
        Vector3 childScale = parentScale * _scaleFactor;

        float offsetAmount = parentScale.x * _offsetFactor;


        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPos = center + Random.insideUnitSphere * offsetAmount;

            children[i] = Spawn(spawnPos, childScale, childrenSplitChance);
        }

        return children;
    }

    public Cube Spawn(Vector3 position, Vector3 scale, float splitChance)
    {
        Cube cube = Instantiate(_cubePrefab, position, Quaternion.identity);

        cube.transform.localScale = scale;
        cube.SplitChance = splitChance;

        return cube;
    }

    private void OnCubeClicked(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}