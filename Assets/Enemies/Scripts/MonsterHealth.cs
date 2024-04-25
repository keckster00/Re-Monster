using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth = 5;
    public float health;
    public Image monsterHealthBar;
    public TMP_Text monsterHealthText;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void Update()
    {
        monsterHealthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        monsterHealthText.text = health.ToString();
        if (health <= 0)
        {
            Destroy(gameObject);
            GetComponent<LootBag>().InstantiateLoot(transform.position);
        }

    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
    }
}
