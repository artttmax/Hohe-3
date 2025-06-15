using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 500f;
    [SerializeField] private float _explosionRadius = 20f;

    public void Explode(Vector3 position, List<Rigidbody> ExplodableObjects)
    {
        foreach (Rigidbody ExplodableObject in ExplodableObjects)
        {
            ExplodableObject.AddExplosionForce(_explosionForce, position, _explosionRadius);
        }
    }

    public void Explode(Vector3 position, int _multiplyDegree)
    {
        foreach (Rigidbody ExplodableObject in GetExplodableObjects(_explosionRadius * _multiplyDegree, position))
        {
            ExplodableObject.AddExplosionForce(_explosionForce * _multiplyDegree, position, _explosionRadius * _multiplyDegree);
        }
    }

    private List<Rigidbody> GetExplodableObjects(float explosionRadius, Vector3 position)
    {
        Collider[] hits = Physics.OverlapSphere(position, explosionRadius);

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
