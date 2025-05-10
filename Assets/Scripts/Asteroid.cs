using System;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] float damage = 20;
    [SerializeField] Rigidbody2D rigidBody;

    Vector2 velocity;
    float angularVelocity;

    private void OnValidate()
    {
        if (rigidBody == null)
            rigidBody = GetComponent<Rigidbody2D>();
    }
    public void SetVelocity(Vector2 velocity, float angularVelocity)
    {
        rigidBody.linearVelocity = velocity;
        rigidBody.angularVelocity = angularVelocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        const float minimalSpeedToDamage = 0.1f;
        if (collision.relativeVelocity.magnitude > minimalSpeedToDamage)
        {
            if (collision.gameObject.TryGetComponent(out HealthObjectsAsteroids ho))
                ho.Damage(damage);
        }
    }

    void OnEnable()
    {
        AsteroidManager.allAsteroid.Add(this);
    }
    void OnDisable()
    {
        AsteroidManager.allAsteroid.Remove(this);
    }
}
