using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5; // Sebess�g v�ltoz�
    [SerializeField] float angularVelocity = 180; // Sz�gsebess�g
    [SerializeField] Transform cameraTransform;

    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal"); // V�zszintes bemenet
        float vInput = Input.GetAxisRaw("Vertical"); // F�gg�leges bemenet

        Vector3 cameraRight = cameraTransform.right * hInput;
        Vector3 cameraForward = cameraTransform.forward * vInput;
        cameraForward.y = 0;
        cameraForward.Normalize();
        Vector3 direction = cameraRight + cameraForward;

        // Vector3 direction = new(hInput, 0, vInput); // Ir�ny vektor

        direction.Normalize(); // Ir�ny normaliz�l�sa
                               // Komment

        float stepLength = speed * Time.deltaTime;
        transform.position += direction * stepLength; // Poz�ci� friss�t�se


        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angularVelocity* Time.deltaTime);
        }

    }
}
