using UnityEngine;

public class SkeletonChase : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Collider2D playerTarget;
    [SerializeField] private float speed = 2f;

    private SpriteRenderer spriteRenderer;
    private bool isPlayerInRange = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player == null || !isPlayerInRange) return;

        Vector2 targetPosition = new Vector2(player.position.x, transform.position.y);

        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        if (player.position.x < transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else if (player.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == playerTarget)
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other == playerTarget)
        {
            isPlayerInRange = false;
        }
    }
}