using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth = 10;
    [SerializeField] private GameObject lootPopUp;
    [SerializeField] private GameObject interactPopUp;
    public float health;
    public Image healthBar;
    public TMP_Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        healthText.text = health.ToString();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void PlayerTakeDamage(int dmg)
    {
        health -= dmg;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Loot")
        {
            if (coll.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals("BloodSprite"))
            {

                lootPopUp.GetComponent<TMP_Text>().text = "Health Up!";
                Instantiate(lootPopUp, coll.gameObject.transform.position, Quaternion.identity, transform);
                health += 3;
                if (health > maxHealth)
                {
                    health = maxHealth;
                }
            }
            else if (coll.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals("FangSprite"))
            {
                lootPopUp.GetComponent<TMP_Text>().text = "Damage Up!";
                Instantiate(lootPopUp, coll.gameObject.transform.position, Quaternion.identity, transform);
                GetComponent<PlayerDamage>().AddDamage(1);
                Debug.Log("fang");
            }
            else if (coll.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals("VenomSprite"))
            {
                lootPopUp.GetComponent<TMP_Text>().text = "Venom!";
                Instantiate(lootPopUp, coll.gameObject.transform.position, Quaternion.identity, transform);
                GetComponent<PlayerController>().movspeed += 0.5f;
                Debug.Log("venom");
            }
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "NPC")
        {
            interactPopUp.GetComponent<TMP_Text>().text = "'E' to Interact";
            Vector3 newPos = new Vector3(coll.gameObject.transform.position.x, coll.gameObject.transform.position.y + 2);
            Instantiate(interactPopUp, newPos, Quaternion.identity, transform);
        }
    }

}
