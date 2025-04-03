using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5; // Sebesség változó
    [SerializeField] float angularVelocity = 180; // Szögsebesség
    [SerializeField] Transform cameraTransform;

    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal"); // Vízszintes bemenet
        float vInput = Input.GetAxisRaw("Vertical"); // Függõleges bemenet

        Vector3 cameraRight = cameraTransform.right * hInput;
        Vector3 cameraForward = cameraTransform.forward * vInput;
        cameraForward.y = 0;
        cameraForward.Normalize();
        Vector3 direction = cameraRight + cameraForward;

        // Vector3 direction = new(hInput, 0, vInput); // Irány vektor

        direction.Normalize(); // Irány normalizálása
                               // Komment

        float stepLength = speed * Time.deltaTime;
        transform.position += direction * stepLength; // Pozíció frissítése


        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angularVelocity* Time.deltaTime);
        }

    }
}
