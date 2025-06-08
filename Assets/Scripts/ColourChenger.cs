using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class ColourChenger : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }
}
