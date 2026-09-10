using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private int health = 20;
    [SerializeField] private string victorySceneName = "Victory";

    private bool isDead = false;

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        health -= damage;

        Debug.Log("Boss health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;

        isDead = true;

        SceneManager.LoadScene("Victory");
    }
}