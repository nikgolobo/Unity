using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float stopDistance = 1.5f;

    [Header("Normal Attack")]
    [SerializeField] private int normalDamage = 15;
    [SerializeField] private float normalAttackRange = 1.6f;
    [SerializeField] private float normalAttackCooldown = 1.5f;

    [Header("Special Attack")]
    [SerializeField] private int specialDamage = 35;
    [SerializeField] private float specialAttackRange = 2.2f;
    [SerializeField] private float specialAttackCooldown = 6f;
    [SerializeField] private float specialAttackDelay = 1.2f;

    [Header("Sound")]
    [SerializeField] private AudioClip attackSound;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private AudioSource audioSource;

    private float nextNormalAttackTime = 0f;
    private float nextSpecialAttackTime = 0f;
    private bool isDoingSpecialAttack = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        FacePlayer();

        float distanceToPlayer = Vector2.Distance(
            transform.position,
            player.position
        );

        if (isDoingSpecialAttack)
        {
            return;
        }

        if (
            distanceToPlayer <= specialAttackRange &&
            Time.time >= nextSpecialAttackTime
        )
        {
            StartSpecialAttack();
            return;
        }

        if (
            distanceToPlayer <= normalAttackRange &&
            Time.time >= nextNormalAttackTime
        )
        {
            NormalAttack();
            return;
        }

        if (distanceToPlayer > stopDistance)
        {
            MoveTowardsPlayer();
        }
        else if (animator != null)
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector2 targetPosition = new Vector2(
            player.position.x,
            transform.position.y
        );

        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

        if (animator != null)
        {
            animator.SetBool("isWalking", true);
        }
    }

    private void FacePlayer()
    {
        if (spriteRenderer == null)
        {
            return;
        }

        if (player.position.x < transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else if (player.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void NormalAttack()
    {
        nextNormalAttackTime = Time.time + normalAttackCooldown;

        if (animator != null)
        {
            animator.SetBool("isWalking", false);
            animator.SetTrigger("NormalAttack");
        }

        PlayAttackSound();

        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(normalDamage);
        }
    }

    private void StartSpecialAttack()
    {
        isDoingSpecialAttack = true;
        nextSpecialAttackTime = Time.time + specialAttackCooldown;

        if (animator != null)
        {
            animator.SetBool("isWalking", false);
            animator.SetTrigger("SpecialAttack");
        }

        PlayAttackSound();

        Invoke(nameof(DoSpecialDamage), specialAttackDelay);
    }

    private void DoSpecialDamage()
    {
        if (player == null)
        {
            isDoingSpecialAttack = false;
            return;
        }

        float distanceToPlayer = Vector2.Distance(
            transform.position,
            player.position
        );

        if (distanceToPlayer <= specialAttackRange)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeUnblockableDamage(specialDamage);
            }
        }

        isDoingSpecialAttack = false;
    }

    private void PlayAttackSound()
    {
        if (attackSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(attackSound);
        }
    }
}