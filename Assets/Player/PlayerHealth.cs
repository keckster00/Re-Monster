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
    [SerializeField] private GameManagerScript gameOverScreen;
    private int level;
    private float xp;
    private float xpNeeded;
    public float health;
    public Image healthBar;
    public TMP_Text healthText;
    public Image xpBar;
    public TMP_Text levelText;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        level = 1;
        xp = 0f;
        xpNeeded = 10f;
        isDead = false;
    }

    public void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        healthText.text = health.ToString();

        xpBar.fillAmount = Mathf.Clamp(xp / xpNeeded, 0, 1);
        levelText.text = level.ToString();

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0 && !isDead)
        {
            isDead = true;
            //open popup screen
            gameOverScreen.OnDeath();
            Destroy(gameObject);
        }
    }

    public void PlayerTakeDamage(float dmg)
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
            if (coll.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals("SnakeXp"))
            {
                //update xp bar
                //update xp number?
                //if xp >= max for level -- level up -- bar at 0 or leftover xp

                lootPopUp.GetComponent<TMP_Text>().text = "XP!";
                Instantiate(lootPopUp, coll.gameObject.transform.position, Quaternion.identity, transform);
                xp += 5;
                if (xp >= xpNeeded)
                {
                    level++;
                    xp = xp - xpNeeded;
                    xpNeeded *= 1.5f;
                    GetComponent<PlayerDamage>().AddDamage(0.5f);
                    health += maxHealth / 3;
                }
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
