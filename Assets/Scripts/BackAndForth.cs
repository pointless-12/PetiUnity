using System.Security.Cryptography;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    [SerializeField] Transform t1,t2;
    [SerializeField] float speed = 5;
    [SerializeField, Range(0,1)] float startPosition;

    [SerializeField] Transform currentTarget;


    private void OnValidate()
    {
        if (t1 == null || t2 == null)
            return;

        //transform.position = (t1.position+ t2.position)/2;
        transform.position = Vector3.Lerp(t1.position, t2.position, startPosition);
    }
    void Start()
    {
        transform.position = t1.position;

        currentTarget = t2;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, t2.position, speed * Time.deltaTime);

        if (transform.position == currentTarget.position)
            currentTarget = currentTarget == t2 ? t1 : t2;
    }
    void OnDrawGizmos()
    {
        if (t1 == null || t2 == null)
            return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(t1.position, t2.position);
    }
}

