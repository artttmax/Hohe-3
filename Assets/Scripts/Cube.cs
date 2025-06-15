using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _multiplyDegree = 1;
    [SerializeField] private int _multiplyRatio = 2;

    private int _minChanceForMultiply = 0;
    private int _maxChanceForMultiply = 100;

    public bool TryToSpawn()
    {
        if (Random.Range(_minChanceForMultiply, _maxChanceForMultiply + 1) <= _maxChanceForMultiply / _multiplyDegree)
        {
            _multiplyDegree *= _multiplyRatio;
            return true;
        }
        else 
        { 
            return false; 
        }
    }

    public int GetMultiplyDegree() 
    { 
        return _multiplyDegree; 
    }
}
