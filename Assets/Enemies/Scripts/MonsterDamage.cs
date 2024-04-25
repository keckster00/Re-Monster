using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private int damage;
    public PlayerHealth playerHealth;
    // Start is called before the first frame update
    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            playerHealth.PlayerTakeDamage(damage);
        }
    }

}
