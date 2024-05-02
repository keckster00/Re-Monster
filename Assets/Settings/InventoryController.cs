using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject inventoryCanvas;
    private bool isOpen;
    // Start is called before the first frame update

    public void Start()
    {
        isOpen = false;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!isOpen)
            {
                isOpen = true;
                inventoryCanvas.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                isOpen = false;
                inventoryCanvas.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
