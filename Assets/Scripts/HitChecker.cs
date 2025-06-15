using UnityEngine;

public class HitChecker : MonoBehaviour
{
    [SerializeField] private Raycaster _raycast;
    [SerializeField] private Cube _currentCube;

    private void OnEnable()
    {
        _raycast.CubeHitted += Hitted;
    }

    private void OnDisable()
    {
        _raycast.CubeHitted -= Hitted;
    }

    private void Hitted(Cube hittedCube)
    {
        if (hittedCube == _currentCube)
        {
            if (_currentCube.TryToSpawn())
            {
                _raycast.GetComponent<CubeSpawner>().Spawn(gameObject, _currentCube.GetMultiplyDegree());
                _raycast.GetComponent<Exploder>().Explode(gameObject.transform.position, _raycast.GetComponent<CubeSpawner>().GetNewCubes());              
            }
            else
            {
                _raycast.GetComponent<Exploder>().Explode(gameObject.transform.position, _currentCube.GetMultiplyDegree());
            }

            Destroy(gameObject);
        }
    }
}
