using UnityEngine;

public class ClosestObjects : MonoBehaviour
{
    [SerializeField] float maxDistance = 10;
    [SerializeField] Color gizmosColor = Color.white;
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmosColor;

        Transform[] allTransforms = FindObjectsByType<Transform>(FindObjectsInactive.Exclude,FindObjectsSortMode.None);


        Vector3 p = transform.position;
        foreach (Transform other in allTransforms)
        {
            float d = Vector3.Distance(other.position, p);
            if(d<=maxDistance)
            {
                Gizmos.DrawLine(p, other.position);
            }
        }
    }
}
