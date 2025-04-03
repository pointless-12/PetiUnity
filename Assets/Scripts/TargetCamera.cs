using UnityEngine;

public class TargetCamera : MonoBehaviour
{
    [SerializeField] Transform target;

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(target.position - transform.position);
    }
}
