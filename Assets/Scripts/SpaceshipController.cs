using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] float angualarSpeed = 180;
    [SerializeField] float acceleration = 10;
    [SerializeField] float maxSpeed = 15;
    [SerializeField] Transform[] guns;

    [SerializeField] GameObject projectile;
    [SerializeField] Rigidbody2D rigidBody;

    int shot=0;

    float linearDamping;

    private void OnValidate()
    {
        if (rigidBody == null)
            rigidBody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        linearDamping = rigidBody.linearDamping;
    }
    private void FixedUpdate()
    {

        float verticalInput = Input.GetAxisRaw("Vertical");
        verticalInput = Mathf.Max(0, verticalInput);

        if (verticalInput > 0)
        {
            rigidBody.linearVelocity += (Vector2)transform.up * acceleration * Time.fixedDeltaTime;
            rigidBody.linearVelocity = Vector2.ClampMagnitude(rigidBody.linearVelocity, maxSpeed);
            rigidBody.linearDamping = 0;
        }
        else
            rigidBody.linearDamping = linearDamping;
        

    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform gun = guns[shot % guns.Length];
            GameObject newProjectileGO = Instantiate(projectile, gun.position, gun.rotation);
            Projectile newProjectile = newProjectileGO.GetComponent<Projectile>();
            newProjectile.velocity += rigidBody.linearVelocity;
            shot++;
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        rigidBody.rotation -= horizontalInput * angualarSpeed * Time.deltaTime;

        //transform.position += velocity * Time.deltaTime;

    }
}
