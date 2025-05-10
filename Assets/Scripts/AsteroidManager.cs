using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] Asteroid[] asteroidsToSpawn;
    [SerializeField] int startAsteroidCount=4;
    [SerializeField] float startVelocityMin=3;
    [SerializeField] float startVelocityMax=6;
    [SerializeField] float startAngularVelocityMin=180;
    [SerializeField] float startAngularVelocityMax=360;

   // [SerializeField] float minStartSpeed;
   // [SerializeField] float maxStartSpeed;

    [SerializeField] float colliderDelay = 1;
    [SerializeField] int randomSeed;

    public static List<Asteroid> allAsteroid=new();
    float colliderTimer;

    private void Start()
    {
        System.Random random = new(randomSeed);

        for (int i = 0; i < startAsteroidCount; i++)
        {
            int randomIndex = Random.Range(0, asteroidsToSpawn.Length);
            Asteroid prototype = asteroidsToSpawn[randomIndex];

            
            Vector2 startPoint = CameraUtility.GetRandomPointInCamera(Camera.main, random);
            Quaternion startRotation = Quaternion.Euler(0, 0, (float)random.NextDouble() * 360);
            Asteroid newAsteroid = Instantiate(prototype, startPoint, startRotation, transform);

           // float speed = (float)random.NextDouble();
          //  speed = Mathf.Lerp(minStartSpeed, maxStartSpeed, speed);

            Vector2 randomDir = Random.insideUnitCircle.normalized;

            Vector2 velocity = randomDir * Random.Range(startVelocityMin, startVelocityMax);
            float angularVelocity = Random.Range(startAngularVelocityMin, startAngularVelocityMax);

            newAsteroid.SetVelocity(velocity, angularVelocity);
            allAsteroid.Add(newAsteroid);
        }
        colliderTimer = colliderDelay;
        DisableCollision();
    }
    private void Update()
    {
        if (colliderTimer != -1)
        {
            colliderTimer -= Time.deltaTime;
            if (colliderTimer <= 0)
            {
                EnableCollision();
                colliderTimer = -1;
            }
        }
    }
    void DisableCollision() { EnableCollision(false); }
    void EnableCollision(bool enable = true)
    {
        for (int i = 0; i < allAsteroid.Count; i++)
        {
            for (int j = i+1; j < allAsteroid.Count; j++)
            {
                Collider2D c1 = allAsteroid[i].GetComponent<Collider2D>();
                Collider2D c2 = allAsteroid[j].GetComponent<Collider2D>();
                Physics2D.IgnoreCollision(c1, c2, !enable);
            }
        }
    }

   /* void Spawn(Asteroid asteroid)
    {
        System.Random random = new(randomSeed);
        Vector2 p = CameraUtility.GetRandomPointInCamera(Camera.main, random);
        Quaternion r = Quaternion.Euler(0, 0, (float) random.NextDouble()*360);
        Asteroid newAsteroid = Instantiate(asteroid, p, r, transform);

        allAsteroid.Add(newAsteroid);

        Vector2 velocity = Random.insideUnitCircle.normalized * Random.Range(startVelocityMin, startVelocityMax);
        float angularVelocity= Random.Range(startAngularVelocityMin, startAngularVelocityMax);

        newAsteroid.SetVelocity(velocity, angularVelocity);
    }*/

    public static void RemoveAsteroid(Asteroid asteroid)
    {
        allAsteroid.Remove(asteroid);
    }
}
