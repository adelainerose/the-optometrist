using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject visualCue;
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private bool triggerOnStart = true;

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
        visualCue.SetActive(false);
    }

    private void Start()
    {
        if (triggerOnStart)
        {
            isActive = true;
        }
    }

    private void Update()
    {
        if (!isActive)
        {
            return;
        }
        
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying && !hasInteracted)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown("space"))
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                hasInteracted = true;
            }
        }
        else
        {
            visualCue.SetActive(false);
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
