using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootPopUp : MonoBehaviour
{
    private float DeathTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DeathTime);
    }
}
