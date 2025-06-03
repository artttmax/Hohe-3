using System;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDrawer : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;
    [SerializeField] private float _maxDistance = 10f;

    void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(_ray.origin, _ray.direction * _maxDistance, Color.gray);

        if (Physics.Raycast(_ray, out hit, _maxDistance))
        {
            Exploder objectHit = hit.collider.gameObject.GetComponent<Exploder>();

            if (objectHit != null)
            {
                objectHit.Hitted();
            }
        }
    }
}
