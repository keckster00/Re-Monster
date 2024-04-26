using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalized(SpriteRenderer spriteRenderer, Animator animator)
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        SpriteRenderer playerSr = spriteRenderer;
        Animator playerAnimator = animator;


        if (Input.GetKey(KeyCode.A))
        {
            playerSr.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
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

        return inputVector;
    }
}
