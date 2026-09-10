using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 1.2f;
    [SerializeField] private int damage = 1;
    [SerializeField] private LayerMask skeletonLayer;
    [SerializeField] private float attackOffset = 0.8f;
    [SerializeField] private float attackCooldown = 0.5f;

    [Header("Sound")]
    [SerializeField] private AudioClip attackSound;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private PlayerBlock playerBlock;
    private AudioSource audioSource;

    private float nextAttackTime = 0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerBlock = GetComponent<PlayerBlock>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        MoveAttackPoint();

        if (
            Mouse.current.leftButton.wasPressedThisFrame &&
            Time.time >= nextAttackTime
        )
        {
            if (playerBlock != null && playerBlock.IsBlocking)
            {
                return;
            }

            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    private void MoveAttackPoint()
    {
        if (spriteRenderer.flipX)
        {
            attackPoint.localPosition = new Vector3(attackOffset, 0f, 0f);
        }
        else
        {
            attackPoint.localPosition = new Vector3(-attackOffset, 0f, 0f);
        }
    }

    private void Attack()
    {
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        if (attackSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(attackSound);
        }

        Collider2D[] hits = Physics2D.OverlapCircleAll(
            attackPoint.position,
            attackRange,
            skeletonLayer
        );

        foreach (Collider2D hit in hits)
        {
            SkeletonHealth skeletonHealth = hit.GetComponent<SkeletonHealth>();

            if (skeletonHealth != null)
            {
                skeletonHealth.TakeDamage(damage);
            }

            BossHealth bossHealth = hit.GetComponent<BossHealth>();

            if (bossHealth != null)
            {
                bossHealth.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}