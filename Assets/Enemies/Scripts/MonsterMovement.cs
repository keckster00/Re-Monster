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
            if (direction.x < 0)
            {
                gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
            else
            {
                gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
            }
        }
    }
}
