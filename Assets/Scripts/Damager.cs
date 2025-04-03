using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] float damage = 10;

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log($"�n {name} �tk�ztem {other.name}-el.");

        HealthObject healthObject = other.GetComponent<HealthObject>();

        if (healthObject != null)
        {
            healthObject.Damage(damage);

        }
    }
}
