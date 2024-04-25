using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{

    public TMP_Text damageText;
    public float damage;
    public MonsterHealth monsterHealth;
    // Start is called before the first frame update

    public void Update()
    {
        damageText.text = damage.ToString();
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.GetComponent<MonsterHealth>().TakeDamage(damage);
        }
    }

    public void AddDamage(float dmg)
    {
        damage += dmg;
    }
}
