using UnityEngine;

public class Shift : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float maxDistance;

    Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }
    private void Update()
    {

        Vector3 distance = target.position - transform.position;
        Vector3 shift = Vector3.ClampMagnitude(distance, maxDistance);

        transform.position = startPosition + shift;
    }
}
