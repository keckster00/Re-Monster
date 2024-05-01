using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] private float movspeed;
    [SerializeField] private Transform playerTransform;
    private bool isChasing;
    [SerializeField] private float chaseDistance;
    [SerializeField] private DefaultDirection defaultDirection;

    private enum DefaultDirection
    {
        Left,
        Right
    }


    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(playerTransform.position, transform.position) <= chaseDistance)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing)
        {
            gameObject.GetComponent<Rigidbody2D>().MovePosition(transform.position += (playerTransform.position - transform.position) * movspeed * Time.deltaTime);
            Vector3 direction = playerTransform.position - transform.position;
            FlipSprite(direction);
        }
    }

    private void FlipSprite(Vector3 direction)
    {
        // Assuming your sprite renderer is attached to the same GameObject
        SpriteRenderer spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();

        // Check if the default direction is left and the player is moving right
        if (defaultDirection == DefaultDirection.Left && direction.x > 0)
        {
            // Flip the sprite to face right
            spriteRenderer.flipX = true;
        }
        // Check if the default direction is right and the player is moving left
        else if (defaultDirection == DefaultDirection.Right && direction.x > 0)
        {
            // Flip the sprite to face left
            spriteRenderer.flipX = false;
        }
        // Otherwise, keep the sprite facing its default direction
        else
        {
            // Flip the sprite based on the default direction
            spriteRenderer.flipX = defaultDirection == DefaultDirection.Left ? false : true;
        }
    }
}
