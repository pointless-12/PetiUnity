using UnityEngine;

public class DamagerAsteroids : MonoBehaviour
{
    [SerializeField] float damage = 10;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out HealthObjectsAsteroids ho))
        {
            ho.Damage(damage);
        }
    }
}
