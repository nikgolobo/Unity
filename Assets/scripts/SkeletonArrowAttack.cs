using UnityEngine;

public class SkeletonArrowAttack : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform shootPoint;

    [SerializeField] private float attackRange = 8f;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private float arrowSpawnDelay = 0.35f;

    private float nextAttackTime = 0f;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        FacePlayer();

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
        {
            StartShooting();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    private void StartShooting()
    {
        if (animator != null)
        {
            animator.SetTrigger("Skeleton");
        }

        Invoke(nameof(ShootArrow), arrowSpawnDelay);
    }

    private void ShootArrow()
    {
        if (player == null || arrowPrefab == null || shootPoint == null) return;

        GameObject arrow = Instantiate(
            arrowPrefab,
            shootPoint.position,
            Quaternion.identity
        );

        Vector2 direction = player.position - shootPoint.position;

        ArrowProjectile arrowScript = arrow.GetComponent<ArrowProjectile>();

        if (arrowScript != null)
        {
            arrowScript.SetDirection(direction);
        }
    }

    private void FacePlayer()
    {
        if (player.position.x < transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else if (player.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
    }
}