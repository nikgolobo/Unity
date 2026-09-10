using UnityEngine;

public class SkeletonHealth : MonoBehaviour
{
    [SerializeField] private int health = 3;

    private bool isDead = false;

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        SkeletonSpawner spawner = FindFirstObjectByType<SkeletonSpawner>();

        if (spawner != null)
        {
            spawner.SkeletonDefeated();
        }

        Destroy(gameObject);
    }
}