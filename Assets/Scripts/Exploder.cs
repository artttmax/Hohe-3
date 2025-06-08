using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Exploder : MonoBehaviour
{
    public void Explode(int explosionForce, int explosionRadius)
    {
        foreach (Rigidbody ExplodableObject in GetExplodableObjects(explosionRadius))
        {
            ExplodableObject.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects(int explosionRadius)
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
