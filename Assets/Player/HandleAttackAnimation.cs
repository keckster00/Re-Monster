using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAttackAnimation : MonoBehaviour
{
    // Reference to the Animator component
    private Animator animator;
    [SerializeField] private GameObject axeAttack;

    private void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
    }

    // Function to reset the AttackTrigger parameter to false
    public void ResetAttackTrigger()
    {
        // Set the AttackTrigger parameter to false
        animator.SetBool("axeAttack", false);
        axeAttack.GetComponent<AxeAttack>().FinishAttack();
    }
}
