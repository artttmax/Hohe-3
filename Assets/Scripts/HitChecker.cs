using UnityEngine;

public class HitChecker : MonoBehaviour
{
    [SerializeField] private int _multiplyDegree = 1;
    [SerializeField] private int _multiplyRatio = 2;
    [SerializeField] private float _explosionForce = 100f;
    [SerializeField] private float _explosionRadius = 2f;
    [SerializeField] private Raycaster _raycast;
    [SerializeField] private Cube _currentCube;

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

    private void Hitted(Cube hittedCube)
    {
        if (hittedCube == _currentCube)
        {
            if (Random.Range(_minChanceForMultiply, _maxChanceForMultiply + 1) <= _maxChanceForMultiply / _multiplyDegree)
            {
                _multiplyDegree *= _multiplyRatio;
                transform.localScale -= (Vector3.one / _multiplyDegree);
                _raycast.GetComponent<CubeSpawner>().Spawn(gameObject);
                _raycast.GetComponent<Exploder>().Explode(_explosionForce, gameObject.transform.position, transform.localScale.x);
            }
            else
            {
                _raycast.GetComponent<Exploder>().Explode(_explosionForce * _multiplyDegree, gameObject.transform.position, _explosionRadius * _multiplyDegree);
            }

            Destroy(gameObject);
        }
    }
}
