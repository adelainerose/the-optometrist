using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private string itemKey;  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        InventoryManager.Instance.AddItem(itemKey);
        Destroy(gameObject);
    }
}
