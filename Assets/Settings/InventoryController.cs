using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject inventoryCanvas;
    [SerializeField] private GameObject inventoryPage;
    [SerializeField] private GameObject abilitiesPage;

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
                InventorySetup();
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

    public void ShowInventory()
    {
        if (!inventoryPage.activeInHierarchy)
        {
            inventoryPage.SetActive(true);
            abilitiesPage.SetActive(false);
        }
        else
        {
            return;
        }
    }

    public void ShowAbilities()
    {
        if (!abilitiesPage.activeInHierarchy)
        {
            inventoryPage.SetActive(false);
            abilitiesPage.SetActive(true);
        }
        else
        {
            return;
        }
    }

    public void InventorySetup()
    {
        inventoryPage.SetActive(true);
        abilitiesPage.SetActive(false);

    }
}
