using UnityEngine;

public class SpawnParentsCubes : MonoBehaviour
{
    [SerializeField] private SpawnChildrensCubes _spawner;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _startScale = Vector3.one;
    [SerializeField] private float _startSplitChance = 1f;
    [SerializeField] private int _amountCube;

    private void Start()
    {

        for(int i = 0; i < _amountCube; i++)
        {
            _startPosition.x += i;
            _startPosition.y += i;
            _startPosition.z += i;

            _spawner.Spawn(_startPosition, _startScale, _startSplitChance);
        }
    }
}
