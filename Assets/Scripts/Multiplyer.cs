using UnityEngine;

public class Multiplyer
{
    private int _minChanceForMultiply = 0;
    private int _maxChanceForMultiply = 100;

    public bool TryMultiply(int _multiplyDegree)
    {
        if (Random.Range(_minChanceForMultiply, _maxChanceForMultiply) <= _maxChanceForMultiply / _multiplyDegree) return true;
        else return false;
    }
}
