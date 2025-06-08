using UnityEngine;

[RequireComponent(typeof(CubeSpawner))]
[RequireComponent(typeof(Exploder))]

public class Cube : MonoBehaviour
{
    public void Destroy()
    {
        GetComponent<CubeSpawner>().Spawn();
        GetComponent<Exploder>().Explode(transform.localScale.x);
        Destroy(gameObject);
    }
}
