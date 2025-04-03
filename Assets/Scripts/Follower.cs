using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] float range = 5;
    [SerializeField] float speed = 10;
    [SerializeField] Transform target;
    //[SerializeField] AnimationCurve

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        float distance = direction.magnitude;



        // float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= range)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            } 
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}