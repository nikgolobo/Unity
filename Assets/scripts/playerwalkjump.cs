using UnityEngine;
using UnityEngine.InputSystem;

public class playerwalkjump : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float blockingSpeed = 1.5f;
    [SerializeField] private float jumpForce = 8f;

    [Header("Sound")]
    [SerializeField] private AudioClip jumpSound;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private PlayerBlock playerBlock;
    private AudioSource audioSource;

    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerBlock = GetComponent<PlayerBlock>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float move = 0f;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            move = -1f;
            spriteRenderer.flipX = false;
        }

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            move = 1f;
            spriteRenderer.flipX = true;
        }

        bool isBlocking = playerBlock != null && playerBlock.IsBlocking;
        float currentSpeed = isBlocking ? blockingSpeed : speed;

        rb.linearVelocity = new Vector2(move * currentSpeed, rb.linearVelocity.y);

        if (animator != null)
        {
            animator.SetBool("isWalking", move != 0f);
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded && !isBlocking)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            if (jumpSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}