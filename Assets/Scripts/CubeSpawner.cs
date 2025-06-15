using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private int _minObjectsCount = 2;
    private int _maxObjectsCount = 6;
    private int _objectsCount;
    private List<Rigidbody> NewCubes = new List<Rigidbody>();

    public void Spawn( GameObject _gameObject, int multiplyDegree)
    {
        _objectsCount = Random.Range(_minObjectsCount, _maxObjectsCount);
        _gameObject.transform.localScale -= (Vector3.one / multiplyDegree);

        for (int i = 1; i <= _objectsCount; i++)
        {
            Instantiate(_gameObject, _gameObject.transform.position, _gameObject.transform.rotation);
            NewCubes.Add(gameObject.GetComponent<Rigidbody>());
        }
    }

    public List<Rigidbody> GetNewCubes ()
    {
        return NewCubes;
    }
}
