using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public void SwingAxe()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public void FinishAttack()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
