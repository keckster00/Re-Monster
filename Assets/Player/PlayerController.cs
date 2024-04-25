using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movspeed = 5f;
    private Vector3 movdir;
    private Rigidbody2D playerRigidBody;

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);
        SpriteRenderer playerSr = this.GetComponentInChildren<SpriteRenderer>();

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
            playerSr.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = 1;
            playerSr.flipX = false;
        }

        inputVector = inputVector.normalized;
        movdir = new Vector3(inputVector.x, inputVector.y, 0);
        //transform.position += movdir * movspeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        playerRigidBody.MovePosition(transform.position += movdir * movspeed * Time.deltaTime);
    }

}
