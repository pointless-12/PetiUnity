using UnityEngine;

public class Glider : MonoBehaviour
{
    [SerializeField] float speed = 10;
    Vector3 targetPoint;

    private void Start()
    {
        targetPoint = transform.position;
    }
    void Update()
    {
        if (transform.position == targetPoint)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                targetPoint += Vector3.up;
            if (Input.GetKeyDown(KeyCode.DownArrow))
                targetPoint += Vector3.down;
            if (Input.GetKeyDown(KeyCode.RightArrow))
                targetPoint += Vector3.right;
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                targetPoint += Vector3.left;
        }

        else
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
    }
}
