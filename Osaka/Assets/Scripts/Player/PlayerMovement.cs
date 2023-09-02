using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }

    [SerializeField] KeyCode interactKey = KeyCode.E;

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    void Update()
    {
        // Check if the dialogue is open, and if so, prevent movement
        if (dialogueUI.IsOpen)
        {
            movement = Vector2.zero;
            animator.SetFloat("Speed", 0f);
            return;
        }

        HandleMovement();
        HandleInteraction();

    }

    private void FixedUpdate()
    {
        Vector2 normalizedMovement = movement.normalized; // Normalize the movement vector, prevents going faster when pressing two directions at the same time
        rb.MovePosition(rb.position + normalizedMovement * moveSpeed * Time.fixedDeltaTime);
    }

    void HandleMovement()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }

        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void HandleInteraction()
    {
        if (Input.GetKeyDown(interactKey))
        {
            Interactable?.Interact(this);
        }
    }
}