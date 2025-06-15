using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Exploder : MonoBehaviour
{
    public void Explode(float explosionForce, Vector3 position, float explosionRadius)
    {
        foreach (Rigidbody ExplodableObject in GetExplodableObjects(explosionRadius, position))
        {
            ExplodableObject.AddExplosionForce(explosionForce, position, explosionRadius);
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
