using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] Vector3 axis = Vector3.up;
    [SerializeField] float angularSpeed;

    void Update()
    {
        transform.Rotate(axis, angularSpeed * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 globalAxis = transform.TransformVector(axis);
        Vector3 a = transform.position + globalAxis;
        Vector3 b = transform.position - globalAxis;
        Gizmos.DrawLine(a,b);
    }
}
