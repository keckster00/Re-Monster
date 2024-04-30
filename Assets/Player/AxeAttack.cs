using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAttack : MonoBehaviour
{

    private Vector2 attackOffsetRight;
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        attackOffsetRight = transform.position;
    }

    public void SwingAxeRight()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        transform.localPosition = attackOffsetRight;
    }

    public void SwingAxeLeft()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        transform.localPosition = new Vector2(attackOffsetRight.x * -1, attackOffsetRight.y);
    }

    public void FinishAttack()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.GetComponent<MonsterHealth>().TakeDamage(GetComponentInParent<PlayerDamage>().damage);
        }
    }
}
