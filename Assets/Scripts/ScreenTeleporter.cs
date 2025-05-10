using System;
using UnityEngine;

public class ScreenTeleporter : MonoBehaviour
{

    Camera cam;
    Collider2D coll;
    private void Start()
    {
        cam = Camera.main; 
    }

    void FixedUpdate()
    {
        
        Rect cameraRect = CameraUtility.GetRect(cam);
        Rect objRect = GetObjectRect();

        if(!cameraRect.Overlaps(objRect))
        {
            Vector2 jump = Vector2.zero;
            
            if (objRect.xMax < cameraRect.xMin)
                jump += Vector2.right * (cameraRect.width + objRect.width);
            if (objRect.xMin > cameraRect.xMax)
                jump += Vector2.left * (cameraRect.width + objRect.width);
            if (objRect.yMax < cameraRect.yMin)
                jump += Vector2.up * (cameraRect.height + objRect.height);
            if (objRect.yMin > cameraRect.yMax)
                jump += Vector2.down * (cameraRect.height + objRect.height);

            transform.position += (Vector3) jump;
        }
    }

    Rect GetObjectRect()
    {
        if (coll == null)
            coll=GetComponent<Collider2D>();

        Bounds bounds = coll.bounds;
        return new Rect(bounds.min, bounds.size);
    }

    private void OnDrawGizmos()
    {
        

        Gizmos.color = Color.yellow;
        Rect objRect = GetObjectRect();
        Gizmos.DrawWireCube(objRect.center,objRect.size);
    }
}
