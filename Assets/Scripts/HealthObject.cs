using System;
using UnityEngine;

public class HealthObject : MonoBehaviour
{
    [SerializeField] float startHealth;
    [SerializeField] MonoBehaviour toDisable;

    float health;

    void Start()
    {
        health = startHealth;
    }

    public void Damage(float damage)
    {
        if (health <= 0)
            return;

        health -= damage;

        if (health <= 0)
            OnDeath();
    }

    void OnDeath()
    {
        Debug.Log("I'm dead!");

        if (toDisable != null)
            toDisable.enabled = false;
    }
}
