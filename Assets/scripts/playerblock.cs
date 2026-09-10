using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlock : MonoBehaviour
{
    public bool IsBlocking { get; private set; }

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        IsBlocking = Keyboard.current.fKey.isPressed;

        if (animator != null)
        {
            animator.SetBool("isBlocking", IsBlocking);
        }
    }
}