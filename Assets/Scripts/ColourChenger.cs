using UnityEngine;

public class ColourChenger : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }
}
