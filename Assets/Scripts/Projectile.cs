using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 25;
    [SerializeField] float lifetime = 2;
    [NonSerialized] public Vector2 velocity;

    float timer;
    void Start()
    {
        velocity += (Vector2)transform.up * speed;
        timer = 0;
    }

    void Update()
    {
        transform.position += (Vector3)velocity * Time.deltaTime;
        timer += Time.deltaTime;

        if (timer>=lifetime)
            Destroy(gameObject);
    }
}
