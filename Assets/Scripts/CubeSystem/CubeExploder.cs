using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _upwardsModifier = 200f;
    [SerializeField] private float _randomTorque = 80f;

    public void Explode(Vector3 center, Cube[] targets)
    {
        foreach (Cube target in targets)
        {
            if (target.TryGetComponent(out Rigidbody rigidbody) == false) 
            {
                rigidbody = target.gameObject.AddComponent<Rigidbody>();
            }   

            rigidbody.AddExplosionForce(_explosionForce, center, _explosionRadius, _upwardsModifier, ForceMode.Impulse);
            rigidbody.AddTorque(Random.insideUnitSphere * _randomTorque, ForceMode.Impulse);
        }
    }
}
