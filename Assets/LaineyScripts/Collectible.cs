using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
    [SerializeField] private string itemKey;
    private bool playerInRange = false;
    public UnityEvent addDialogue;

    private void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown("e"))
            {
                InventoryManager.Instance.AddItem(itemKey);
                playerInRange = false;
                Destroy(gameObject);
                if (addDialogue != null)
                {
                    addDialogue.Invoke();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = true;
    }

}
