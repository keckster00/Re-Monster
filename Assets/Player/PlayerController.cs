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
        movdir = new Vector3(inputVector.x, inputVector.y, 0);
    }

    private void FixedUpdate()
    {
        playerRigidBody.MovePosition(transform.position += movdir * movspeed * Time.deltaTime);
    }

}
