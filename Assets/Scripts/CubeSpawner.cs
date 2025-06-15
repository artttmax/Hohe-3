using UnityEditor;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private int _minObjectsCount = 2;
    private int _maxObjectsCount = 6;
    private int _objectsCount;

    public void Spawn( GameObject _gameObject)
    {
        _objectsCount = Random.Range(_minObjectsCount, _maxObjectsCount);

        for (int i = 1; i <= _objectsCount; i++)
        {
            Instantiate(_gameObject, _gameObject.transform.position, _gameObject.transform.rotation);      
        }
    }
}
