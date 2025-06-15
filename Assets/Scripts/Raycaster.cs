using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance = 10f;

    public event Action<Cube> CubeHitted;

    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * _maxDistance, Color.gray);

        if (Physics.Raycast(ray, out RaycastHit _hit, _maxDistance))
        {
            GameObject gameObject = _hit.collider.gameObject;

            if (gameObject.TryGetComponent(out Cube cube))
            {
                CubeHitted?.Invoke(cube);
            }
        }
    }
}
