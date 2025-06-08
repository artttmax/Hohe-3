using UnityEngine;

[RequireComponent(typeof(CubeSpawner))]
[RequireComponent(typeof(Exploder))]

public class Cube : MonoBehaviour
{
    public void Destroy()
    {
        GetComponent<CubeSpawner>().Spawn();
        Destroy(gameObject);
    }
}
