using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 normalizedMovement = movement.normalized; // Normalize the movement vector, prevents going faster when pressing two directions at the same time
        rb.MovePosition(rb.position + normalizedMovement * moveSpeed * Time.fixedDeltaTime);
    }
}