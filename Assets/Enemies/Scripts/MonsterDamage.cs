using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private float damage;
    public PlayerHealth playerHealth;
    private float attackInterval = 1f;
    private Coroutine attackOrder;
    // Start is called before the first frame update
    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            attackOrder = StartCoroutine(Attack(damage));
            //playerHealth.PlayerTakeDamage(damage);
        }
    }

    public void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            StopCoroutine(attackOrder);
        }

    }
    IEnumerator Attack(float damage)
    {
        playerHealth.PlayerTakeDamage(damage);
        yield return new WaitForSeconds(attackInterval);
        attackOrder = StartCoroutine(Attack(damage));
    }

}
