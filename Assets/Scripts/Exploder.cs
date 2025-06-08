using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 50f;

    public void Explode(float explosionRadius)
    {
        foreach (Rigidbody ExplodableObject in GetExplodableObjects(explosionRadius))
        {
            ExplodableObject.AddExplosionForce(_explosionForce, transform.position, explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects(float explosionRadius)
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);

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
