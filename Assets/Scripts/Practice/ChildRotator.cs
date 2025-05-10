using UnityEngine;

public class ChildRotator : MonoBehaviour
{
    [SerializeField] float angularSpeed = 50;

    
    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if(child.TryGetComponent(out MeshRenderer _))
            {
                child.Rotate(0, angularSpeed*Time.deltaTime,0,Space.Self);
            }

        }
    }
}
