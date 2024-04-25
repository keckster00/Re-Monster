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
            //refactor to be like playermovement
            transform.position += (playerTransform.position - transform.position) * movspeed * Time.deltaTime;
        }
    }
}
