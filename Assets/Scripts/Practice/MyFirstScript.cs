using UnityEngine;

class MyFirstScript : MonoBehaviour
{
    void Start()
    {
        Vector2 v2a = new(1, 2);     // 2 Dimenziós
        Vector3 v3a = new(1, 2, 5);  // 3 Dimenziós

        Vector3 v3b = new(2, 6, 5);

        Vector3 v3c = v3a + v3b;  // (3,8,10)

        float length = v3c.magnitude;

        Vector3 norm = v3c.normalized;

        v3c.Normalize();

        // -----------------------

        Vector3 v1 = Vector3.up;    // (0,1,0)
        Vector3 v2 = Vector3.left;  // (-1,0,0)
        Vector3 v3 = Vector3.back;  // (0,0,-1)

        Vector3 v4 = Vector3.zero;  // (0,0,0)
        Vector3 v5 = Vector3.one;   // (1,1,)





    }
}