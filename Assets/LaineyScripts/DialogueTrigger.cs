using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueTrigger : MonoBehaviour
{
    //[SerializeField] private GameObject visualCue;
    [SerializeField] private TextAsset inkJSON;

    private bool isActive = false;

    private bool playerInRange;
    private bool hasInteracted;

    public void EnableComponent()
    {
        isActive = true;
    }

    public void DisableComponent()
    {
        isActive = false;
    }

    private void Awake()
    {
        playerInRange = false;
        hasInteracted = false;
        //visualCue.SetActive(false);
    }

    private void Update()
    {

        
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying && !hasInteracted)
        {
            //visualCue.SetActive(true);
            if (Input.GetKeyDown("e"))
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                hasInteracted = true;
            }
        }
        else
        {
            //visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
            hasInteracted = false;
        }
    }
}
