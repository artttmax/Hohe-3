using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _multiplyDegree = 1;
    [SerializeField] private int _multiplyRatio = 2;

    private int _minChanceForMultiply = 0;
    private int _maxChanceForMultiply = 100;
    private int _minObjectsCount = 2;
    private int _maxObjectsCount = 6;
    private int _objectsCount;

    public void Spawn()
    {
        if (Random.Range(_minChanceForMultiply, _maxChanceForMultiply + 1) <= _maxChanceForMultiply / _multiplyDegree)
        {
            _multiplyDegree *= _multiplyRatio;
            transform.localScale -= (Vector3.one / _multiplyDegree);
            _objectsCount = Random.Range(_minObjectsCount, _maxObjectsCount);

            for (int i = 1; i <= _objectsCount; i++)
            {
                Instantiate(transform);
                
            }
        }
    }
}
