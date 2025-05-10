
using UnityEngine;

public class HealthObjectsAsteroids : MonoBehaviour
{
    [SerializeField] float startHp;
    float hp;


    void Start()
    {
        hp = startHp;
    }

    public void Damage(float damage)
    {
        if (hp <= 0)
            return;

        hp -= damage;
        if (hp <= 0)
            Destroy(gameObject);
    }
}
