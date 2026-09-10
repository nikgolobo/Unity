using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;

    [Header("UI")]
    [SerializeField] private Slider healthSlider;

    [Header("Block Sound")]
    [SerializeField] private AudioClip blockSound;
    [SerializeField, Range(0f, 1f)] private float blockSoundVolume = 1f;

    [Header("Scene")]
    [SerializeField] private string gameOverSceneName = "GameOver";

    private AudioSource audioSource;
    private PlayerBlock playerBlock;

    void Awake()
    {
        playerBlock = GetComponent<PlayerBlock>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    void Start()
    {
        currentHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.minValue = 0;
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            return;
        }

        if (playerBlock != null && playerBlock.IsBlocking)
        {
            damage = Mathf.CeilToInt(damage * 0.5f);

            Debug.Log("Attack successfully blocked");

            if (blockSound != null)
            {
                audioSource.PlayOneShot(blockSound, blockSoundVolume);
            }
            else
            {
                Debug.LogWarning("Block Sound is not assigned on PlayerHealth.");
            }
        }

        ApplyDamage(damage);
    }

    public void TakeUnblockableDamage(int damage)
    {
        ApplyDamage(damage);
    }

    private void ApplyDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Gameover");
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }
    }
}