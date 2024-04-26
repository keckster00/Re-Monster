using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string[] dialogue;
    private int index = 0;
    public float wordSpeed;
    private bool isClose;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && isClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                ZeroText(); //don't really like this logic
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
            Destroy(GameObject.FindGameObjectWithTag("InteractPopUp"));
        }
        if (Input.GetKeyDown(KeyCode.Space) && dialogueText.text == dialogue[index])
        {
            NextLine();
        }
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ZeroText();
            index = 0;
        }
    }

    public void ZeroText()
    {
        dialogueText.text = "";
        index = 0;
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isClose = true;
            ZeroText();
        }
    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isClose = false;
            dialoguePanel.SetActive(false);
            ZeroText();
        }
        Destroy(GameObject.FindGameObjectWithTag("InteractPopUp"));
    }
}