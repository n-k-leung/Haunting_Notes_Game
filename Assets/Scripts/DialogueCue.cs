using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueCue : MonoBehaviour
{
    
    [Header("Visual_Pop_up")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] public TextAsset inkJSON;

    private bool playerInRange;
   
     void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

     public void Update()
    {
        if(playerInRange && !DialogueManager.GetInstance().dialoguePlaying)
        {
            visualCue.SetActive(true);
            if (Input.GetButtonDown("Interact"))
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
            
        }
        else
        {
            visualCue.SetActive(false);
        }
    }
     void OnTriggerEnter2D(Collider2D collider)
    {
       if(collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

     void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
    
}
