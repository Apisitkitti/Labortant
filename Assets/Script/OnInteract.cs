using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInteract : MonoBehaviour
{
    public GameObject tutorialUI;
    public GameObject interactUI;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            interactUI.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            tutorialUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            tutorialUI.SetActive(false);
            interactUI.SetActive(false);
        }
    }
}