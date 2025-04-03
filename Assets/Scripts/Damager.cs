using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] float damage = 10;

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log($"Én {name} ütköztem {other.name}-el.");

        HealthObject healthObject = other.GetComponent<HealthObject>();

        if (healthObject != null)
        {
            healthObject.Damage(damage);

        }
    }
}
