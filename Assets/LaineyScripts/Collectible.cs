using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private string itemKey;
    private bool playerInRange = false;

    private void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown("e"))
            {
                InventoryManager.Instance.AddItem(itemKey);
                playerInRange = false;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = true;
    }

}
