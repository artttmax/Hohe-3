using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private GameObject _currentObject;
    [SerializeField] private float _explosionForce;
    [SerializeField]  private int _multiplyDegree = 1;

    private int _minObjectsCount = 2;
    private int _maxObjectsCount = 6;
    private float _explosionRadius;
    private bool _isHitted;
    private MultiplyingChance _multiplier;


    private void Start()
    {
        GameObject _tempGameObject = new GameObject();
        _tempGameObject.AddComponent<MultiplyingChance>();
        _multiplier = _tempGameObject.GetComponent<MultiplyingChance>();
        Destroy(_tempGameObject);

        _explosionRadius = _currentObject.transform.localPosition.x / 2;
        _isHitted = false;
    }

    private void Update()
    {
        if (_isHitted)
        {
            if (_multiplier.TryMultiply(_multiplyDegree))
            {
                _multiplyDegree *= 2;
                transform.localScale -= (Vector3.one / _multiplyDegree);

                for (int i = 1; i <= Random.Range(_minObjectsCount, _maxObjectsCount); i++)
                {
                    Instantiate(transform);
                }

                Explode();
            }

            Destroy(gameObject);
        }
    }

    public void Hitted()
    {
        _isHitted = true; 
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
