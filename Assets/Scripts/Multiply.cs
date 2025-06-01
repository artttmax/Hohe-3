using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Multiply : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private int _multiplyDegree = 1;

    private int _minObjectsCount = 1;
    private int _maxObjectsCount = 6;
    private int _minChanceForMultiply = 0;
    private int _maxChanceForMultiply = 100;

    private void OnMouseDown()
    {
        if (ChanceForMultiplyObject())
        {
            _multiplyDegree *= 2;
            transform.localScale -= (Vector3.one / _multiplyDegree);

            for (int i = 1; i <= Random.Range(_minObjectsCount, _maxObjectsCount); i++)
            {
                MultiplyObject();
            }

            Explode();
        }

        Destroy(gameObject);
    }

    private bool ChanceForMultiplyObject()
    {
        if (Random.Range(_minChanceForMultiply, _maxChanceForMultiply) <= _maxChanceForMultiply/ _multiplyDegree) return true; 
        else return false;
    }

    private void MultiplyObject()
    {
        Instantiate(transform);
    }

    private void Explode()
    {
        foreach (Rigidbody ExplodableObject in GetExplodableObjects())
        {
            ExplodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects() 
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> ExplodableObjects = new List<Rigidbody>();
        
        foreach (Collider hit in hits) 
        { 
            if (hit.attachedRigidbody != null)
            {
                ExplodableObjects.Add(hit.attachedRigidbody);
            }
        }

        return ExplodableObjects;
    }
}
