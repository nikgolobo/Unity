using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private int damage = 10;
    [SerializeField] private float lifetime = 5f;

    [SerializeField] private float rotationOffset = 180f;

    private Vector2 direction;

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle + rotationOffset);
    }

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth == null)
        {
            playerHealth = other.GetComponentInParent<PlayerHealth>();
        }

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }

        if (!other.CompareTag("Skeleton") && !other.CompareTag("Arrow"))
        {
            Destroy(gameObject);
        }
    }
}