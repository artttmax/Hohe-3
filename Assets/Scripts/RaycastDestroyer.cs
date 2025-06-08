using UnityEngine;

public class RaycastDestroyer : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance = 10f;

    private void Update()
    {
        Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(_ray.origin, _ray.direction * _maxDistance, Color.gray);

        if (Physics.Raycast(_ray, out hit, _maxDistance))
        {
            Cube hittedCube = hit.collider.gameObject.GetComponent<Cube>();

            if (hittedCube != null)
            {
                hittedCube.Destroy();
            }
        }
    }
}
