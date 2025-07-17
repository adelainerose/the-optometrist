using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueTrigger : MonoBehaviour
{
    //[SerializeField] private GameObject visualCue;
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private bool playOnStart = false;

    private bool playerInRange;
    private bool hasInteracted;

    private void Start()
    {
        if (playOnStart)
        {
            StartDialogue();
        }
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
                StartDialogue();
                hasInteracted = true;
            }
        }
        else
        {
            //visualCue.SetActive(false);
        }
    }

    public void StartDialogue()
    {
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
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
