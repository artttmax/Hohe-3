using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private int _minObjectsCount = 2;
    private int _maxObjectsCount = 6;
    private int _objectsCount;

    public void Spawn()
    {
        _objectsCount = Random.Range(_minObjectsCount, _maxObjectsCount);

        for (int i = 1; i <= _objectsCount; i++)
        {
            Instantiate(transform);      
        }
    }
}
