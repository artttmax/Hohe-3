using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _multiplyDegree = 1;
    [SerializeField] private int _multiplyRatio = 2;
    [SerializeField] private float _explosionForce = 100f;
    [SerializeField] private float _explosionRadius = 2f;
    [SerializeField] private Raycaster _raycast;

    private int _minChanceForMultiply = 0;
    private int _maxChanceForMultiply = 100;

    private void OnEnable()
    {
        _raycast.CubeHitted += Hitted;
    }

    private void OnDisable()
    {
        _raycast.CubeHitted -= Hitted;        
    }

    private void Hitted (Cube hittedCube)
    {
        if (hittedCube == this)
        {
            if (Random.Range(_minChanceForMultiply, _maxChanceForMultiply + 1) <= _maxChanceForMultiply / _multiplyDegree)
            {
                _multiplyDegree *= _multiplyRatio;
                transform.localScale -= (Vector3.one / _multiplyDegree);
                GetComponent<CubeSpawner>().Spawn();
                GetComponent<Exploder>().Explode(_explosionForce, transform.localScale.x);
            }
            else
            {
                GetComponent<Exploder>().Explode(_explosionForce * _multiplyDegree, _explosionRadius * _multiplyDegree);
            }

            Destroy(gameObject);
        }
    }
}
