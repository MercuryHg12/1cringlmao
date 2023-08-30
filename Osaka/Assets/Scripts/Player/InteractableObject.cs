using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public float interactionRadius = 2f; // The distance within which the player can interact
    public KeyCode interactionKey = KeyCode.E; // The key to trigger interaction


    private Transform player; // Reference to the player's transform
    private bool isInRange = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Calculate the distance between the player and the object
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Check if the player is in range and presses the interaction key
        if (distanceToPlayer <= interactionRadius && Input.GetKeyDown(interactionKey))
        {
            Interact();
        }
    }

    private void Interact()
    {
        // Define the interaction behavior here
        Debug.Log("Interacting with the object!");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
