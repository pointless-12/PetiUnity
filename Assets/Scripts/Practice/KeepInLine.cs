using UnityEngine;
using System.Collections.Generic;

public class KeepInLine : MonoBehaviour
{
    [SerializeField] List<Transform>objects;

    
    void Update()
    {
        if (objects.Count <= 2)
            return;

        Vector3 posStart = transform.position;
        Vector3 posEnd = objects[objects.Count - 1].position;

        for (int i = 0; i < objects.Count; i++)
        {
            float rate = i / (float)(objects.Count - 1);
            objects[i].position = Vector3.Lerp(posStart, posEnd, rate);
        }
    }
}
