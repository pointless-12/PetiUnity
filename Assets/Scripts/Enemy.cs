using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] float smoothMovementTime = 1;
    [SerializeField] float waitingTime = 2;
    [SerializeField] float shootDelay = 3;
    [SerializeField] Projectile projectile;

    Vector2 targetPoint;

    float waitingTimer;
    float shootingTimer;

    Vector2 velocity;

    private void Start()
    {
        targetPoint = CameraUtility.GetRandomPointInCamera(Camera.main);
        shootingTimer = shootDelay;
    }
    void Update()
    {
        HandleMoving();

        HandleShooting();

    }

    private void HandleMoving()
    {
        Vector2 pos = (Vector2)transform.position;

        if (waitingTimer <= 0)
        {
            float epsilon = 0.01f;
            if (Vector2.Distance(pos,targetPoint)>epsilon)
            {
                transform.position = Vector2.SmoothDamp(pos, targetPoint, ref velocity, smoothMovementTime);
            }
            else
            {
                waitingTimer = waitingTime;
                targetPoint = CameraUtility.GetRandomPointInCamera(Camera.main);
            }

        }
        else
        {
            waitingTimer -= Time.deltaTime;

        }
    }

    private void HandleShooting()
    {
        shootingTimer -= Time.deltaTime;
        if (shootingTimer <= 0)
        {
            SpaceshipController player = FindAnyObjectByType<SpaceshipController>();
            if (player != null)
            {
                Vector3 playerPoint = player.transform.position;
                Vector3 direction = playerPoint - transform.position;
                float angle = Vector3.SignedAngle(direction, Vector3.up, -Vector3.forward);

                Quaternion rotation = Quaternion.Euler(0, 0, angle);
                Projectile newProjectile = Instantiate(projectile, transform.position, rotation);
                shootingTimer += shootDelay;
            }
        }
    }

     
}
