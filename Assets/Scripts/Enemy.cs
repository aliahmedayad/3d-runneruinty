using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Rigidbody rb;
    public bool playerInSightRange;
    public float sightRange;

    // Reference to the player object
    private Transform player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // Find the player object dynamically by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the player is tagged with 'Player'.");
        }
    }

    void Update()
    {
        if (player == null)
            return; // Player not found, so don't proceed with the update

        // Calculate direction and distance to player
        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        // Check if player is within sight range
        if (distanceToPlayer <= 10)
        {
            playerInSightRange = true;
        }
        else
        {
            playerInSightRange = false;
        }

        // If player is within sight range, set destination to player
        if (playerInSightRange)
        {
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
            enemy.SetDestination(targetPosition);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "graphic")
        {
            Destroy(collision.gameObject);
            Debug.Log("lol");

        }
        if (collision.gameObject.name == "coin(Clone)")
        {
            
            Destroy(collision.gameObject);

        }
    }
}
