using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    [Header("Настройки деления")]
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private int _minSplitCount = 2;
    [SerializeField] private int _maxSplitCount = 6;

    [Header("Эффект взрыва")]
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _randomTorque = 80f;

    private bool _isSplitting = false;
    private Rigidbody _rigidbody;

    private float _chanceCreationCube = 1f;
    private float _diver = 2;

private void OnMouseDown()
    {
        if (_isSplitting) return;

        _isSplitting = true;

        if (ShouldSplit(_chanceCreationCube))
        { 
            float currentScale = transform.localScale.x;
            
            SplitIntoSmallerCubes();    
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void SplitIntoSmallerCubes()
    {
        int count = Random.Range(_minSplitCount, _maxSplitCount + 1);

        Vector3 center = transform.position;
        
        Vector3 currentScale = transform.localScale;
        
        float offsetAmount = currentScale.x * 0.35f; 

        for (int i = 0; i < count; i++)
        {
            Vector3 offset = Random.insideUnitSphere * offsetAmount;

            Vector3 spawnPos = center + offset;

            GameObject prefabToUse = _cubePrefab != null ? _cubePrefab : gameObject;

            GameObject newCube = Instantiate(prefabToUse, spawnPos, Quaternion.identity);

            newCube.transform.localScale = currentScale * 0.5f;

            _rigidbody = newCube.GetComponent<Rigidbody>();

            if (_rigidbody == null)
            { 
                _rigidbody = newCube.AddComponent<Rigidbody>();
            }

            _rigidbody.AddExplosionForce(_explosionForce, center, _explosionRadius , 200f, ForceMode.Impulse);

            _rigidbody.AddTorque(Random.insideUnitSphere * _randomTorque);

            PassChanceChild(newCube);
        }

        Destroy(gameObject);
    }

    private bool ShouldSplit(float chance)
    {
        float random = Random.value;

        return random < chance;
    }

    private void PassChanceChild(GameObject child)
    {
        CubeClickHandler childHandler = child.GetComponent<CubeClickHandler>();

        if (childHandler != null)
        {
            childHandler._chanceCreationCube = _chanceCreationCube / _diver;
        }
    }
}