using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    public float movspeed = 5f;
    private Vector3 movdir;
    private Rigidbody2D playerRigidBody;
    Animator playerAnimator;

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized(this.GetComponentInChildren<SpriteRenderer>(), playerAnimator);
        /*Vector2 inputVector = new Vector2(0, 0);
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
        if (inputVector != Vector2.zero)
        {
            playerAnimator.SetFloat("isWalking", 1);
        }
        else
        {
            playerAnimator.SetFloat("isWalking", 0);
        }
        inputVector = inputVector.normalized;
        */
        movdir = new Vector3(inputVector.x, inputVector.y, 0);
        //transform.position += movdir * movspeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        playerRigidBody.MovePosition(transform.position += movdir * movspeed * Time.deltaTime);
    }

}
