using UnityEngine;

public class ShootingTarget : MonoBehaviour
{
    [SerializeField] float health = 50f;


    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
