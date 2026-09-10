using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform player;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float smoothTime = 0.2f;
    [SerializeField] private float hoverHeight = 0.25f;
    [SerializeField] private float hoverSpeed = 2f;

    [Header("Detection")]
    [SerializeField] private float detectionRange = 7f;
    [SerializeField] private float stopFollowingRange = 9f;
    [SerializeField] private float heightAbovePlayer = 0.5f;

    [Header("Attack")]
    [SerializeField] private float attackRange = 1.1f;
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private float attackCooldown = 1f;

    [Header("Sprite Direction")]
    [SerializeField] private bool spriteFacesLeftByDefault = true;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private Vector2 startPosition;
    private Vector2 smoothVelocity;

    private float nextAttackTime;
    private bool isFollowing;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        startPosition = rb.position;

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

        float distanceToPlayer = Vector2.Distance(
            transform.position,
            player.position
        );

        if (!isFollowing && distanceToPlayer <= detectionRange)
        {
            isFollowing = true;
        }

        if (isFollowing && distanceToPlayer > stopFollowingRange)
        {
            isFollowing = false;
        }

        if (isFollowing)
        {
            FacePlayer();
        }

        if (
            isFollowing &&
            distanceToPlayer <= attackRange &&
            Time.time >= nextAttackTime
        )
        {
            AttackPlayer();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void FixedUpdate()
    {
        Vector2 targetPosition;

        if (isFollowing && player != null)
        {
            targetPosition = new Vector2(
                player.position.x,
                player.position.y + heightAbovePlayer
            );
        }
        else
        {
            float hoverOffset =
                Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;

            targetPosition = new Vector2(
                startPosition.x,
                startPosition.y + hoverOffset
            );
        }

        Vector2 newPosition = Vector2.SmoothDamp(
            rb.position,
            targetPosition,
            ref smoothVelocity,
            smoothTime,
            moveSpeed
        );

        rb.MovePosition(newPosition);
    }

    private void FacePlayer()
    {
        if (spriteRenderer == null || player == null)
        {
            return;
        }

        bool playerIsLeft = player.position.x < transform.position.x;

        if (spriteFacesLeftByDefault)
        {
            spriteRenderer.flipX = !playerIsLeft;
        }
        else
        {
            spriteRenderer.flipX = playerIsLeft;
        }
    }

    private void AttackPlayer()
    {
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth == null)
        {
            playerHealth = player.GetComponentInParent<PlayerHealth>();
        }

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}